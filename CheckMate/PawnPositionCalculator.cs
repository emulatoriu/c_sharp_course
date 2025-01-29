using System;
using System.Collections;
using System.Drawing;

namespace CheckMate.Engine
{
	internal class PawnPositionCalculator : PositionCalculator
	{
		Player player;

		public PawnPositionCalculator(Board chessboard) : base(chessboard)
		{
		}

		internal void SetCurrentPlayer(Player aPlayer)
		{
			player = aPlayer;
		}


		private ArrayList CalculateKillingPositions(Block block, Boolean SupportPosition)
		{
		

			if (player.GetPlayerType() == PlayerType.PLAYER1)
			{
				GoLeftDown(block.GetChessPosition()	, SupportPosition);
				GoRightDown(block.GetChessPosition(), SupportPosition);
			}
			else if (player.GetPlayerType() == PlayerType.PLAYER2)
			{
				GoLeftUp(block.GetChessPosition(), SupportPosition);
				GoRightUp(block.GetChessPosition(), SupportPosition);
			}


			return ValidBlocks;

		}
			
		internal override ArrayList CalculatePositions(Block block, bool SupportPosition)
		{
			base.CalculatePositions(block, SupportPosition);

			if (SupportPosition)
				return this.CalculateKillingPositions(block, SupportPosition);
			else
			{

				if (player.GetPlayerType() == PlayerType.PLAYER1)
				{
					if (OrigBlock.GetChessPosition().Y == 1)
						GoDown( block.GetChessPosition(), 2);
					else
						GoDown( block.GetChessPosition(), 1 );

					GoLeftDown(block.GetChessPosition(), false);
					GoRightDown(block.GetChessPosition(), false);


				}
				else if (player.GetPlayerType() == PlayerType.PLAYER2)
				{
					if (OrigBlock.GetChessPosition().Y == 6)
						GoUp( block.GetChessPosition(), 2 );
					else
						GoUp( block.GetChessPosition(), 1 );

					GoLeftUp(block.GetChessPosition(), false);
					GoRightUp(block.GetChessPosition(), false);
				}


				return ValidBlocks;
			}
		}


		private void GoDown(Point cp, Byte steps)
		{
			byte aStep = 0;

			while( aStep < steps)
			{
				if (HelperFunction.IncY(ref cp))		
					ProceedIfNoPiece(cp.X, cp.Y);

				aStep++;
			}

		}

		private void GoLeftUp(Point cp, bool SupportPosition)	
		{
			if (HelperFunction.DecXDecY(ref cp))		
				if (SupportPosition)
					ProcessBlockForPawnInclusive(cp.X, cp.Y);
				else
					ProcessBlockForPawn(cp.X, cp.Y);
		}

		private void GoLeftDown(Point cp, bool SupportPosition)	
		{
			if (HelperFunction.DecXIncY(ref cp))		
				if (SupportPosition)
					ProcessBlockForPawnInclusive(cp.X, cp.Y);
				else
					ProcessBlockForPawn(cp.X, cp.Y);
		}

		private void GoRightUp(Point cp, bool SupportPosition)	
		{
			if (HelperFunction.IncXDecY(ref cp))		
				if (SupportPosition)
					ProcessBlockForPawnInclusive(cp.X, cp.Y);
				else
					ProcessBlockForPawn(cp.X, cp.Y);
		}

		private void GoRightDown(Point cp, bool SupportPosition)	
		{
			if (HelperFunction.IncXIncY(ref cp))		
				if (SupportPosition)
					ProcessBlockForPawnInclusive(cp.X, cp.Y);
				else
					ProcessBlockForPawn(cp.X, cp.Y);
		}

		private void GoUp(Point cp,  Byte steps)
		{
			byte aStep = 0;

			while( aStep < steps)
			{
				if (HelperFunction.DecY(ref cp))		
			  		ProceedIfNoPiece(cp.X, cp.Y);

				aStep++;
			}
		}


		private bool ProceedIfNoPiece(int x, int y)
		{
			Block b = cb.GetBlockByChessPosition(new Point(x, y));
			if (b != null) 
			{
				if (b.GetPiece() == null)	
				{
					ValidBlocks.Add(b);
					return true;
				}
					
			}
			return false;
		}

		private bool ProcessBlockForPawnInclusive(int x, int y)
		{
			Block b = cb.GetBlockByChessPosition(new Point(x, y));
			if (b != null) 
			{
				ValidBlocks.Add(b);
				return true;
			}
					
			return false;

		}

		private bool ProcessBlockForPawn(int x, int y)
		{
			Block b = cb.GetBlockByChessPosition(new Point(x, y));
			if (b != null) 
			{
				if (b.GetPiece() == null)	
				{
					return false;
				}
				else
				{
					if (b.GetPiece().GetPieceColor() == OrigBlock.GetPiece().GetPieceColor()) 
						return false;
					else
					{
						ValidBlocks.Add(b);
						return true;
					}
				}
					
			}
			return false;

		}


	}
}
