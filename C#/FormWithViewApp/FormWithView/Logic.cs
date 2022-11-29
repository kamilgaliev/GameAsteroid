using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormWithView
{
    class Logic
    {
        IView view;
        int a, b;

        public Logic (IView view)
        {
            this.view = view;
        }

        int GetInteger (string s)
        {
            int.TryParse(s,out int i);
            return i;
        }

        public void Sum()
        {
            a = GetInteger(view.A);
            b = GetInteger(view.B);
            view.Res = $"{a} + {b} = {a + b}";
        }

        public void Minus()
        {
            a = GetInteger(view.A);
            b = GetInteger(view.B);
            view.Res = $"{a} - {b} = {a - b}";
        }
    }
}
