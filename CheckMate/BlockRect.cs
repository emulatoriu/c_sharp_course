/// <summary>
/// Summary description for BlockRect.
/// </summary>
/// 


using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CheckMate.Graphix
{

	internal class BlockRect
	{
		protected Color bColor;
		protected Brush brush;

		~BlockRect()
		{
			if (brush != null)
			  brush.Dispose();
		}

		internal virtual void Draw(Graphics g, int x, int y, string title, bool bHighLight, bool bLastMove)	
		{
			//g.FillRectangle(new SolidBrush(bColor) , x, y, ChessConstants.BLOCKSIZE, ChessConstants.BLOCKSIZE );
			
			g.FillRectangle(brush , x, y, ChessConstants.BLOCKSIZE, ChessConstants.BLOCKSIZE );

			// HighLight
			Pen pen;
			Pen LastMovePen;

			if (bLastMove)
				LastMovePen = new Pen(ChessConstants.LastMoveColor, ChessConstants.HIGHLIGHTPENSIZE);
			else
				LastMovePen = new Pen(Color.Transparent, ChessConstants.HIGHLIGHTPENSIZE);
		

			if (bHighLight) 
				pen = new Pen(ChessConstants.HIGHLIGHTPENCOLOR, ChessConstants.HIGHLIGHTPENSIZE);
			else
				pen = new Pen(Color.Transparent, ChessConstants.HIGHLIGHTPENSIZE);

			try
			{

				// Draw Last Move
				g.DrawRectangle(LastMovePen, 
					x + 10 + (ChessConstants.HIGHLIGHTPENSIZE / 2), 
					y + 10 + ChessConstants.HIGHLIGHTPENSIZE / 2, 
					ChessConstants.BLOCKSIZE - ChessConstants.HIGHLIGHTPENSIZE - 20, 
					ChessConstants.BLOCKSIZE - ChessConstants.HIGHLIGHTPENSIZE - 20 );

				// Draw highlight border
				g.DrawRectangle(pen, 
					x + 20 + (ChessConstants.HIGHLIGHTPENSIZE / 2), 
					y + 20 + ChessConstants.HIGHLIGHTPENSIZE / 2, 
					ChessConstants.BLOCKSIZE - ChessConstants.HIGHLIGHTPENSIZE - 40, 
					ChessConstants.BLOCKSIZE - ChessConstants.HIGHLIGHTPENSIZE - 40 );

			}
			finally
			{
				pen.Dispose();
				LastMovePen.Dispose();
			}
/*
			// todo : Temporary Position Drawing
			Font drawFont = new Font("Arial", 7);
			SolidBrush drawBrush = new SolidBrush(Color.Yellow);
			RectangleF drawRect = new RectangleF( x + 10, y + 10, x+30, y+30);
			RectangleF drawRecttext = new RectangleF( x + 20, y + 60, x+30, y+30);
			string[] str = title.Split('/');
			try
			{
				g.DrawString(str[0], drawFont, drawBrush, drawRect);
				if (str.GetLength(0) > 1)
					g.DrawString(str[1], drawFont, drawBrush, drawRecttext);

			}
			finally
			{
				drawFont.Dispose();
				drawBrush.Dispose();
			}
*/
		}
	}


	internal class BlackRect : BlockRect
	{
		internal BlackRect()	
		{
			bColor = ChessConstants.BLACKBLOCKCOLOR;
			brush = ChessConstants.GetBlackBlockBrush();
		}
	}

	internal class WhiteRect : BlockRect
	{
		internal WhiteRect()	
		{
			bColor = ChessConstants.WHITEBLOCKCOLOR;
			brush = ChessConstants.GetWhiteBlockBrush();
		}
	}

}
