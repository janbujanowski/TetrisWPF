using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Tetris
{
    class Board
    {
        private int Rows;
        private int Columns;
        private int Score;
        private int LinesFilled;
        public Element Element;
        private Label[,] BlockControls;

        static private Brush NoBrush = Brushes.Transparent;
        static private Brush SilverBrush = Brushes.Gray;
        public Board(Grid TetrisGrid)
        {
            Rows = TetrisGrid.RowDefinitions.Count;
            Columns = TetrisGrid.ColumnDefinitions.Count;
            Score = 0;
            LinesFilled = 0;
            BlockControls = new Label[Columns, Rows];

            for (int i = 0; i < Columns; i++)
            {
                for (int j = 0; j < Rows; j++)
                {
                    BlockControls[i, j] = new Label();
                    BlockControls[i, j].Background = NoBrush;
                    BlockControls[i, j].BorderBrush = SilverBrush;
                    BlockControls[i, j].BorderThickness = new System.Windows.Thickness(1, 1, 1, 1);
                    Grid.SetColumn(BlockControls[i, j], i);
                    Grid.SetRow(BlockControls[i, j], j);
                    TetrisGrid.Children.Add(BlockControls[i, j]);
                }
            }

            Element = new Element();
            DrawElement();
        }

        private void EraseElement()
        {
            Point Position = Element.GetPosition();
            Point[] Shape = Element.GetShape();
            foreach (Point a in Shape)
            {
                BlockControls[(int)(a.X + Position.X) + ((Columns / 2) - 1), (int)(a.Y + Position.Y) ].Background = NoBrush;
            }
        }

        private void DrawElement()
        {
            Point Position = Element.GetPosition();
            Point[] Shape = Element.GetShape();
            Brush Color = Element.GetColor();
            foreach (Point a in Shape)
            {
                BlockControls[((int)(a.X + Position.X) + ((Columns / 2) - 1)), (int)(a.Y + Position.Y) ].Background = Color;
            }
        }

        public int GetScore()
        {
            return Score;
        }
        public int GetLines()
        {
            return LinesFilled;
        }



        public void CheckRows()
        {
            bool full;
            for (int i = Rows - 1; i > 0; i--)
            {
                full = true;
                for (int j = 0; j < Columns; j++)
                {
                    if (BlockControls[j, i].Background == NoBrush)
                    {
                        full = false;
                    }
                }
                if (full)
                {
                    RemoveRow(i);
                    Score += 100;
                    LinesFilled += 1;
                }
            }

        }
        public void RemoveRow(int row)
        {
            for (int i = row; i > 2; i--)
            {
                for (int j = 0; j < Columns; j++)
                {
                    BlockControls[j, i].Background = BlockControls[j, i - 1].Background;

                }
            }
        }
        public void CurrentElementMoveLeft()
        {
            Point Position = Element.GetPosition();
            Point[] Shae = Element.GetShape();
            bool move = true;
            EraseElement();
            foreach (Point a in Shae)
            {
                if (((int)(a.X + Position.X) + ((Columns / 2) - 1) - 1) < 0)
                {
                    move = false;
                }

                else if (BlockControls[((int)(a.X + Position.X) + ((Columns / 2) - 1) - 1), (int)(a.Y + Position.Y) ].Background != NoBrush)
                {
                    move = false;
                }
            }
            if (move)
            {
                Element.MoveLeft();
                DrawElement();
            }
            else
            {
                DrawElement();
            }

        }
        public void CurrentElementMoveRight()
        {
            Point Position = Element.GetPosition();
            Point[] Shae = Element.GetShape();
            bool move = true;
            EraseElement();
            foreach (Point a in Shae)
            {
                if (((int)(a.X + Position.X) + ((Columns / 2) - 1) + 1) >= Columns)
                {
                    move = false;
                }

                else if (BlockControls[((int)(a.X + Position.X) + ((Columns / 2) - 1) + 1), (int)(a.Y + Position.Y) ].Background != NoBrush)
                {
                    move = false;
                }
            }
            if (move)
            {
                Element.MoveRight();
                DrawElement();
            }
            else
            {
                DrawElement();
            }
        }

        internal void CurrentElementMoveDown()
        {
            Point Position = Element.GetPosition();
            Point[] Shae = Element.GetShape();
            bool move = true;
            EraseElement();
            foreach (Point a in Shae)
            {
                if ((int)(a.Y + Position.Y)  + 1 >= Rows)
                {
                    move = false;
                }

                else if (BlockControls[((int)(a.X + Position.X) + (Columns / 2) - 1), (int)(a.Y + Position.Y)  + 1].Background != NoBrush)
                {
                    move = false;
                }
            }
            if (move)
            {
                Element.MoveDown();
                DrawElement();
            }
            else
            {
                DrawElement();
                CheckRows();
                Element = new Element();
                DrawElement();
            }

        }
    }
}
