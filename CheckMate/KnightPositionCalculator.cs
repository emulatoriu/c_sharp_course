using System;
using System.Collections;
using System.Drawing;

namespace CheckMate.Engine
{
	internal class KnightPositionCalculator : PositionCalculator
	{
		public KnightPositionCalculator(Board chessboard): base(chessboard)
		{
		}


		internal override ArrayList CalculatePositions(Block block, bool SupportPosition)
		{
			base.CalculatePositions(block, SupportPosition);
			
			UpLeft( new Point(block.GetChessPosition().X, block.GetChessPosition().Y) ,		SupportPosition);
			UpRight( new Point(block.GetChessPosition().X, block.GetChessPosition().Y),		SupportPosition);
			DownLeft( new Point(block.GetChessPosition().X, block.GetChessPosition().Y),	SupportPosition);
			DownRight( new Point(block.GetChessPosition().X, block.GetChessPosition().Y),	SupportPosition);
			LeftUp( new Point(block.GetChessPosition().X, block.GetChessPosition().Y),		SupportPosition);
			LeftDown( new Point(block.GetChessPosition().X, block.GetChessPosition().Y),	SupportPosition);
			RightUp( new Point(block.GetChessPosition().X, block.GetChessPosition().Y),		SupportPosition);
			RightDown( new Point(block.GetChessPosition().X, block.GetChessPosition().Y),	SupportPosition);

			return ValidBlocks;
		}

		
		protected new  bool ProcessBlock(int x, int y)
		{
			Block b = cb.GetBlockByChessPosition(new Point(x, y));
			if (b != null) 
			{
				Piece piece =  b.GetPiece();
				if (piece != null) 
				{
					if (piece.GetPieceColor() == OrigBlock.GetPiece().GetPieceColor()) 
					{
						return false;
					}
				}

				ValidBlocks.Add(b);
				return false;
			}
			return false;
		}


		protected new  bool ProcessBlockInclusive(int x, int y)
		{
			Block b = cb.GetBlockByChessPosition(new Point(x, y));
			if (b != null) 
			{
				ValidBlocks.Add(b);
				return false;
			}
			return false;
		}

		// Up
		private void UpLeft(Point cp, bool SupportPosition)	
		{
			if (HelperFunction.KnightUpLeft(ref cp))		
				if (SupportPosition)
					this.ProcessBlockInclusive(cp.X, cp.Y);
				else
					this.ProcessBlock(cp.X, cp.Y);
		}

		private void UpRight(Point cp, bool SupportPosition)	
		{
			if (HelperFunction.KnightUpRight(ref cp))		
				if (SupportPosition)
					this.ProcessBlockInclusive(cp.X, cp.Y);
				else
					this.ProcessBlock(cp.X, cp.Y);
		}

		// Down
		private void DownRight(Point cp, bool SupportPosition)	
		{
			if (HelperFunction.KnightDownRight(ref cp))		
				if (SupportPosition)
					this.ProcessBlockInclusive(cp.X, cp.Y);
				else
					this.ProcessBlock(cp.X, cp.Y);
		}
		
		private void DownLeft(Point cp, bool SupportPosition)	
		{
			if (HelperFunction.KnightDownLeft(ref cp))		
				if (SupportPosition)
					this.ProcessBlockInclusive(cp.X, cp.Y);
				else
					this.ProcessBlock(cp.X, cp.Y);
		}

		// Left
		private void LeftDown(Point cp, bool SupportPosition)	
		{
			if (HelperFunction.KnightLeftDown(ref cp))		
				if (SupportPosition)
					this.ProcessBlockInclusive(cp.X, cp.Y);
				else
					this.ProcessBlock(cp.X, cp.Y);
		}

		private void LeftUp(Point cp, bool SupportPosition)	
		{
			if (HelperFunction.KnightLeftUp(ref cp))		
				if (SupportPosition)
					this.ProcessBlockInclusive(cp.X, cp.Y);
				else
					this.ProcessBlock(cp.X, cp.Y);
		}

		// Right
		private void RightDown(Point cp, bool SupportPosition)	
		{
			if (HelperFunction.KnightRightDown(ref cp))		
				if (SupportPosition)
					this.ProcessBlockInclusive(cp.X, cp.Y);
				else
					this.ProcessBlock(cp.X, cp.Y);
		}

		private void RightUp(Point cp, bool SupportPosition)	
		{
			if (HelperFunction.KnightRightUp(ref cp))		
				if (SupportPosition)
					this.ProcessBlockInclusive(cp.X, cp.Y);
				else
					this.ProcessBlock(cp.X, cp.Y);
		}

	}
}
