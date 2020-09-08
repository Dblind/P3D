using System;
using System.Threading;

namespace P3D
{
    class app
    {
        static void Main()
        {

            Setting sorce = new Setting();
            Screen screen = new Screen(sorce);
            //System.Console.WriteLine(" \frac{h'}{2} left(1-\frac{1}{d}\right) qquad");
            //flagGame = true;
            Console.Clear();
            while (sorce.flagGame)
            {

                for (int x = 0; x < sorce.ScreenWidth; x++)
                {
                    float RayAngle = (sorce.PlayerA - sorce.FOV / 2.0f) + ((float)x /
                        (float)sorce.ScreenWidth) * sorce.FOV;
                    float DistanceToWall = 0.0f;
                    bool HitWall = false;
                    float EyeX = (float)Math.Sin(RayAngle);
                    float EyeY = (float)Math.Cos(RayAngle);
                    while (!HitWall && DistanceToWall < sorce.Depth)
                    {
                        DistanceToWall += 0.1f;
                        int TestX = (int)(sorce.PlayerX + EyeX * DistanceToWall);
                        int TestY = (int)(sorce.PlayerY + EyeY * DistanceToWall);
                        if (TestX < 0 || TestX >= sorce.MapWidth || TestY < 0 || TestY >= sorce.MapHeight)
                        {
                            HitWall = true;
                            DistanceToWall = sorce.Depth;
                        }
                        else if (sorce.map[TestY][TestX] == '#') HitWall = true;
                        // for (int y = 0; y < sorce.ScreenHeight; y++)
                        // {

                        // }
                    }
                    int Ceiling = (int)((sorce.ScreenHeight / 2.0f) - sorce.ScreenHeight / DistanceToWall);
                    int Floor = sorce.ScreenHeight - Ceiling;
                    short ShadeChar = (short)'u';
                    if (DistanceToWall <= sorce.Depth * .05f) ShadeChar = 9609;//0x2588;
                    else if (DistanceToWall < sorce.Depth * .1f) ShadeChar = 9610;//0x2593;
                    else if (DistanceToWall < sorce.Depth * .2f) ShadeChar = 9611;// 0x2592;
                    else if (DistanceToWall < sorce.Depth * .3f) ShadeChar = 9612;//0x2591;
                    else if (DistanceToWall < sorce.Depth * .5f) ShadeChar = 9613;
                    else if (DistanceToWall < sorce.Depth * .7f) ShadeChar = 9614;
                    else if (DistanceToWall < sorce.Depth * .9f) ShadeChar = 9615;
                    else if (DistanceToWall < sorce.Depth) ShadeChar = (short)'`';//(short)'X';
                    else ShadeChar = (short)' ';
                    for (int y = 0; y < sorce.ScreenHeight; y++)
                    {
                        if (y <= Ceiling) screen.screen[y][x] = ' ';
                        else if (y > Ceiling && y <= Floor)
                            screen.screen[y][x] = (char)ShadeChar;
                        else
                        {
                            char ch = ' ';
                            float b = 1.0f - ((float)y - sorce.ScreenHeight / 2.0f) / ((float)sorce.ScreenHeight / 2.0f);
                            if (b < 0.25) ch = '#';
                            else if (b < .5f) ch = 'x';
                            else if (b < .25) ch = '~';
                            else if (b < .9) ch = '-';
                            else ch = ' ';
                            screen.screen[y][x] = ch;
                        }
                    }
                }
                for (int y = 15; y >= 0; y--)
                {
                    for (int x = 0, xR = 15; x < 16; x++, xR--)
                    {
                        screen.screen[y][xR] = sorce.map[y][x];
                    }
                }
                screen.screen[(int)sorce.PlayerY][(int)sorce.PlayerX] = 'P';
                Screen.Display(screen);
                //sorce.PlayerA += .1f;
                Thread.Sleep(100);
                Control.Move(sorce);
                //if(Console.KeyAvailable) flagGame = false;
                /*    System.Console.WriteLine();
               for (int i = 0x2570; i < 0x2600; i++)
               {
                   System.Console.Write((char)i);
                   if(i%10 == 0) System.Console.Write(i);
               } */
            }
        }
    }
}