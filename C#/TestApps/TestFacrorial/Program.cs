using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFacrorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int fact = Fact(n);
            Console.WriteLine(fact);

            Console.WriteLine((int)SomeEnum.Second);
            Console.ReadLine();
        }
        private enum SomeEnum
        {
            First = 4,
            Second,
            Third = 7
        }

        private static int Fact(int n)
        {
            if (n == 0)
                return 1;
            else
                return n * Fact(n-1);
        }
    }
}
