﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using System.Linq;
using System.Globalization;

namespace SrcChess2 {
    /// <summary>
    /// Utility class to help handling PGN files. Help filtering PGN files or creating one from an existing board
    /// </summary>
    public class PgnUtil {

        /// <summary>
        /// Used when creating a PGN move
        /// </summary>
        [Flags]
        private enum PGNAmbiguity {
            /// <summary>No ambiguity in the move. Can use short notation</summary>
            NotFound            = 0,
            /// <summary>An ambiguity has been found. More than one move can be found if using short notation</summary>
            Found               = 1,
            /// <summary>Column must be specified to remove ambiguity</summary>
            ColMustBeSpecify    = 2,
            /// <summary>Row must be specified to remove ambiguity</summary>
            RowMustBeSpecify    = 4
        }
        
        /// <summary>Information use to filter a PGN file</summary>
        public class FilterClause {
            /// <summary>All ELO rating included if true</summary>
            public  bool                        IsAllRanges { get; set; }
            /// <summary>Includes unrated games if true</summary>
            public  bool                        IncludesUnrated { get; set; }
            /// <summary>If not all ELO rating included, hash of all ELO which must be included. Each value represent a range (value, value+99)</summary>
            public  Dictionary<int, int>?       HashRanges { get; set; }
            /// <summary>All players included if true</summary>
            public  bool                        IncludeAllPlayers { get; set; }
            /// <summary>Hash of all players to include if not all included</summary>
            public  Dictionary<string,string?>? HashPlayerList { get; set; }
            /// <summary>Includes all ending if true</summary>
            public  bool                        IncludeAllEnding { get; set; }
            /// <summary>true to include game winned by white player</summary>
            public  bool                        IncludeWhiteWinningEnding { get; set; }
            /// <summary>true to include game winned by black player</summary>
            public  bool                        IncludeBlackWinningEnding { get; set; }
            /// <summary>true to include draws game </summary>
            public  bool                        IncludeDrawEnding { get; set; }
        }
        
        /// <summary>
        /// Open an file for reading
        /// </summary>
        /// <param name="inpFileName">      File name to open</param>
        /// <returns>
        /// Stream or null if unable to open the file.
        /// </returns>
        public static Stream? OpenInpFile(string inpFileName) {
            Stream? retVal;
            
            try {
                retVal = File.OpenRead(inpFileName);
            } catch(Exception) {
                MessageBox.Show("Unable to open the file - " + inpFileName);
                retVal = null;
            }
            return(retVal);
        }

        /// <summary>
        /// Creates a new file
        /// </summary>
        /// <param name="outFileName">  Name of the file to create</param>
        /// <returns>
        /// Stream or null if unable to create the file.
        /// </returns>
        public static StreamWriter? CreateOutFile(string outFileName) {
            StreamWriter?   retVal;
            Stream          streamOut;
            
            try {
                streamOut   = File.Create(outFileName);
                retVal      = new StreamWriter(streamOut, Encoding.GetEncoding(1252));
            } catch(Exception) {
                MessageBox.Show($"Unable to create the file - {outFileName}");
                retVal = null;
            }
            return(retVal);
        }

        /// <summary>
        /// Write a PGN game in the specified output stream
        /// </summary>
        /// <param name="pgnBuffer">    PGN buffer</param>
        /// <param name="writer">       Text writer</param>
        /// <param name="pgnGame">      PGN game</param>
        private void WritePGN(PgnLexical pgnBuffer, TextWriter writer, PgnGame pgnGame) => writer.Write(pgnBuffer.GetStringAtPos(pgnGame.StartingPos, pgnGame.Length));

        /// <summary>
        /// Gets the information about a PGN game
        /// </summary>
        /// <param name="rawGame">      Raw PGN game</param>
        /// <param name="gameResult">   Result of the game</param>
        /// <param name="gameDate">     Date of the game</param>
        private static void GetPGNGameInfo(PgnGame      rawGame,
                                           out string?  gameResult,
                                           out string?  gameDate) {
            if (rawGame.Attrs == null || !rawGame.Attrs.TryGetValue("Result", out gameResult)) {
                gameResult = null;
            }
            if (rawGame.Attrs == null || !rawGame.Attrs.TryGetValue("Date", out gameDate)) {
                gameDate = null;
            }
        }

