using System;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Text;
using System.Windows.Shapes;

namespace Tetris1998
{
    public class Tetromino
    {
        private int[,] CurrentBlock;
        private int CurrentRow;
        private int CurrentColumn;
        private int BlockID;

        public int getCurrentRow() 
        {
            return CurrentRow;
        }
        public int getCurrentColumn() 
        {
            return CurrentColumn;
        }

        public int getBlockID() 
        {
            return BlockID;
        }
        public int[,] getCurrentBlock() 
        {
            return CurrentBlock;
        } 
        public Tetromino(int[,] CurrentBlock, int row, int col, int BlockID )  
        {
            this.CurrentBlock = CurrentBlock;
            this.CurrentRow = row;  
            this.CurrentColumn = col;
            this.BlockID = BlockID;
        }

        public void undo() 
        {

        }
        public void MoveLeft() 
        {
             CurrentColumn--;
        }
        public void MoveUp() 
        {
            CurrentRow--;
        }
        public void MoveRight() { CurrentColumn++; }

        public void MoveDown() {  CurrentRow++; }

        public void Reset(int[,] block, int row, int col, int id) 
        {
            CurrentBlock = block;
            CurrentRow = row;
            CurrentColumn = col;
            BlockID = id;
        }
    }


}
