using System;
using System.Drawing;

namespace AsteroidGameApp
{
    class Ship : BaseObject
    {
        private int _energy = 100;
        public int Energy => _energy;

        private int _gameresult = 0;
        public int GameResult => _gameresult;
        protected Image img = Image.FromFile(@"ship.png");

        public void EnergyLow (int n)
        {
            _energy -= n;
        }

        public void EnergyHigh(int n)
        {
            if(_energy < 100)
                _energy += n;
        }

        public void AsteriodsDestroyCount()
        {
            _gameresult++;
        }

        public Ship(Point pos, Point dir, Size size): base(pos,dir,size)
        {

        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(img, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
        public void Up()
        {
            if (Pos.Y > 0) Pos.Y = Pos.Y - Dir.Y;
        }
        public void Down()
        {
            if (Pos.Y < Game.Height - Size.Height) Pos.Y = Pos.Y + Dir.Y;
        }
        public void Left()
        {
            if (Pos.X > 0) Pos.X = Pos.X - Dir.X;
        }
        public void Right()
        {
            if (Pos.X < Game.Width-Size.Width) Pos.X = Pos.X + Dir.X;
        }
        public void Die()
        {
            MessageDie?.Invoke();
        }

        public static event Message MessageDie;

    }
}
