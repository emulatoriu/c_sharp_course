using System;

namespace SrcChess2 {
    /// <summary>Test board evaluation function</summary>
    public class BoardEvaluationTest : BoardEvaluationBasic {

        /// <summary>
        /// Class constructor
        /// </summary>
        public BoardEvaluationTest() {}

        /// <summary>
        /// Name of the evaluation method
        /// </summary>
        public override string Name => "Test Version";

        /// <summary>
        /// Evaluates a board. The number of point is greater than 0 if white is in advantage, less than 0 if black is.
        /// </summary>
        /// <param name="board">            Board to evaluate</param>
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
        public override int Points(ChessBoard.PieceType[]   board,
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
            return(retVal);
        }
    } // Class BoardEvaluationTest
} // Namespace
