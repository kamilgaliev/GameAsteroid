using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxApp
{
    class Program
    {
        //Галиев Камиль
        //Написать функцию нахождения максимального из трех чисел
        static void Main(string[] args)
        {
            Console.WriteLine("Введите A");
            int a = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("Введите B");
            int b = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите C");
            int c = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Самое большое число из {a}, {b} и {c} - это {Max(a,b,c)}");

            Console.ReadLine();
        }

        private static int Max(int a, int b, int c)
        {
            int max = a;

            if (b > c && b > max)
                max = b;
            else if (c > max)
                max = c;

            return max;
        }
    }
}
