using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;

namespace CheckMate.Engine
{


	internal class BoardDecorator
	{
		Board board;
		Piece MouseDownPiece;
		bool mouse_down;
		PictureBox mainBox;

		public BoardDecorator(Board cb, PictureBox container)	
		{
			board = cb;
			mainBox = container;

			// MouseMove

			mainBox.MouseMove += new MouseEventHandler(mouseMove);
			mainBox.MouseUp   += new MouseEventHandler(mouseUp);
			mainBox.MouseDown += new MouseEventHandler(mouseDown);
			mainBox.Paint     += new PaintEventHandler(paint);
		}
		


		internal void mouseUp(object sender, MouseEventArgs e)
		{
			if ((mouse_down) && (MouseDownPiece != null))
			{

				Block OrigBlock	= MouseDownPiece.GetContainerBlock();
				Block CurrentBlock = board.GetBlock(e.X, e.Y);

				if (! IsOutOfBoard(e.X, e.Y) && (CurrentBlock != null) && (board.IsValidBlock(CurrentBlock)))
				{
					board.MovePiece(MouseDownPiece, CurrentBlock, OrigBlock);

					//if (! board.MovePiece(MouseDownPiece, CurrentBlock, OrigBlock))

					//	MouseDownPiece.SetStartPosition(new Point(	OrigBlock.GetStartPosition().X + ChessConstants.PIECELEFT,
					//		OrigBlock.GetStartPosition().Y + ChessConstants.PIECETOP));
				}
				else
				{
					MouseDownPiece.SetStartPosition(new Point(	OrigBlock.GetStartPosition().X + ChessConstants.PIECELEFT,
						OrigBlock.GetStartPosition().Y + ChessConstants.PIECETOP));
				}

				board.ClearValidPositions();
				board.Refresh();
				mouse_down = false;
				MouseDownPiece = null;
			}
		}

		internal void mouseMove(object sender, MouseEventArgs e)	
		{
			if (mouse_down)
				if (MouseDownPiece != null)
				{
					// Move piece
					MouseDownPiece.SetStartPosition(new Point(e.X - 20, e.Y - 20));

					// Refresh moving area
					board.Invalidate(new Rectangle(e.X - 60, e.Y-60, e.X+60, e.Y+60));

				}
		}

		internal void mouseEnter(object sender, EventArgs e)
		{
		}

		internal void mouseLeave(object sender, EventArgs e)
		{
		}

		internal void paint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			try
			{
				board.Draw(g);
				
				if (MouseDownPiece != null)
					board.DrawPiece(g, MouseDownPiece);

			}
			finally
			{
				// Can not dispose here
				//g.Dispose();
			}
		}

		internal void mouseDown(object sender, MouseEventArgs e)
		{
			mouse_down = true;
			Block CurrentBlock = board.GetBlock(e.X, e.Y);
			if (CurrentBlock != null)
			{
				Piece aPiece = CurrentBlock.GetPiece();

				if (aPiece != null)
				{
					
					if (aPiece.GetIsEnabled())
					{
						board.ShowValidPositions(CurrentBlock);
						if (board.ValidPositionCount() > 0)
							MouseDownPiece = aPiece;
						
					}
				}
			}
		}

		private bool IsOutOfBoard(int x, int y)
		{
			int aWidth = ChessConstants.BLOCKSIZE * ChessConstants.BLOCKSPERROW;

			if	((x < Board.BoardLeft) || (x > Board.BoardLeft + aWidth) ||
				 (y < Board.BoardTop) || (y > Board.BoardTop + aWidth)) 
				return true;

			return false;

		}


	}
}
