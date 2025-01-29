namespace SrcChess2 {

    /// <summary>Basic board evaluation function</summary>
    public class BoardEvaluationBasic : IBoardEvaluation {
        /// <summary>Value of each piece/color.</summary>
        static protected int[]      s_piecesPoint;

        /// <summary>
        /// Static constructor
        /// </summary>
        static BoardEvaluationBasic() {
            s_piecesPoint                                                               = new int[16];
            s_piecesPoint[(int)ChessBoard.PieceType.Pawn]                                  = 100;
            s_piecesPoint[(int)ChessBoard.PieceType.Rook]                                  = 500;
            s_piecesPoint[(int)ChessBoard.PieceType.Knight]                                = 300;
            s_piecesPoint[(int)ChessBoard.PieceType.Bishop]                                = 325;
            s_piecesPoint[(int)ChessBoard.PieceType.Queen]                                 = 900;
            s_piecesPoint[(int)ChessBoard.PieceType.King]                                  = 1000000;
            s_piecesPoint[(int)(ChessBoard.PieceType.Pawn   | ChessBoard.PieceType.Black)]    = -100;
            s_piecesPoint[(int)(ChessBoard.PieceType.Rook   | ChessBoard.PieceType.Black)]    = -500;
            s_piecesPoint[(int)(ChessBoard.PieceType.Knight | ChessBoard.PieceType.Black)]    = -300;
            s_piecesPoint[(int)(ChessBoard.PieceType.Bishop | ChessBoard.PieceType.Black)]    = -325;
            s_piecesPoint[(int)(ChessBoard.PieceType.Queen  | ChessBoard.PieceType.Black)]    = -900;
            s_piecesPoint[(int)(ChessBoard.PieceType.King   | ChessBoard.PieceType.Black)]    = -1000000;
        }

        /// <summary>
        /// Name of the evaluation method
        /// </summary>
        public virtual string Name => "Basic";

        /// <summary>
        /// Evaluates a board. The number of point is greater than 0 if white is in advantage, less than 0 if black is.
        /// </summary>
        /// <param name="board">            Board</param>
        /// <param name="countPerPiece">    Number of each pieces</param>
        /// <param name="posInfo">          Information about pieces position</param>
        /// <param name="whiteKingPos">     Position of the white king</param>
        /// <param name="blackKingPos">     Position of the black king</param>
        /// <param name="whiteCastle">      White has castled</param>
        /// <param name="blackCastle">      Black has castled</param>
        /// <param name="moveCountDelta">   Number of possible white move - Number of possible black move</param>
        /// <returns>
        /// Points
        /// </returns>
        public virtual int Points(ChessBoard.PieceType[]   board,
                                  int[]                 countPerPiece,
                                  ChessBoard.PosInfo    posInfo,
                                  int                   whiteKingPos,
                                  int                   blackKingPos,
                                  bool                  whiteCastle,
                                  bool                  blackCastle,
                                  int                   moveCountDelta) {
            int retVal = 0;
            
            for (int i = 0; i < countPerPiece.Length; i++) {
                retVal += s_piecesPoint[i] * countPerPiece[i];
            }
            if (board[12] == ChessBoard.PieceType.Pawn) {
                retVal -= 4;
            }
            if (board[52] == (ChessBoard.PieceType.Pawn | ChessBoard.PieceType.Black)) {
                retVal += 4;
            }
            if (whiteCastle) {
                retVal += 10;
            }
            if (blackCastle) {
                retVal -= 10;
            }
            retVal += moveCountDelta;
            retVal += posInfo.PiecesAttacked << 1;
            return(retVal);
        }
    } // Class BoardEvaluationBasic
} // Namespace
