/// <summary>
/// Summary description for PieceRect.
/// </summary>
/// 

using System;
using System.Drawing;

namespace CheckMate.Graphix
{
	public class PieceRect 
	{
		protected Image image = null;

		~PieceRect()
		{
			if (image != null)
				image.Dispose();
		}


		public  virtual void Draw(Graphics g,  Point pos)
		{

			g.DrawImage(image, 
						pos.X , 
						pos.Y , 
						ChessConstants.PIECESIZE , 
						ChessConstants.PIECESIZE);
		}


		protected Image ReadImage(string aName)
		{
			Image img;

			ResReader rr =  new ResReader();
			try
			{
				img = rr.ReadImage(aName);
			}
			finally
			{
				rr.Close();
			}

			return img;
		}

	}


	internal class PawnRect		: PieceRect
	{

		internal PawnRect(PieceColor pColor ) 
		{
		
			if (pColor == PieceColor.WHITE) 
				image = ReadImage("WHITEPAWN");
			else
				image = ReadImage("BLACKPAWN");
		}
	}

	internal class RookRect		: PieceRect
	{

		internal RookRect(PieceColor pColor)
		{
			if (pColor == PieceColor.WHITE) 
				image = ReadImage("WHITEROOK");
			else
				image = ReadImage("BLACKROOK");
		}
	}

	internal class BishopRect	: PieceRect
	{
		internal BishopRect(PieceColor pColor )
		{
			if (pColor == PieceColor.WHITE) 
				image = ReadImage("WHITEBISHOP");
			else
				image = ReadImage("BLACKBISHOP");
		}
	}

	internal class KnightRect	: PieceRect
	{
		internal KnightRect(PieceColor pColor )
		{
			if (pColor == PieceColor.WHITE) 
				image = ReadImage("WHITEKNIGHT");
			else
				image = ReadImage("BLACKKNIGHT");
		}
	}

	internal class QueenRect	: PieceRect
	{
		internal QueenRect(PieceColor pColor )
		{
			if (pColor == PieceColor.WHITE) 
				image = ReadImage("WHITEKING");
			else
				image = ReadImage("BLACKKING");
		}
	}

	internal class KingRect		: PieceRect
	{
		internal KingRect(PieceColor pColor )
		{
			if (pColor == PieceColor.WHITE) 
				image = ReadImage("WHITEQUEEN");
			else
				image = ReadImage("BLACKQUEEN");

		}
	}

}
