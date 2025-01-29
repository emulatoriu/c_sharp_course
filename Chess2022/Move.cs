using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SrcChess2 {
    /// <summary>
    /// Defines a chess move
    /// </summary>
    public struct Move {
        /// <summary>Type of possible move</summary>
        public enum MoveType : byte {
            /// <summary>Normal move</summary>
            Normal                  = 0,
            /// <summary>Pawn which is promoted to a queen</summary>
            PawnPromotionToQueen    = 1,
            /// <summary>Castling</summary>
            Castle                  = 2,
            /// <summary>Prise en passant</summary>
            EnPassant               = 3,
            /// <summary>Pawn which is promoted to a rook</summary>
            PawnPromotionToRook     = 4,
            /// <summary>Pawn which is promoted to a bishop</summary>
            PawnPromotionToBishop   = 5,
            /// <summary>Pawn which is promoted to a knight</summary>
            PawnPromotionToKnight   = 6,
            /// <summary>Pawn which is promoted to a pawn</summary>
            PawnPromotionToPawn     = 7,
            /// <summary>Piece type mask</summary>
            MoveTypeMask            = 15,
            /// <summary>The move eat a piece</summary>
            PieceEaten              = 16,
            /// <summary>Move coming from book opening</summary>
            MoveFromBook            = 32
        }

        /// <summary>Original piece if a piece has been eaten</summary>
        public ChessBoard.PieceType OriginalPiece;
        /// <summary>Start position of the move (0-63)</summary>
        public byte                 StartPos;
        /// <summary>End position of the move (0-63)</summary>
        public byte                 EndPos;
        /// <summary>Type of move</summary>
        public MoveType             Type;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="originalPiece">    Piece which has been eaten if any</param>
        /// <param name="startPos">         Starting position</param>
        /// <param name="endPos">           Ending position</param>
        /// <param name="moveType">         Move type</param>
        public Move(ChessBoard.PieceType originalPiece, int startPos, int endPos, MoveType moveType) {
            OriginalPiece   = originalPiece;
            StartPos        = (byte)startPos;
            EndPos          = (byte)endPos;
            Type            = moveType;
        }
    }
}
