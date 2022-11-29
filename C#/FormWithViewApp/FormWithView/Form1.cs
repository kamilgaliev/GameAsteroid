using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormWithView
{
    public partial class Form1 : Form,IView
    {
        Logic c;
        public Form1()
        {
            InitializeComponent();
        }

        public string A { get { return tbA.Text; } }

        public string B { get { return tbB.Text; } }
        public string Res { set { lbRes.Text = value; } }

        private void Form1_Load(object sender, EventArgs e)
        {
            c = new Logic(this);
        }

        private void btnSum_Click(object sender, EventArgs e)
        {
            c.Sum();
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            c.Minus();
        }
    }
}
