/// <summary>
/// Summary description for Board.
/// </summary>

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using CheckMate.Graphix;
using CheckMate.WinForms;

namespace CheckMate.Engine
{

	internal class Board 
	{
		internal const byte BlockCount = 64;
		internal const byte PieceCount = 16;
		internal const int BoardLeft = 20;
		internal const int BoardTop  = 20;

		private PictureBox container;
		private BlockPositioner bPositioner;
		private BoardDecorator cbDecorator;
		private ArrayList BlockList;
		private ArrayList WhitePieceList;
		private ArrayList BlackPieceList;
		private Piece WhiteKingPiece, BlackKingPiece;
		private ArrayList ValidBlockList;
		private BlockFactory bFactory;
		private PieceFactory pFactory;
		private KilledPieceManager KilledPieceMgr;
		private BoardInitializer BoardDrawer;
		private PositionCalculatorFactory PosCalculatorFactory;
		private Game game;
		private Block IsLastActiveBlock;




		public Board( Game aGame, PictureBox mainBox, PictureBox killedWhiteBox, PictureBox killedBlackBox )
		{
			game		= aGame;
			container	= mainBox;

			// Create ArrayList
			BlockList		= new ArrayList();
			WhitePieceList	= new ArrayList();
			BlackPieceList	= new ArrayList();

			// Create Block Factory
			bFactory = new BlockFactory();
			pFactory = new PieceFactory();

			// Create Positioner
			bPositioner = new BlockPositioner();

			// Block Drawer
			BoardDrawer = new BoardInitializer(this, BlockList, WhitePieceList, BlackPieceList, bFactory, pFactory, bPositioner);
			BoardDrawer.Initialize();

			// Killed Piece 
			KilledPieceMgr = new KilledPieceManager(killedWhiteBox, killedBlackBox);
			
			// Create Decorator and assign events
			cbDecorator = new BoardDecorator(this, mainBox);

			PosCalculatorFactory = new PositionCalculatorFactory(this);

		}

		internal void Initialize()
		{
			KilledPieceMgr.Initialize();
			BoardDrawer.DrawPieces();
			SetLastMoveIndicator(null);
			container.Refresh();
		}

		internal ArrayList GetWhitePieceList()
		{
			 return WhitePieceList;
		}

		internal ArrayList GetBlackPieceList()
		{
			return BlackPieceList;
		}

		internal void Invalidate(Rectangle rect)
		{		
			container.Invalidate(rect);
		}

		internal void Refresh()
		{
			container.Refresh();
		}

		internal void SetWhiteKing(Piece aKingPiece)
		{
			WhiteKingPiece = aKingPiece;
		}

		internal void SetBlackKing(Piece aKingPiece)
		{
			BlackKingPiece = aKingPiece;
		}
		


		internal Block GetBlock(int x, int y)
		{
			Block block ;

			int ChessWidth = ChessConstants.BLOCKSIZE * ChessConstants.BLOCKSPERROW;

			if ((x < BoardLeft) || (y < BoardTop) || (x > BoardLeft + ChessWidth) || (y > BoardLeft + ChessWidth))
				return null;


			for (int i=0; i < BlockCount; i++) 	
			{
				block = (Block) BlockList[i];

				if (block != null) 
					if (block.Contains(x, y)) 
						return block;
			}
			return null;
		}

		public Piece GetPiece(int x, int y)
		{
			Block block = GetBlock(x, y);
			if (block != null)
				return block.GetPiece();
			else
				return null;
		}
		

		private void DrawBlock(Graphics g, Block block, bool highlight, bool bIsLastMove)
		{
			if (block != null)
			{
				block.Draw(bFactory, g, highlight, bIsLastMove);

				// Draw Piece
				Piece piece = block.GetPiece();
				DrawPiece(g, piece);
			}

		}

		internal void DrawPiece(Graphics g, Piece piece)
		{
			if (piece != null)
				piece.Draw(pFactory, g);
		}

