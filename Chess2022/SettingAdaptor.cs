using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using System.Text;
using SrcChess2.FICSInterface;
using System.Windows;

namespace SrcChess2 {

    /// <summary>
    /// Transfer object setting from/to the properties setting
    /// </summary>
    internal class SettingAdaptor {

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="settings"> Properties setting</param>
        public SettingAdaptor(Properties.Settings settings) => Settings = settings;

        /// <summary>
        /// Settings
        /// </summary>
        public Properties.Settings Settings { get; private set; }

        /// <summary>
        /// Convert a color name to a color
        /// </summary>
        /// <param name="colorName">    Name of the color or hexa representation of the color</param>
        /// <returns>
        /// Color
        /// </returns>
        private Color NameToColor(string colorName) {
            Color   retVal;

            if (colorName.Length == 8 && (Char.IsLower(colorName[0]) || Char.IsDigit(colorName[0])) &&
                Int32.TryParse(colorName, System.Globalization.NumberStyles.HexNumber, null, out int val)) {
                retVal = Color.FromArgb((byte)((val >> 24) & 255), (byte)((val >> 16) & 255), (byte)((val >> 8) & 255), (byte)(val & 255));
            } else {
                retVal = (Color)ColorConverter.ConvertFromString(colorName);
            }
            return (retVal);    
        }

        /// <summary>
        /// Load the FICS connection setting from the properties setting
        /// </summary>
        /// <param name="ficsSetting">  FICS connection setting</param>
        public void LoadFICSConnectionSetting(FICSConnectionSetting ficsSetting) {
            ficsSetting.HostName    = Settings.FICSHostName;
            ficsSetting.HostPort    = Settings.FICSHostPort;
            ficsSetting.UserName    = Settings.FICSUserName;
            ficsSetting.Anonymous   = string.Compare(Settings.FICSUserName, "guest", true) == 0;
        }

        /// <summary>
        /// Save the connection settings to the property setting
        /// </summary>
        /// <param name="ficsSetting">  Copy the FICS connection setting to the properties setting</param>
        public void SaveFICSConnectionSetting(FICSConnectionSetting ficsSetting) {
            Settings.FICSHostName = ficsSetting.HostName;
            Settings.FICSHostPort = ficsSetting.HostPort;
            Settings.FICSUserName = ficsSetting.Anonymous ? "Guest" : ficsSetting.UserName;
        }

        /// <summary>
        /// Load the chess board control settings from the property setting
        /// </summary>
        /// <param name="chessCtl"> Chess board control</param>
        public void LoadChessBoardCtl(ChessBoardControl chessCtl) {
            chessCtl.LiteCellColor      = NameToColor(Settings.LiteCellColor);
            chessCtl.DarkCellColor      = NameToColor(Settings.DarkCellColor);
            chessCtl.WhitePieceColor    = NameToColor(Settings.WhitePieceColor);
            chessCtl.BlackPieceColor    = NameToColor(Settings.BlackPieceColor);
            chessCtl.MoveFlashing       = Settings.FlashPiece;
        }

        /// <summary>
        /// Save the chess board control settings to the property setting
        /// </summary>
        /// <param name="chessCtl"> Chess board control</param>
        public void SaveChessBoardCtl(ChessBoardControl chessCtl) {
            Settings.WhitePieceColor  = chessCtl.WhitePieceColor.ToString();
            Settings.BlackPieceColor  = chessCtl.BlackPieceColor.ToString();
            Settings.LiteCellColor    = chessCtl.LiteCellColor.ToString();
            Settings.DarkCellColor    = chessCtl.DarkCellColor.ToString();
            Settings.FlashPiece       = chessCtl.MoveFlashing;
        }

        /// <summary>
        /// Load main window settings from the property setting
        /// </summary>
        /// <param name="mainWnd">      Main window</param>
        /// <param name="pieceSetList"> List of available piece sets</param>
        public void LoadMainWindow(MainWindow mainWnd, SortedList<string,PieceSet> pieceSetList) {
            WindowState     windowState;

            mainWnd.m_colorBackground   = NameToColor(Settings.BackgroundColor);
            mainWnd.Background          = new SolidColorBrush(mainWnd.m_colorBackground);
            mainWnd.PieceSet            = pieceSetList[Settings.PieceSet];
            if (!Enum.TryParse(Settings.WndState, out windowState)) {
                windowState = WindowState.Normal;
            }
            mainWnd.WindowState     = windowState;
            mainWnd.Height          = Settings.WndHeight;
            mainWnd.Width           = Settings.WndWidth;
            if (Settings.WndLeft != Double.NaN) {
                mainWnd.Left        = Settings.WndLeft;
            }
            if (Settings.WndTop != Double.NaN) {
                mainWnd.Top         = Settings.WndTop;
            }
            mainWnd.m_puzzleMasks[0]  = Settings.PuzzleDoneLow;
            mainWnd.m_puzzleMasks[1]  = Settings.PuzzleDoneHigh;
        }

