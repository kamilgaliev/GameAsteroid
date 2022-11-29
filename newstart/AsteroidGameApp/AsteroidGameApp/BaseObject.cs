using System.Drawing;

namespace AsteroidGameApp
{
    abstract class BaseObject: ICollision
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;

        public delegate void Message();


        protected BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        public abstract void Draw();

        public abstract void Update();
        public Rectangle Rect => new Rectangle(Pos, Size);

        public bool Collision(ICollision obj) => obj.Rect.IntersectsWith(this.Rect);
    }
}
