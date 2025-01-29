using System;
using System.Drawing;

namespace CheckMate.Engine
{
	/// <summary>
	/// Summary description for HelperFunction.
	/// </summary>
	internal class HelperFunction
	{
		public HelperFunction()
		{
		}

		private static bool Validate(int x, int y)
		{
			return ((x>=0) && (x<=7) && (y>=0) && (y<=7));
		}


		protected internal static bool IncX( ref Point aPosition)
		{
			if (Validate(aPosition.X + 1, aPosition.Y))
			{
				aPosition.X =  (aPosition.X + 1);
				return true;
			}
			else
				return false;
		}

		protected internal static bool DecX( ref Point aPosition)
		{
			if (Validate(aPosition.X - 1, aPosition.Y))
			{
				aPosition.X =  (aPosition.X - 1);
				return true;
			}
			else
				return false;
		}

		protected internal static bool IncY( ref Point aPosition)
		{
			if (Validate(aPosition.X , aPosition.Y + 1))
			{
				aPosition.Y = aPosition.Y + 1;
				return true;
			}
			else
				return false;
		}

		protected internal static bool DecY( ref Point aPosition)
		{
			if (Validate(aPosition.X , aPosition.Y - 1))
			{
				aPosition.Y = aPosition.Y - 1;
				return true;
			}
			else
				return false;
		}



		protected internal static bool IncXDecY( ref Point aPosition)
		{
			if (Validate(aPosition.X + 1 , aPosition.Y - 1))
			{
				aPosition.X = aPosition.X + 1;
				aPosition.Y = aPosition.Y - 1;
				return true;
			}
			else
				return false;
		}

		protected internal static bool DecXDecY( ref Point aPosition)
		{
			if (Validate(aPosition.X - 1 , aPosition.Y - 1))
			{
				aPosition.X = aPosition.X - 1;
				aPosition.Y = aPosition.Y - 1;
				return true;
			}
			else
				return false;
		}

		protected internal static bool DecXIncY( ref Point aPosition)
		{
			if (Validate(aPosition.X - 1 , aPosition.Y + 1))
			{
				aPosition.X = aPosition.X- 1;
				aPosition.Y = aPosition.Y + 1;
				return true;
			}
			else
				return false;
		}

		protected internal static bool IncXIncY( ref Point aPosition)
		{
			if (Validate(aPosition.X + 1 , aPosition.Y + 1))
			{
				aPosition.X = aPosition.X + 1;
				aPosition.Y = aPosition.Y + 1;
				return true;
			}
			else
				return false;
		}


		// UP
		protected internal static bool KnightUpLeft( ref Point aPosition)
		{
			if (DecY(ref aPosition) && DecY(ref aPosition) && DecX(ref aPosition))
				return true;
			else
				return false;
		}

		protected internal static bool KnightUpRight( ref Point aPosition)
		{
			if (DecY(ref aPosition) && DecY(ref aPosition) && IncX(ref aPosition))
				return true;
			else
				return false;
		}

		// Down
		protected internal static bool KnightDownLeft( ref Point aPosition)
		{
			if (IncY(ref aPosition) && IncY(ref aPosition) && DecX(ref aPosition))
				return true;
			else
				return false;
		}

		protected internal static bool KnightDownRight( ref Point aPosition)
		{
			if (IncY(ref aPosition) && IncY(ref aPosition) && IncX(ref aPosition))
				return true;
			else
				return false;
		}

		//Left
		protected internal static bool KnightLeftUp( ref Point aPosition)
		{
			if (DecX(ref aPosition) && DecX(ref aPosition) && DecY(ref aPosition))
				return true;
			else
				return false;
		}

		protected internal static bool KnightLeftDown( ref Point aPosition)
		{
			if (DecX(ref aPosition) && DecX(ref aPosition) && IncY(ref aPosition))
				return true;
			else
				return false;
		}

		// Right
		protected internal static bool KnightRightUp( ref Point aPosition)
		{
			if (IncX(ref aPosition) && IncX(ref aPosition) && DecY(ref aPosition))
				return true;
			else
				return false;
		}

		protected internal static bool KnightRightDown( ref Point aPosition)
		{
			if (IncX(ref aPosition) && IncX(ref aPosition) && IncY(ref aPosition))
				return true;
			else
				return false;
		}


	}
}
