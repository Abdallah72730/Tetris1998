using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris1998
{
    public class Shape
    {
        private int r;
        private int c;
        private int[,] Block;

        public Shape(int r, int c ) 
        {
            this.r = r;
            this.c = c;
            
        }
    }
}
