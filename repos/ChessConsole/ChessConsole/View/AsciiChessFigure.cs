using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessConsole.View
{
    internal class AsciiChessFigure
    {
		private static AsciiChessFigure printedBoard = new AsciiChessFigure();
		private Dictionary<String, String[]> chessFiguresAscii = new Dictionary<String, String[]>();

		public static AsciiChessFigure getInstance()
		{
			return printedBoard;
		}

		public Dictionary<String, String[]> getChessBoard()
		{
			return chessFiguresAscii;
		}

		public String[] getAscii(String key)
		{
			return chessFiguresAscii.GetValueOrDefault(key);
		}

		public AsciiChessFigure()
		{
			String[] SF = {"#########",
				"#########",
				"#########",
				"#########",
				"#########"};
			chessFiguresAscii.Add("SF", //Schwarzes Feld
					SF);

			String[] WF = {"         ",
				"         ",
				"         ",
				"         ",
				"         "};
			chessFiguresAscii.Add("WF", // Weißes Feld 
					WF);

			String[] STWF = {"         ",
				  " [`'`']  ",
				  "  |::|   ",
				  "  |::|   ",
				  "         "};
			chessFiguresAscii.Add("STWF", // SchwarzerTurmWeißesFeld 
						STWF);

			String[] WTWF = {"         ",
				  " [`'`']  ",
				  "  |  |   ",
				  "  |  |   ",
				  "         "};
			chessFiguresAscii.Add("WTWF", // WeißerTurmWeißesFeld 
					WTWF);

			String[] STSF = {"#########",
				"#[`'`']##",
				"##|::|###",
				"##|::|###",
				"#########"};
			chessFiguresAscii.Add("STSF", // SchwarzerTurmSchwarzesFeld 
					  STSF);

			String[] WTSF = {"#########",
				"#[`'`']##",
				"##|  |###",
				"##|  |###",
				"#########"};
			chessFiguresAscii.Add("WTSF", // WeißerTurmSchwarzesFeld 
					  WTSF);

			String[] WBWF = {"    _    ",
				"   (_)   ",
				"   | |   ",
				"   |_|   ",
				"         "};
			chessFiguresAscii.Add("WBWF", // WeißerBauerWeißesFeld 
					  WBWF);

			String[] SBWF = {"    _    ",
				"   (:)   ",
				"   |:|   ",
				"   |:|   ",
				"         "};
			chessFiguresAscii.Add("SBWF", // SchwarzerBauerWeißesFeld 
					  SBWF);

			String[] WBSF = {"#########",
				  "###(_)###",
				  "###| |###",
				  "###|_|###",
				  "#########"};
			chessFiguresAscii.Add("WBSF", // WeißerBauerSchwarzesFeld 
						WBSF);

			String[] SBSF = {"#########",
				  "###(:)###",
				  "###|:|###",
				  "###|:|###",
				  "#########"};
			chessFiguresAscii.Add("SBSF", // SchwarzerBauerSchwarzesFeld 
					SBSF);

			String[] SSSF = {"#########",
				"##\\`.'/##",
				"##(o:o)##",
				"###\\:/:\\#",
				"####\"####"};
			chessFiguresAscii.Add("SSSF", // SchwarzerSpringerSchwarzesFeld 
					  SSSF);

			String[] WSSF = {"#########",
				"##\\` '/##",
				"##(o o)##",
				"###\\ / \\#",
				"####\"####"};
			chessFiguresAscii.Add("WSSF", // WeißerSpringerSchwarzesFeld 
					  WSSF);

			String[] SSWF = {"         ",
				  "  \\`.'/  ",
				  "  (o:o)  ",
				  "   \\:/:\\ ",
				  "    \"    "};
			chessFiguresAscii.Add("SSWF", // SchwarzerSpringerSchwarzesFeld 
						SSWF);

			String[] WSWF = {"         ",
				  "  \\` '/  ",
				  "  (o o)  ",
				  "   \\ / \\ ",
				  "    \"    "};
			chessFiguresAscii.Add("WSWF", // WeißerSpringerWeißesFeld 
					WSWF);


			String[] WLSF = {"#########",
				"##'\\v/`##",
				"##(o 0)##",
				"###(_)###",
				"#########"};
			chessFiguresAscii.Add("WLSF", // WeißerLäuferSchwarzesFeld 
					  WLSF);

			String[] WLWF = {"         ",
				  "  '\\v/`  ",
				  "  (o 0)  ",
				  "   (_)   ",
				  "         "};
			chessFiguresAscii.Add("WLWF", // WeißerLäuferWeißesFeld 
					WLWF);

			String[] SLWF = {"         ",
				"  ':v:`  ",
				"  (o:0)  ",
				"   (:)   ",
				"         "};
			chessFiguresAscii.Add("SLWF", // WeißerLäuferWeißesFeld 
					  SLWF);

			String[] SLSF = {"#########",
				"##':v:`##",
				"##(o:0)##",
				"###(:)###",
				"#########"};
			chessFiguresAscii.Add("SLSF", // WeißerLäuferWeißesFeld 
					  SLSF);

			String[] SKWF = {"   ___   ",
				"  /\\*/\\  ",
				" /(o o)\\ ",
				"   (_)   ",
				"         "};
			chessFiguresAscii.Add("SKWF", // WeißerLäuferWeißesFeld 
					  SKWF);

			String[] SKSF = {"###___###",
				  "##/\\*/\\##",
				  "#/(o o)\\#",
				  "###(_)###",
				  "#########"};
			chessFiguresAscii.Add("SKSF", // WeißerLäuferWeißesFeld 
					SKSF);

			String[] WKSF = {"#########",
				"##|`+'|##",
				"##(o o)##",
				"###(_)###",
				"#########"};
			chessFiguresAscii.Add("WKSF", // WeißerLäuferWeißesFeld 
					  WKSF);

			String[] WKWF = {"         ",
				  "  |`+'|  ",
				  "  (o o)  ",
				  "   (_)   ",
				  "         "};
			chessFiguresAscii.Add("WKWF", // WeißerLäuferWeißesFeld 
					WKWF);

			String[] SDSF = {"#########",
				"##/\\:/\\##",
				"#/(o:o)\\#",
				"###(:)###",
				"#########"};
			chessFiguresAscii.Add("SDSF", // WeißerLäuferWeißesFeld 
					  SDSF);

			String[] SDWF = {"         ",
				  "  /\\:/\\  ",
				  " /(o:o)\\ ",
				  "   (:)   ",
				  "         "};
			chessFiguresAscii.Add("SDWF", // WeißerLäuferWeißesFeld 
					SDWF);

			String[] WDWF = {"         ",
				"  |:+:|  ",
				"  (o:o)  ",
				"   (:)   ",
				"         "};
			chessFiguresAscii.Add("WDWF", // WeißerLäuferWeißesFeld 
					  WDWF);

			String[] WDSF = {"#########",
				  "##|:+:|##",
				  "##(o:o)##",
				  "###(:)###",
				  "#########"};
			chessFiguresAscii.Add("WDSF", // WeißerLäuferWeißesFeld 
					WDSF);

		}

	}
}
