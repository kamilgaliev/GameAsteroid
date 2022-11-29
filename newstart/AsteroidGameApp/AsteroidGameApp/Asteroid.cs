using System;
using System.Drawing;

namespace AsteroidGameApp
{
    class Asteroid : BaseObject, ICloneable, IComparable
    {
        public int Power { get; set; } = 3;

        public Asteroid(Point pos, Point dir, Size size): base(pos, dir, size)
        {
            if(size.Width <= 20)
                Power = 1;
            if (size.Width > 20 && size.Width <=30)
                Power = 2;
            if (size.Width > 30)
                Power = 3;
        }
        public override void Draw()
        {
            if ((Pos.Y + Size.Height) > Game.Height || (Pos.Y - Size.Height / 2) < 0)
            {
                Size.Height = Size.Height / 2;
                Size.Width = Size.Width / 2;
            }
            Game.Buffer.Graphics.FillEllipse(Brushes.Orange, Pos.X, Pos.Y,Size.Width, Size.Height);
        }

        public void Damage(int y)
        {
            Pos.X = Pos.X = Game.Width + Size.Width;
            Pos.Y = y;
        }

        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
            
            //Pos.Y = Pos.Y + Dir.Y;
            //if (Pos.X < 0) Dir.X = -Dir.X;
            //if (Pos.X > Game.Width) Dir.X = -Dir.X;
            //if (Pos.Y < 0) Dir.Y = -Dir.Y;
            //if (Pos.Y > Game.Height) Dir.Y = -Dir.Y;
        }

        public object Clone()
        {
            Asteroid asteroid = new Asteroid(new Point(Pos.X, Pos.Y), new Point(Dir.X, Dir.Y),
                                new Size(Size.Width, Size.Height)) { Power = Power };

            return asteroid;
        }

        public int CompareTo(object obj)
        {
            if (obj is Asteroid temp)
            {
                if (Power > temp.Power)
                    return 1;
                if (Power < temp.Power)
                    return -1;
                else
                    return 0;
            }

            throw new ArgumentException("Параметр не Астероида!");
        }
    }
}