        /// <summary>
        /// Scan the PGN stream to retrieve some informations
        /// </summary>
        /// <param name="pgnGames">         PGN games</param>
        /// <param name="setPlayerList">    Set to be filled with the players list</param>
        /// <param name="minELO">           Minimum ELO found in the games</param>
        /// <param name="maxELO">           Maximum ELO found in the games</param>
        /// <returns>
        /// List of raw games without the move list
        /// </returns>
        public void FillFilterList(List<PgnGame> pgnGames, HashSet<String> setPlayerList, ref int minELO, ref int maxELO) {
            int     avgELO;
            string? player;
            
            foreach (PgnGame pgnGame in pgnGames) {
                if (setPlayerList != null) {
                    player = pgnGame.WhitePlayerName;
                    if (player != null && !setPlayerList.Contains(player)) {
                        setPlayerList.Add(player);
                    }
                    player = pgnGame.BlackPlayerName;
                    if (player != null && !setPlayerList.Contains(player)) {
                        setPlayerList.Add(player);
                    }
                }
                if (pgnGame.WhiteELO != -1 && pgnGame.BlackELO != -1) {
                    avgELO = (pgnGame.WhiteELO + pgnGame.BlackELO) / 2;
                    if (avgELO > maxELO) {
                        maxELO = avgELO;
                    }
                    if (avgELO < minELO) {
                        minELO = avgELO;
                    }
                }
            }
        }

        /// <summary>
        /// Checks if the specified game must be retained accordingly to the specified filter
        /// </summary>
        /// <param name="rawGame">          PGN Raw game</param>
        /// <param name="avgELO">           Game average ELO</param>
        /// <param name="filterClause">     Filter clause</param>
        /// <returns>
        /// true if must be retained
        /// </returns>
        private bool IsRetained(PgnGame rawGame, int avgELO, FilterClause filterClause) {
            bool    retVal;

            if (avgELO == -1) {
                retVal = filterClause.IncludesUnrated;
            } else if (filterClause.IsAllRanges) {
                retVal = true;
            } else {
                avgELO = avgELO / 100 * 100;
                retVal = filterClause.HashRanges!.ContainsKey(avgELO);
            }
            if (retVal) {
                if (!filterClause.IncludeAllPlayers || !filterClause.IncludeAllEnding) {
                    GetPGNGameInfo(rawGame, out string? gameResult,out string? gameDate);
                    if (!filterClause.IncludeAllPlayers) {
                        if (!filterClause.HashPlayerList!.ContainsKey(rawGame.BlackPlayerName ?? "") &&
                            !filterClause.HashPlayerList!.ContainsKey(rawGame.WhitePlayerName ?? "")) {
                            retVal = false;
                        }
                    }
                    if (retVal && !filterClause.IncludeAllEnding) {
                        if (gameResult == "1-0") {
                            retVal = filterClause.IncludeWhiteWinningEnding;
                        } else if (gameResult == "0-1") {
                            retVal = filterClause.IncludeBlackWinningEnding;
                        } else if (gameResult == "1/2-1/2") {
                            retVal = filterClause.IncludeDrawEnding;
                        } else {
                            retVal = false;
                        }
                    }
                }                
            }
            return(retVal);
        }

        /// <summary>
        /// Filter the content of the PGN file in the input stream to fill the output stream
        /// </summary>
        /// <param name="pgnParser">        PGN parser</param>
        /// <param name="rawGames">         List of PGN raw games without move list</param>
        /// <param name="textWriter">       Output stream. If null, just run to determine the result count.</param>
        /// <param name="filterClause">     Filter clause</param>
        /// <returns>
        /// Number of resulting games.
        /// </returns>
        public int FilterPGN(PgnParser pgnParser, List<PgnGame> rawGames, TextWriter? textWriter, FilterClause filterClause) {
            int     retVal;
            int     whiteELO;
            int     blackELO;
            int     avgELO;
            
            retVal = 0;
            try {
                foreach (PgnGame rawGame in rawGames) {
                    whiteELO    = rawGame.WhiteELO;
                    blackELO    = rawGame.BlackELO;
                    avgELO      = (whiteELO != -1 && blackELO != -1) ? (whiteELO + blackELO) / 2 : -1;
                    if (IsRetained(rawGame, avgELO, filterClause)) {
                        if (textWriter != null) {
                            WritePGN(pgnParser.PGNLexical!, textWriter, rawGame);
                        }
                        retVal++;
                    }
                }
                textWriter?.Flush();
            } catch(Exception exc) {
                MessageBox.Show("Error writing in destination file.\r\n" + exc.Message);
                retVal = 0;
            }
            return(retVal);
        }

