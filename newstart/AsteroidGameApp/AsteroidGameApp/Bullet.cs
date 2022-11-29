using System.Drawing;

namespace AsteroidGameApp
{
    class Bullet : BaseObject
    {
        public Bullet(Point pos, Point dir, Size size): base(pos, dir, size)
        {

        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawRectangle(Pens.OrangeRed, Pos.X, Pos.Y, Size.Width,Size.Height);
        }

        public int GetPos()
        {
            return Pos.X + Size.Width;
        }

        public override void Update()
        {
            Pos.X = Pos.X + 15;
            if (Pos.X > Game.Width) Pos.X = 0;
        }
    }
}
