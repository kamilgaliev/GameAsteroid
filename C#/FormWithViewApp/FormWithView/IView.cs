using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormWithView
{
    interface IView
    {
        string A { get; }
        string B { get; }
        string Res { set; }
    }
}
