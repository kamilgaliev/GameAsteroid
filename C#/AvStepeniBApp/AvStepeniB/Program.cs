using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvStepeniB
{
    class Program
    {
        //Галиев Камиль
        //Реализовать функцию возведения числа a в степень b
        public static int MyFunc(int a, int b)
        {
            int n = a;
            for (int i = 1; i < b; i++)
            {
                n = n * a;
            }
            return n;
        }

        public static int MyFuncReq(int a, int b)
        {
            if (b == 1)
                return a;
            else
                return a * MyFuncReq(a, b - 1);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число a"); 
            int a = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите число b");
            int b = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Простая функция : {a} ^ {b} = {MyFunc(a, b)}");
            Console.WriteLine($"Рекурсия : {a} ^ {b} = {MyFuncReq(a, b)}");
            Console.ReadLine();

        }
    }
}
