using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris1998
{
    public class GameManager
    {
        public GameGrid GameGrid;
        public Tetromino CurrentBlock;
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
            fallSpeed = 0.25;
        }

        public void StartGame() 
        {
            GameGrid.Reset();
            isGameOver = false;
            isPaused = false;
            score = 0;
            SpawnNewBlock();

            new TetrisBlock();
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


            if (GameGrid.CanPlaceBlock(CurrentBlock.getCurrentBlock(), CurrentBlock.getCurrentRow(), CurrentBlock.getCurrentColumn()-1)) 
            {
                CurrentBlock.MoveLeft();
            }
        }

        public void MoveBlockRight() 
        {
            if (CurrentBlock == null) return;

            
            if (GameGrid.CanPlaceBlock(CurrentBlock.getCurrentBlock(), CurrentBlock.getCurrentRow(), CurrentBlock.getCurrentColumn() + 1)) 
            {
                CurrentBlock.MoveRight();
            }
        }

        public void MoveBlockDown() 
        {
            if (CurrentBlock == null) return;



            if (GameGrid.CanPlaceBlock(CurrentBlock.getCurrentBlock(), CurrentBlock.getCurrentRow() + 1, CurrentBlock.getCurrentColumn()))
            {
                CurrentBlock.MoveDown();
            }
            else 
            {
                LockBlock();
                GameGrid.clearCompletedRow();
                score += GameGrid.completedRows;
                GameGrid.completedRows = 0;
                SpawnNewBlock();
            }
        }

        public void LockBlock() 
        {
            GameGrid.PlaceBlock(CurrentBlock.getCurrentBlock(), CurrentBlock.getCurrentRow(), CurrentBlock.getCurrentColumn());
        }

        public void Update(double deltaTime)
        {
            if (isGameOver || isPaused) 
            {
                return;
            }

            timeSinceLastFall += deltaTime;

            if (timeSinceLastFall >= fallSpeed) 
            {
                MoveBlockDown();
                timeSinceLastFall = 0;
            }
        }
        
    }
}