        /// <summary>
        /// Creates a PGN file as a subset of an existing one.
        /// </summary>
        /// <param name="pgnParser">    PGN parser</param>
        /// <param name="pgnGames">     Source PGN games</param>
        /// <param name="filterClause"> Filter clause</param>
        public void CreateSubsetPGN(PgnParser       pgnParser,
                                    List<PgnGame>   pgnGames,
                                    FilterClause    filterClause) {
            SaveFileDialog  saveDlg;
            StreamWriter?   streamWriter;
            int             count;

            saveDlg = new SaveFileDialog {
                AddExtension    = true,
                CheckPathExists = true,
                DefaultExt      = "pgn",
                Filter          = "Chess PGN Files (*.pgn)|*.pgn",
                OverwritePrompt = true,
                Title           = "PGN File to Create"
            };
            if (saveDlg.ShowDialog() == true) {
                streamWriter = CreateOutFile(saveDlg.FileName);
                if (streamWriter != null) {
                    using(streamWriter) {
                        count = FilterPGN(pgnParser,
                                          pgnGames,
                                          streamWriter,
                                          filterClause);
                        MessageBox.Show($"The file '{saveDlg.FileName}' has been created with {count} game(s)");
                    }
                }
            }
        }

        /// <summary>
        /// Creates one or many PGN files as a subset of an existing one.
        /// </summary>
        /// <param name="parentWnd">    Parent window</param>
        public void CreatePGNSubsets(Window parentWnd) {
            OpenFileDialog  openDlg;
            List<PgnGame>   pgnGames;
            PgnParser       pgnParser;
            HashSet<string> setPlayer;
            String[]        arrPlayer;
            int             minELO;
            int             maxELO;
            frmPgnFilter    pgnFilterFrm;
            frmLoadPGNGames loadPGNGamesFrm;

            openDlg = new OpenFileDialog {
                AddExtension    = true,
                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt      = "pgn",
                Filter          = "Chess PGN Files (*.pgn)|*.pgn",
                Multiselect     = false,
                Title           = "Open Source PGN File"
            };
            if (openDlg.ShowDialog() == true) {
                setPlayer               = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                minELO                  = Int32.MaxValue;
                maxELO                  = Int32.MinValue;
                loadPGNGamesFrm = new frmLoadPGNGames(openDlg.FileName) {
                    Owner = parentWnd
                };
                if (loadPGNGamesFrm.ShowDialog() == true) {
                    pgnGames    = loadPGNGamesFrm.PGNGames!;
                    pgnParser   = loadPGNGamesFrm.PGNParser!;
                    if (pgnGames.Count == 0) {
                        MessageBox.Show("No games found in the file.");
                    } else {
                        FillFilterList(pgnGames, setPlayer, ref minELO, ref maxELO);
                        arrPlayer = new string[setPlayer.Count];
                        setPlayer.CopyTo(arrPlayer, 0);
                        Array.Sort(arrPlayer);
                        pgnFilterFrm = new frmPgnFilter(pgnParser,
                                                        this,
                                                        pgnGames,
                                                        minELO,
                                                        maxELO,
                                                        arrPlayer,
                                                        openDlg.FileName);
                        pgnFilterFrm.ShowDialog();
                    }
                }
            }
        }

