using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Hourglass
{
    class Program
    {
        public static class Display
        {
            public static List<string> FrameChar { get; set; } = new List<string>();
            public static StringBuilder FrameString { get; set; } = new StringBuilder();
            public static StringBuilder DisplayFrame { get; set; } = new StringBuilder();
            public static ConsoleColor Color { get; set; } = ConsoleColor.Yellow;
            public static int Width { get; set; } = 0;
            public static int Time { get; set; } = 30;
            public static Random Random { get; set; } = new Random();
        }

        static void Main(string[] args)
        {

            //Start Thred to Read Keypress
            Task.Factory.StartNew(() => Key.Press());

            //Pull in the Board
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Console.SetWindowSize(60, 40);
            }
            Console.CursorVisible = false;
            Console.Clear();
            Frame.SetFrame();
            Display.FrameChar.AddRange(Display.FrameString.ToString().Select(Chars => Chars.ToString()));

            //Set the Values for Movement Calculations
            string[] Lines = Display.FrameString.ToString().Split((char)10);
            Display.Width = Lines[0].Length + 1;

            // Display.Time is then used to sleep - so for 97 * the process needs to sleep 309ms for 30 seconds
            // since the process needs also runtime the sleep time needs to be reduced to about 270ms
            // so we have to reduce by another 40ms
            Display.Time = (Display.Time * 1000) / (Display.FrameString.ToString().Split('*').Length - 1);

            Display.Time = Display.Time - 40;

            //Console.WriteLine("Display Time = " + Display.Time);
            //Console.WriteLine(Display.FrameString.ToString().Split('*').Length - 1);
            //Console.WriteLine(Display.FrameString.ToString().Count(f => (f == '*')));

            //Thread.Sleep(10000);

            do
            {
                Console.ForegroundColor = Display.Color;

                foreach (int i in Enumerable.Range(0, Display.FrameChar.Count).OrderBy(x => Display.Random.Next()))
                {
                    int Direction = Display.Random.Next(0, 2) == 0 ? -1 : 1;

                    if (((i + Display.Width) > 1) && ((i + Display.Width + 1) < Display.FrameChar.Count) && Display.FrameChar[i] == "*")
                    {
                        foreach (int index in new[]
                        {
                            i + Display.Width,
                            i + Display.Width + Direction,
                            i + Display.Width - Direction
                        })
                        {
                            if (Display.FrameChar[index] == " ")
                            {
                                Display.FrameChar[i] = " ";
                                Display.FrameChar[index] = "*";
                                break;
                            }
                        }
                    }
                }

                //Update Display
                Display.DisplayFrame.Clear();
                Display.FrameChar.ForEach(Item => Display.DisplayFrame.Append(Item));
                //Display.DisplayFrame.Append(System.Environment.NewLine);

                //Write Display to Console
                Console.SetCursorPosition(0, 0);
                Console.Write(Display.DisplayFrame);
                System.Threading.Thread.Sleep(Display.Time/*270*/);

            } while (true);
        }
    }
}
