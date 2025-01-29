/// <summary>
/// Summary description for ResWriter & ResReader.
/// </summary>

using System;
using System.Resources;
using System.Drawing;
using System.Collections;

namespace CheckMate.Graphix
{
	public class ResWriter 
	{
		private IResourceWriter writer;
		public ResWriter()
		{
			// Creates a resource writer.
			writer = new ResourceWriter("Chess.resources");
		}

		public void Close()
		{
			writer.Close();
		}

		public void WriteImage(string aName, Image aImage)
		{
			writer.AddResource(aName, aImage);
		}

		public void AddIcon(string filename)
		{
			Image image;

			image = Image.FromFile(filename);
			WriteImage("MAINICON", image);


		}

		public void AddImages()
		{
			Image image;

			image = Image.FromFile("./WhitePawn.gif");
			WriteImage("WHITEPAWN", image);

			image = Image.FromFile("./WhiteRook.gif");
			WriteImage("WHITEROOK", image);

			image = Image.FromFile("./WhiteKnight.gif");
			WriteImage("WHITEKNIGHT", image);

			image = Image.FromFile("./WhiteBishop.gif");
			WriteImage("WHITEBISHOP", image);

			image = Image.FromFile("./WhiteQueen.gif");
			WriteImage("WHITEQUEEN", image);

			image = Image.FromFile("./WhiteKing.gif");
			WriteImage("WHITEKING", image);

			image = Image.FromFile("./BlackPawn.gif");
			WriteImage("BLACKPAWN", image);

			image = Image.FromFile("./BlackRook.gif");
			WriteImage("BLACKROOK", image);

			image = Image.FromFile("./BlackKnight.gif");
			WriteImage("BLACKKNIGHT", image);

			image = Image.FromFile("./BlackBishop.gif");
			WriteImage("BLACKBISHOP", image);

			image = Image.FromFile("./BlackQueen.gif");
			WriteImage("BLACKQUEEN", image);

			image = Image.FromFile("./BlackKing.gif");
			WriteImage("BLACKKING", image);
		}

	}

	public class ResReader
	{
		private IResourceReader reader;

		public ResReader()
		{
			// Creates a resource writer.
			reader = new ResourceReader("Chess.resources");
		}


		public void Close()
		{
			reader.Close();
		}

		public Image ReadImage(String aName)
		{

			// Create an IDictionaryEnumerator to iterate through the resources.
			IDictionaryEnumerator id = reader.GetEnumerator(); 

			// Iterate through the resources and display the contents to the console. 
			while(id.MoveNext())
			{
				if (id.Key.ToString() == aName)
					return (Image) id.Value;
			}

			return null;
		}

	}



}
