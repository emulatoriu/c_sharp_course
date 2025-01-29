using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SrcChess2 {
    /// <summary>Base class for Search Engine</summary>
    public class SearchEngineAlphaBeta : SearchEngine {

        /// <summary>Result from AlphaBeta calling</summary>
        private struct AlphaBetaResult {
            /// <summary>Best move found</summary>
            public Move BestMovePos;
            /// <summary>Point given for this move</summary>
            public int  Pts;
            /// <summary>Number of tried permutation</summary>
            public int  PermCount;
            /// <summary>Maximum search depth</summary>
            public int  MaxDepth;
        };

        /// <summary>Private class use to pass info at AlphaBeta decreasing the stack space use</summary>
        private class AlphaBetaInfo {
            
            /// <summary>
            /// Ctor
            /// </summary>
            /// <param name="transTable">   Translation table</param>
            /// <param name="moves">        </param>
            /// <param name="searchMode">   Search mode</param>
            public AlphaBetaInfo(TransTable? transTable, Move[] moves, SearchMode searchMode) {
                TransTable  = transTable;
                Moves       = moves;
                SearchMode  = searchMode;
            }

            /// <summary>Transposition table</summary>
            public TransTable?          TransTable { get; private set; }
            /// <summary>Array of move position per depth</summary>
            public Move[]               Moves { get; private set; }
            /// <summary>Search mode</summary>
            public SearchMode           SearchMode { get; private set; }
            /// <summary>Time before timeout. Use for iterative</summary>
            public DateTime             TimeOut { get; set; }
            /// <summary>Number of board evaluated</summary>
            public int                  PermCount { get; set; }
            /// <summary>Maximum depth to search</summary>
            public int                  MaxDepth { get; set; }
            /// <summary>Information about pieces attacks</summary>
            public ChessBoard.PosInfo   WhitePosInfo { get; set; }
            /// <summary>Information about pieces attacks</summary>
            public ChessBoard.PosInfo   BlackPosInfo { get; set; }
        };

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="trace">    Trace object or null</param>
        /// <param name="rnd">      Random object</param>
        /// <param name="rndRep">   Repetitive random object</param>
        public SearchEngineAlphaBeta(ITrace? trace, Random rnd, Random rndRep) : base(trace, rnd, rndRep) {}

        /// <summary>
        /// Alpha Beta pruning function.
        /// </summary>
        /// <param name="board">            Chess board</param>
        /// <param name="playerColor">      Color doing the move</param>
        /// <param name="depth">            Actual search depth</param>
        /// <param name="alpha">            Alpha limit</param>
        /// <param name="beta">             Beta limit</param>
        /// <param name="whiteMoveCount">   Number of moves white can do</param>
        /// <param name="blackMoveCount">   Number of moves black can do</param>
        /// <param name="abInfo">           Supplemental information</param>
        /// <returns>
        /// Points to give for this move or Int32.MinValue for timed out
        /// </returns>
        private int AlphaBeta(ChessBoard                board, 
                              ChessBoard.PlayerColor    playerColor,
                              int                       depth,
                              int                       alpha,
                              int                       beta,
                              int                       whiteMoveCount,
                              int                       blackMoveCount,
                              AlphaBetaInfo             abInfo) {
            int                         retVal;
            List<Move>                  moveList;
            int                         pts;
            int                         moveCount;
            TransEntryType              type = TransEntryType.Alpha;
            ChessBoard.BoardStateMask   boardExtraInfo;
            ChessBoard.RepeatResult     result;

            if (abInfo.TimeOut != DateTime.MaxValue && DateTime.Now >= abInfo.TimeOut) {
                retVal = Int32.MinValue;   // Time out!
            } else if (board.IsEnoughPieceForCheckMate()) {
                boardExtraInfo = board.ComputeBoardExtraInfo(playerColor, true);
                retVal         = abInfo.TransTable?.ProbeEntry(board.ZobristKey, boardExtraInfo, depth, alpha, beta) ?? Int32.MaxValue;
                if (retVal == Int32.MaxValue) {
                    if (depth == 0 || s_cancelSearch) {
                        retVal = board.Points(abInfo.SearchMode,
                                              playerColor,
                                              abInfo.MaxDepth - depth,
                                              whiteMoveCount - blackMoveCount,
                                              abInfo.WhitePosInfo,
                                              abInfo.BlackPosInfo);
                        if (playerColor == ChessBoard.PlayerColor.Black) {
                            retVal = -retVal;
                        }
                        abInfo.PermCount++;
                        abInfo.TransTable?.RecordEntry(board.ZobristKey,
                                                       boardExtraInfo,
                                                       depth,
                                                       retVal,
                                                       TransEntryType.Exact);
                    } else {
                        moveList  = board.EnumMoveList(playerColor, needMoveList: true, out ChessBoard.PosInfo posInfo)!;
                        moveCount = moveList.Count;
                        if (playerColor == ChessBoard.PlayerColor.White) {
                            whiteMoveCount      = moveCount;
                            abInfo.WhitePosInfo = posInfo;
                        } else {
                            blackMoveCount      = moveCount;
                            abInfo.BlackPosInfo = posInfo;
                        }
                        if (moveCount == 0) {
                            if (board.IsCheck(playerColor)) {
                                retVal = -1000000 - depth;
                            } else {
                                retVal = 0;    // Draw
                            }
                            abInfo.TransTable?.RecordEntry(board.ZobristKey,
                                                           boardExtraInfo,
                                                           depth,
                                                           retVal,
                                                           TransEntryType.Exact);
                        } else {
                            retVal = alpha;
                            foreach (Move move in moveList) {
                                result                  = board.DoMoveNoLog(move);
                                abInfo.Moves[depth - 1] = move;
                                if (result == ChessBoard.RepeatResult.NoRepeat) {
                                    pts = -AlphaBeta(board,
                                                      (playerColor == ChessBoard.PlayerColor.Black) ? ChessBoard.PlayerColor.White : ChessBoard.PlayerColor.Black,
                                                      depth - 1,
                                                      -beta,
                                                      -retVal,
                                                      whiteMoveCount,
                                                      blackMoveCount,
                                                      abInfo);
                                } else {
                                    pts = 0;
                                }
                                board.UndoMoveNoLog(move);
                                if (pts == Int32.MinValue) {
                                    retVal = pts;
                                    break;
                                } else {
                                    if (pts > retVal) {
                                        retVal = pts;
                                        type   = TransEntryType.Exact;
                                    }
                                    if (retVal >= beta) {
                                        retVal = beta;
                                        type   = TransEntryType.Beta;
                                        break;
                                    }
                                }
                            }
                            if (retVal != Int32.MinValue) {
                                abInfo.TransTable?.RecordEntry(board.ZobristKey, boardExtraInfo, depth, retVal, type);
                            }
                        }
                    }
                }
            } else {
                retVal = 0;
            }
            return(retVal);
        }

        /// <summary>
        /// Find the best move for a player using alpha-beta for a given depth
        /// </summary>
        /// <param name="board">            Chess board</param>
        /// <param name="searchMode">       Search mode</param>
        /// <param name="transTable">       Transposition table or null if not using one</param>
        /// <param name="playerColor">      Color doing the move</param>
        /// <param name="moveList">         List of move to try</param>
        /// <param name="whitePosInfo">     Information about pieces attacks for the white</param>
        /// <param name="blackPosInfo">     Information about pieces attacks for the black</param>
        /// <param name="totalMoveCount">   Total list of moves</param>
        /// <param name="depth">            Maximum depth</param>
        /// <param name="alpha">            Alpha bound</param>
        /// <param name="beta">             Beta bound</param>
        /// <param name="timeOut">          Time limit (DateTime.MaxValue for no time limit)</param>
        /// <param name="permCount">        Total permutation evaluated</param>
        /// <param name="bestMoveIndex">    Index of the best move</param>
        /// <param name="hasTimeOut">       Return true if time out</param>
        /// <param name="points">           Returns point of each move in move list</param>
        /// <returns>
        /// Points
        /// </returns>
        private int FindBestMoveUsingAlphaBetaAtDepth(ChessBoard                board,
                                                      SearchMode                searchMode,
                                                      TransTable?               transTable,
                                                      ChessBoard.PlayerColor    playerColor,
                                                      List<Move>                moveList,
                                                      ChessBoard.PosInfo        whitePosInfo,
                                                      ChessBoard.PosInfo        blackPosInfo,
                                                      int                       totalMoveCount,
                                                      int                       depth,
                                                      int                       alpha,
                                                      int                       beta,
                                                      DateTime                  timeOut,
                                                      out int                   permCount,
                                                      out int                   bestMoveIndex,
                                                      out bool                  hasTimeOut,
                                                      out int[]                 points) {
            int                     retVal;
            int                     whiteMoveCount;
            int                     blackMoveCount;
            int                     moveCount;
            int                     index;
            int                     pts;
            Move                    move;
            AlphaBetaInfo           abInfo;
            ChessBoard.RepeatResult result;
                        
            hasTimeOut      = false;
            abInfo          = new AlphaBetaInfo(transTable, new Move[depth], searchMode) {
                PermCount       = 0,
                TimeOut         = timeOut,
                MaxDepth        = depth,
                WhitePosInfo  = whitePosInfo,
                BlackPosInfo  = blackPosInfo
            };
            bestMoveIndex   = -1;
            points          = new int[moveList.Count];
            if (playerColor == ChessBoard.PlayerColor.White) {
                whiteMoveCount = totalMoveCount;
                blackMoveCount = 0;
            } else {
                whiteMoveCount = 0;
                blackMoveCount = totalMoveCount;
            }
            moveCount = moveList.Count;
            index     = 0;
            retVal    = alpha;
            while (index < moveCount && !hasTimeOut) {
                move                    = moveList[index];
                result                  = board.DoMoveNoLog(move);
                abInfo.Moves[depth - 1] = move;
                if (result == ChessBoard.RepeatResult.NoRepeat) {
                    pts = -AlphaBeta(board,
                                     (playerColor == ChessBoard.PlayerColor.Black) ? ChessBoard.PlayerColor.White : ChessBoard.PlayerColor.Black,
                                     depth - 1,
                                     -beta,
                                     -retVal,
                                     whiteMoveCount,
                                     blackMoveCount,
                                     abInfo);
                } else {
                    pts = 0;
                }                                         
                points[index] = pts;
                board.UndoMoveNoLog(move);
                if (pts == Int32.MinValue) {
                    retVal  = pts;
                    hasTimeOut = true;
                } else {
                    if (pts > retVal) {
                        TraceSearch(depth, playerColor, move, pts);
                        retVal         = pts;
                        bestMoveIndex  = index;
                    }
                }
                index++;
            }
            permCount = abInfo.PermCount;
            return(retVal);
        }

        /// <summary>
        /// Find the best move for a player using alpha-beta in a secondary thread
        /// </summary>
        /// <param name="board">            Chess board</param>
        /// <param name="searchMode">       Search mode</param>
        /// <param name="transTable">       Translation table if any</param>
        /// <param name="playerColor">      Color doing the move</param>
        /// <param name="moveList">         List of move to try</param>
        /// <param name="whitePosInfo">     Information about pieces attacks for the white</param>
        /// <param name="blackPosInfo">     Information about pieces attacks for the black</param>
        /// <param name="totalMoveCount">   Total number of moves</param>
        /// <param name="alpha">            Alpha bound</param>
        /// <param name="beta">             Beta bound</param>
        /// <returns>
        /// Points
        /// </returns>
        private AlphaBetaResult FindBestMoveUsingAlphaBetaAsync(ChessBoard              board,
                                                                SearchMode              searchMode,
                                                                TransTable?             transTable,
                                                                ChessBoard.PlayerColor  playerColor,
                                                                List<Move>              moveList,
                                                                ChessBoard.PosInfo      whitePosInfo,
                                                                ChessBoard.PosInfo      blackPosInfo,
                                                                int                     totalMoveCount,
                                                                int                     alpha,
                                                                int                     beta) {
            AlphaBetaResult                 retVal;
            DateTime                        timeOut;
            int                             depth;
            int                             point;
            int                             bestMoveIndex;
            int                             depthLimit;
            int[]                           points;
            System.Threading.ThreadPriority threadPriority;
            bool                            hasTimeOut;
            bool                            isIterativeDepthFirst;

            retVal                                          = new AlphaBetaResult();
            threadPriority                                  = System.Threading.Thread.CurrentThread.Priority;
            System.Threading.Thread.CurrentThread.Priority  = System.Threading.ThreadPriority.BelowNormal;
            isIterativeDepthFirst            = (searchMode.m_option.HasFlag(SearchMode.Option.UseIterativeDepthSearch));
            retVal.BestMovePos.StartPos      = 255;
            retVal.BestMovePos.EndPos        = 255;
            retVal.BestMovePos.OriginalPiece = ChessBoard.PieceType.None;
            retVal.BestMovePos.Type          = Move.MoveType.Normal;
            try {
                retVal.PermCount  = 0;
                if (searchMode.m_searchDepth == 0 || isIterativeDepthFirst) {
                    timeOut     = (isIterativeDepthFirst) ? DateTime.MaxValue : DateTime.Now + TimeSpan.FromSeconds(searchMode.m_timeOutInSec);
                    depthLimit  = (isIterativeDepthFirst) ? searchMode.m_searchDepth : 999;
                    depth       = 1;
                    retVal.Pts  = FindBestMoveUsingAlphaBetaAtDepth(board,
                                                                    searchMode,
                                                                    transTable,
                                                                    playerColor,
                                                                    moveList,
                                                                    whitePosInfo,
                                                                    blackPosInfo,
                                                                    totalMoveCount,
                                                                    depth,
                                                                    alpha,
                                                                    beta,
                                                                    DateTime.MaxValue,
                                                                    out int permCountAtLevel,
                                                                    out bestMoveIndex,
                                                                    out hasTimeOut,
                                                                    out points);
                    if (bestMoveIndex != -1) {
                        retVal.BestMovePos = moveList[bestMoveIndex];
                    }
                    retVal.PermCount   += permCountAtLevel;
                    retVal.MaxDepth     = depth;
                    while (DateTime.Now < timeOut && !s_cancelSearch && !hasTimeOut && depth < depthLimit) {
                        moveList = SortMoveList(moveList, points);
                        depth++;
                        point    = FindBestMoveUsingAlphaBetaAtDepth(board,
                                                                     searchMode,
                                                                     transTable,
                                                                     playerColor,
                                                                     moveList,
                                                                     whitePosInfo,
                                                                     blackPosInfo,
                                                                     totalMoveCount,
                                                                     depth,
                                                                     alpha,
                                                                     beta,
                                                                     timeOut,
                                                                     out permCountAtLevel,
                                                                     out bestMoveIndex,
                                                                     out hasTimeOut,
                                                                     out points);
                        if (!hasTimeOut) {
                            if (bestMoveIndex != -1) {
                                retVal.BestMovePos = moveList[bestMoveIndex];
                            }
                            retVal.PermCount   += permCountAtLevel;
                            retVal.MaxDepth     = depth;
                            retVal.Pts          = point;
                        }
                    } 
                } else {
                    retVal.MaxDepth = searchMode.m_searchDepth;
                    retVal.Pts      = FindBestMoveUsingAlphaBetaAtDepth(board,
                                                                        searchMode,
                                                                        transTable,
                                                                        playerColor,
                                                                        moveList,
                                                                        whitePosInfo,
                                                                        blackPosInfo,
                                                                        totalMoveCount,
                                                                        retVal.MaxDepth,
                                                                        alpha,
                                                                        beta,
                                                                        DateTime.MaxValue,
                                                                        out retVal.PermCount,
                                                                        out bestMoveIndex,
                                                                        out hasTimeOut,
                                                                        out points);
                    if (bestMoveIndex != -1) {
                        retVal.BestMovePos = moveList[bestMoveIndex];
                    }
                }
            } finally {
                System.Threading.Thread.CurrentThread.Priority = threadPriority;
            }
            return(retVal);
        }

        /// <summary>
        /// Find the best move for a player using alpha-beta
        /// </summary>
        /// <param name="board">        Chess board</param>
        /// <param name="searchMode">   Search mode</param>
        /// <param name="transTable">   Translation table if any</param>
        /// <param name="playerColor">  Player doing the move</param>
        /// <param name="moveList">     Move list</param>
        /// <param name="indexes">      Order of evaluation of the moves</param>
        /// <param name="posInfo">      Information about pieces attacks</param>
        /// <param name="bestMove">     Best move found</param>
        /// <param name="permCount">    Total permutation evaluated</param>
        /// <param name="cacheHit">     Number of moves found in the translation table cache</param>
        /// <param name="maxDepth">     Maximum depth to use</param>
        /// <returns>
        /// true if a move has been found
        /// </returns>
        protected override bool FindBestMove(ChessBoard             board,
                                             SearchMode             searchMode,
                                             TransTable?            transTable,
                                             ChessBoard.PlayerColor playerColor,
                                             List<Move>             moveList,
                                             int[]                  indexes, 
                                             ChessBoard.PosInfo     posInfo,
                                             ref Move               bestMove,
                                             out int                permCount,
                                             out long               cacheHit,
                                             out int                maxDepth) {
            bool                    retVal = false;
            bool                    isMultipleThread;
            ChessBoard[]            boards;
            Task<AlphaBetaResult>[] taskArray;
            List<Move>[]            moveListArr;
            AlphaBetaResult         alphaBetaRes;
            ChessBoard.PosInfo      whitePosInfo;
            ChessBoard.PosInfo      blackPosInfo;
            int                     alpha;
            int                     beta;
            int                     threadCount;
            
            if (playerColor == ChessBoard.PlayerColor.White) {
                whitePosInfo = posInfo;
                blackPosInfo = ChessBoard.s_posInfoNull;
            } else {
                whitePosInfo = ChessBoard.s_posInfoNull;
                blackPosInfo = posInfo;
            }
            searchMode.m_option   &= ~SearchMode.Option.UseTransTable;
            cacheHit               = 0;
            maxDepth               = 0;
            permCount              = 0;
            alpha                  = -10000000;
            beta                   = +10000000;
            isMultipleThread         = (searchMode.m_threadingMode == SearchMode.ThreadingMode.OnePerProcessorForSearch);
            threadCount            = Environment.ProcessorCount;
            if (isMultipleThread && threadCount < 2) {
                isMultipleThread = false;    // No reason to go with multi-threading if only one processor
            }
            if (isMultipleThread) {
                boards      = new ChessBoard[threadCount];
                moveListArr = new List<Move>[threadCount];
                taskArray   = new Task<AlphaBetaResult>[threadCount];
                for (int i = 0; i < threadCount; i++) {
                    boards[i]       = board.Clone();
                    moveListArr[i]  = new List<Move>(moveList.Count / threadCount + 1);
                    for (int step = i; step < moveList.Count; step += threadCount) {
                        moveListArr[i].Add(moveList[indexes[step]]);
                    }
                }
                for (int i = 0; i < threadCount; i++) {
                    taskArray[i] = Task<AlphaBetaResult>.Factory.StartNew((param) => {
                                                int step = (int)param!;
                                                return(FindBestMoveUsingAlphaBetaAsync(boards[step],
                                                                                       searchMode,
                                                                                       transTable,
                                                                                       playerColor,
                                                                                       moveListArr[step],
                                                                                       whitePosInfo,
                                                                                       blackPosInfo,
                                                                                       moveList.Count,
                                                                                       alpha,
                                                                                       beta));
                                        }, i);
                }
                maxDepth = 999;
                for (int step = 0; step < threadCount; step++) {
                    alphaBetaRes = taskArray[step].Result;
                    if (alphaBetaRes.BestMovePos.StartPos != 255) {
                        permCount += alphaBetaRes.PermCount;
                        maxDepth   = Math.Min(maxDepth, alphaBetaRes.MaxDepth);
                        if (alphaBetaRes.Pts > alpha) {
                            alpha      = alphaBetaRes.Pts;
                            bestMove   = alphaBetaRes.BestMovePos;
                            retVal     = true;
                        }
                    }
                }
                if (maxDepth == 999) {
                    maxDepth = -1;
                }
            } else {
                ChessBoard  chessBoardTmp;
                List<Move>  moveListTmp;
                
                chessBoardTmp = board.Clone();
                moveListTmp   = new List<Move>(moveList.Count);
                for (int i = 0; i < moveList.Count; i++) {
                    moveListTmp.Add(moveList[indexes[i]]);
                }
                alphaBetaRes = FindBestMoveUsingAlphaBetaAsync(chessBoardTmp,
                                                               searchMode,
                                                               transTable,
                                                               playerColor,
                                                               moveListTmp,
                                                               whitePosInfo,
                                                               blackPosInfo,
                                                               moveList.Count,
                                                               alpha,
                                                               beta);
                permCount  = alphaBetaRes.PermCount;
                maxDepth   = alphaBetaRes.MaxDepth;
                if (alphaBetaRes.BestMovePos.StartPos != 255) {
                    bestMove   = alphaBetaRes.BestMovePos;
                    retVal     = true;
                }
            }
            if (transTable != null) {
                cacheHit =  transTable.CacheHit;
            }
            return(retVal);
        }
    } // Class SearchEngineAlphaBeta
} // Namespace
