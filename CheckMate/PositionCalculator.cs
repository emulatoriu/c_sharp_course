using System;
using System.Drawing;
using System.Collections;

namespace CheckMate.Engine
{


	internal class PositionCalculator 
	{
		protected ArrayList ValidBlocks ;
		protected Board cb;
		protected Block OrigBlock;

		public PositionCalculator(Board chessboard)
		{
			cb = chessboard;
			ValidBlocks = new ArrayList();
		}

		protected void ClearBlockList()
		{
			ValidBlocks.Clear();
		}

		protected bool ProcessBlock(int x, int y)
		{
			Block b = cb.GetBlockByChessPosition(new Point(x, y));
			if (b != null) 
			{
				if (b.GetPiece() == null)	
				{
					ValidBlocks.Add(b);
					return true;
				}
				else if (b.GetPiece().GetPieceColor() == OrigBlock.GetPiece().GetPieceColor()) 
				{
					return false;
				}
				else
				{
					ValidBlocks.Add(b);
					return false;
				}
			}
			return false;

		}

		protected bool ProcessBlockInclusive(int x, int y)
		{
			Block b = cb.GetBlockByChessPosition(new Point(x, y));
			if (b != null) 
			{
				if (b.GetPiece() == null)	
				{
					ValidBlocks.Add(b);
					return true;
				}
				else 
				{
					ValidBlocks.Add(b);
					return false;
				}
			}
			return false;
		}
		
		internal virtual ArrayList CalculatePositions(Block block, bool SupportPosition)
		{

			// Clear Valid Block List
			ClearBlockList();
			// Keep original block
			OrigBlock = block;

			return null;
		}

	}
}