		public void Draw(Graphics g)
		{
			int width = ChessConstants.BLOCKSIZE * ChessConstants.BLOCKSPERROW;

			g.FillRectangle(new SolidBrush(ChessConstants.BORDERCOLOR), 
				BoardLeft - 10, 
				BoardTop  - 10,
				width + 20 ,
				width + 20);

			Block block;

			for(int i=0; i < BlockCount; i++)
			{ 
				// Draw 
				block = (Block) BlockList[i];
				DrawBlock(g, block, false, block.GetIsLastMove());
			}
		
		}


		public Block GetBlockByChessPosition(Point cPosition) 
		{
			Block block;

			for (int i=0; i < BlockCount; i++) 	
			{
				block = (Block) BlockList[i];

				if (block != null) 
				{
					if  (  (block.GetChessPosition().X == cPosition.X) 
						&& (block.GetChessPosition().Y == cPosition.Y))
						return block;
				}
			}
			return null;
		}

		
		public Size GetSize()	
		{
			int height, width;

			height = (ChessConstants.BLOCKSIZE * ChessConstants.BLOCKSPERROW) 
				+ (BoardLeft * 2) ;

			width = height;
			return new Size(width, height);
		}


		public void ShowValidPositions(Block block)
		{
			if (block == null)
				return;

			Piece piece = block.GetPiece();
			if (piece == null)
				return;

			PositionCalculator PosCalc = PosCalculatorFactory.GetPositionCalculator(piece.GetPieceType(), game.GetCurrentPlayer());

			Graphics g = container.CreateGraphics();
			try
			{
				
				ArrayList tempBlockList = PosCalc.CalculatePositions(block, false);
				ValidBlockList = (ArrayList) tempBlockList.Clone();

				for (int i= 0; i<ValidBlockList.Count ; i++)
				{
					((Block) ValidBlockList[i]).SetIsHighLight(true);
					DrawBlock(g,(Block) ValidBlockList[i], true,((Block) ValidBlockList[i]).GetIsLastMove() );
				}
			}
			finally
			{
				g.Dispose();
			}
		}

		public int ValidPositionCount()
		{
			return ValidBlockList.Count;
		}

		internal void ClearValidPositions()
		{
			if (ValidBlockList != null)
			{
				Graphics g = container.CreateGraphics();
				try
				{
					for (int i= 0; i<ValidBlockList.Count ; i++)
					{
						((Block) ValidBlockList[i]).SetIsHighLight(false);
						DrawBlock(g,(Block) ValidBlockList[i], true, ((Block) ValidBlockList[i]).GetIsLastMove());
					}
				}
				finally
				{
					g.Dispose();
				}
			}
		}

		internal bool IsValidBlock(Block block)
		{
			if (ValidBlockList == null)
				return false;

			for(int i=0; i<ValidBlockList.Count; i++)
			{  
				Block b = (Block) ValidBlockList[i];

				if ((b.GetChessPosition().X == block.GetChessPosition().X) &&
					(b.GetChessPosition().Y == block.GetChessPosition().Y))
					return true;
			}

			return false;
		}

		private Piece GetPieceAtBlock(Block b)
		{
			if (b != null)
			{
				Piece piece = b.GetPiece();
				if (piece != null)
					return piece;
				else
					return null;

			}
			else
				return null;
		}



		// Todo : Revisit

		private void MoveRookForCastle(Block OriginalBlock, int Direction)
		{
			if (Direction == 0) 
				return;
			
			int xPos;
			
			if (Direction > 0)
				xPos = 7;
			else
				xPos = 0;

			Block block = GetBlockByChessPosition(new Point(xPos, OriginalBlock.GetChessPosition().Y));
			Piece RookPiece = GetPieceAtBlock(block);

			if (RookPiece!= null)
			{
				Block TargetBlock = GetBlockByChessPosition(new Point(OriginalBlock.GetChessPosition().X + Direction, OriginalBlock.GetChessPosition().Y));
				RealMove(RookPiece, TargetBlock, block, null); 
				//MovePiece(p, , block);
				RookPiece.SetCanCastle(false);
				RookPiece.SetStartPosition(new Point(	TargetBlock.GetStartPosition().X + ChessConstants.PIECELEFT,
														TargetBlock.GetStartPosition().Y + ChessConstants.PIECETOP));
			}


		}

