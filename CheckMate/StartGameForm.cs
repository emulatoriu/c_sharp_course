using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace CheckMate.WinForms
{
	/// <summary>
	/// Summary description for StartGameForm.
	/// </summary>
	public class StartGameForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.TextBox edPlayer1;
		private System.Windows.Forms.TextBox edPlayer2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox cbxNoTimeLimit;
		private System.Windows.Forms.TextBox edMintues;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public StartGameForm()
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
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnStart = new System.Windows.Forms.Button();
			this.edPlayer1 = new System.Windows.Forms.TextBox();
			this.edPlayer2 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.cbxNoTimeLimit = new System.Windows.Forms.CheckBox();
			this.edMintues = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(176, 120);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Text = "Cancel";
			// 
			// btnStart
			// 
			this.btnStart.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnStart.Location = new System.Drawing.Point(96, 120);
			this.btnStart.Name = "btnStart";
			this.btnStart.TabIndex = 1;
			this.btnStart.Text = "Start";
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// edPlayer1
			// 
			this.edPlayer1.Location = new System.Drawing.Point(96, 21);
			this.edPlayer1.Name = "edPlayer1";
			this.edPlayer1.Size = new System.Drawing.Size(152, 20);
			this.edPlayer1.TabIndex = 2;
			this.edPlayer1.Text = "Player 1";
			// 
			// edPlayer2
			// 
			this.edPlayer2.Location = new System.Drawing.Point(96, 51);
			this.edPlayer2.Name = "edPlayer2";
			this.edPlayer2.Size = new System.Drawing.Size(152, 20);
			this.edPlayer2.TabIndex = 3;
			this.edPlayer2.Text = "Player 2";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(40, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 16);
			this.label1.TabIndex = 4;
			this.label1.Text = "Player 1";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(40, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 16);
			this.label2.TabIndex = 5;
			this.label2.Text = "Player 2";
			// 
			// cbxNoTimeLimit
			// 
			this.cbxNoTimeLimit.Location = new System.Drawing.Point(48, 80);
			this.cbxNoTimeLimit.Name = "cbxNoTimeLimit";
			this.cbxNoTimeLimit.TabIndex = 6;
			this.cbxNoTimeLimit.Text = "No Time Limit";
			this.cbxNoTimeLimit.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// edMintues
			// 
			this.edMintues.Location = new System.Drawing.Point(208, 83);
			this.edMintues.Name = "edMintues";
			this.edMintues.Size = new System.Drawing.Size(40, 20);
			this.edMintues.TabIndex = 7;
			this.edMintues.Text = "30";
			this.edMintues.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(152, 85);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 16);
			this.label3.TabIndex = 8;
			this.label3.Text = "Minutes";
			// 
			// StartGameForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(270, 163);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.edMintues);
			this.Controls.Add(this.edPlayer2);
			this.Controls.Add(this.edPlayer1);
			this.Controls.Add(this.cbxNoTimeLimit);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnStart);
			this.Controls.Add(this.btnCancel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "StartGameForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Start Game";
			this.Load += new System.EventHandler(this.StartGameForm_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
		{
		
		}

		private void StartGameForm_Load(object sender, System.EventArgs e)
		{
			edPlayer1.Text = p1;
			edPlayer2.Text = p2;
			cbxNoTimeLimit.Checked = notime;
			edMintues.Text = min;
		}


		string p1 = "Player 1", p2 = "Player 2", 	min = "30";
		bool notime = false;

		internal string GetPlayer1Name()
		{ 
			return p1;
		}

		internal string GetPlayer2Name()
		{ 
			return p2;
		}

		internal int GetGameMinute()
		{ 
			return Convert.ToInt16(min);
		}

		internal bool GetNoTimeLimit()
		{
			return notime;
		}

		internal void SetPlayer1Name(string aName)
		{
			p1 = aName;
		}

		internal void SetPlayer2Name(string aName)
		{
			p2 = aName;
		}

		internal void SetGameMinute(int Min)
		{
			min = Min.ToString();
		}

		internal void SetNoTimeLimit(bool NoTimeLimit)
		{
			notime = NoTimeLimit;
		}

		private void btnStart_Click(object sender, System.EventArgs e)
		{
			SetPlayer1Name(edPlayer1.Text);
			SetPlayer2Name(edPlayer2.Text);
			SetNoTimeLimit(cbxNoTimeLimit.Checked);
			try
			{
				SetGameMinute(Convert.ToInt16(edMintues.Text));
			}
			catch(Exception E)
			{
				SetGameMinute(30);
			}

			

		}

	}
}
