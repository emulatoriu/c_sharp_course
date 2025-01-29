/// <summary>
/// Summary description for PositionCalculatorFactory.
/// </summary>

using System;

namespace CheckMate.Engine
{
	internal class PositionCalculatorFactory
	{

		private PawnPositionCalculator		PawnCalculator;
		private RookPositionCalculator		RookCalculator;
		private KnightPositionCalculator	KnightCalculator;
		private BishopPositionCalculator	BishopCalculator;
		private QueenPositionCalculator		QueenCalculator;
		private KingPositionCalculator		KingCalculator;

		private Board board;
		
		public PositionCalculatorFactory(Board aBoard)
		{
			board = aBoard;
		}

		internal PositionCalculator GetPositionCalculator(PieceType pType, Player aPlayer)
		{
			switch(pType)       
			{         
				case PieceType.PAWN:   
				{
					if (PawnCalculator == null)
						PawnCalculator = new PawnPositionCalculator(board);

					PawnCalculator.SetCurrentPlayer(aPlayer);

					return PawnCalculator;
				}
				case PieceType.ROOK:            
				{
					if (RookCalculator == null)
						RookCalculator = new RookPositionCalculator(board);

					return RookCalculator;
				}
				case PieceType.KNIGHT:            
				{
					if (KnightCalculator == null)
						KnightCalculator = new KnightPositionCalculator(board);

					return KnightCalculator;
				}
				case PieceType.BISHOP:            
				{
					if (BishopCalculator == null)
						BishopCalculator = new BishopPositionCalculator(board);

					return BishopCalculator;
				}
				case PieceType.QUEEN:            
				{
					if (QueenCalculator == null)
						QueenCalculator = new QueenPositionCalculator(board);

					return QueenCalculator;
				}
				case PieceType.KING:   
				{
					if (KingCalculator == null)
						KingCalculator = new KingPositionCalculator(board);

					return KingCalculator;
				}
			}
			
			throw( new Exception("PieceFactory.GetPieceRect : Invalid PieceType") );
		}

	}
}
