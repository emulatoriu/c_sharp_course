using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace SrcChess2 {
    /// <summary>Base class for Search Engine</summary>
    public abstract class SearchEngine {

        #region Inner Class
        /// <summary>Interface to implement to do a search</summary>
        public interface ITrace {
            /// <summary>
            /// Search trace
            /// </summary>
            /// <param name="depth">        Depth of the move</param>
            /// <param name="playerColor">  Player's color</param>
            /// <param name="movePos">      Move position</param>
            /// <param name="pts">          Points for the board</param>
            void TraceSearch(int depth, ChessBoard.PlayerColor playerColor, Move movePos, int pts);
        };

        private struct PointIndex : IComparable<PointIndex> {
            public int     Index;
            public int     Points;

            public int CompareTo(PointIndex Other) {
                int retVal;
            
                if (Points < Other.Points) {
                    retVal = 1;
                } else if (Points > Other.Points) {
                    retVal = -1;
                } else {
                    retVal = (Index < Other.Index) ? -1 : 1;
                }
                return(retVal);
            }
        }
        #endregion

        #region Members
        /// <summary>Working search engine</summary>
        private static SearchEngine?            m_searchEngineWorking = null;
        /// <summary>Translation table</summary>
        private static TransTable?              s_transTable = null;
        /// <summary>true to cancel the search</summary>
        protected static bool                   s_cancelSearch = false;
        /// <summary>Object where to redirect the trace if any</summary>
        private readonly ITrace?                m_trace;
        /// <summary>Random number generator</summary>
        private readonly Random                 m_rnd;
        /// <summary>Random number generator (repetitive, seed = 0)</summary>
        private readonly Random                 m_rndRep;
        #endregion

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="trace">    Trace object or null</param>
        /// <param name="rnd">      Random object</param>
        /// <param name="rndRep">   Repetitive random object</param>
        protected SearchEngine(ITrace? trace, Random rnd, Random rndRep) {
            m_trace         =   trace;
            m_rnd           =   rnd;
            m_rndRep        =   rndRep;
        }

        /// <summary>
        /// Debugging routine
        /// </summary>
        /// <param name="depth">        Actual search depth</param>
        /// <param name="playerColor">  Color doing the move</param>
        /// <param name="move">         Move</param>
        /// <param name="pts">          Points for this move</param>
        protected void TraceSearch(int depth, ChessBoard.PlayerColor playerColor, Move move, int pts) => m_trace?.TraceSearch(depth, playerColor, move, pts);

        /// <summary>
        /// Cancel the search
        /// </summary>
        public static void SearchCancelled() => s_cancelSearch = true;

        /// <summary>
        /// Return true if search engine is busy
        /// </summary>
        public static bool IsSearchEngineBusy => m_searchEngineWorking != null;

        /// <summary>
        /// Return true if the search has been canceled
        /// </summary>
        public static bool IsSearchHasBeenCanceled => s_cancelSearch;

        /// <summary>
        /// Sort move list using the specified point array so the highest point move come first
        /// </summary>
        /// <param name="moveList"> Source move list to sort</param>
        /// <param name="points">   Array of points for each move</param>
        /// <returns>
        /// Sorted move list
        /// </returns>
        protected static List<Move> SortMoveList(List<Move> moveList, int[] points) {
            List<Move>      retVal;
            PointIndex[]    pointIndexes;
            
            retVal          = new List<Move>(moveList.Count);
            pointIndexes    = new PointIndex[points.Length];
            for (int i = 0; i < pointIndexes.Length; i++) {
                pointIndexes[i].Points = points[i];
                pointIndexes[i].Index  = i;
            }
            Array.Reverse(pointIndexes);
            Array.Sort<PointIndex>(pointIndexes);
            for (int i = 0; i < pointIndexes.Length; i++) {
                retVal.Add(moveList[pointIndexes[i].Index]);
            }
            return(retVal);
        }

        /// <summary>
        /// Find the best move using a specific search method
        /// </summary>
        /// <param name="chessBoard">       Chess board</param>
        /// <param name="searchMode">       Search mode</param>
        /// <param name="transTable">       Translation table or null if none</param>
        /// <param name="playerColor">      Player doing the move</param>
        /// <param name="moveList">         Move list</param>
        /// <param name="indexes">          Order of evaluation of the moves</param>
        /// <param name="posInfo">          Position information</param>
        /// <param name="bestMove">         Best move found</param>
        /// <param name="permCount">        Total permutation evaluated</param>
        /// <param name="cacheHit">         Number of moves found in the translation table cache</param>
        /// <param name="maxDepth">         Maximum depth to use</param>
        /// <returns>
        /// true if a move has been found
        /// </returns>
        protected abstract bool FindBestMove(ChessBoard             chessBoard,
                                             SearchMode             searchMode,
                                             TransTable?            transTable,
                                             ChessBoard.PlayerColor playerColor,
                                             List<Move>             moveList,
                                             int[]                  indexes,
                                             ChessBoard.PosInfo     posInfo,
                                             ref Move               bestMove,
                                             out int                permCount,
                                             out long               cacheHit,
                                             out int                maxDepth);

        /// <summary>
        /// Find the best move for a player using a specific method
        /// </summary>
        /// <param name="board">            Board</param>
        /// <param name="searchMode">       Search mode</param>
        /// <param name="transTable">       Translation table or null if none</param>
        /// <param name="playerColor">      Player making the move</param>
        /// <param name="dispatcher">       Dispatcher of the main thread if function is called on a background thread</param>
        /// <param name="foundMoveAction">  Action to call with the found move</param>
        /// <param name="cookie">           Cookie to pass to the action</param>
        private void FindBestMove<T>(ChessBoard             board,
                                     SearchMode             searchMode,
                                     TransTable?            transTable,
                                     ChessBoard.PlayerColor playerColor,
                                     Dispatcher?            dispatcher,
                                     Action<T,MoveExt>      foundMoveAction,
                                     T                      cookie) {
            List<Move>  moveList;
            MoveExt     moveExt;
            Move        move;
            int[]       indexes;
            int         swapIndex;
            int         tmp;
            Random      rnd;

            moveList = board.EnumMoveList(playerColor, needMoveList: true, out ChessBoard.PosInfo posInfo)!;
            indexes  = new int[moveList.Count];
            for (int i = 0; i < moveList.Count; i++) {
                indexes[i] = i;
            }
            if (searchMode.m_randomMode != SearchMode.RandomMode.Off) {
                rnd = (searchMode.m_randomMode == SearchMode.RandomMode.OnRepetitive) ? m_rndRep : m_rnd;
                for (int i = 0; i < moveList.Count; i++) {
                    swapIndex           = rnd.Next(moveList.Count);
                    tmp                 = indexes[i];
                    indexes[i]          = indexes[swapIndex];
                    indexes[swapIndex]  = tmp;
                }
            }
            move.StartPos           = 0;
            move.EndPos             = 0;
            move.OriginalPiece      = ChessBoard.PieceType.None;
            move.Type               = Move.MoveType.Normal;
            FindBestMove(board, searchMode, transTable, playerColor, moveList, indexes, posInfo, ref move, out int permCount, out long _, out int maxDepth);
            moveExt                 = new MoveExt(move, "", permCount, maxDepth, maxDepth, 0);
            m_searchEngineWorking   = null;
            if (dispatcher != null) {
                dispatcher.Invoke(foundMoveAction, cookie, moveExt);
            } else {
                foundMoveAction(cookie, moveExt);
            }
        }

        /// <summary>
        /// Find the best move for the given player
        /// </summary>
        /// <param name="trace">            Trace object or null</param>
        /// <param name="rnd">              Random object</param>
        /// <param name="rndRep">           Repetitive random object</param>
        /// <param name="board">            Board</param>
        /// <param name="searchMode">       Search mode</param>
        /// <param name="playerColor">      Player making the move</param>
        /// <param name="dispatcher">       Main thread dispatcher</param>
        /// <param name="moveFoundAction">  Action to execute when the find best move routine is done</param>
        /// <param name="cookie">           Cookie to pass to the actionMoveFound action</param>
        /// <returns>
        /// true if search has started, false if search engine is busy
        /// </returns>
        public static bool FindBestMove<T>(ITrace?                  trace,
                                           Random                   rnd,
                                           Random                   rndRep,
                                           ChessBoard               board,
                                           SearchMode               searchMode,
                                           ChessBoard.PlayerColor   playerColor,
                                           Dispatcher               dispatcher,
                                           Action<T,MoveExt>        moveFoundAction,
                                           T                        cookie) {
            bool            retVal;
            bool            isMultipleThread;
            SearchEngine    searchEngine;
            TransTable?     transTable;

            if (IsSearchEngineBusy) { 
                retVal = false;
            } else {
                retVal         = true;
                s_cancelSearch = false;
                if ((searchMode.m_option & SearchMode.Option.UseTransTable) != 0) {
                    if (s_transTable == null || s_transTable.EntryCount != searchMode.m_transTableEntryCount) {
                        s_transTable = new TransTable(searchMode.m_transTableEntryCount);
                    } else {
                        s_transTable.Reset();
                    }
                    transTable = s_transTable;
                } else {
                    transTable = null;
                }
                if (searchMode.m_option == SearchMode.Option.UseMinMax) {
                    searchEngine = new SearchEngineMinMax(trace, rnd, rndRep);
                } else {
                    searchEngine = new SearchEngineAlphaBeta(trace, rnd, rndRep);
                }
                isMultipleThread      = (searchMode.m_threadingMode == SearchMode.ThreadingMode.DifferentThreadForSearch ||
                                         searchMode.m_threadingMode == SearchMode.ThreadingMode.OnePerProcessorForSearch);
                m_searchEngineWorking = searchEngine;
                if (isMultipleThread) {
                    Task.Factory.StartNew(() => searchEngine.FindBestMove(board,
                                                                          searchMode,
                                                                          transTable,
                                                                          playerColor,
                                                                          dispatcher,
                                                                          moveFoundAction,
                                                                          cookie));
                } else {
                    searchEngine.FindBestMove(board,
                                              searchMode,
                                              transTable,
                                              playerColor,
                                              dispatcher: null,
                                              moveFoundAction,
                                              cookie);
                }
            }
            return(retVal);
        }
    } // Class SearchEngine
} // Namespace
