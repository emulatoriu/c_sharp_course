/// <summary>
/// Summary description for Constants.
/// </summary>
/// 

using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CheckMate
{
	/// <summary>
	/// Summary description for Constants.
	/// </summary>
	/// 

	public enum PlayerType 	
	{ 
		PLAYER1, 
		PLAYER2 
	};

	public enum BlockColor 	
	{ 
		WHITE, 
		BLACK 
	};

	public enum PieceColor 	
	{ 
		WHITE, 
		BLACK 
	};
		
	public enum PieceType 	
	{ 
		PAWN, 
		ROOK,
		KNIGHT,
		BISHOP,
		QUEEN,
		KING
	};


	public struct ChessPosition 
	{
		public int x, y;

		public ChessPosition (int x, int y) 
		{
			this.x = x;
			this.y = y;
		}

		
		public override string ToString()
		{
			return(String.Format("({0},{1})", x, y));   
		}
	}


	public class ChessConstants	
	{

		// Block
		public static int BLOCKSIZE    = 80;
		public static int BLOCKSPERROW =  8;

		// Block Colors
		
		public static Color BLACKBLOCKCOLOR  = Color.Peru;
		public static Color BLACKBLOCKCOLOR1 = Color.Peru;
		public static Color WHITEBLOCKCOLOR  = Color.Beige;
		public static Color WHITEBLOCKCOLOR1 = Color.Beige;
		public static LinearGradientMode MODE = LinearGradientMode.Vertical;


		// Border Color
		public static Color BORDERCOLOR  = Color.Sienna;


		// Highlight Outline Pen
		public static int HIGHLIGHTPENSIZE = 4;
		public static Color HIGHLIGHTPENCOLOR = Color.Chocolate;
		public static Color LastMoveColor = Color.Gold;




		// Game
		public static bool NOTIMELIMIT = false;
		public static int GAMEMINUTES = 30;


		// Piece 
		public static int PIECESIZE    = 40;
		public static int PIECELEFT    = 20;
		public static int PIECETOP     = 20;

 

		public ChessConstants()
		{
		}

		public static Brush GetWhiteBlockBrush()
		{
			return new LinearGradientBrush(new Rectangle(30, 30, BLOCKSIZE, BLOCKSIZE), WHITEBLOCKCOLOR, WHITEBLOCKCOLOR1, MODE);
		}

		public static Brush GetBlackBlockBrush()
		{
			return new LinearGradientBrush(new Rectangle(30, 30, BLOCKSIZE, BLOCKSIZE), BLACKBLOCKCOLOR, BLACKBLOCKCOLOR1, MODE);

		}




	}



}