        /// <summary>
        /// Save main window settings from the property setting
        /// </summary>
        /// <param name="mainWnd"> Main window</param>
        public void SaveMainWindow(MainWindow mainWnd) {
            Settings.BackgroundColor  = mainWnd.m_colorBackground.ToString();
            Settings.PieceSet         = mainWnd.PieceSet?.Name ?? "???";
            Settings.WndState         = mainWnd.WindowState.ToString();
            Settings.WndHeight        = mainWnd.Height;
            Settings.WndWidth         = mainWnd.Width;
            Settings.WndLeft          = mainWnd.Left;
            Settings.WndTop           = mainWnd.Top;
            Settings.PuzzleDoneLow    = mainWnd.m_puzzleMasks[0];
            Settings.PuzzleDoneHigh   = mainWnd.m_puzzleMasks[1];
        }

        /// <summary>
        /// Save the chess board control settings to the property setting
        /// </summary>
        /// <param name="chessCtl"> Chess board control</param>
        public void FromChessBoardCtl(ChessBoardControl chessCtl) {
            Settings.WhitePieceColor    = chessCtl.WhitePieceColor.ToString();
            Settings.BlackPieceColor    = chessCtl.BlackPieceColor.ToString();
            Settings.LiteCellColor      = chessCtl.LiteCellColor.ToString();
            Settings.DarkCellColor      = chessCtl.DarkCellColor.ToString();
        }

        /// <summary>
        /// Load search setting from property settings
        /// </summary>
        /// <param name="boardEvalUtil">    Board evaluation utility</param>
        /// <param name="searchMode">       Search mode setting</param>
        public void LoadSearchMode(BoardEvaluationUtil boardEvalUtil, SettingSearchMode searchMode) {
            int transTableSize;

            transTableSize = Settings.TransTableSize;
            if (transTableSize < 5) {
                transTableSize = 5;
            } else if (transTableSize > 1000) {
                transTableSize = 1000;
            }
            searchMode.TransTableEntryCount = transTableSize / 32 * 1000000;
            searchMode.Option               = Settings.UseAlphaBeta ? SearchMode.Option.UseAlphaBeta : SearchMode.Option.UseMinMax;
            switch(Settings.DifficultyLevel) {
            case 0:
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
                searchMode.DifficultyLevel = (SettingSearchMode.SettingDifficultyLevel)Settings.DifficultyLevel;
                break;
            default:
                searchMode.DifficultyLevel = SettingSearchMode.SettingDifficultyLevel.Manual;
                break;
            }
            switch((SettingSearchMode.SettingBookMode)Settings.BookType) {
            case SettingSearchMode.SettingBookMode.NoBook:
            case SettingSearchMode.SettingBookMode.Unrated:
                searchMode.BookMode = (SettingSearchMode.SettingBookMode)Settings.BookType;
                break;
            default:
                searchMode.BookMode = SettingSearchMode.SettingBookMode.ELOGT2500;
                break;
            } 
            if (Settings.UseTransTable) {
                searchMode.Option |= SearchMode.Option.UseTransTable;
            }
            if (Settings.UsePlyCountIterative) {
                searchMode.Option |= SearchMode.Option.UseIterativeDepthSearch;
            }
            searchMode.ThreadingMode = Settings.UseThread switch
            {
                0 => SearchMode.ThreadingMode.Off,
                1 => SearchMode.ThreadingMode.DifferentThreadForSearch,
                _ => SearchMode.ThreadingMode.OnePerProcessorForSearch,
            };
            searchMode.WhiteBoardEvaluation = boardEvalUtil.FindBoardEvaluator(Settings.WhiteBoardEval) ?? boardEvalUtil.BoardEvaluators[0];
            searchMode.BlackBoardEvaluation = boardEvalUtil.FindBoardEvaluator(Settings.BlackBoardEval) ?? boardEvalUtil.BoardEvaluators[0];
            searchMode.SearchDepth          = Settings.UsePlyCount | Settings.UsePlyCountIterative ? ((Settings.PlyCount > 1 && Settings.PlyCount < 9) ? Settings.PlyCount : 6) : 0;
            searchMode.TimeOutInSec         = Settings.UsePlyCount | Settings.UsePlyCountIterative ? 0 : (Settings.AverageTime > 0 && Settings.AverageTime < 1000) ? Settings.AverageTime : 15;
            searchMode.RandomMode           = (Settings.RandomMode >= 0 && Settings.RandomMode <= 2) ? (SearchMode.RandomMode)Settings.RandomMode : SearchMode.RandomMode.On;
        }