        /// <summary>
        /// Gets Square Id from the PGN representation
        /// </summary>
        /// <param name="move"> PGN square representation.</param>
        /// <returns>
        /// square id (0-63)
        /// PGN representation
        /// </returns>
        public static int GetSquareIDFromPGN(string move) {
            int     retVal;
            Char    chr1;
            Char    chr2;
            
            if (move.Length != 2) {
                retVal = -1;
            } else {
                chr1 = move.ToLower()[0];
                chr2 = move[1];
                if (chr1 < 'a' || chr1 > 'h' || chr2 < '1' || chr2 > '8') {
                    retVal = -1;
                } else {
                    retVal = 7 - (chr1 - 'a') + ((chr2 - '0') << 3);
                }
            }            
            return(retVal);
        }

        /// <summary>
        /// Gets the PGN representation of a square
        /// </summary>
        /// <param name="pos">  Absolute position of the square.</param>
        /// <returns>
        /// PGN representation
        /// </returns>
        public static string GetPGNSquareID(int pos) => ((Char)('a' + 7 - (pos & 7))).ToString() + ((Char)((pos >> 3) + '1')).ToString();

        /// <summary>
        /// Find all moves which end to the same position which can create ambiguity
        /// </summary>
        /// <param name="chessBoard">   Chessboard before the move has been done.</param>
        /// <param name="move">         Move to convert</param>
        /// <param name="playerColor">  Player making the move</param>
        /// <returns>
        /// PGN move
        /// </returns>
        private static PGNAmbiguity FindMoveAmbiguity(ChessBoard chessBoard, Move move, ChessBoard.PlayerColor playerColor) {
            PGNAmbiguity            retVal = PGNAmbiguity.NotFound;
            ChessBoard.PieceType    pieceType;
            List<Move>              moveList;
            
            moveList  = chessBoard.EnumMoveList(playerColor);
            pieceType = chessBoard[move.StartPos];
            foreach (Move moveTest in moveList.Where(x => x.EndPos == move.EndPos)) {
                if (moveTest.StartPos == move.StartPos) {
                    if (moveTest.Type == move.Type) {
                        retVal |= PGNAmbiguity.Found;
                    }
                } else {
                    if (chessBoard[moveTest.StartPos] == pieceType) {
                        if ((moveTest.StartPos & 7) != (move.StartPos & 7)) {
                            retVal |= PGNAmbiguity.ColMustBeSpecify;
                        } else {
                            retVal |= PGNAmbiguity.RowMustBeSpecify;
                        }
                    }
                }
            }
            return(retVal);
        }

