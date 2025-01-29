using System;
using System.Collections;
using System.Drawing;

namespace CheckMate.Engine
{
	internal class KingPositionCalculator: PositionCalculator
	{
		public KingPositionCalculator(Board board) : base(board)
		{
		}


		internal override ArrayList CalculatePositions(Block block, bool SupportPosition)
		{
			base.CalculatePositions(block, SupportPosition);
			
			GoUp( new Point(block.GetChessPosition().X, block.GetChessPosition().Y) ,		SupportPosition);
			GoDown( new Point(block.GetChessPosition().X, block.GetChessPosition().Y),		SupportPosition );
			GoRight( new Point(block.GetChessPosition().X, block.GetChessPosition().Y),		SupportPosition );
			GoLeft( new Point(block.GetChessPosition().X, block.GetChessPosition().Y),		SupportPosition );
			GoLeftUp( new Point(block.GetChessPosition().X, block.GetChessPosition().Y),	SupportPosition );
			GoLeftDown( new Point(block.GetChessPosition().X, block.GetChessPosition().Y),	SupportPosition );
			GoRightUp( new Point(block.GetChessPosition().X, block.GetChessPosition().Y),	SupportPosition );
			GoRightDown( new Point(block.GetChessPosition().X, block.GetChessPosition().Y), SupportPosition );
			CastlePositions();
			
			return ValidBlocks;
		}

		private void CastlePositions()
		{
			if (OrigBlock == null)
				return;

			Piece piece = OrigBlock.GetPiece();

			if (piece == null)
				return;

			// It must be KING
			if ( piece.GetPieceType() != PieceType.KING)
				return;

			// Must be able to castle
			if (! piece.GetCanCastle())
				return;

			Point point = OrigBlock.GetChessPosition();

			bool GotPiece = false;

			if (CanCastle(new Point(0, point.Y)))
			{
				for (int i=point.X - 1; i>0; i--)
				{
					Block b = cb.GetBlockByChessPosition(new Point(i, point.Y));

					if (b.GetPiece() != null)
						GotPiece = true;
				}

				if (! GotPiece)
					ValidBlocks.Add(cb.GetBlockByChessPosition(new Point(point.X - 2, point.Y)));
			}
			

			GotPiece = false;

			if (CanCastle(new Point(7, point.Y)))
			{

				for (int i=point.X + 1; i<7; i++)
				{
					Block b = cb.GetBlockByChessPosition(new Point(i, point.Y));

					if (b.GetPiece() != null)
						GotPiece = true;
				}

				if (! GotPiece)
					ValidBlocks.Add(cb.GetBlockByChessPosition(new Point(point.X + 2, point.Y)));
			}

		}

		private bool CanCastle(Point p)
		{
			Block block = cb.GetBlockByChessPosition(p);

			if (block == null) 
				return false;

			Piece piece = block.GetPiece();

			if (piece == null)
				return false;

			if (piece.GetPieceType() != PieceType.ROOK)
				return false;

			if (! piece.GetCanCastle())
				return false;

			return true;
		}

		private void GoRight(Point cp, bool SupportPosition)
		{
			 if (HelperFunction.IncX(ref cp))		
				 if (SupportPosition)
					 ProcessBlockInclusive(cp.X, cp.Y);
				else
					ProcessBlock(cp.X, cp.Y);
		}

		private void GoLeft(Point cp, bool SupportPosition)
		{
			if (HelperFunction.DecX(ref cp))		
				if (SupportPosition)
					ProcessBlockInclusive(cp.X, cp.Y);
				else
					ProcessBlock(cp.X, cp.Y);
		}

		private void GoUp(Point cp, bool SupportPosition)
		{
			if (HelperFunction.DecY(ref cp))		
				if (SupportPosition)
					ProcessBlockInclusive(cp.X, cp.Y);
				else
					ProcessBlock(cp.X, cp.Y);
		}

		private void GoDown(Point cp, bool SupportPosition)
		{
			if (HelperFunction.IncY(ref cp))		
				if (SupportPosition)
					ProcessBlockInclusive(cp.X, cp.Y);
				else
					ProcessBlock(cp.X, cp.Y);
		}

		private void GoLeftUp(Point cp, bool SupportPosition)
		{
			if (HelperFunction.DecXDecY(ref cp))		
				if (SupportPosition)
					ProcessBlockInclusive(cp.X, cp.Y);
				else
					ProcessBlock(cp.X, cp.Y);
		}

		private void GoLeftDown(Point cp, bool SupportPosition)
		{
			if (HelperFunction.DecXIncY(ref cp))		
				if (SupportPosition)
					ProcessBlockInclusive(cp.X, cp.Y);
				else
					ProcessBlock(cp.X, cp.Y);
		}

		private void GoRightUp(Point cp, bool SupportPosition)
		{
			if (HelperFunction.IncXDecY(ref cp))		
				if (SupportPosition)
					ProcessBlockInclusive(cp.X, cp.Y);
				else
					ProcessBlock(cp.X, cp.Y);
		}

		private void GoRightDown(Point cp, bool SupportPosition)
		{
			if (HelperFunction.IncXIncY(ref cp))		
				if (SupportPosition)
					ProcessBlockInclusive(cp.X, cp.Y);
				else
					ProcessBlock(cp.X, cp.Y);
		}

	}

}
