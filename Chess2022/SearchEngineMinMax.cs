using System;
using System.Collections.Generic;

namespace SrcChess2 {
    /// <summary>Base class for Search Engine</summary>
    public sealed class SearchEngineMinMax : SearchEngine {

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="trace">    Trace object or null</param>
        /// <param name="rnd">      Random object</param>
        /// <param name="rndRep">   Repetitive random object</param>
        public SearchEngineMinMax(ITrace? trace, Random rnd, Random rndRep) : base(trace, rnd, rndRep) {}

        /// <summary>
        /// Minimum/maximum depth first search
        /// </summary>
        /// <param name="board">            Chess board</param>
        /// <param name="searchMode">       Search mode</param>
        /// <param name="playerColor">      Player doing the move</param>
        /// <param name="depth">            Actual search depth</param>
        /// <param name="whiteMoveCount">   Number of moves white can do</param>
        /// <param name="blackMoveCount">   Number of moves black can do</param>
        /// <param name="permCount">        Total permutation evaluated</param>
        /// <returns>
        /// Points to give for this move
        /// </returns>
        private int MinMax(ChessBoard board, SearchMode searchMode, ChessBoard.PlayerColor playerColor, int depth, int whiteMoveCount, int blackMoveCount, ref int permCount) {
            int                     retVal;
            int                     moveCount;
            int                     pts;
            List<Move>              moveList;
            ChessBoard.RepeatResult result;
            
            if (board.IsEnoughPieceForCheckMate()) {
                if (depth == 0 || s_cancelSearch) {
                    retVal = (playerColor == ChessBoard.PlayerColor.Black) ? -board.Points(searchMode, playerColor, 0, whiteMoveCount - blackMoveCount, ChessBoard.s_posInfoNull, ChessBoard.s_posInfoNull) :
                                                                              board.Points(searchMode, playerColor, 0, whiteMoveCount - blackMoveCount, ChessBoard.s_posInfoNull, ChessBoard.s_posInfoNull);
                    permCount++;
                } else {
                    moveList  = board.EnumMoveList(playerColor);
                    moveCount = moveList.Count;
                    if (playerColor == ChessBoard.PlayerColor.White) {
                        whiteMoveCount = moveCount;
                    } else {
                        blackMoveCount = moveCount;
                    }
                    if (moveCount == 0) {
                        if (board.IsCheck(playerColor)) {
                            retVal = -1000000 - depth;
                        } else {
                            retVal = 0; // Draw
                        }
                    } else {
                        retVal  = Int32.MinValue;
                        foreach (Move move in moveList) {
                            result = board.DoMoveNoLog(move);
                            if (result == ChessBoard.RepeatResult.NoRepeat) {
                                pts = -MinMax(board,
                                              searchMode,
                                              (playerColor == ChessBoard.PlayerColor.Black) ? ChessBoard.PlayerColor.White : ChessBoard.PlayerColor.Black,
                                              depth - 1,
                                              whiteMoveCount,
                                              blackMoveCount,
                                              ref permCount);
                            } else {
                                pts = 0;
                            }
                            board.UndoMoveNoLog(move);
                            if (pts > retVal) {
                                retVal = pts;
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
        /// Find the best move for a player using minmax search
        /// </summary>
        /// <param name="board">        Chess board</param>
        /// <param name="searchMode">   Search mode</param>
        /// <param name="playerColor">  Color doing the move</param>
        /// <param name="moveList">     Move list</param>
        /// <param name="indexes">      Order of evaluation of the moves</param>
        /// <param name="depth">        Maximum depth</param>
        /// <param name="bestMove">     Best move found</param>
        /// <param name="permCount">    Total permutation evaluated</param>
        /// <returns>
        /// true if a move has been found
        /// </returns>
        private bool FindBestMoveUsingMinMaxAtDepth(ChessBoard board, SearchMode searchMode, ChessBoard.PlayerColor playerColor, List<Move> moveList, int[] indexes, int depth, ref Move bestMove, out int permCount) {
            bool                    retVal = false;
            Move                    move;
            int                     pts;
            int                     whiteMoveCount;
            int                     blackMoveCount;
            int                     bestPts;
            ChessBoard.RepeatResult result;
            
            permCount  = 0;
            bestPts    = Int32.MinValue;
            if (playerColor == ChessBoard.PlayerColor.White) {
                whiteMoveCount = moveList.Count;
                blackMoveCount = 0;
            } else {
                whiteMoveCount = 0;
                blackMoveCount = moveList.Count;
            }
            foreach (int index in indexes) {
                move   = moveList[index];
                result = board.DoMoveNoLog(move);
                if (result == ChessBoard.RepeatResult.NoRepeat) {
                    pts = -MinMax(board,
                                  searchMode,
                                  (playerColor == ChessBoard.PlayerColor.Black) ? ChessBoard.PlayerColor.White : ChessBoard.PlayerColor.Black,
                                  depth - 1,
                                  whiteMoveCount,
                                  blackMoveCount,
                                  ref permCount);
                } else {
                    pts = 0;
                }                                   
                board.UndoMoveNoLog(move);
                if (pts > bestPts) {
                    TraceSearch(depth, playerColor, move, pts);
                    bestPts  = pts;
                    bestMove = move;
                    retVal   = true;
                }
            }
            return(retVal);
        }

        /// <summary>
        /// Find the best move for a player using minmax search
        /// </summary>
        /// <param name="board">        Chess board</param>
        /// <param name="searchMode">   Search mode</param>
        /// <param name="transTable">   Translation table if any</param>
        /// <param name="playerColor">  Color doing the move</param>
        /// <param name="moveList">     Move list</param>
        /// <param name="indexes">      Order of evaluation of the moves</param>
        /// <param name="posInfo">      Information about pieces attacks</param>
        /// <param name="bestMove">     Best move found</param>
        /// <param name="permCount">    Nb of permutations evaluated</param>
        /// <param name="cacheHit">     Nb of cache hit</param>
        /// <param name="maxDepth">     Maximum depth evaluated</param>
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
            bool        retVal;
            DateTime    timeOut;
            int         depth;

            permCount = 0;
            cacheHit  = 0;
            if (searchMode.m_searchDepth == 0) {
                timeOut = DateTime.Now + TimeSpan.FromSeconds(searchMode.m_timeOutInSec);
                depth   = 0;
                do {
                    retVal = FindBestMoveUsingMinMaxAtDepth(board,
                                                            searchMode,
                                                            playerColor,
                                                            moveList,
                                                            indexes,
                                                            depth + 1,
                                                            ref bestMove,
                                                            out int permCountAtLevel);
                    permCount += permCountAtLevel;
                    depth++;
                } while (DateTime.Now < timeOut);
                maxDepth = depth;
            } else {
                maxDepth = searchMode.m_searchDepth;
                retVal   = FindBestMoveUsingMinMaxAtDepth(board,
                                                          searchMode,
                                                          playerColor,
                                                          moveList,
                                                          indexes,
                                                          maxDepth,
                                                          ref bestMove,
                                                          out permCount);
            }
            return(retVal);
        }
    } // Class SearchEngineMinMax
} // Namespace
