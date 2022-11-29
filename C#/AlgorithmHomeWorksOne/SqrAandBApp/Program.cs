using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqrAandBApp
{
    class Program
    {
        //Галиев Камиль
        //Ввести a и b и вывести квадраты и кубы чисел от a до b.

        static void Main(string[] args)
        {
            Console.WriteLine("Введите А");
            int a = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("Введите B");
            int b = Convert.ToInt32(Console.ReadLine());

            int aa = Square(a);
            int bb = Square(b);

            int aaa = Cube(a);
            int bbb = Cube(b);

            Console.WriteLine($"Квадрат числа {a} = {aa}");
            Console.WriteLine($"Квадрат числа {b} = {bb}");

            Console.WriteLine($"Куб числа {a} = {aaa}");
            Console.WriteLine($"Куб числа {b} = {bbb}");

            Console.ReadLine();
        }

        private static int Square(int n)
        {
            return n * n;
        }
        private static int Cube(int n)
        {
            return Square(n) * n;
        }
    }
}
