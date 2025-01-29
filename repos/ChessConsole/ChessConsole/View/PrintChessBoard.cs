using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessConsole.View
{
    internal class PrintChessBoard
    {

        static List<List<String>> listOfPieces = new List<List<string>>();
        Dictionary<String, String> chessBoard = new Dictionary<String, String>();
        private void initChessBoaard()
        {
			chessBoard.Add("00", "WT");
			chessBoard.Add("01", "WS");
			chessBoard.Add("02", "WL");
			chessBoard.Add("03", "WD");
			chessBoard.Add("04", "WK");
			chessBoard.Add("05", "WL");
			chessBoard.Add("06", "WS");
			chessBoard.Add("07", "WT");

			chessBoard.Add("10", "WB");
			chessBoard.Add("11", "WB");
			chessBoard.Add("12", "WB");
			chessBoard.Add("13", "WB");
			chessBoard.Add("14", "");
			chessBoard.Add("15", "WB");
			chessBoard.Add("16", "WB");
			chessBoard.Add("17", "WB");

			chessBoard.Add("20", "");
			chessBoard.Add("21", "");
			chessBoard.Add("22", "");
			chessBoard.Add("23", "");
			chessBoard.Add("24", "");
			chessBoard.Add("25", "");
			chessBoard.Add("26", "");
			chessBoard.Add("27", "");

			chessBoard.Add("30", "");
			chessBoard.Add("31", "");
			chessBoard.Add("32", "");
			chessBoard.Add("33", "");
			chessBoard.Add("34", "WB");
			chessBoard.Add("35", "");
			chessBoard.Add("36", "");
			chessBoard.Add("37", "");

			chessBoard.Add("40", "");
			chessBoard.Add("41", "");
			chessBoard.Add("42", "");
			chessBoard.Add("43", "");
			chessBoard.Add("44", "");
			chessBoard.Add("45", "");
			chessBoard.Add("46", "");
			chessBoard.Add("47", "");

			chessBoard.Add("50", "");
			chessBoard.Add("51", "");
			chessBoard.Add("52", "");
			chessBoard.Add("53", "");
			chessBoard.Add("54", "");
			chessBoard.Add("55", "");
			chessBoard.Add("56", "");
			chessBoard.Add("57", "");

			chessBoard.Add("60", "SB");
			chessBoard.Add("61", "SB");
			chessBoard.Add("62", "SB");
			chessBoard.Add("63", "SB");
			chessBoard.Add("64", "SB");
			chessBoard.Add("65", "SB");
			chessBoard.Add("66", "SB");
			chessBoard.Add("67", "SB");

			chessBoard.Add("70", "ST");
			chessBoard.Add("71", "SS");
			chessBoard.Add("72", "SL");
			chessBoard.Add("73", "SD");
			chessBoard.Add("74", "SK");
			chessBoard.Add("75", "SL");
			chessBoard.Add("76", "SS");
			chessBoard.Add("77", "ST");
		}

		public delegate void printBoardStyle(Dictionary<String, String> chessBoard);



        public void printChessBoard()
        {
			initChessBoaard();

			List<String> oneRowOfBoard = new List<String>();
			foreach (KeyValuePair<String, string> entry in chessBoard)
			{
				try
				{
					int x_coord = int.Parse(entry.Key.Substring(0, 1));
					int y_coord = int.Parse(entry.Key.Substring(1, 1));

					if ((x_coord + y_coord) % 2 == 0) // is it a black field?
					{
						oneRowOfBoard.Add(entry.Value + "SF"); // makes from ST for example STSF = SchwarzerTurmSchwarzesFeld
					}
					else
					{
						oneRowOfBoard.Add(entry.Value + "WF"); // makes from ST for example STWF = SchwarzerTurmWeißesFeld
					}

					if (y_coord == 7) // new row on chessboard
					{
						listOfPieces.Add(oneRowOfBoard);
						oneRowOfBoard = new List<String>();

					}
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
					return;
				}

			} // end for loop

			// now print backwards each row of the generated listOfPieces
			for (int i = listOfPieces.Count() - 1; i >= 0; i--)
			{
				for (int linecounter = 0; linecounter < 5; linecounter++)// each piece in the map of asciis consits of 5 rows
				{
					for (int j = 0; j < listOfPieces[i].Count(); j++)
					{
						String mapKeyOfPiece = listOfPieces[i][j]; // e.g. STSF
						String[] asciiPieceAndField = AsciiChessFigure.getInstance().getAscii(mapKeyOfPiece);

						Console.Write(asciiPieceAndField[linecounter]);
					}
					Console.WriteLine();
				}
			}



		}
	}
}
