/// <summary>
/// Summary description for Piece.
/// </summary>

using System;
using System.Drawing;
using CheckMate.Graphix;

namespace CheckMate.Engine
{
	internal class Piece 
	{

		private PieceColor pColor;
		private Block block;
		private PieceType pType;
		private bool bCanCastle;
		private Point imagePos;
		private bool bEnable;

		internal Piece(PieceType type, PieceColor color, Block b)	
		{
			block = b;
			pType = type;
			pColor = color;
			bCanCastle  = ((type == PieceType.KING) || ((type == PieceType.ROOK)));
			bEnable = false;
		}

		~Piece()
		{
		}

		internal bool GetIsEnabled()
		{
			return bEnable;
		}
		internal void SetIsEnabled(bool aEnable) 
		{
			bEnable = aEnable;
		}

		internal bool GetCanCastle()
		{
			return bCanCastle;
		}
		internal void SetCanCastle(bool aCanCastle) 
		{
			bCanCastle = aCanCastle;
		}

		internal PieceType GetPieceType()
		{
			return pType;		
		}
		internal void SetPieceType(PieceType aType)
		{
			pType = aType;
		}
		

		internal PieceColor GetPieceColor()
		{
			return pColor;
		}
		internal void SetPieceColor(PieceColor aColor)
		{
			pColor = aColor;
		}


		internal Block GetContainerBlock()
		{
			return block;
		}
		internal void SetContainerBlock(Block aBlock)
		{
			block = aBlock;
		}


		internal Point GetStartPosition()
		{
			return imagePos;
		}
		internal void SetStartPosition(Point aPosition)
		{
			imagePos.X = aPosition.X;
			imagePos.Y = aPosition.Y;
		}


		internal bool Contains(int x, int y)	
		{
			return ((x > imagePos.X) && (x < imagePos.X + ChessConstants.PIECESIZE) &&
					(y > imagePos.Y) && (y < imagePos.Y + ChessConstants.PIECESIZE));
		}

		internal void Draw(PieceFactory pFactory, Graphics g) 
		{
			PieceRect pRect = pFactory.GetPieceRect(pType, pColor);
			imagePos.X = this.GetStartPosition().X ;
			imagePos.Y = this.GetStartPosition().Y ;
			pRect.Draw(g, imagePos);
		}
	}
}
