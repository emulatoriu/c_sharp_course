/// <summary>
/// Summary description for Game.
/// </summary>

using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using System.Text;

namespace CheckMate.Engine
{
	
	public class Game
	{
		
		private Player Player1, Player2;
		private bool IsNoTimeLimitGame;
		private Timer TimerGame;
		private Label lblPlayer1,lblPlayer2;

		private Board board;
		Font TitleFont;
		SolidBrush TitleBrush; 

		
		public Game( PictureBox aMainBox, PictureBox aKilledWhiteBox, PictureBox aKilledBlackBox )
		{
			board = new Board(this, aMainBox, aKilledWhiteBox, aKilledBlackBox);
			TitleFont = new Font("Arial", 10, GraphicsUnit.Point);
			
			TitleBrush = new SolidBrush(Color.Black);
		}

		~Game()
		{
			if (TitleBrush != null)
				TitleBrush.Dispose();

			if (TitleFont != null)
				TitleFont.Dispose();
		}
	

		#region Public Methods
		public void InitializeGame()
		{
			Player1 = null;
			Player2 = null;
			CreatePlayers();

			board.Initialize();

			Player1.SetPieceList(board.GetWhitePieceList());
			Player2.SetPieceList(board.GetBlackPieceList());

		}

		public void StartGame( string Player1Name, string  Player2Name, int GameMinutes, Label aPlayer1Box, Label aPlayer2Box )
		{
			InitializeGame();
			Player1.SetName(Player1Name);
			Player2.SetName(Player2Name);

			lblPlayer1 = aPlayer1Box;
			lblPlayer2 = aPlayer2Box;


			IsNoTimeLimitGame = (GameMinutes <= 0);


			if (IsNoTimeLimitGame)
			{
				DisposeTimer();

			}
			else
			{
				Player1.SetTime(GameMinutes * 60);
				Player2.SetTime(GameMinutes * 60);

				StartTimer();
			}


			ChangePlayer();

		}

		#endregion


		private void CreatePlayers()
		{
			Player1 = new Player(PlayerType.PLAYER1, "Player 1", PieceColor.WHITE);
			Player2 = new Player(PlayerType.PLAYER2, "Player 2", PieceColor.BLACK);
		}

		private void StartTimer()
		{
			if (TimerGame == null)
				CreateTimer();

			TimerGame.Enabled = true;
		}

		private void StopTimer()
		{
			if (TimerGame != null)
				TimerGame.Enabled = false;
		}
		
		private void CreateTimer()
		{
			TimerGame = new System.Windows.Forms.Timer();
			TimerGame.Enabled = false;
			TimerGame.Interval = 1000;

			TimerGame.Tick += new EventHandler(GameTimerTick);
		}

		private void DisposeTimer()
		{
			if (TimerGame != null)
				TimerGame.Dispose();
		}

		private void GameTimerTick(	object sender,	EventArgs e	)
		{
			if (IsNoTimeLimitGame)
				return;
			
			int Secs = GetCurrentPlayer().GetTime();



			if (Secs <= 0)
			{
				GameOver(GetCurrentPlayer());
				return;
			}

			GetCurrentPlayer().SetTime(Secs - 1);
			UpdatePlayerTitle();

				
		}


		internal void GameOver(Player PlayerLost)
		{
			StopTimer();

			System.Windows.Forms.MessageBox.Show(String.Format("Game Over ! {0} lost", PlayerLost.GetName()) );

			for (int i=0; i<Board.PieceCount; i++)
			{

				ArrayList aPlayer1List = Player1.GetPieceList();
				ArrayList aPlayer2List = Player2.GetPieceList();

				Piece aPiece1 = (Piece) aPlayer1List[i];
				Piece aPiece2 = (Piece) aPlayer2List[i];

				if (aPiece1 != null)
					aPiece1.SetIsEnabled(false);
				if (aPiece2 != null)
					aPiece2.SetIsEnabled(false);

			}

		}

		internal Player GetPlayer1()
		{
			return Player1;
		}

		internal Player GetPlayer2()
		{
			return Player2;
		}

		internal Player GetCurrentPlayer()
		{
			if (Player2.GetTurn())
				return Player2;
			else
				return Player1;
		}

		internal Player GetOtherPlayer()
		{
			if (Player2.GetTurn())
				return Player1;
			else
				return Player2;
		}


		void UpdatePlayerTitle()
		{

			StringBuilder Str1, Str2;

			Str1 = new StringBuilder();
			Str2 = new StringBuilder();


			// Add Indicator
			if  (Player1.GetTurn())
				Str1.Append(" --> ");

			if  (Player2.GetTurn())
				Str2.Append(" --> ");

			// Add name
			Str1.Append(Player1.GetName());
			Str2.Append(Player2.GetName());

			// Add game Status

			if (IsNoTimeLimitGame)
			{
				Str1.Append(" (No Time Limit) ");
				Str2.Append(" (No Time Limit) ");
			}
			else
			{
				int quot1, rem1;
				quot1 = Math.DivRem(GetPlayer1().GetTime(), 60, out rem1);

				Str1.Append(String.Format(" ({0}:{1}) ", quot1, rem1));

				int quot2, rem2;
				quot2 = Math.DivRem(GetPlayer2().GetTime(), 60, out rem2);
				Str2.Append(String.Format(" ({0}:{1}) ", quot2, rem2));


			}

			if (Player1.GetCheckStatus())
				Str1.Append(" Check");

			if (Player2.GetCheckStatus())
				Str2.Append(" Check");

			lblPlayer1.Text = Str1.ToString();
			lblPlayer2.Text = Str2.ToString();


			
		}

		internal void ChangePlayer() 
		{
			if (Player1.GetTurn())
			{
				Player1.SetTurn(false);
				Player2.SetTurn(true);

			}
			else 
			{
				Player1.SetTurn(true);
				Player2.SetTurn(false);
			}

			ActivatePieces();
			UpdatePlayerTitle();



		}

		private void ActivatePieces()
		{
			
			ArrayList aPlayer1List = Player1.GetPieceList();
			ArrayList aPlayer2List = Player2.GetPieceList();

			for (int i=0; i<Board.PieceCount; i++)
			{
				Piece aPiece1 = (Piece) aPlayer1List[i];
				Piece aPiece2 = (Piece) aPlayer2List[i];

				if (aPiece1 != null) 
					aPiece1.SetIsEnabled(Player1.GetTurn());

				if (aPiece2 != null) 
					aPiece2.SetIsEnabled(Player2.GetTurn());
			}
		}

		
	}
}
