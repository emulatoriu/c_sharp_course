/// <summary>
/// Summary description for Block.
/// </summary>

using System;
using System.Drawing;
using System.Text;
using CheckMate.Graphix;


namespace CheckMate.Engine
{
	internal class Block
	{
		private BlockColor bColor;
		private Piece aPiece ;
		private Point ChessPos;
		private Point StartPos;
		private bool IsHighlight;
		private bool IsLastMove;

		internal Block()
		{
			ChessPos = new Point(0,0);
			StartPos = new Point(0,0);
			aPiece   = null;
			IsLastMove = false;
		}
		
		~Block()
		{
		}


		internal BlockColor GetColor()
		{
			return bColor;
		}
		internal void SetColor(BlockColor color)
		{
			bColor = color;
		}

		internal Point GetStartPosition()
		{
			return StartPos;
		}
		internal void SetStartPosition(Point point)
		{
			StartPos = point;
		}


		// ChessPosition
		internal Point GetChessPosition()
		{
			return ChessPos;
		}
		internal void SetChessPosition(Point point)
		{
			// Generate Exception. Todo : Write to Log
			if ((point.X < 0) || (point.X >7) || (point.Y < 0) || (point.Y >7))
				throw( new Exception(String.Format("Block.SetChessPosition : Invalid ChessPosition ({0},{1})", point.X, point.Y)) );

			ChessPos = point;
		}


		// Piece
		internal Piece GetPiece()
		{
			return aPiece;
		}
		internal void SetPiece(Piece piece)
		{
			aPiece = piece;
		}


		// Draw Single/Multiple Block
		internal void Draw (BlockFactory bFactory, Graphics g, bool bHighLight, bool bIsLastMove)
		{
			
			StringBuilder title = new StringBuilder();
			

			BlockRect bRect = bFactory.GetBlockRect( bColor);

			if (aPiece == null)
				title.Append(ChessPos.ToString()) ;
			else
				title.Append(ChessPos.ToString() + '/' + aPiece.GetPieceType().ToString());

			
			bRect.Draw(g, StartPos.X, StartPos.Y, title.ToString(), IsHighlight, bIsLastMove);

		}


		// contains
		internal bool Contains(int x, int y)	
		{
			return ((x > StartPos.X) && (x < StartPos.X + ChessConstants.BLOCKSIZE) &&
				(y > StartPos.Y) && (y < StartPos.Y + ChessConstants.BLOCKSIZE));
		}

		internal void SetIsHighLight(bool aHighlight)
		{
			IsHighlight = aHighlight;
		}

		internal bool GetHighLight()
		{
			return IsHighlight;
		}

		internal void SetIsLastMove(bool aIsLastMove)
		{
			IsLastMove = aIsLastMove;
		}

		internal bool GetIsLastMove()
		{
			return IsLastMove;
		}
		
	}
}
