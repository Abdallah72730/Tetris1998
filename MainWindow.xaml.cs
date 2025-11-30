using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Tetris1998
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameManager gameManager;
        private DispatcherTimer gameTimer;
        private const int CellSize = 24;
        private Dictionary<int, SolidColorBrush> BlockColors;




        public MainWindow()
        {
            InitializeComponent();
            BlockColors = new Dictionary<int, SolidColorBrush> 
            {
                {1, Brushes.Cyan },
                { 2, Brushes.Red },
                { 3, Brushes.Green },
                { 4, Brushes.Blue },
                { 5, Brushes.Yellow },
                { 6, Brushes.Orange}
            };
            gameManager = new GameManager(20, 10);
            gameManager.StartGame();
            gameTimer = new DispatcherTimer();
            gameTimer.Interval = TimeSpan.FromMilliseconds(16);
            gameTimer.Tick += Timer_Tick;
            gameTimer.Start();
            this.KeyDown += Window_KeyDown;
            DrawGridlines();
        }

        public void Window_KeyDown(object sender, KeyEventArgs e) 
        {
            if (gameManager.isGameOver || gameManager.isPaused) return;

            switch (e.Key) 
            {
                case Key.Left: gameManager.MoveBlockLeft(); break;
                case Key.Right: gameManager.MoveBlockRight(); break;
                case Key.Down: gameManager.MoveBlockDown(); break;
                default: break;
            }
            DrawGame();
            UpdateScoreDisplay();
        }

        public void Timer_Tick(object sender, EventArgs e) 
        {
            double deltaTime = 0.016;
            gameManager.Update(deltaTime);
            UpdateScoreDisplay();
            DrawGame(); 
        }

        public void DrawGame() 
        {
            Canvas.Children.Clear();
            DrawGridlines();
            DrawGrid();
            DrawCurrentBlock();
        }

        public void DrawGrid() 
        {
            for (int rows = 0; rows < gameManager.GameGrid.Rows; rows++) 
            {
                for (int cols = 0; cols < gameManager.GameGrid.Columns; cols++) 
                {
                    int CellValue = gameManager.GameGrid.GetCell(rows, cols);

                    if (CellValue != 0) 
                    {
                        Rectangle cell = new Rectangle();
                        cell.Width = CellSize;
                        cell.Height = CellSize;
                        cell.Fill = BlockColors[CellValue];
                        Canvas.SetLeft(cell, cols*CellSize);
                        Canvas.SetTop(cell, rows*CellSize);

                        Canvas.Children.Add(cell);
                    }
                }
            }
        }

        public void DrawCurrentBlock() 
        {
            int[,] currentBlock = gameManager.CurrentBlock.getCurrentBlock();
            int CurrentRow = gameManager.CurrentBlock.getCurrentRow();
            int CurrentColumn = gameManager.CurrentBlock.getCurrentColumn();
            int BlockID = gameManager.CurrentBlock.getBlockID();

            for (int r = 0; r < currentBlock.GetLength(0); r++) 
            {
                for(int c =0; c< currentBlock.GetLength(1); c++) 
                {
                    if (currentBlock[r, c] != 0) 
                    {
                        Rectangle CurrentBlockCell = new Rectangle();
                        CurrentBlockCell.Width = CellSize;
                        CurrentBlockCell.Height = CellSize;

                        CurrentBlockCell.Fill = BlockColors[BlockID];

                        int x = (CurrentColumn + c) * CellSize;
                        int y = (CurrentRow + r) * CellSize;

                        Canvas.SetLeft(CurrentBlockCell, x);
                        Canvas.SetTop(CurrentBlockCell, y);

                        Canvas.Children.Add(CurrentBlockCell);
                    }
                }
            }
        }

        public void DrawGridlines() 
        {
            for (int r = 0; r < gameManager.GameGrid.Rows; r++) 
            {
                Line HLine = new Line();
                HLine.X1 = 0;
                HLine.Y1 = r*CellSize;
                HLine.X2 = gameManager.GameGrid.Columns*CellSize;
                HLine.Y2 = r*CellSize;

                HLine.Stroke = Brushes.Gray;
                HLine.StrokeThickness = 1;

                Canvas.Children.Add(HLine);
            }

            for (int c = 0; c < gameManager.GameGrid.Columns; c++) 
            {
                Line VLine = new Line();

                VLine.X1 = c*CellSize;
                VLine.Y1 = 0;
                VLine.X2 = c*CellSize;
                VLine.Y2 = gameManager.GameGrid.Rows*CellSize;

                VLine.Stroke = Brushes.Gray;
                VLine.StrokeThickness = 1;
                Canvas.Children.Add(VLine);

            }
        }

        public void UpdateScoreDisplay() 
        {
            ScoreText.Text = $"Score: {gameManager.score}";
        }

    }
}