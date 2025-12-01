using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Tetris1998
{
    public static class RotationHelper
    {
        public static int[,] RotateClockwise(int[,] block) 
        {
            int oldRows = block.GetLength(0);
            int oldCols = block.GetLength(1);

            int[,] RotatedBlock = new int[oldCols, oldRows];

            for (int r = 0; r < oldRows; r++) 
            {
                for (int c = 0; c < oldCols; c++) 
                {
                    RotatedBlock[c, oldRows -1-r] = block[r, c];
                }
            }
            return RotatedBlock;
        }
    }
}