        /// <summary>
        /// Save the search mode to properties setting
        /// </summary>
        /// <param name="searchMode">   Search mode</param>
        public void SaveSearchMode(SettingSearchMode searchMode) {
            Settings.UseAlphaBeta         = (searchMode.Option & SearchMode.Option.UseAlphaBeta) != 0;
            Settings.UseTransTable        = (searchMode.Option & SearchMode.Option.UseTransTable) != 0;
            Settings.UsePlyCountIterative = (searchMode.Option & SearchMode.Option.UseIterativeDepthSearch) != 0;
            Settings.UsePlyCount          = (searchMode.Option & SearchMode.Option.UseIterativeDepthSearch) == 0 && searchMode.SearchDepth != 0;
            Settings.DifficultyLevel      = (searchMode.DifficultyLevel == SettingSearchMode.SettingDifficultyLevel.Manual) ? 0 : (int)searchMode.DifficultyLevel;
            Settings.PlyCount             = searchMode.SearchDepth;
            Settings.AverageTime          = searchMode.TimeOutInSec;
            Settings.BookType             = (int)searchMode.BookMode;
            Settings.UseThread            = (int)searchMode.ThreadingMode;
            Settings.RandomMode           = (int)searchMode.RandomMode;
            Settings.TransTableSize       = searchMode.TransTableEntryCount * 32 / 1000000;
            Settings.WhiteBoardEval       = searchMode.WhiteBoardEvaluation?.Name ?? "???";
            Settings.BlackBoardEval       = searchMode.BlackBoardEvaluation?.Name ?? "???";
        }

        /// <summary>
        /// Load move viewer setting from properties setting
        /// </summary>
        /// <param name="moveViewer">   Move viewer</param>
        public void LoadMoveViewer(MoveViewer moveViewer) => moveViewer.DisplayMode  = (Settings.MoveNotation == 0) ? MoveViewer.ViewerDisplayMode.MovePos : MoveViewer.ViewerDisplayMode.PGN;

        /// <summary>
        /// Save move viewer setting to properties setting
        /// </summary>
        /// <param name="moveViewer">   Move viewer</param>
        public void SaveMoveViewer(MoveViewer moveViewer) => Settings.MoveNotation = (moveViewer.DisplayMode == MoveViewer.ViewerDisplayMode.MovePos) ? 0 : 1;

        /// <summary>
        /// Load FICS search criteria from properties setting
        /// </summary>
        /// <param name="searchCriteria">   Search criteria</param>
        public void LoadFICSSearchCriteria(SearchCriteria searchCriteria) {
            searchCriteria.PlayerName           = Settings.FICSSPlayerName;
            searchCriteria.BlitzGame            = Settings.FICSSBlitz;
            searchCriteria.LightningGame        = Settings.FICSSLightning;
            searchCriteria.UntimedGame          = Settings.FICSSUntimed;
            searchCriteria.StandardGame         = Settings.FICSSStandard;
            searchCriteria.IsRated              = Settings.FICSSRated;
            searchCriteria.MinRating            = SearchCriteria.CnvToNullableIntValue(Settings.FICSSMinRating);
            searchCriteria.MinTimePerPlayer     = SearchCriteria.CnvToNullableIntValue(Settings.FICSSMinTimePerPlayer);
            searchCriteria.MaxTimePerPlayer     = SearchCriteria.CnvToNullableIntValue(Settings.FICSSMaxTimePerPlayer);
            searchCriteria.MinIncTimePerMove    = SearchCriteria.CnvToNullableIntValue(Settings.FICSSMinIncTimePerMove);
            searchCriteria.MaxIncTimePerMove    = SearchCriteria.CnvToNullableIntValue(Settings.FICSSMaxIncTimePerMove);
            searchCriteria.MaxMoveDone          = Settings.FICSSMaxMoveDone;
            searchCriteria.MoveTimeOut          = SearchCriteria.CnvToNullableIntValue(Settings.FICSMoveTimeOut);
        }

        /// <summary>
        /// Save FICS search criteria to properties setting
        /// </summary>
        /// <param name="searchCriteria">   Search criteria</param>
        public void SaveFICSSearchCriteria(FICSInterface.SearchCriteria searchCriteria) {
            Settings.FICSSPlayerName          = searchCriteria.PlayerName;
            Settings.FICSSBlitz               = searchCriteria.BlitzGame;
            Settings.FICSSLightning           = searchCriteria.LightningGame;
            Settings.FICSSUntimed             = searchCriteria.UntimedGame;
            Settings.FICSSStandard            = searchCriteria.StandardGame;
            Settings.FICSSRated               = searchCriteria.IsRated;
            Settings.FICSSMinRating           = searchCriteria.MinRating.ToString();
            Settings.FICSSMinTimePerPlayer    = searchCriteria.MinTimePerPlayer.ToString();
            Settings.FICSSMaxTimePerPlayer    = searchCriteria.MaxTimePerPlayer.ToString();
            Settings.FICSSMinIncTimePerMove   = searchCriteria.MinIncTimePerMove.ToString();
            Settings.FICSSMaxIncTimePerMove   = searchCriteria.MaxIncTimePerMove.ToString();
            Settings.FICSSMaxMoveDone         = searchCriteria.MaxMoveDone;
            Settings.FICSMoveTimeOut          = searchCriteria.MoveTimeOut.ToString();
        }


    }
}
