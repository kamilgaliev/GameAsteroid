using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthsApp
{
    class Program
    {
        //Галиев Камиль
        // С клавиатуры вводится номер месяца. Требуется определить, к какому времени года он относится
        public static string Seasons(int n)
        {
            string str = string.Empty;

            if (n == 12 || (n <= 2 && n > 0))
                str = "Зима";
            else if (n >= 3 && n <= 5)
                str = "Весна";
            else if (n >= 6 && n <= 8)
                str = "Лето";
            else if (n >= 9 && n <= 11)
                str = "Осень";
            else
                str = "Не удалось определить";

            return str;
        }
        static void Main(string[] args)
        {
            while(true) {
                Console.WriteLine("Введите номер месяца\n");
                int n = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"\n{Seasons(n)}\n"); 
            }

        }
    }
}