        /// <summary>
        /// Gets a PGN move from a MovePosS structure and a chessboard.
        /// </summary>
        /// <param name="chessBoard">       Chessboard before the move has been done.</param>
        /// <param name="move">             Move to convert</param>
        /// <param name="includeEnding">    true to include ending</param>
        /// <returns>
        /// PGN move
        /// </returns>
        public static string GetPGNMoveFromMove(ChessBoard chessBoard, MoveExt move, bool includeEnding) {
            string                  retVal;
            string                  startPos;
            ChessBoard.PieceType    pieceType;
            PGNAmbiguity            ambiguity;
            ChessBoard.PlayerColor  playerColor;
            
            if (move.Move.Type == Move.MoveType.Castle) {
                retVal = (move.Move.EndPos == 1 || move.Move.EndPos == 57) ? "O-O" : "O-O-O";
            } else {
                pieceType   = chessBoard[move.Move.StartPos] & ChessBoard.PieceType.PieceMask;
                playerColor = chessBoard.CurrentPlayer;
                ambiguity   = FindMoveAmbiguity(chessBoard, move.Move, playerColor);
                retVal      = pieceType switch {
                    ChessBoard.PieceType.King   => "K",
                    ChessBoard.PieceType.Queen  => "Q",
                    ChessBoard.PieceType.Rook   => "R",
                    ChessBoard.PieceType.Bishop => "B",
                    ChessBoard.PieceType.Knight => "N",
                    ChessBoard.PieceType.Pawn   => "",
                    _                           => "",
                };
                startPos = GetPGNSquareID(move.Move.StartPos);
                if ((ambiguity & PGNAmbiguity.ColMustBeSpecify) == PGNAmbiguity.ColMustBeSpecify) {
                    retVal += startPos[0];
                }
                if ((ambiguity & PGNAmbiguity.RowMustBeSpecify) == PGNAmbiguity.RowMustBeSpecify) {
                    retVal += startPos[1];
                }
                if ((move.Move.Type & Move.MoveType.PieceEaten) == Move.MoveType.PieceEaten) {
                    if (pieceType == ChessBoard.PieceType.Pawn                          && 
                        (ambiguity & PGNAmbiguity.ColMustBeSpecify) == (PGNAmbiguity)0  &&
                        (ambiguity & PGNAmbiguity.RowMustBeSpecify) == (PGNAmbiguity)0) {
                        retVal += startPos[0];
                    }
                    retVal += 'x';
                }
                retVal += GetPGNSquareID(move.Move.EndPos);
                switch(move.Move.Type & Move.MoveType.MoveTypeMask) {
                case Move.MoveType.PawnPromotionToQueen:
                    retVal += "=Q";
                    break;
                case Move.MoveType.PawnPromotionToRook:
                    retVal += "=R";
                    break;
                case Move.MoveType.PawnPromotionToBishop:
                    retVal += "=B";
                    break;
                case Move.MoveType.PawnPromotionToKnight:
                    retVal += "=N";
                    break;
                case Move.MoveType.PawnPromotionToPawn:
                    retVal += "=P";
                    break;
                default:
                    break;
                }
            }
            chessBoard.DoMoveNoLog(move.Move);
            switch(chessBoard.GetCurrentResult()) {
            case ChessBoard.GameResult.OnGoing:
                break;
            case ChessBoard.GameResult.Check:
                retVal += "+";
                break;
            case ChessBoard.GameResult.Mate:
                retVal += "#";
                if (includeEnding) {
                    if (chessBoard.CurrentPlayer == ChessBoard.PlayerColor.Black) {
                        retVal += " 1-0";
                    } else {
                        retVal += " 0-1";
                    }
                }
                break;
            case ChessBoard.GameResult.ThreeFoldRepeat:
            case ChessBoard.GameResult.FiftyRuleRepeat:
            case ChessBoard.GameResult.TieNoMove:
            case ChessBoard.GameResult.TieNoMatePossible:
                if (includeEnding) {
                    retVal += " 1/2-1/2";
                }
                break;
            default:
                break;
            }
            chessBoard.UndoMoveNoLog(move.Move);
            return(retVal);
        }

