using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsteroidGameApp
{
    public partial class StartGame : Form
    {
        public StartGame()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //this.Hide();
            
            Form form = new Form();
            form.Width = 800;
            form.Height = 600;

            Game.Init(form);
            form.ShowDialog();
            

            
        }
    }
}
