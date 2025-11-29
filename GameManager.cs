using System;
using System.Collections.Generic;
using System.Text;

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


        }

        public void SpawnNewBlock() 
        {
            CurrentBlock = 
        }

        
    }
}
