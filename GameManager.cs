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

        public Tetromino NextBlock;


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
        private Tetromino GenerateRandomBlock() 
        {
            int blockIndex = RandomInteger.Next(0, TetrisBlock.AllBlocks.Length);
            int[,] block = TetrisBlock.AllBlocks[blockIndex];

            return new Tetromino(block, 0, 0, blockIndex+1);
        }

        public void SpawnNewBlock() 
        {

            int StartRow = 0;
            int StartCol = GameGrid.Columns / 2 - 1;

            if (CurrentBlock == null)
            {
                CurrentBlock = GenerateRandomBlock();
                CurrentBlock.Reset(CurrentBlock.getCurrentBlock(), StartRow, StartCol, CurrentBlock.getBlockID());

                NextBlock = GenerateRandomBlock();
            }
            else 
            {
                CurrentBlock = NextBlock;
                CurrentBlock.Reset(CurrentBlock.getCurrentBlock(), StartRow, StartCol, CurrentBlock.getBlockID());

                NextBlock = GenerateRandomBlock();
            }

            if (!GameGrid.CanPlaceBlock(CurrentBlock.getCurrentBlock(), CurrentBlock.getCurrentRow(), CurrentBlock.getCurrentColumn())) 
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
                score += GameGrid.completedRows * 100;
                GameGrid.completedRows = 0;
                SpawnNewBlock();
            }
        }

        public void RotateBlock() 
        {
            if (CurrentBlock == null|| isGameOver|| isPaused) return;

            int[,] rotatedBlock = RotationHelper.RotateClockwise(CurrentBlock.getCurrentBlock());

            if (GameGrid.CanPlaceBlock(rotatedBlock, CurrentBlock.getCurrentRow(), CurrentBlock.getCurrentColumn())) 
            {
                CurrentBlock.Reset(rotatedBlock, CurrentBlock.getCurrentRow(), CurrentBlock.getCurrentColumn(), CurrentBlock.getBlockID());
            } ;
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
