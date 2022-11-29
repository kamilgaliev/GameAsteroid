using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashApp
{
    class Program
    {
        //Сумма символов
        public static int SumChar(string s)
        {
            //Строку переводим в массив символов
            char[] ch = s.ToCharArray();
            int sum = 0;
            
            //Проходим по массиву
            foreach (char item in ch)
            {
                //Добавляем значение символа в результат
                sum += (int)item;
            }
            return sum;

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите слово или набор букв и цифр");
            string str = Console.ReadLine();
            
            //Если str не пустое то выводим сумму символов, иначе простое сообщение
            if (str.Length > 0)
            {
                Console.WriteLine($"Сумма символов - {SumChar(str)}");
            }
            else
                Console.WriteLine("вы ничего не ввели");
            
            Console.ReadLine();
        }
    }
}
