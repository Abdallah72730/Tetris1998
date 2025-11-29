using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Tetris1998
{
    public class GameGrid
    {
        public int Rows { get; private set; }
        public int Columns { get; private set; }

        private int[,] gameGrid;

        public int completedRows;

        public GameGrid(int rows, int cols) 
        {
            this.Rows = rows;
            this.Columns = cols;
            gameGrid = new int[rows, cols];
        }

        public bool IsCellEmpty(int r, int c) 
        {
            if (gameGrid[r, c] != 0) 
            {
                return false;
            }
            return true;
        }

        public bool isCellPositionValid(int r, int c) 
        {
            if (r > Rows - 1 || r < 0 || c > Columns - 1 || c < 0 ) 
            {
                return false;
            }
            return IsCellEmpty(r, c);
        }

        public void fixCell(int r, int c, int id) 
        {
            if (isCellPositionValid(r, c)) 
            {
                gameGrid[r, c] = id;
            }
        }

        public int GetCell(int row, int col) 
        {
            if (row >= 0 && row < Rows && col >= 0 && col < Columns) 
            {
                return gameGrid[row, col];
            }
            return 0;
        }

        public bool isRowFull(int r) 
        {
            for (int c = 0; c < Columns; c++) 
            {
                if (gameGrid[r, c] == 0) 
                {
                    return false;
                }
            }
            return true;
        }
        public void ClearRow(int row)
        {
            for (int c = 0; c < Columns; c++) 
            {
                gameGrid[row, c] = 0;
            }
        }

        public void clearCompletedRow() 
        {
            for (int rows = Rows-1; rows >= 0; rows--) 
            {
                if (isRowFull(rows)) 
                {
                    for (int r = rows; r > 0; r--) 
                    {
                        for (int c = 0; c < Columns; c++) 
                        {
                            gameGrid[r, c] = gameGrid[r - 1, c];
                        }
                        
                    }
                    ClearRow(0);
                    rows++;
                    completedRows++;
                }
                
            }
            
        }

        public bool CanPlaceBlock(int[,] Block, int row, int col) 
        {
            for (int r = 0; r < Block.GetLength(0); r++) 
            {
                for (int c = 0; c < Block.GetLength(1); c++) 
                {
                    if (Block[r, c] != 0) 
                    {
                        int gameGridRow = row + r;
                        int gameGridCol = col + c;

                        if (!isCellPositionValid(gameGridRow, gameGridCol)) 
                        {
                            return false;
                        }
                    }
                }
            }
            return true;

        }

        public void PlaceBlock(int[,] Block, int row, int col) 
        {
                for (int r = 0; r < Block.GetLength(0); r++) 
                {
                    for (int c = 0; c < Block.GetLength(1); c++) 
                    {
                        if (Block[r, c]!=0) {
                            gameGrid[row + r, col + c] = Block[r, c];
                        }

                    }
                }
        }

        public void Reset() 
        {
            for (int r = 0; r < Rows; r++) 
            {
                for (int c = 0; c < Columns; c++) 
                {
                    gameGrid[r, c] = 0;
                }
            }
            completedRows = 0;
        }


        public bool IsGameOver() 
        {
            for (int r = 0; r < 2; r++) 
            {
                for (int c = 0; c < Columns; c++) 
                {
                    if (gameGrid[r, c] != 0) 
                    {
                        return true;
                    }
                    
                }
            }
            return false;
        }
    }
}