        /// <summary>
        /// Generates FEN
        /// </summary>
        /// <param name="chessBoard">       Actual chess board (after the move)</param>
        /// <returns>
        /// PGN representation of the game
        /// </returns>
        public static string GetFENFromBoard(ChessBoard chessBoard) {
            StringBuilder               strBuilder;
            int                         emptyCount;
            ChessBoard.PieceType        pieceType;
            Char                        pieceChr;
            ChessBoard.PlayerColor      nextMoveColor;
            ChessBoard.BoardStateMask   boardStateMask;
            int                         enPassantPos;
            int                         halfMoveClock;
            int                         halfMoveCount;
            int                         fullMoveCount;
            bool                        isCastling;
            
            strBuilder     = new StringBuilder(512);
            nextMoveColor  = chessBoard.CurrentPlayer;
            boardStateMask = chessBoard.ComputeBoardExtraInfo(nextMoveColor, false);
            enPassantPos   = (int)(boardStateMask & ChessBoard.BoardStateMask.EnPassant);
            for (int row = 7; row >= 0; row--) {
                emptyCount = 0;
                for (int col = 7; col >= 0; col--) {
                    pieceType = chessBoard[(row << 3) + col];
                    if (pieceType == ChessBoard.PieceType.None) {
                        emptyCount++;
                    } else {
                        if (emptyCount != 0) {
                            strBuilder.Append(emptyCount.ToString());
                            emptyCount = 0;
                        }
                        pieceChr = (pieceType & ChessBoard.PieceType.PieceMask) switch {
                            ChessBoard.PieceType.King   => 'K',
                            ChessBoard.PieceType.Queen  => 'Q',
                            ChessBoard.PieceType.Rook   => 'R',
                            ChessBoard.PieceType.Bishop => 'B',
                            ChessBoard.PieceType.Knight => 'N',
                            ChessBoard.PieceType.Pawn   => 'P',
                            _                           => '?',
                        };
                        if ((pieceType & ChessBoard.PieceType.Black) == ChessBoard.PieceType.Black) {
                            pieceChr = Char.ToLower(pieceChr);
                        }
                        strBuilder.Append(pieceChr);
                    }
                }
                if (emptyCount != 0) {
                    strBuilder.Append(emptyCount.ToString());
                }
                if (row != 0) {
                    strBuilder.Append('/');
                }
            }
            strBuilder.Append(' ');
            strBuilder.Append((nextMoveColor == ChessBoard.PlayerColor.White) ? 'w' : 'b');
            strBuilder.Append(' ');
            isCastling = false;
            if ((boardStateMask & ChessBoard.BoardStateMask.WRCastling) == ChessBoard.BoardStateMask.WRCastling) {
                strBuilder.Append('K');
                isCastling = true;
            }
            if ((boardStateMask & ChessBoard.BoardStateMask.WLCastling) == ChessBoard.BoardStateMask.WLCastling) {
                strBuilder.Append('Q');
                isCastling = true;
            }
            if ((boardStateMask & ChessBoard.BoardStateMask.BRCastling) == ChessBoard.BoardStateMask.BRCastling) {
                strBuilder.Append('k');
                isCastling = true;
            }
            if ((boardStateMask & ChessBoard.BoardStateMask.BLCastling) == ChessBoard.BoardStateMask.BLCastling) {
                strBuilder.Append('q');
                isCastling = true;
            }
            if (!isCastling) {
                strBuilder.Append('-');
            }
            strBuilder.Append(' ');
            if (enPassantPos == 0) {
                strBuilder.Append('-');
            } else {
                strBuilder.Append(GetPGNSquareID(enPassantPos));
            }
            halfMoveClock  = chessBoard.MoveHistory.GetCurrentHalfMoveCount;
            halfMoveCount  = chessBoard.MovePosStack.PositionInList + 1;
            fullMoveCount  = (halfMoveCount + 2) / 2;
            strBuilder.Append($" {halfMoveClock.ToString(CultureInfo.InvariantCulture)} {fullMoveCount.ToString(CultureInfo.InvariantCulture)}");
            return(strBuilder.ToString());
        }

