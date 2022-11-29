using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

namespace AsteroidGameApp
{
    class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;

        public static int Width { get; set; }
        public static int Height { get; set; }

        public static BaseObject[] _objs;

        //private static Bullet _bullet;
        private static List<Bullet> _bullets = new List<Bullet>();

        //private static Asteroid[] _asteroids;
        private static List<Asteroid> _asteroids = new List<Asteroid>();

        private static Ship _ship = new Ship(new Point(10, 400), new Point(5, 5), new Size(20, 20));

        private static Timer _timer = new Timer();
        public static Random Rnd = new Random();
        private static event Action<string> ActionMes;
        private static HealthBox _hb;

        private static int _level = 1;



        static Game()
        {

        }

        public static void Init(Form form)
        {
            Graphics g;

            _context = BufferedGraphicsManager.Current;

            g = form.CreateGraphics();
            

            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;

            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));

            form.KeyDown += Form_KeyDown;
            Ship.MessageDie += Finish;
            ActionMes += Game_ActionMes;

            form.FormClosed += Form_FormClosed;

            Load();

            _timer = new Timer { Interval = 100 };
            _timer.Start();
            _timer.Tick += Timer_Tick;
            ActionMes?.Invoke($"{DateTime.Now} - Игра запущена");
        }

        

        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey) _bullets.Add(new Bullet(new Point(_ship.Rect.X + 10, _ship.Rect.Y + _ship.Rect.Height/2), new Point(4, 0), new Size(4, 1)));
            if (e.KeyCode == Keys.Up) _ship.Up();
            if (e.KeyCode == Keys.Down) _ship.Down();
            if (e.KeyCode == Keys.Left) _ship.Left();
            if (e.KeyCode == Keys.Right) _ship.Right();
        }

        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);

            //Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
            Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));


            //Buffer.Render();

            //Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
                obj.Draw();
            foreach (Asteroid obj in _asteroids)
                obj.Draw();
            //_bullet?.Draw();
            foreach (Bullet b in _bullets) b.Draw();

            _ship?.Draw();
            _hb?.Draw();
            if (_ship != null)
            {
                Buffer.Graphics.DrawString("Energy:" + _ship.Energy, SystemFonts.DefaultFont, Brushes.White, 0, 0);

                Buffer.Graphics.DrawString("Result:" + _ship.GameResult, SystemFonts.DefaultFont, Brushes.White, 100, 0);

                Buffer.Graphics.DrawString("Level:" + _level, SystemFonts.DefaultFont, Brushes.White, Game.Width/2, 0);
            }

            Buffer.Render();
            
        }

        public static void Load()
        {
            //_objs = new BaseObject[30];
            //for (int i = 0; i < _objs.Length / 2; i++)
            //    _objs[i] = new BaseObject(new Point(600, i * 20), new Point(-i, -i), new Size(10, 10));
            //for (int i = _objs.Length / 2; i < _objs.Length; i++)
            //    _objs[i] = new Star(new Point(600, i * 10), new Point(i, i), new Size(5, 5));
            
            _objs = new BaseObject[30];
            //_bullet = new Bullet(new Point(0, 200), new Point(5, 0), new Size(4, 1));
            //_asteroids = new Asteroid[10];
            var rnd = new Random();
            for (var i = 0; i < _objs.Length; i++)
            {
                int r = rnd.Next(5, 50);
                _objs[i] = new Star(new Point(1000, rnd.Next(0, Game.Height)), new
                Point(r, r), new Size(3, 3));
            }

            CreateAsteroids();

            // _hb = new HealthBox(new Point(1000, rnd.Next(0, Game.Height)), new Point(-10, 10), new Size(20, 20));
            CreateHB();
        }

        public static void Update()
        {
            if(_asteroids.Count==0)
            {
                _level++;
                ActionMes?.Invoke($"{DateTime.Now} - Уровень: {_level}");
                CreateAsteroids();
            }
            var rnd = new Random();
            foreach (BaseObject obj in _objs)
                obj.Update();

            _hb?.Update();

            for (int j = 0; j < _bullets.Count; j++)
            {
                if (_bullets[j].GetPos() >= Game.Width-10)
                {
                    _bullets.RemoveAt(j);
                }
            }

            foreach (Bullet b in _bullets) b?.Update();


        

            for (int i=0; i < _asteroids.Count; i++)
            {
                _asteroids[i].Update();

                for (int j = 0; j < _bullets.Count; j++)
                {
                    if (_asteroids.Count > 0)
                    {
                        if (_bullets[j] != null && _asteroids[i].Collision(_bullets[j]))
                        {
                            System.Media.SystemSounds.Hand.Play();
                            
                            ActionMes?.Invoke($"{DateTime.Now} - Снаряд попал по астероиду");
                            _bullets.RemoveAt(j);

                            
                            _asteroids[i].Power--;
                            
                            if (_asteroids[i].Power == 0)
                            {
                                //_asteroids[i].Damage(rnd.Next(0, Game.Height));
                                _ship.AsteriodsDestroyCount();
                                _asteroids.RemoveAt(i);
                            }
                            //continue;
                            if (i > 0)
                                i--;
                        }
                    }
                }

                if (_asteroids.Count>0)
                {
                    if ( _ship.Collision(_asteroids[i]))
                    {
                        ShipDamage();
                    }

                    if(_asteroids[i].Rect.X - _asteroids[i].Rect.Width < 0 )
                        ShipDamage();
                }
            }

            for (int j = 0; j < _bullets.Count; j++)
            {
                if ((_bullets[j] != null && _hb.Collision(_bullets[j])) || _ship.Collision(_hb))
                {
                    System.Media.SystemSounds.Hand.Play();
                    _ship.EnergyHigh(_hb.GetHealth);
                    CreateHB();
                    ActionMes?.Invoke($"{DateTime.Now} - Аптечка получена");
                    _bullets.RemoveAt(j);

                }
            }

            if (_ship.Collision(_hb))
            {
                System.Media.SystemSounds.Hand.Play();
                _ship.EnergyHigh(_hb.GetHealth);
                CreateHB();
                ActionMes?.Invoke($"{DateTime.Now} - Аптечка получена");

            }
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        public static void Finish()
        {
            _timer.Stop();
            Buffer.Graphics.DrawString("Вы проиграли", new Font(FontFamily.GenericSansSerif,
            60, FontStyle.Underline), Brushes.White, 100, Game.Height/2 - 60);
            ActionMes?.Invoke($"{DateTime.Now} - Игра окончена");
            Buffer.Render();
        }

        private static void Game_ActionMes(string obj)
        {
            Console.WriteLine(obj);
            StreamWriter sw = File.AppendText("log.txt");
            sw.WriteLine(obj);
            sw.Close();
        }

        private static void CreateHB()
        {
            var rnd = new Random();
            _hb = new HealthBox(new Point(1000, rnd.Next(0, Game.Height)), new Point(-10, 10), new Size(20, 20));
        }

        //private static void RemoveBullet(int i)
        //{
        //    _bullets.RemoveAt(i);
        //}

        private static void CreateAsteroids(int n=9)
        {
            var rnd = new Random();
           
            for (var i = 0; i < n+_level; i++)
            {
                int r = rnd.Next(5, 50);
                _asteroids.Add(new Asteroid(new Point(1000, rnd.Next(0, Game.Height)),
                new Point(-r / 5, r), new Size(r, r)));
            }
        }

        private static void ShipDamage()
        {
            var rnd = new Random();
            _ship?.EnergyLow(rnd.Next(1, 10));
            System.Media.SystemSounds.Asterisk.Play();
            if (_ship.Energy <= 0) _ship?.Die();
        }


        private static void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            //CloseGame();
            Application.Restart();
        }
    }
}
