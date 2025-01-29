using System;
using System.Collections;
using System.Drawing;

namespace CheckMate.Engine
{

	internal class QueenPositionCalculator : PositionCalculator
	{

		public QueenPositionCalculator(Board chessboard)  : base(chessboard)
		{
		}


		internal override ArrayList CalculatePositions(Block block, bool SupportPosition)
		{
			base.CalculatePositions(block, SupportPosition);

			GoUp( new Point(block.GetChessPosition().X, block.GetChessPosition().Y),	SupportPosition );
			GoDown( new Point(block.GetChessPosition().X, block.GetChessPosition().Y),	SupportPosition );
			GoRight( new Point(block.GetChessPosition().X, block.GetChessPosition().Y), SupportPosition );
			GoLeft( new Point(block.GetChessPosition().X, block.GetChessPosition().Y) , SupportPosition );

			GoLeftUp( new Point(block.GetChessPosition().X, block.GetChessPosition().Y) ,		SupportPosition );
			GoLeftDown( new Point(block.GetChessPosition().X, block.GetChessPosition().Y) ,		SupportPosition );
			GoRightUp( new Point(block.GetChessPosition().X, block.GetChessPosition().Y) ,		SupportPosition );
			GoRightDown( new Point(block.GetChessPosition().X, block.GetChessPosition().Y) ,	SupportPosition );

			return ValidBlocks;
		}

	
		private void GoRight(Point cp, bool SupportPosition)
		{
			while (HelperFunction.IncX(ref cp))		
			{
				if (SupportPosition)
				{
					if (! ProcessBlockInclusive(cp.X, cp.Y))
						break;
				}
				else
				{
					if (! ProcessBlock(cp.X, cp.Y))
						break;
				}
			}
		}

		private void GoLeft(Point cp, bool SupportPosition)
		{
			while (HelperFunction.DecX(ref cp))		
			{
				if (SupportPosition)
				{
					if (! ProcessBlockInclusive(cp.X, cp.Y))
						break;
				}
				else
				{
					if (! ProcessBlock(cp.X, cp.Y))
						break;
				}
			}
		}

		private void GoUp(Point cp, bool SupportPosition)
		{
			while (HelperFunction.DecY(ref cp))		
			{
				if (SupportPosition)
				{
					if (! ProcessBlockInclusive(cp.X, cp.Y))
						break;
				}
				else
				{
					if (! ProcessBlock(cp.X, cp.Y))
						break;
				}
			}
		}

		private void GoDown(Point cp, bool SupportPosition)
		{
			while (HelperFunction.IncY(ref cp))		
			{
				if (SupportPosition)
				{
					if (! ProcessBlockInclusive(cp.X, cp.Y))
						break;
				}
				else
				{
					if (! ProcessBlock(cp.X, cp.Y))
						break;
				}
			}
		}

		private void GoLeftUp(Point cp, bool SupportPosition)
		{
			while (HelperFunction.DecXDecY(ref cp))		
			{
				if (SupportPosition)
				{
					if (! ProcessBlockInclusive(cp.X, cp.Y))
						break;
				}
				else
				{
					if (! ProcessBlock(cp.X, cp.Y))
						break;
				}
			}
		}

		private void GoLeftDown(Point cp, bool SupportPosition)
		{
			while (HelperFunction.DecXIncY(ref cp))		
			{
				if (SupportPosition)
				{
					if (! ProcessBlockInclusive(cp.X, cp.Y))
						break;
				}
				else
				{
					if (! ProcessBlock(cp.X, cp.Y))
						break;
				}
			}
		}

		private void GoRightUp(Point cp, bool SupportPosition)
		{
			while (HelperFunction.IncXDecY(ref cp))		
			{
				if (SupportPosition)
				{
					if (! ProcessBlockInclusive(cp.X, cp.Y))
						break;
				}
				else
				{
					if (! ProcessBlock(cp.X, cp.Y))
						break;
				}
			}
		}

		private void GoRightDown(Point cp, bool SupportPosition)
		{
			while (HelperFunction.IncXIncY(ref cp))		
			{
				if (SupportPosition)
				{
					if (! ProcessBlockInclusive(cp.X, cp.Y))
						break;
				}
				else
				{
					if (! ProcessBlock(cp.X, cp.Y))
						break;
				}
			}
		}


	}
}
