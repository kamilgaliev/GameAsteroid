using System;
using System.Drawing;

namespace AsteroidGameApp
{
    class HealthBox : BaseObject
    {
        private int _getHealth = 1;
        public int GetHealth => _getHealth;
        protected Image img = Image.FromFile(@"health.png");

        public HealthBox (Point pos, Point dir, Size size): base(pos, dir, size)
        {

        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(img, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
            var r = new Random();

            Pos.X = Pos.X + Dir.X;
            if (Pos.X < 0)
            {
                Pos.X = Game.Width + Size.Width;
                int rnd = r.Next(1, 20);
                if (Pos.Y < Game.Height + Size.Height + rnd)
                    Pos.Y += rnd;
                else
                    Pos.Y = 0 + Size.Height;
            }
        }
    }
}
