using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CheckMate.Engine;
using CheckMate.Graphix;


namespace CheckMate.WinForms
{
	/// <summary>
	/// Summary description for PawnReplacementFrm.
	/// </summary>
	internal class PawnReplacementFrm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBoxSelect;
		private System.Windows.Forms.RadioButton radioButtonQueen;
		private System.Windows.Forms.RadioButton radioButtonBishop;
		private System.Windows.Forms.RadioButton radioButtonRook;
		private System.Windows.Forms.RadioButton radioButtonKnight;
		private System.Windows.Forms.PictureBox pictureBoxPiece;
		private System.Windows.Forms.Button buttonOk;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PawnReplacementFrm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		private Board cb;
		private PieceType pType;
		private PieceFactory pFactory;
		private PieceColor pColor;

		public PieceType GetSelectedPieceType()
		{
			return pType;
		}

		public PawnReplacementFrm(Board chessboard, PieceColor aColor)
		{
			
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			pType = PieceType.QUEEN;
			pColor = aColor;

			pFactory = new PieceFactory();

			pictureBoxPiece.Paint += new PaintEventHandler(PiecePaint);
			
		}


		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBoxSelect = new System.Windows.Forms.GroupBox();
			this.radioButtonKnight = new System.Windows.Forms.RadioButton();
			this.radioButtonRook = new System.Windows.Forms.RadioButton();
			this.radioButtonBishop = new System.Windows.Forms.RadioButton();
			this.radioButtonQueen = new System.Windows.Forms.RadioButton();
			this.pictureBoxPiece = new System.Windows.Forms.PictureBox();
			this.buttonOk = new System.Windows.Forms.Button();
			this.groupBoxSelect.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBoxSelect
			// 
			this.groupBoxSelect.Controls.Add(this.radioButtonKnight);
			this.groupBoxSelect.Controls.Add(this.radioButtonRook);
			this.groupBoxSelect.Controls.Add(this.radioButtonBishop);
			this.groupBoxSelect.Controls.Add(this.radioButtonQueen);
			this.groupBoxSelect.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBoxSelect.Location = new System.Drawing.Point(0, 0);
			this.groupBoxSelect.Name = "groupBoxSelect";
			this.groupBoxSelect.Size = new System.Drawing.Size(258, 56);
			this.groupBoxSelect.TabIndex = 0;
			this.groupBoxSelect.TabStop = false;
			this.groupBoxSelect.Text = "Select";
			// 
			// radioButtonKnight
			// 
			this.radioButtonKnight.Location = new System.Drawing.Point(140, 26);
			this.radioButtonKnight.Name = "radioButtonKnight";
			this.radioButtonKnight.Size = new System.Drawing.Size(56, 16);
			this.radioButtonKnight.TabIndex = 3;
			this.radioButtonKnight.Text = "Knight";
			this.radioButtonKnight.CheckedChanged += new System.EventHandler(this.radioButtonQueen_CheckedChanged);
			// 
			// radioButtonRook
			// 
			this.radioButtonRook.Location = new System.Drawing.Point(196, 26);
			this.radioButtonRook.Name = "radioButtonRook";
			this.radioButtonRook.Size = new System.Drawing.Size(52, 16);
			this.radioButtonRook.TabIndex = 2;
			this.radioButtonRook.Text = "Rook";
			this.radioButtonRook.CheckedChanged += new System.EventHandler(this.radioButtonQueen_CheckedChanged);
			// 
			// radioButtonBishop
			// 
			this.radioButtonBishop.Location = new System.Drawing.Point(76, 26);
			this.radioButtonBishop.Name = "radioButtonBishop";
			this.radioButtonBishop.Size = new System.Drawing.Size(64, 16);
			this.radioButtonBishop.TabIndex = 1;
			this.radioButtonBishop.Text = "Bishop";
			this.radioButtonBishop.CheckedChanged += new System.EventHandler(this.radioButtonQueen_CheckedChanged);
			// 
			// radioButtonQueen
			// 
			this.radioButtonQueen.Checked = true;
			this.radioButtonQueen.Location = new System.Drawing.Point(12, 26);
			this.radioButtonQueen.Name = "radioButtonQueen";
			this.radioButtonQueen.Size = new System.Drawing.Size(64, 16);
			this.radioButtonQueen.TabIndex = 0;
			this.radioButtonQueen.TabStop = true;
			this.radioButtonQueen.Text = "Queen";
			this.radioButtonQueen.CheckedChanged += new System.EventHandler(this.radioButtonQueen_CheckedChanged);
			// 
			// pictureBoxPiece
			// 
			this.pictureBoxPiece.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxPiece.Location = new System.Drawing.Point(16, 72);
			this.pictureBoxPiece.Name = "pictureBoxPiece";
			this.pictureBoxPiece.Size = new System.Drawing.Size(60, 60);
			this.pictureBoxPiece.TabIndex = 1;
			this.pictureBoxPiece.TabStop = false;
			// 
			// buttonOk
			// 
			this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOk.Location = new System.Drawing.Point(176, 104);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.TabIndex = 2;
			this.buttonOk.Text = "OK";
			this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
			// 
			// PawnReplacementFrm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(258, 143);
			this.ControlBox = false;
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.pictureBoxPiece);
			this.Controls.Add(this.groupBoxSelect);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PawnReplacementFrm";
			this.Text = "Seelct Piece";
			this.Load += new System.EventHandler(this.PawnReplacementFrm_Load);
			this.groupBoxSelect.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void radioButtonQueen_CheckedChanged(object sender, System.EventArgs e)
		{
			
			if ((sender as RadioButton).Checked)
			{
				if ((sender as RadioButton).Text == "Queen")
					pType = PieceType.QUEEN;
				else if ((sender as RadioButton).Text == "Bishop")
					pType = PieceType.BISHOP;
				else if ((sender as RadioButton).Text == "Knight")
					pType = PieceType.KNIGHT;
				else if ((sender as RadioButton).Text == "Rook")
					pType = PieceType.ROOK;

				pictureBoxPiece.Refresh();
			}
			
		}

		private void PiecePaint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			PieceRect pieceRect = pFactory.GetPieceRect(pType, pColor);
			pieceRect.Draw(g, new Point(10,10));
		}

		private void buttonOk_Click(object sender, System.EventArgs e)
		{
			//Hide();
		}

		private void PawnReplacementFrm_Load(object sender, System.EventArgs e)
		{
		
		}


	}
}
