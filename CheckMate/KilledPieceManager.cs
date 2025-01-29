/// <summary>
/// Summary description for KilledPieceManager.
/// </summary>
/// 

using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using CheckMate.Graphix;

namespace CheckMate.Engine
{
	internal class KilledPieceManager
	{
		private PictureBox KilledWhiteContainer;
		private PictureBox KilledBlackContainer;

		private ArrayList KilledWhitePieceList;
		private ArrayList KilledBlackPieceList;

		private int xWhitePawn, yWhitePawn, xWhiteOthers,
					xBlackPawn, yBlackPawn, xBlackOthers;

		private PieceFactory pFactory ;

		public KilledPieceManager(PictureBox WhiteContainer, PictureBox BlackContainer)
		{
			KilledWhiteContainer = WhiteContainer;
			KilledBlackContainer = BlackContainer;

			pFactory = new PieceFactory();
			KilledWhitePieceList = new ArrayList();
			KilledBlackPieceList = new ArrayList();

			WhiteContainer.Paint += new PaintEventHandler(KilledWhiteContainerPaint);
			BlackContainer.Paint += new PaintEventHandler(KilledBlackContainerPaint);

		}

		~KilledPieceManager()
		{
		}

		internal void Initialize()
		{
			KilledWhitePieceList.Clear();
			KilledBlackPieceList.Clear();

			KilledWhiteContainer.Refresh();
			KilledBlackContainer.Refresh();

			InitializeKilledPiecePositions();
		}

		private void KilledWhiteContainerPaint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			try
			{
				for (int i=0; i<KilledWhitePieceList.Count; i++)
				{
					Piece KilledPiece  = (Piece) KilledWhitePieceList[i];
					KilledPiece.Draw(pFactory, g);
				}
			}
			finally
			{
			}
		}

		private void KilledBlackContainerPaint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			try
			{
				for (int i=0; i<KilledBlackPieceList.Count; i++)
				{
					Piece KilledPiece  = (Piece) KilledBlackPieceList[i];
					KilledPiece.Draw(pFactory, g);
				}
			}
			finally
			{
			}
		}

		internal void AddKilledPiece(Piece KilledPiece)
		{
			if (KilledPiece.GetPieceColor() == PieceColor.WHITE)
			{
				KilledWhitePieceList.Add(KilledPiece);

				if (KilledPiece.GetPieceType() == PieceType.PAWN)
				{
					KilledPiece.SetStartPosition(new Point(xWhitePawn , yWhitePawn ));
					xWhitePawn = xWhitePawn + 30;
				}
				else
				{
					KilledPiece.SetStartPosition(new Point(xWhiteOthers , yWhitePawn - 50 ));
					xWhiteOthers = xWhiteOthers + 30;
				}

				KilledWhiteContainer.Refresh();

			}
			else
			{
				KilledBlackPieceList.Add(KilledPiece);
				if (KilledPiece.GetPieceType() == PieceType.PAWN)
				{
					KilledPiece.SetStartPosition(new Point(xBlackPawn , yBlackPawn ));
					xBlackPawn = xBlackPawn + 30;
				}
				else
				{
					KilledPiece.SetStartPosition(new Point(xBlackOthers , yBlackPawn - 50 ));
					xBlackOthers = xBlackOthers + 30;
				}

				KilledBlackContainer.Refresh();

			}

		}

		private void InitializeKilledPiecePositions()
		{
			xWhitePawn = 30; yWhitePawn = 100; xWhiteOthers = 30;
			xBlackPawn = 30; yBlackPawn = 100; xBlackOthers = 30;
		}

		

	}
}
