using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks.Dataflow;

namespace Tetris1998
{
    public class TetrisBlock
    {
        public static int[][,] AllBlocks;
        private static int[,] IBlock = new int[,] { { 1, 1, 1, 1 } };

        private static int[,] OBlock = new int[,] { {2 , 2 },
                                                    { 2 , 2} };

        private static int[,] LBlock = new int[,] { { 3, 3 },
                                                      {0, 3},
                                                      {0, 3} };

        private static int[,] SBlock = new int[,] { { 0, 4, 4 },
                                                    { 4, 4, 0} };

        private static int[,] ZBlock = new int[,] { { 5, 5, 0 },
                                                    {0, 5, 5 } };

        private static int[,] TBlock = new int[,] { {0, 6, 0 },
                                                    {6, 6, 6 } };

        static TetrisBlock()
        {

            AllBlocks = new int[][,] { IBlock, OBlock, LBlock, SBlock, ZBlock, TBlock };

        }

    }
}
