using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgPostfixApp
{
    class Program
    {
        //Галиев Камиль
        //*Реализовать алгоритм перевода из инфиксной записи арифметического выражения в
        //постфиксную.

        static void Main(string[] args)
        {
            Console.WriteLine("Проверочный");
            Alg a = new Alg("5*8*(2+9)+(7-5+8-9*(5*5)+5)");

            Console.WriteLine("\nИз методички для примера");
            Alg b = new Alg("(2/(2*2))");

            Console.WriteLine("введите свое: без пробелов! (Например: 2+(1*2))");
            string s = Console.ReadLine();

            Alg c = new Alg(s);
            Console.ReadLine();
        }
    }
}
