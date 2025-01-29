/// <summary>
/// Summary description for Player.
/// </summary>

using System;
using System.Collections;

namespace CheckMate.Engine
{

	internal class Player
	{
		private string name;
		private bool turn, IsCheck;
		private int aSec;
		private PlayerType pType;
		private PieceColor pColor;
		private ArrayList PieceList;

		public Player(PlayerType aType, string aName, PieceColor aColor)
		{
			turn = false;
			pType = aType;
			name = aName;
			pColor = aColor;
			IsCheck = false;
		}

		internal void SetPieceList (ArrayList aPieceList)
		{
			PieceList = aPieceList;
		}

		internal ArrayList GetPieceList()
		{
			return PieceList;
		}

		internal bool GetCheckStatus()
		{
			return IsCheck;
		}

		internal void SetCheckStatus(bool aIsCheck)
		{
			IsCheck=aIsCheck;
		}

		internal void SetTime(int aSeconds)
		{
			aSec = aSeconds;
		}

		internal int GetTime()
		{
			return aSec;
		}


		internal string GetName()
		{
			return name;
		}

		internal void SetName(string aName)
		{
			name = aName;
		}

		internal bool GetTurn()
		{
			return turn;
		}

		internal void SetTurn(bool aTurn)
		{
			turn = aTurn;
		}

		internal PlayerType GetPlayerType()
		{
			return pType;
		}

		internal PieceColor GetPieceColor()
		{
			return pColor;
		}

		#region Public Methods
		#endregion
	}
}