		private bool CheckForCurrentPlayer(PieceColor pColor)
		{
			if (pColor == PieceColor.WHITE)
                return CheckForOpponent(PieceColor.BLACK, game.GetOtherPlayer());
			else
				return CheckForOpponent(PieceColor.WHITE, game.GetOtherPlayer());
		}
		
		private bool CheckForOpponent(PieceColor pColor, Player aPlayer)
		{
			ArrayList TargetList = new ArrayList();
			ArrayList tempTargetList = new ArrayList();

			ArrayList tempList;
			Piece OpponentKingPiece;

			if (pColor==PieceColor.WHITE)
			{
				tempList = WhitePieceList;
				OpponentKingPiece = BlackKingPiece;
			}
			else
			{
				tempList = BlackPieceList;
				OpponentKingPiece = WhiteKingPiece;
			}

			for (int i=0; i<PieceCount; i++)
			{
				Piece piece = (Piece) tempList[i];

				if (piece!=null)
				{
					Block block = piece.GetContainerBlock();
					if (block!=null)
					{
						PositionCalculator posCalculator = PosCalculatorFactory.GetPositionCalculator(piece.GetPieceType(), aPlayer);
						tempTargetList = posCalculator.CalculatePositions(block, true);

						TargetList.AddRange(tempTargetList);
					}
				}
				tempTargetList.Clear();
			}

			return IsKingInDanger(OpponentKingPiece, TargetList);
			
		}

		private bool IsKingInDanger(Piece aKingPiece, ArrayList aTargetList)
		{
			//if (aKingPiece.GetPieceType() != PieceType.KING)
			//	throw Exception

			Block KingBlock = aKingPiece.GetContainerBlock();

			for (int i=0; i<aTargetList.Count; i++)
			{
				Block block = (Block) aTargetList[i];

				if (block != null)
					if ((block.GetChessPosition().X == KingBlock.GetChessPosition().X) &&
						(block.GetChessPosition().Y == KingBlock.GetChessPosition().Y))
						return true;
			}

			return false;
		}

		private PieceType OpenPawnReplacementForm(PieceColor pColor)
		{

			PieceType pType = PieceType.QUEEN;
			PawnReplacementFrm frmPawnReplace = new PawnReplacementFrm(this, pColor);

			if (frmPawnReplace.ShowDialog() == DialogResult.OK)
			{
				pType = frmPawnReplace.GetSelectedPieceType();
				frmPawnReplace.Dispose();
			}

			return pType;

			
		}


		private void RollbackMove(Piece aMovingPiece, Block aNewBlock, Block aOrigBlock, Piece aGonePiece )
		{

			if (aGonePiece != null)
			{
				aGonePiece.SetContainerBlock(aNewBlock);
				aNewBlock.SetPiece(aGonePiece);
				aGonePiece.SetStartPosition(new Point(	aNewBlock.GetStartPosition().X + ChessConstants.PIECELEFT,
					aNewBlock.GetStartPosition().Y + ChessConstants.PIECETOP));

			}
			else
				aNewBlock.SetPiece(null);

			aOrigBlock.SetPiece(aMovingPiece);
			aMovingPiece.SetContainerBlock(aOrigBlock);
			

			aMovingPiece.SetStartPosition(new Point(	aOrigBlock.GetStartPosition().X + ChessConstants.PIECELEFT,
													aOrigBlock.GetStartPosition().Y + ChessConstants.PIECETOP));
		}

