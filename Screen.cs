using System;
using System.Text;

namespace P3D
{
    class Screen
    {
        public char[][] screen;
        StringBuilder sb;// = new StringBuilder(widthScreen).Append('.',120);
        
        public Screen(Setting s)
        {
            sb = new StringBuilder(s.ScreenWidth).Append('.',s.ScreenWidth);
            string Mask = sb.ToString();
            screen = new char[s.ScreenHeight][];

            for (int y = 0; y < s.ScreenHeight; y++)
            {
                // screen[y] = string.Clon
                //screen[y] = sb.ToString();
                screen[y] = Mask.ToCharArray();
            }
        }
        public static void Display(Screen s)
        {
            
            Console.CursorTop = 0; Console.CursorLeft = 0;
            string[] rowScreen = new string[s.screen.Length];
            for (int i = 0; i < rowScreen.Length; i++)
            {
                //d[i] = string. s.screen[i]
                s.sb.Clear(); s.sb.Append(s.screen[i]); rowScreen[i] = s.sb.ToString();
                System.Console.WriteLine(rowScreen[i]);
            }
        }
    }
}