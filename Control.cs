using System;

namespace P3D
{
    class Control
    {
        static ConsoleKeyInfo key = new ConsoleKeyInfo();
        public static void Move(Setting s)
        {
            if (Console.KeyAvailable)
            {
                key = Console.ReadKey();
                switch ((char)key.KeyChar)
                {
                    case ('h'):
                        s.PlayerA -= .13f;
                        break;
                    case ('k'):
                        s.PlayerA += .13f;
                        break;
                    case ('u'):
                        s.PlayerX += (float)Math.Sin(s.PlayerA) * 1.0f;
                        s.PlayerY += (float)Math.Cos(s.PlayerA) * 1.0f;
                        if (s.map[(int)s.PlayerY][(int)s.PlayerX] == '#')
                        {
                            s.PlayerX -= (float)Math.Sin(s.PlayerA) * 1.0f;
                            s.PlayerY -= (float)Math.Cos(s.PlayerA) * 1.0f;
                        }
                        break;
                    case ('j'):
                        s.PlayerX -= (float)Math.Sin(s.PlayerA) * 1.0f;
                        s.PlayerY -= (float)Math.Cos(s.PlayerA) * 1.0f;
                        if (s.map[(int)s.PlayerY][(int)s.PlayerX] == '#')
                        {
                            s.PlayerX += (float)Math.Sin(s.PlayerA) * 1.0f;
                            s.PlayerY += (float)Math.Cos(s.PlayerA) * 1.0f;
                        }
                        break;
                    case ('q'):
                        s.flagGame = false;
                        break;
                }
            }
        }
    }
}