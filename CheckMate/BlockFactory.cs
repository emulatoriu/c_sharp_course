/// <summary>
/// Summary description for BlockFactory.
/// </summary>

using System;

namespace CheckMate.Graphix
{

	internal class BlockFactory 
	{
		BlockRect bBlockRect, wBlockRect;
		
		internal BlockFactory()	
		{
			wBlockRect = new WhiteRect();
			bBlockRect = new BlackRect();
		}
		~BlockFactory()
		{
			//if (wBlockRect != null)
			//	wBlockRect.Dispose();

			//if (bBlockRect != null)
			//	bBlockRect.Dispose();
		}


		internal BlockRect GetBlockRect(BlockColor bColor)	
		{
			switch ( bColor)
			{
				case BlockColor.WHITE:
						return wBlockRect;
				case BlockColor.BLACK:
						return bBlockRect;
				default: 
						throw( new Exception("BlockFactory.GetBlockRect : Invalid BlockColor") );
						
			}
		}

	}
}
