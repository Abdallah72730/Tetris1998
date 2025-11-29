using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Controls.Primitives;

namespace Tetris1998
{
    public class GameManager
    {
        private GameGrid GameGrid;
        private Tetromino CurrentBlock;
        private Random RandomInteger;


        public bool isGameOver;
        public bool isPaused;
        public int score;

        public double fallSpeed;
        public double timeSinceLastFall;

        public GameManager(int rows, int cols) 
        {
            GameGrid = new GameGrid(rows, cols);
            RandomInteger = new Random();
            isGameOver = false;
            isPaused = false;
            score = 0;
            timeSinceLastFall = 0;
            fallSpeed = 1;
            new TetrisBlock();
        }

        public void StartGame() 
        {
            GameGrid.Reset();
            isGameOver = false;
            isPaused = false;
            score = 0;
            SpawnNewBlock();


        }

        public void SpawnNewBlock() 
        {
            int blockIndex = RandomInteger.Next(0, TetrisBlock.AllBlocks.Length);
            int[,] block = TetrisBlock.AllBlocks[blockIndex];

            int StartRow = 0;
            int StartCol = GameGrid.Columns / 2 - 1;

            if (CurrentBlock == null)
            {
                CurrentBlock = new Tetromino(block, StartRow, StartCol, blockIndex + 1);
            }
            else 
            {
                CurrentBlock.Reset(block, StartRow, StartCol, blockIndex+1);
            }

            if (!GameGrid.CanPlaceBlock(block, StartRow, StartCol)) 
            {             
                isGameOver = true;

            }
        }

        public void MoveBlockLeft() 
        {
            if (CurrentBlock == null) return;

            CurrentBlock.MoveLeft();

            if (!GameGrid.CanPlaceBlock(CurrentBlock.getCurrentBlock(), CurrentBlock.getCurrentRow(), CurrentBlock.getCurrentColumn()-1)) 
            {
                CurrentBlock.MoveRight();
                LockBlock();
            }
        }

        public void MoveBlockRight() 
        {
            if (CurrentBlock == null) return;

            CurrentBlock.MoveRight();
            if (!GameGrid.CanPlaceBlock(CurrentBlock.getCurrentBlock(), CurrentBlock.getCurrentRow(), CurrentBlock.getCurrentColumn() + 1)) 
            {
                CurrentBlock.MoveLeft();
                LockBlock();
            }
        }

        public void MoveBlockDown() 
        {
            if (CurrentBlock == null) return;

            CurrentBlock.MoveDown();

            if (!GameGrid.CanPlaceBlock(CurrentBlock.getCurrentBlock(), CurrentBlock.getCurrentRow() + 1, CurrentBlock.getCurrentColumn())) 
            {
                CurrentBlock.MoveUp();
                LockBlock();
            }
        }

        public void LockBlock() 
        {
            GameGrid.PlaceBlock(CurrentBlock.getCurrentBlock(), CurrentBlock.getCurrentRow(), CurrentBlock.getCurrentColumn());
        }

        public void  Update(double deltaTime) 
        {
            if (isGameOver || isPaused) return;

            timeSinceLastFall += deltaTime;

            if(timeSinceLastFall >= fallSpeed) 
            {
                MoveBlockDown();
                timeSinceLastFall = 0;
            }
        }


        
    }
}
