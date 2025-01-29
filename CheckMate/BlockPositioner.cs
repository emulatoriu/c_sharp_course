/// <summary>
/// This is most important class for designing GUI.
/// This will handle all drawing of ChessBoard.
/// Only deals with Blocks.
/// </summary>
/// 

using System;
using System.Drawing;

namespace CheckMate.Engine
{
	internal class BlockPositioner
	{

		// Start Positions
		private int x, y, cnt;
		private bool newline;
		private byte row, col;

	
		public BlockPositioner() 
		{
			Reset();
		}

		internal void Reset()	
		{
			x = Board.BoardLeft;
			y = Board.BoardTop;
			cnt = 0;
			newline = true;
			row = 0;
			col = 0;
		}

		internal int NextX()	
		{
			return x;
		}

		internal int NextY()	
		{
			return y;
		}
		
		internal void Incr()	
		{
			int rem;
			int quotient;
			
			cnt++;

			// This will decide new line or not.
			quotient = Math.DivRem(cnt,  ChessConstants.BLOCKSPERROW, out rem);

			col = (byte) rem;

			if (rem == 0) 
			{
				// New line.. Increment Y and Reset X
				x = Board.BoardLeft;
				y += ChessConstants.BLOCKSIZE;
				newline = true;
				row++;
			}
			else 
			{
				// Same line.. Increment X 
				x += ChessConstants.BLOCKSIZE;
				newline = false;
			}
		}

		internal bool IsNewLine()
		{
			return newline;
		}

		internal Point GetPosition()
		{
			return new Point(col, row);
		}

	}
}