        /// <summary>
        /// Generates the PGN representation of the board
        /// </summary>
        /// <param name="chessBoard">       Actual chess board (after the move)</param>
        /// <param name="includeRedoMove">  true to include redo move</param>
        /// <param name="eventName">        Event tag</param>
        /// <param name="site">             Site tag</param>
        /// <param name="date">             Date tag</param>
        /// <param name="round">            Round tag</param>
        /// <param name="whitePlayerName">  White player's name</param>
        /// <param name="blackPlayerName">  Black player's name</param>
        /// <param name="whitePlayerType">  White player's type</param>
        /// <param name="blackPlayerType">  Black player's type</param>
        /// <param name="whitePlayerTime">  Timer for the white</param>
        /// <param name="blackPlayerTime">  Timer for the black</param>
        /// <returns>
        /// PGN representation of the game
        /// </returns>
        public static string GetPGNFromBoard(ChessBoard     chessBoard,
                                             bool           includeRedoMove,
                                             string         eventName,
                                             string         site,
                                             string         date,
                                             string         round,
                                             string         whitePlayerName,
                                             string         blackPlayerName,
                                             PgnPlayerType  whitePlayerType,
                                             PgnPlayerType  blackPlayerType,
                                             TimeSpan       whitePlayerTime,
                                             TimeSpan       blackPlayerTime) {
            int             moveIndex;
            StringBuilder   strBuilder;
            StringBuilder   lineStrBuilder;
            int             oriIndex;
            int             moveCount;
            MovePosStack    movePosStack;
            MoveExt         move;
            string          result;
            
            movePosStack    = chessBoard.MovePosStack;
            oriIndex        = movePosStack.PositionInList;
            moveCount       = (includeRedoMove) ? movePosStack.Count : oriIndex + 1;
            strBuilder      = new StringBuilder(10 * moveCount + 256);
            lineStrBuilder  = new StringBuilder(256);
            switch(chessBoard.GetCurrentResult()) {
            case ChessBoard.GameResult.Check:
            case ChessBoard.GameResult.OnGoing:
                result = "*";
                break;
            case ChessBoard.GameResult.Mate:
                result = (chessBoard.CurrentPlayer == ChessBoard.PlayerColor.White) ? "0-1" : "1-0";
                break;
            case ChessBoard.GameResult.FiftyRuleRepeat:
            case ChessBoard.GameResult.ThreeFoldRepeat:
            case ChessBoard.GameResult.TieNoMove:
            case ChessBoard.GameResult.TieNoMatePossible:
                result = "1/2-1/2";
                break;
            default:
                result = "*";
                break;
            }
            chessBoard.UndoAllMoves();
            strBuilder.Append($"[Event \"{eventName}\"]\n");
            strBuilder.Append($"[Site \"{site}\"]\n");
            strBuilder.Append($"[Date \"{date}\"]\n");
            strBuilder.Append($"[Round \"{round}\"]\n");
            strBuilder.Append($"[White \"{whitePlayerName}\"]\n");
            strBuilder.Append($"[Black \"{blackPlayerName}\"]\n");
            strBuilder.Append($"[Result \"{result}\"]\n");
            if (!chessBoard.IsStdInitialBoard) {
                strBuilder.Append("[SetUp \"1\"]\n");
                strBuilder.Append($"[FEN \"{GetFENFromBoard(chessBoard)}\"]\n");
            }
            strBuilder.Append($"[WhiteType \"{((whitePlayerType == PgnPlayerType.Human) ? "human" : "program")}\"]\n");
            strBuilder.Append($"[BlackType \"{((blackPlayerType == PgnPlayerType.Human) ? "human" : "program")}\"]\n");
            strBuilder.Append($"[TimeControl \"?:{whitePlayerTime.Ticks.ToString(CultureInfo.InvariantCulture)}:{blackPlayerTime.Ticks.ToString(CultureInfo.InvariantCulture)}\"]\n");
            strBuilder.Append('\n');
            lineStrBuilder.Length = 0;
            for (moveIndex = 0; moveIndex < moveCount; moveIndex++) {
                if (lineStrBuilder.Length > 60) {
                    strBuilder.Append(lineStrBuilder);
                    strBuilder.Append("\n");
                    lineStrBuilder.Length = 0;
                }
                move = movePosStack[moveIndex];
                if ((moveIndex & 1) == 0) {
                    lineStrBuilder.Append(((moveIndex + 1) / 2 + 1).ToString(CultureInfo.InvariantCulture));
                    lineStrBuilder.Append(". ");
                }
                lineStrBuilder.Append(GetPGNMoveFromMove(chessBoard, move, true) + " ");
                chessBoard.RedoMove();
            }
            lineStrBuilder.Append(' ');
            lineStrBuilder.Append(result);
            strBuilder.Append(lineStrBuilder);
            strBuilder.Append('\n');
            return(strBuilder.ToString());
        }

        /// <summary>
        /// Generates the PGN representation of a series of moves
        /// </summary>
        /// <param name="chessBoard">   Actual chess board.</param>
        /// <returns>
        /// PGN representation of the game
        /// </returns>
        public static string[] GetPGNArrayFromMoveList(ChessBoard chessBoard) {
            string[]        retVal;
            int             oriPos;
            int             moveIndex;
            MovePosStack    moveStack;
            
            oriPos      = chessBoard.MovePosStack.PositionInList;
            chessBoard.UndoAllMoves();
            moveStack   = chessBoard.MovePosStack;
            retVal      = new string[moveStack.Count];
            moveIndex   = 0;
            foreach (MoveExt move in moveStack.List) {
                retVal[moveIndex++] = GetPGNMoveFromMove(chessBoard, move, includeEnding: false);
                chessBoard.RedoMove();
            }
            chessBoard.SetUndoRedoPosition(oriPos);
            return(retVal);
        }
    } // Class PgnUtil
} // Namespace
