using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Tetris
{
    public class Element
    {
        private Point Position;
        private Point[] Shape;
        private Brush Color;
        private bool rotate;
        public Element()
        {
            Position = new Point(0, 0);
            Color = Brushes.Transparent;
            Shape = SetRandomShape();
        }
        public Brush GetColor()
        {
            return Color;
        }
        public Point GetPosition()
        {
            return Position;
        }
        public Point[] GetShape()
        {
            return Shape;
        }

        public void MoveLeft()
        { Position.X -= 1; }
        public void MoveRight()
        { Position.X += 1; }
        public void MoveDown()
        { Position.Y += 1; }


        private Point[] SetRandomShape()
        {
            Random rand = new Random();
            switch (rand.Next() % 4)
            {
                case 1:
                    rotate = true;
                    Color = Brushes.Tomato;
                    return new Point[]{
                        new Point(0,0),
                        new Point(-1,0),
                        new Point(1,0),
                        new Point(2,0)
                        };
                case 2:
                    rotate = true;
                    Color = Brushes.SteelBlue;
                    return new Point[]{
                        new Point(0,0),
                        new Point(1,0),
                        new Point(2,0),
                        new Point(3,0)
                        };
                case 3:
                    rotate = true;
                    Color = Brushes.RosyBrown;
                    return new Point[]{
                        new Point(0,0),
                        new Point(1,0),
                        new Point(2,1),
                        new Point(1,1)
                        };
                default:
                    Color = Brushes.Black;
                    return new Point[]{
                        new Point(0,0),
                        new Point(1,0)
                        };

            }
        }
    }

}
