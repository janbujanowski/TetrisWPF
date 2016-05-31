using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tetris
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public List<Element> PossibleElements;
        Board myBoard;
        System.Windows.Threading.DispatcherTimer Timer;
        public MainWindow()
        {
            InitializeComponent();
            
            PossibleElements = new List<Element>() {
                new Element(),new Element(), new Element(), new Element()
            };
            this.KeyDown += MainWindow_KeyDown;
        }
        void MainWindow_Initilized(object sender, EventArgs e)
        {
            Timer = new System.Windows.Threading.DispatcherTimer();
            Timer.Tick += new EventHandler(GameTick);
            Timer.Interval = new TimeSpan(0, 0, 1);
            GameStart();
        }

        private void GameStart()
        {
            MainGrid.Children.Clear();
            myBoard = new Board(MainGrid);
            Timer.Start();
        }

        private void GameTick(object sender, EventArgs e)
        {
            //Score.Content = myBoard.GetScore().ToString("000000000");
            myBoard.CurrentElementMoveDown();
        }
        void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left:
                    if (Timer.IsEnabled)
                    {
                        myBoard.CurrentElementMoveLeft();
                    }
                    break;
                case Key.Right:
                    if (Timer.IsEnabled)
                    {
                        myBoard.CurrentElementMoveRight();
                    }
                    break;
                case Key.Down:
                    if (Timer.IsEnabled)
                    {
                        myBoard.CurrentElementMoveDown();
                    }
                    break;
                default:
                    break;
            }
        }

        private void Move(object sender, EventArgs e)
        {
            Thread.Sleep(1000);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Define_Click(object sender, RoutedEventArgs e)
        {
            DefineShapes win2 = new DefineShapes();
            win2.DataContext = PossibleElements;
            win2.Show();
        }
    }
}
