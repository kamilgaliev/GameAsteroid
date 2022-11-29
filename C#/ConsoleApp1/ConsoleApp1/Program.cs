using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 256, b = 1024, c = 0;
            while(b > 0)
            {
                c = a % b;
                a = b;
                b = c;
            }
            Console.WriteLine(a);

            int s = 301, n = 0;
            while(s > 0)
            {
                s = s - 10; n = n + 2;
            }
            Console.WriteLine(n);
            Console.ReadLine();
        }
    }
}
