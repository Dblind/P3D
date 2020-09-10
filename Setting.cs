using System;

namespace P3D
{
    class Setting
    {
        public bool flagGame = true;
        public int ScreenWidth = 160;
        public int ScreenHeight = 40;
        public float PlayerX = 8.0f;
        public float PlayerY = 2.0f;
        public float PlayerA = .0f;
        public int MapHeight = 16, MapWidth = 16;
        public float FOV = 3.14159f / 3;
        public float Depth = 14.0f;
        public UInt16 BytesWritten = 0;
        public string[] map = new string[16];

        public Setting()
        {
            map[0] = map[MapWidth - 1] = "################";
            /* for (int i = 1; i < MapWidth - 1; i++)
            {
                map[i] = "#..............#";
            } */
            map[2] = "#..........##..#";
            map[3] = "#..........##..#";
            map[4] = "#..........##..#";
            map[5] = "#..............#";
            map[6] = "#..............#";
            map[7] = "#..##..........#";
            map[8] = "#..##..........#";
            map[9] = "#..##.##########";
            map[10] = "#..##..........#";
            map[11] = "#..###########.#";
            map[12] = "#..##..........#";
            map[13] = "#..##.##########";
            map[14] = "#..##..........#";
            //map[15] = "#..##..........#";
            //map[16] = "#..##..........#";
            //map[17] = "#..##..........#";
            //map[18] = "#..##..........#";
            //         1234512345123451            
             map[1] = "#..............#";
            // map[4] = "#......##......#";
            // map[5] = "#......##......#";


        }

        //public string[] Ma5p { get => ma5p; set => ma5p = value; }

    }

}