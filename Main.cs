using System;
using System.Threading;

namespace P3D
{
    class app
    {
        static void Main()
        {

            Setting source = new Setting();
            Screen screen = new Screen(source);
            //System.Console.WriteLine(" \frac{h'}{2} left(1-\frac{1}{d}\right) qquad");
            //flagGame = true;
            Console.Clear();
            while (source.flagGame)
            {

                for (int x = 0; x < source.ScreenWidth; x++)
                {
                    float RayAngle = (source.PlayerA - source.FOV / 2.0f) + ((float)x /
                        (float)source.ScreenWidth) * source.FOV;
                    float DistanceToWall = 0.0f;
                    bool HitWall = false;
                    float EyeX = (float)Math.Sin(RayAngle);
                    float EyeY = (float)Math.Cos(RayAngle);
                    while (!HitWall && DistanceToWall < source.Depth)
                    {
                        DistanceToWall += 0.1f;
                        int TestX = (int)(source.PlayerX + EyeX * DistanceToWall);
                        int TestY = (int)(source.PlayerY + EyeY * DistanceToWall);
                        if (TestX < 0 || TestX >= source.MapWidth || TestY < 0 || TestY >= source.MapHeight)
                        {
                            HitWall = true;
                            DistanceToWall = source.Depth;
                        }
                        else if (source.map[TestY][TestX] == '#') HitWall = true;
                        // for (int y = 0; y < sorce.ScreenHeight; y++)
                        // {

                        // }
                    }
                    int Ceiling = (int)((source.ScreenHeight / 2.0f) - source.ScreenHeight / DistanceToWall);
                    int Floor = source.ScreenHeight - Ceiling;
                    short ShadeChar = (short)'u';
                    /* if (DistanceToWall <= source.Depth * .05f) ShadeChar = 9609;//0x2588;
                    else if (DistanceToWall < source.Depth * .1f) ShadeChar = 9610;//0x2593;
                    else if (DistanceToWall < source.Depth * .2f) ShadeChar = 9611;// 0x2592;
                    else if (DistanceToWall < source.Depth * .3f) ShadeChar = 9612;//0x2591;
                    else if (DistanceToWall < source.Depth * .5f) ShadeChar = 9613;
                    else if (DistanceToWall < source.Depth * .7f) ShadeChar = 9614;
                    else if (DistanceToWall < source.Depth * .9f) ShadeChar = 9615;
                    else if (DistanceToWall < source.Depth) ShadeChar = (short)'`';//(short)'X';
                    else ShadeChar = (short)' '; */
                    if (DistanceToWall <= source.Depth * .05f) ShadeChar = 9608;//0x2588;
                    else if (DistanceToWall < source.Depth * .1f) ShadeChar = 9619;//0x2593;
                    else if (DistanceToWall < source.Depth * .2f) ShadeChar = 9611;// 0x2592;
                    else if (DistanceToWall < source.Depth * .3f) ShadeChar = 9612;//0x2591;
                    else if (DistanceToWall < source.Depth * .5f) ShadeChar = 9613;
                    else if (DistanceToWall < source.Depth * .7f) ShadeChar = 9614;
                    else if (DistanceToWall < source.Depth * .9f) ShadeChar = 9615;
                    else if (DistanceToWall < source.Depth) ShadeChar = (short)'`';//(short)'X';
                    else ShadeChar = (short)' ';
                    for (int y = 0; y < source.ScreenHeight; y++)
                    {
                        if (y <= Ceiling) screen.screen[y][x] = ' ';
                        else if (y > Ceiling && y <= Floor)
                            screen.screen[y][x] = (char)ShadeChar;
                        else
                        {
                            char ch = ' ';
                            float b = 1.0f - ((float)y - source.ScreenHeight / 2.0f) / ((float)source.ScreenHeight / 2.0f);
                            if (b < 0.25) ch = '=';
                            else if (b < .5f) ch = '~';
                            else if (b < .75) ch = '-';
                            else if (b < .9) ch = '`';
                            else ch = ' ';
                            screen.screen[y][x] = ch;
                        }
                    }
                }
                for (int y = 15; y >= 0; y--)
                {
                    for (int x = 0, xR = 15; x < 16; x++, xR--)
                    {
                        screen.screen[y][xR] = source.map[y][x];
                    }
                }
                screen.screen[(int)source.PlayerY][source.MapWidth - (int)source.PlayerX-1] = 'P';
                Screen.Display(screen);
                //sorce.PlayerA += .1f;
                Thread.Sleep(100);
                Control.Move(source);
                //if(Console.KeyAvailable) flagGame = false;
                   System.Console.WriteLine();
               /* for (int i = 9500; i < 10000; i++)
               {
                   System.Console.Write((char)i);
                   if(i%10 == 0) System.Console.Write(i);
               } */
            }
        }
    }
}