using System;
using System.Collections;
using System.Drawing;

namespace CheckMate.Engine
{
	internal class BishopPositionCalculator : PositionCalculator
	{
		public BishopPositionCalculator(Board chessboard) : base(chessboard)
		{
		}


		internal override ArrayList CalculatePositions(Block block, bool SupportPosition)
		{
			base.CalculatePositions(block, SupportPosition);

			GoLeftUp( new Point(block.GetChessPosition().X, block.GetChessPosition().Y),	SupportPosition );
			GoLeftDown( new Point(block.GetChessPosition().X, block.GetChessPosition().Y),	SupportPosition );
			GoRightUp( new Point(block.GetChessPosition().X, block.GetChessPosition().Y),	SupportPosition );
			GoRightDown( new Point(block.GetChessPosition().X, block.GetChessPosition().Y), SupportPosition );

			return ValidBlocks;
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
