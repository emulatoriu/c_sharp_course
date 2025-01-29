/// <summary>
/// Summary description for BoardInitializer.
/// </summary>
/// 

using System;
using System.Collections;
using System.Drawing;
using CheckMate.Graphix;

namespace CheckMate.Engine
{
	internal class BoardInitializer
	{

		ArrayList bList, WhitePieceList, BlackPieceList;
		BlockFactory bFactory;
		PieceFactory pFactory;
		BlockPositioner bPositioner;
		Board board;

		public BoardInitializer(Board aBoard, ArrayList aBlockList, ArrayList aWhitePieceList, ArrayList aBlackPieceList, BlockFactory aBlockFactory, PieceFactory aPieceFactory, BlockPositioner aBlockPositioner  )
		{
			board       = aBoard;
			bList		= aBlockList;
			WhitePieceList = aWhitePieceList;
			BlackPieceList	= aBlackPieceList;
			bFactory	= aBlockFactory;
			pFactory	= aPieceFactory;
			bPositioner = aBlockPositioner;

		}

		private BlockColor GetColor(BlockColor oldColor)
		{

			// If new line, keep same block color
			// else reverse it
			if (! bPositioner.IsNewLine())	
			{

				if (oldColor == BlockColor.WHITE)
					return  BlockColor.BLACK;
				else
					return BlockColor.WHITE;
			}
			else
				return oldColor;

		}

		internal void DrawPieces()
		{
			// Clear arrays
			WhitePieceList.Clear();
			BlackPieceList.Clear();


			// Clear All Piece from Blocks
			for (int i=0; i<Board.BlockCount; i++)
				((Block) bList[i]).SetPiece(null);

			// Create WhitePieces
			CreateWhitePiece();

			// Create BlackPieces
			CreateBlackPiece();
		}



		internal void Initialize()	
		{
			CreateBlocks();

			bPositioner.Reset();
			for(int cnt=0; cnt < Board.BlockCount; cnt++)		
			{
				Block block = (Block) bList[cnt];
				block.SetStartPosition( new Point( bPositioner.NextX(), bPositioner.NextY() ) );
				bPositioner.Incr();
			}
		}

		private void CreateBlocks()	
		{

			BlockColor bColor = BlockColor.BLACK;

			Block block;

			int line = -1, col=0;


			// Reset Positioner
			bPositioner.Reset();

			for(int cnt=0; cnt < Board.BlockCount; cnt++)	
			{
				block = new Block();
				block.SetColor(GetColor(bColor));
				block.SetStartPosition(bPositioner.GetPosition());

				if (bPositioner.IsNewLine())
				{
					line++;
					col = 0;
				}
				else
					col++;

				block.SetChessPosition(new Point(col, line));

				bList.Add(block);

				bColor = block.GetColor();

				// Increment Positioner
				bPositioner.Incr();

			}
		}

		private void CreateWhitePiece()
		{
			Block block;
			int cnt = 0;

			while (cnt < 8)
			{
				block = board.GetBlockByChessPosition(new Point(cnt, 1));
				CreatePiece(block, PieceType.PAWN, PieceColor.WHITE);
				cnt++;
			}

			block = board.GetBlockByChessPosition(new Point(0,0));
			CreatePiece(block, PieceType.ROOK, PieceColor.WHITE);

			block = board.GetBlockByChessPosition(new Point(1,0));
			CreatePiece(block, PieceType.KNIGHT, PieceColor.WHITE);

			block = board.GetBlockByChessPosition(new Point(2,0));
			CreatePiece(block, PieceType.BISHOP, PieceColor.WHITE);
			
			block = board.GetBlockByChessPosition(new Point(3,0));
			CreatePiece(block, PieceType.QUEEN, PieceColor.WHITE);

			block = board.GetBlockByChessPosition(new Point(4,0));
			board.SetWhiteKing(CreatePiece(block, PieceType.KING, PieceColor.WHITE));

			block = board.GetBlockByChessPosition(new Point(5,0));
			CreatePiece(block, PieceType.BISHOP, PieceColor.WHITE);

			block = board.GetBlockByChessPosition(new Point(6,0));
			CreatePiece(block, PieceType.KNIGHT, PieceColor.WHITE);

			block = board.GetBlockByChessPosition(new Point(7,0));
			CreatePiece(block, PieceType.ROOK, PieceColor.WHITE);
		}


		private void CreateBlackPiece()
		{
			Block block;
			int cnt = 0;

			while (cnt < 8)
			{
				block = board.GetBlockByChessPosition(new Point(cnt, 6));
				CreatePiece(block, PieceType.PAWN, PieceColor.BLACK);
				cnt++;
			}

			block = board.GetBlockByChessPosition(new Point(0,7));
			CreatePiece(block, PieceType.ROOK, PieceColor.BLACK);

			block = board.GetBlockByChessPosition(new Point(1,7));
			CreatePiece(block, PieceType.KNIGHT, PieceColor.BLACK);

			block = board.GetBlockByChessPosition(new Point(2,7));
			CreatePiece(block, PieceType.BISHOP, PieceColor.BLACK);

			block = board.GetBlockByChessPosition(new Point(3,7));
			CreatePiece(block, PieceType.QUEEN, PieceColor.BLACK);

			block = board.GetBlockByChessPosition(new Point(4,7));
			board.SetBlackKing(CreatePiece(block, PieceType.KING, PieceColor.BLACK));

			block = board.GetBlockByChessPosition(new Point(5,7));
			CreatePiece(block, PieceType.BISHOP, PieceColor.BLACK);

			block = board.GetBlockByChessPosition(new Point(6,7));
			CreatePiece(block, PieceType.KNIGHT, PieceColor.BLACK);

			block = board.GetBlockByChessPosition(new Point(7,7));
			CreatePiece(block, PieceType.ROOK, PieceColor.BLACK);
		}

		private Piece CreatePiece(Block block, PieceType pType, PieceColor pColor)
		{
			Piece piece = new Piece(pType, pColor, block);
			// Set Piece Properties
			Point p = new Point(block.GetStartPosition().X + ChessConstants.PIECELEFT,
				block.GetStartPosition().Y + ChessConstants.PIECETOP);								

			piece.SetStartPosition(p);
			piece.SetContainerBlock(block);

			// Set Block Properties
			block.SetPiece(piece);

			// Add to ArrayList
			if (pColor==PieceColor.WHITE)
				WhitePieceList.Add(piece);
			else
				BlackPieceList.Add(piece);

			return piece;
		}


	}


}
