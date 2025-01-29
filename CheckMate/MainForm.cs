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
	/// Summary description for MainForm.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel pnlLeft;
		private System.Windows.Forms.PictureBox pbWhiteKilledPieces;
		private System.Windows.Forms.PictureBox pbBlackKilledPieces;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.Label lblPlayer2;
		private System.Windows.Forms.Label lblPlayer1;
		private System.Windows.Forms.PictureBox pbBoard;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem8;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MainForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}


		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainForm));
			this.pnlLeft = new System.Windows.Forms.Panel();
			this.pbBoard = new System.Windows.Forms.PictureBox();
			this.lblPlayer2 = new System.Windows.Forms.Label();
			this.lblPlayer1 = new System.Windows.Forms.Label();
			this.pbWhiteKilledPieces = new System.Windows.Forms.PictureBox();
			this.pbBlackKilledPieces = new System.Windows.Forms.PictureBox();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.pnlLeft.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlLeft
			// 
			this.pnlLeft.Controls.Add(this.pbBoard);
			this.pnlLeft.Controls.Add(this.lblPlayer2);
			this.pnlLeft.Controls.Add(this.lblPlayer1);
			this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlLeft.Location = new System.Drawing.Point(0, 0);
			this.pnlLeft.Name = "pnlLeft";
			this.pnlLeft.Size = new System.Drawing.Size(672, 731);
			this.pnlLeft.TabIndex = 0;
			// 
			// pbBoard
			// 
			this.pbBoard.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pbBoard.Location = new System.Drawing.Point(0, 23);
			this.pbBoard.Name = "pbBoard";
			this.pbBoard.Size = new System.Drawing.Size(672, 685);
			this.pbBoard.TabIndex = 5;
			this.pbBoard.TabStop = false;
			// 
			// lblPlayer2
			// 
			this.lblPlayer2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.lblPlayer2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblPlayer2.Location = new System.Drawing.Point(0, 708);
			this.lblPlayer2.Name = "lblPlayer2";
			this.lblPlayer2.Size = new System.Drawing.Size(672, 23);
			this.lblPlayer2.TabIndex = 4;
			this.lblPlayer2.Text = "Player 2";
			this.lblPlayer2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lblPlayer1
			// 
			this.lblPlayer1.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblPlayer1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.lblPlayer1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblPlayer1.ForeColor = System.Drawing.Color.Black;
			this.lblPlayer1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.lblPlayer1.Location = new System.Drawing.Point(0, 0);
			this.lblPlayer1.Name = "lblPlayer1";
			this.lblPlayer1.Size = new System.Drawing.Size(672, 23);
			this.lblPlayer1.TabIndex = 3;
			this.lblPlayer1.Text = "Player 1";
			this.lblPlayer1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// pbWhiteKilledPieces
			// 
			this.pbWhiteKilledPieces.Dock = System.Windows.Forms.DockStyle.Top;
			this.pbWhiteKilledPieces.Location = new System.Drawing.Point(672, 0);
			this.pbWhiteKilledPieces.Name = "pbWhiteKilledPieces";
			this.pbWhiteKilledPieces.Size = new System.Drawing.Size(378, 264);
			this.pbWhiteKilledPieces.TabIndex = 1;
			this.pbWhiteKilledPieces.TabStop = false;
			// 
			// pbBlackKilledPieces
			// 
			this.pbBlackKilledPieces.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pbBlackKilledPieces.Location = new System.Drawing.Point(672, 483);
			this.pbBlackKilledPieces.Name = "pbBlackKilledPieces";
			this.pbBlackKilledPieces.Size = new System.Drawing.Size(378, 248);
			this.pbBlackKilledPieces.TabIndex = 2;
			this.pbBlackKilledPieces.TabStop = false;
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1,
																					  this.menuItem7});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem2,
																					  this.menuItem5,
																					  this.menuItem6,
																					  this.menuItem3,
																					  this.menuItem4});
			this.menuItem1.Text = "&Game";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.Text = "&New";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 1;
			this.menuItem5.Text = "-";
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 2;
			this.menuItem6.Text = "Show Killed &Pieces";
			this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 3;
			this.menuItem3.Text = "-";
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 4;
			this.menuItem4.Text = "E&xit";
			this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 1;
			this.menuItem7.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem8});
			this.menuItem7.Text = "&Help";
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 0;
			this.menuItem8.Text = "&About";
			this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.FloralWhite;
			this.ClientSize = new System.Drawing.Size(1050, 731);
			this.Controls.Add(this.pbBlackKilledPieces);
			this.Controls.Add(this.pbWhiteKilledPieces);
			this.Controls.Add(this.pnlLeft);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Menu = this.mainMenu1;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "CheckMate";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.pnlLeft.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		Game g;

		private void MainForm_Load(object sender, System.EventArgs e)
		{
			menuItem6_Click(sender, e);
			g = new Game(pbBoard, pbWhiteKilledPieces, pbBlackKilledPieces);
		
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			int min;

			if (ShowStartForm() == DialogResult.OK)
			{
				if (startForm.GetNoTimeLimit())
					min = -1;
				else
					min = startForm.GetGameMinute();


				g.StartGame(startForm.GetPlayer1Name(), startForm.GetPlayer2Name(), min, lblPlayer1, lblPlayer2);
			}
		}

		StartGameForm startForm ;
		private DialogResult ShowStartForm()
		{
			if (startForm == null)
				startForm = new StartGameForm();

			return startForm.ShowDialog();

		}

		bool ShowKilledPieces = true;

		private void menuItem6_Click(object sender, System.EventArgs e)
		{
			ShowKilledPieces = (! ShowKilledPieces);

			if (ShowKilledPieces)
			{
				menuItem6.Text = "Hide Killed Pieces";
				this.Width = 1060;

			}
			else
			{
				menuItem6.Text = "Show Killed Pieces";
				this.Width = 700;

			}

		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		AboutForm aboutForm;

		private void menuItem8_Click(object sender, System.EventArgs e)
		{
			if (aboutForm == null)
				aboutForm = new AboutForm();

			aboutForm.ShowDialog();
		
		}


	}
}
