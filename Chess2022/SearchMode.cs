using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SrcChess2 {

    /// <summary>Search Options</summary>
    public class SearchMode {

        /// <summary>Threading mode</summary>
        public enum ThreadingMode {
            /// <summary>No threading at all. User interface share the search one.</summary>
            Off                         = 0,
            /// <summary>Use a different thread for search and user interface</summary>
            DifferentThreadForSearch    = 1,
            /// <summary>Use one thread for each processor for search and one for user inetrface</summary>
            OnePerProcessorForSearch    = 2
        }
        
        /// <summary>Random mode</summary>
        public enum RandomMode {
            /// <summary>No random</summary>
            Off                         = 0,
            /// <summary>Use a repetitive random</summary>
            OnRepetitive                = 1,
            /// <summary>Use random with time seed</summary>
            On                          = 2
        }
        
        /// <summary>Search options</summary>
        [Flags]
        public enum Option {
            /// <summary>Use MinMax search</summary>
            UseMinMax                   = 0,
            /// <summary>Use Alpha-Beta prunning function</summary>
            UseAlphaBeta                = 1,
            /// <summary>Use transposition table</summary>
            UseTransTable               = 2,
            /// <summary>Use iterative depth-first search on a fix ply count</summary>
            UseIterativeDepthSearch     = 8
        }

        /// <summary>Opening book create using EOL greater than 2500</summary>
        private static readonly Book?   m_book2500;
        /// <summary>Opening book create using unrated games</summary>
        private static readonly Book?   m_bookUnrated;
        /// <summary>Board evaluation for the white</summary>
        public IBoardEvaluation         m_whiteBoardEvaluation;
        /// <summary>Board evaluation for the black</summary>
        public IBoardEvaluation         m_blackBoardEvaluation;
        /// <summary>Search option</summary>
        public Option                   m_option;
        /// <summary>Threading option</summary>
        public ThreadingMode            m_threadingMode;
        /// <summary>Maximum search depth (or 0 to use iterative deepening depth-first search with time out)</summary>
        public int                      m_searchDepth;
        /// <summary>Time out in second if using iterative deepening depth-first search</summary>
        public int                      m_timeOutInSec;
        /// <summary>Random mode</summary>
        public RandomMode               m_randomMode;
        /// <summary>Book to use for player hint</summary>
        public Book?                    m_playerBook;
        /// <summary>Book to use for computer move</summary>
        public Book?                    m_computerBook;
        /// <summary>Numbers of entry in the translation table if any</summary>
        public int                      m_transTableEntryCount;

        /// <summary>
        /// Try to read a book from a file or resource if file is not found
        /// </summary>
        /// <param name="bookName">  Book name</param>
        /// <returns>
        /// Book
        /// </returns>
        private static Book? ReadBook(string bookName) {
            Book?   retVal;
            bool    succeed = false;

            retVal = new Book();
            try {
                if (retVal.ReadBookFromFile(bookName + ".bin")) {
                    succeed = true;
                }
            } catch (Exception) {
            }
            if (!succeed) {
                try {
                    if (!retVal.ReadBookFromResource("SrcChess2." + bookName + ".bin")) {
                        retVal = null;
                    }
                } catch (Exception) {
                    retVal = null;
                }
            }
            return(retVal);
        }

        /// <summary>
        /// Static Ctor
        /// </summary>
        static SearchMode() {
            m_book2500      = ReadBook("Book2500");
            m_bookUnrated   = ReadBook("BookUnrated");
        }
        
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="whiteBoardEval">       Board evaluation for white player</param>
        /// <param name="blackBoardEval">       Board evaluation for black player</param>
        /// <param name="option">               Search options</param>
        /// <param name="threadingMode">        Threading mode</param>
        /// <param name="searchDepth">          Search depth</param>
        /// <param name="timeOutInSec">         Timeout in second</param>
        /// <param name="randomMode">           Random mode</param>
        /// <param name="playerBook">           Book use for player</param>
        /// <param name="computerBook">         Book use for human</param>
        /// <param name="transTableEntryCount"> Size of the translation table</param>
        public SearchMode(IBoardEvaluation  whiteBoardEval,
                          IBoardEvaluation  blackBoardEval,
                          Option            option,
                          ThreadingMode     threadingMode,
                          int               searchDepth,
                          int               timeOutInSec,
                          RandomMode        randomMode,
                          Book?             playerBook,
                          Book?             computerBook,
                          int               transTableEntryCount) {
            m_option                = option;
            m_threadingMode         = threadingMode;
            m_searchDepth           = searchDepth;
            m_timeOutInSec          = timeOutInSec;
            m_randomMode            = randomMode;
            m_whiteBoardEvaluation  = whiteBoardEval;
            m_blackBoardEvaluation  = blackBoardEval;
            m_playerBook            = playerBook;
            m_computerBook          = computerBook;
            m_transTableEntryCount  = transTableEntryCount;
        }

        /// <summary>
        /// Book builds from games of player having ELO greater or equal to 2500
        /// </summary>
        public static Book? Book2500 => m_book2500;

        /// <summary>
        /// Book builds from games of unrated player
        /// </summary>
        public static Book? BookUnrated => m_bookUnrated;

        /// <summary>
        /// Gets human search mode
        /// </summary>
        /// <returns>
        /// Search mode
        /// </returns>
        public string HumanSearchMode() {
            StringBuilder   strb = new StringBuilder();

            if ((m_option & SearchMode.Option.UseAlphaBeta) == SearchMode.Option.UseAlphaBeta) {
                strb.Append("Alpha-Beta ");
            } else {
                strb.Append("Min-Max ");
            }
            if (m_searchDepth == 0) {
                strb.Append("(Iterative " + m_timeOutInSec.ToString() + " secs) ");
            } else if ((m_option & SearchMode.Option.UseIterativeDepthSearch) == SearchMode.Option.UseIterativeDepthSearch) {
                strb.Append("(Iterative " + m_searchDepth.ToString() + " ply) ");
            } else {
                strb.Append(m_searchDepth.ToString() + " ply) ");
            }
            if (m_threadingMode == SearchMode.ThreadingMode.OnePerProcessorForSearch) {
                strb.Append("using " + Environment.ProcessorCount.ToString() + " processor");
                if (Environment.ProcessorCount > 1) {
                    strb.Append('s');
                }
                strb.Append(". ");
            } else {
                strb.Append("using 1 processor. ");
            }
            return(strb.ToString());
        }
    } // Class SearchMode

    /// <summary>
    /// Global search mode setting. Keep the value of manual setting even if hard coded one is used
    /// </summary>
    public class SettingSearchMode {

        /// <summary>Opening book used by the computer</summary>
        public enum SettingBookMode {
            /// <summary>No opening book</summary>
            NoBook                      = 0,
            /// <summary>Use a book built from unrated games</summary>
            Unrated                     = 1,
            /// <summary>Use a book built from games by player with ELO greater then 2500</summary>
            ELOGT2500                   = 2
        }

        /// <summary>Difficulty level</summary>
        public enum SettingDifficultyLevel {
            /// <summary>Manual</summary>
            Manual                      = 0,
            /// <summary>Very easy: 2 ply, (no book, weak board evaluation for computer)</summary>
            VeryEasy                    = 1,
            /// <summary>Easy: 2 ply, (no book, normal board evaluation for computer)</summary>
            Easy                        = 2,
            /// <summary>Intermediate: 4 ply, (unrated book, normal board evaluation for computer)</summary>
            Intermediate                = 3,
            /// <summary>Hard: 4 ply, (ELO 2500 book, normal board evaluation for computer)</summary>
            Hard                        = 4,
            /// <summary>Hard: 6 ply, (ELO 2500 book, normal board evaluation for computer)</summary>
            VeryHard                    = 5
        }

        /// <summary>Evaluation method to be used</summary>
        public enum SettingEvaluationMode {
            /// <summary>Weak evaluation method to be used for very easy game</summary>
            Weak    = 0,
            /// <summary>Weak evaluation method to be used for everything but very easy game</summary>
            Basic   = 1
        }

        /// <summary>Difficulty level</summary>
        public SettingDifficultyLevel   DifficultyLevel { get; set; }
        /// <summary>Board evaluation for the white</summary>
        public SettingBookMode          BookMode { get; set; }
        /// <summary>Search option</summary>
        public SearchMode.Option        Option { get; set; }
        /// <summary>Threading option</summary>
        public SearchMode.ThreadingMode ThreadingMode { get; set; }
        /// <summary>Maximum search depth (or 0 to use iterative deepening depth-first search with time out)</summary>
        public int                      SearchDepth { get; set; }
        /// <summary>Time out in second if using iterative deepening depth-first search</summary>
        public int                      TimeOutInSec { get; set; }
        /// <summary>Random mode</summary>
        public SearchMode.RandomMode    RandomMode { get; set; }
        /// <summary>Board evaluation method for white player</summary>
        public IBoardEvaluation?        WhiteBoardEvaluation { get; set; }
        /// <summary>Board evaluation method for black player</summary>
        public IBoardEvaluation?        BlackBoardEvaluation { get; set; }
        /// <summary>Number of entries in the translation table</summary>
        public int                      TransTableEntryCount { get; set; }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="difficultyLevel">  Difficulty level</param>
        /// <param name="whiteBoardEval">   Board evaluation for white player</param>
        /// <param name="blackBoardEval">   Board evaluation for black player</param>
        /// <param name="option">           Search options</param>
        /// <param name="threadingMode">    Threading mode</param>
        /// <param name="searchDepth">      Search depth</param>
        /// <param name="timeOutInSec">     Timeout in second</param>
        /// <param name="randomMode">       Random mode</param>
        /// <param name="bookMode">         Book mode</param>
        public SettingSearchMode(SettingDifficultyLevel     difficultyLevel,
                                 IBoardEvaluation?          whiteBoardEval,
                                 IBoardEvaluation?          blackBoardEval,
                                 SearchMode.Option          option,
                                 SearchMode.ThreadingMode   threadingMode,
                                 int                        searchDepth,
                                 int                        timeOutInSec,
                                 SearchMode.RandomMode      randomMode,
                                 SettingBookMode            bookMode) {
            DifficultyLevel         = difficultyLevel;
            WhiteBoardEvaluation    = whiteBoardEval;
            BlackBoardEvaluation    = blackBoardEval;
            Option                  = option;
            ThreadingMode           = threadingMode;
            SearchDepth             = searchDepth;
            TimeOutInSec            = timeOutInSec;
            RandomMode              = randomMode;
            BookMode                = bookMode;
            TransTableEntryCount    = 320000000;
        }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="difficultyLevel"> Difficuly level</param>
        public SettingSearchMode(SettingDifficultyLevel difficultyLevel) : this(difficultyLevel,
                                                                                whiteBoardEval: null,
                                                                                blackBoardEval: null,
                                                                                SearchMode.Option.UseAlphaBeta,
                                                                                SearchMode.ThreadingMode.OnePerProcessorForSearch,
                                                                                searchDepth:  2,
                                                                                timeOutInSec: 0,
                                                                                SearchMode.RandomMode.On,
                                                                                SettingBookMode.ELOGT2500) {
        }

        /// <summary>
        /// Ctor
        /// </summary>
        public SettingSearchMode() : this(SettingDifficultyLevel.Easy) {}

        /// <summary>
        /// Gets the mode tooltip description
        /// </summary>
        /// <param name="level">   Difficulty level</param>
        public static string ModeTooltip(SettingDifficultyLevel level) {
            SettingSearchMode   searchMode = new SettingSearchMode(level);

            return(searchMode.HumanSearchMode());
        }

        /// <summary>
        /// Gets the active computer book mode
        /// </summary>
        public SettingBookMode ActiveComputerBookMode {
            get {
                SettingBookMode   retVal;

                switch (DifficultyLevel) {
                case SettingDifficultyLevel.Manual:
                    retVal = BookMode;
                    break;
                case SettingDifficultyLevel.VeryEasy:
                case SettingDifficultyLevel.Easy:
                    retVal = SettingBookMode.NoBook;
                    break;
                case SettingDifficultyLevel.Intermediate:
                    retVal = SettingBookMode.Unrated;
                    break;
                case SettingDifficultyLevel.Hard:
                case SettingDifficultyLevel.VeryHard:
                default:
                    retVal = SettingBookMode.ELOGT2500;
                    break;
                }
                return(retVal);
            }
        }

        /// <summary>
        /// Gets the search mode from the setting
        /// </summary>
        /// <returns></returns>
        public SearchMode GetSearchMode() {
            SearchMode                  retVal;
            SearchMode.Option           option;
            SearchMode.ThreadingMode    threadingMode;
            int                         timeOutInSec;
            Book?                       computerBook;

            option          = SearchMode.Option.UseAlphaBeta | SearchMode.Option.UseIterativeDepthSearch | SearchMode.Option.UseTransTable;
            threadingMode   = SearchMode.ThreadingMode.OnePerProcessorForSearch;
            timeOutInSec    = 0;
            computerBook    = ActiveComputerBookMode switch {
                SettingBookMode.NoBook  => null,
                SettingBookMode.Unrated => SearchMode.BookUnrated,
                _                       => SearchMode.Book2500,
            };
            retVal          = DifficultyLevel switch {
                SettingDifficultyLevel.VeryEasy         => new SearchMode(new BoardEvaluationWeak(),
                                                                          new BoardEvaluationWeak(),
                                                                          option,
                                                                          threadingMode,
                                                                          2 /*iSearchDepth*/,
                                                                          timeOutInSec,
                                                                          SearchMode.RandomMode.On,
                                                                          SearchMode.Book2500,
                                                                          computerBook,
                                                                          TransTableEntryCount),
                SettingDifficultyLevel.Easy             => new SearchMode(new BoardEvaluationBasic(),
                                                                          new BoardEvaluationBasic(),
                                                                          option,
                                                                          threadingMode,
                                                                          2 /*iSearchDepth*/,
                                                                          timeOutInSec,
                                                                          SearchMode.RandomMode.On,
                                                                          SearchMode.Book2500,
                                                                          computerBook,
                                                                          TransTableEntryCount),
                SettingDifficultyLevel.Intermediate     => new SearchMode(new BoardEvaluationBasic(),
                                                                          new BoardEvaluationBasic(),
                                                                          option,
                                                                          threadingMode,
                                                                          4 /*iSearchDepth*/,
                                                                          timeOutInSec,
                                                                          SearchMode.RandomMode.On,
                                                                          SearchMode.Book2500,
                                                                          computerBook,
                                                                          TransTableEntryCount),
                SettingDifficultyLevel.Hard             => new SearchMode(new BoardEvaluationBasic(),
                                                                          new BoardEvaluationBasic(),
                                                                          option,
                                                                          threadingMode,
                                                                          4 /*iSearchDepth*/,
                                                                          timeOutInSec,
                                                                          SearchMode.RandomMode.On,
                                                                          SearchMode.Book2500,
                                                                          computerBook,
                                                                          TransTableEntryCount),
                SettingDifficultyLevel.VeryHard         => new SearchMode(WhiteBoardEvaluation ?? new BoardEvaluationBasic(),
                                                                          BlackBoardEvaluation ?? new BoardEvaluationBasic(),
                                                                          option,
                                                                          threadingMode,
                                                                          6 /*iSearchDepth*/,
                                                                          timeOutInSec,
                                                                          SearchMode.RandomMode.On,
                                                                          SearchMode.Book2500,
                                                                          computerBook,
                                                                          TransTableEntryCount),
                _                                       => new SearchMode(WhiteBoardEvaluation ?? new BoardEvaluationBasic(),
                                                                          BlackBoardEvaluation ?? new BoardEvaluationBasic(),
                                                                          Option,
                                                                          ThreadingMode,
                                                                          SearchDepth,
                                                                          TimeOutInSec,
                                                                          RandomMode,
                                                                          SearchMode.Book2500,
                                                                          computerBook,
                                                                          TransTableEntryCount),
            };
            return (retVal);
        }

        /// <summary>
        /// Convert the search setting to a human form
        /// </summary>
        /// <returns>
        /// Search mode description
        /// </returns>
        public string HumanSearchMode() {
            StringBuilder   strb       = new StringBuilder();
            SearchMode      searchMode = GetSearchMode();

            strb.Append(searchMode.HumanSearchMode());
            switch(ActiveComputerBookMode) {
            case SettingBookMode.NoBook:
                strb.Append("No opening book. ");
                break;
            case SettingBookMode.Unrated:
                strb.Append("Using unrated opening book. ");
                break;
            default:
                strb.Append("Using master opening book. ");
                break;
            }
            if (DifficultyLevel == SettingDifficultyLevel.VeryEasy) {
                strb.Append("Using weak board evaluation");
            }
            return(strb.ToString());
        }
    } // Class SettingSearchMode
} // Namespace
