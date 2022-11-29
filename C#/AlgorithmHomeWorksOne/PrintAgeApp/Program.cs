using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintAgeApp
{
    class Program
    {
        //Галиев Камиль
        //Ввести возраст человека(от 1 до 150 лет) и вывести его вместе с последующим словом «год»,
        //«года» или «лет»
        public static void PrintAge()
        {
            for (int i = 1; i <= 150; i++)
            {
                Console.WriteLine($"{i} {AgeStr(i)}");
            }
        }

        public static string AgeStr(int n)
        {
            string str = string.Empty;

            if (n % 10 == 1 && n / 10 != 1)
                str = "год";
            else if ((n % 10 >= 2 && n % 10 <= 4) && n / 10 != 1)
                str = "года";
            else if (n % 10 == 0 || (n % 10 >= 5 && n % 10 <= 9) || n / 10 == 1)
                str = "лет";
            return str;
        }
        static void Main(string[] args)
        {
            PrintAge();

            Console.ReadLine();
        }
    }
}