		private void RealMove(Piece aMovingPiece, Block aNewBlock, Block aOrigBlock, Piece aGonePiece )
		{
			// 1. Check for Gone Piece
			if (aGonePiece != null)
				aGonePiece.SetContainerBlock(null);
			
			// 2. Set Null to Original Block
			aOrigBlock.SetPiece(null);

			// 3. Set new Block to piece
			aMovingPiece.SetContainerBlock(aNewBlock);

			// 4. Set Piece for new block
			aNewBlock.SetPiece(aMovingPiece);
		}

		
		private bool IsPieceKing(Piece aPiece)
		{
			if (aPiece == null)
				return false;
			else
			    return (aPiece.GetPieceType() == PieceType.KING);
		}

		internal bool MovePiece(Piece MovingPiece, Block NewBlock, Block OrigBlock)
		{


			// if new block contains a piece, make that piece's block to null
			Piece GonePiece = NewBlock.GetPiece();

			// Can not kill KING
			if (IsPieceKing(GonePiece))
			{
				RollbackMove(MovingPiece, NewBlock, OrigBlock, GonePiece);
				return false;
			}

			// Move the Piece 
			RealMove(MovingPiece, NewBlock, OrigBlock, GonePiece);

	
			// Do we have check ?
			if (CheckForCurrentPlayer(MovingPiece.GetPieceColor()))
			{
				RollbackMove(MovingPiece, NewBlock, OrigBlock, GonePiece);
				return false;
			}
			
			// If Pawn reached to the other side
			if (MovingPiece.GetPieceType()==PieceType.PAWN)
			{
				PieceType pType;

				if (((MovingPiece.GetPieceColor() == PieceColor.WHITE) && (NewBlock.GetChessPosition().Y == 7)) ||
					((MovingPiece.GetPieceColor() == PieceColor.BLACK) && (NewBlock.GetChessPosition().Y == 0)))  
				{
					pType = OpenPawnReplacementForm(MovingPiece.GetPieceColor());

					MovingPiece.SetPieceType(pType);
				}
			}


			// Castle
			if ((MovingPiece.GetPieceType() == PieceType.KING) || (MovingPiece.GetPieceType() == PieceType.ROOK))
				MovingPiece.SetCanCastle(false);
			
			// KING CASTLE
			if (MovingPiece.GetPieceType() == PieceType.KING)
			{
				int Direction = 0;

				// Move ROOK
				if (NewBlock.GetChessPosition().X == OrigBlock.GetChessPosition().X + 2) 
					Direction = 1;
				else if	(NewBlock.GetChessPosition().X == OrigBlock.GetChessPosition().X - 2)
					Direction = -1;

				MoveRookForCastle(OrigBlock, Direction);
			}

			// 5. Set Piece's Start Position
			MovingPiece.SetStartPosition( new Point(NewBlock.GetStartPosition().X + ChessConstants.PIECELEFT,
				NewBlock.GetStartPosition().Y + ChessConstants.PIECETOP));

			if (GonePiece != null)
				KilledPieceMgr.AddKilledPiece(GonePiece);

			// 6. Do opponent has check ?
			bool IsOpponentCheck = false;
			IsOpponentCheck = CheckForOpponent(MovingPiece.GetPieceColor(), game.GetCurrentPlayer());


			// Show the Last Move
			SetLastMoveIndicator(NewBlock);


			// 7.. Change player
			game.GetCurrentPlayer().SetCheckStatus(false);
			game.ChangePlayer();
			game.GetCurrentPlayer().SetCheckStatus(IsOpponentCheck);

			return true;
		}

		private void SetLastMoveIndicator (Block aBlock)
		{
			if (IsLastActiveBlock != null)
				IsLastActiveBlock.SetIsLastMove(false);

			IsLastActiveBlock = aBlock;

			if (IsLastActiveBlock != null)
  				IsLastActiveBlock.SetIsLastMove(true);

		}



	}
}
