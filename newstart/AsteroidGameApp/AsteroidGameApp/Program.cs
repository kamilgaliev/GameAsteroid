using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsteroidGameApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Form form = new Form();
            //form.Width = 800;
            //form.Height = 600;

            //Game.Init(form);
            //form.Show();
            ////Game.Load();
            //Game.Draw();
            //Application.Run(form);

            StartGame st = new StartGame();
            st.Show();
            Application.Run(st);
        }
    }
}
