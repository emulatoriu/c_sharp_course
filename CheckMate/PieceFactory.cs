/// <summary>
/// Summary description for PieceFactory.
/// </summary>

using System;

namespace CheckMate.Graphix
{
	public class PieceFactory
	{
		PieceRect	bPawnRect, bRookRect, bKnightRect, bBishopRect, bQueenRect, bKingRect, 
					wPawnRect, wRookRect, wKnightRect, wBishopRect, wQueenRect, wKingRect ;

		public PieceFactory()
		{
			wPawnRect = new PawnRect( PieceColor.WHITE);
			bPawnRect = new PawnRect( PieceColor.BLACK);
			// Rook
			wRookRect = new RookRect( PieceColor.WHITE);
			bRookRect = new RookRect( PieceColor.BLACK);
			// Knight
			wKnightRect = new KnightRect( PieceColor.WHITE);
			bKnightRect = new KnightRect( PieceColor.BLACK);
			// Bishop
			wBishopRect = new BishopRect( PieceColor.WHITE);
			bBishopRect = new BishopRect( PieceColor.BLACK);
			// Queen
			wQueenRect = new QueenRect( PieceColor.WHITE);
			bQueenRect = new QueenRect( PieceColor.BLACK);
			// King
			bKingRect = new KingRect( PieceColor.BLACK);
			wKingRect = new KingRect( PieceColor.WHITE);
		}

		~PieceFactory()
		{
			//if (bPawnRect != null)
			//	bPawnRect.Dispose();
		}


		public PieceRect GetPieceRect(PieceType pType, PieceColor pColor)
		{
			switch(pType)       
			{         
				case PieceType.PAWN:   
					 if (pColor == PieceColor.WHITE)
						return wPawnRect;
					else
						return bPawnRect;
					
				case PieceType.ROOK:            
					if (pColor == PieceColor.WHITE)
						return wRookRect;
					else
						return bRookRect;

				case PieceType.KNIGHT:            
					if (pColor == PieceColor.WHITE)
						return wKnightRect;
					else
						return bKnightRect;

				case PieceType.BISHOP:            
					if (pColor == PieceColor.WHITE)
						return wBishopRect;
					else
						return bBishopRect;

				case PieceType.QUEEN:            
					if (pColor == PieceColor.WHITE)
						return wQueenRect;
					else
						return bQueenRect;

				case PieceType.KING:   
					if (pColor == PieceColor.WHITE)
						return wKingRect;
					else
						return bKingRect;
			}

			throw( new Exception("PieceFactory.GetPieceRect : Invalid PieceType") );
		}

	}
}
