using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSortApp
{
    class Program
    {
        //Галиев Камиль
        //Реализовать быструю сортировку.
        public static Random r = new Random();//Для генерации индекса
        public static int[] m = new int[9] { 5, 4, 9, 7, 2, 1, 3, 6, 8 };//тестовый массив

        //Сортировка
        public static void QuickSort( int start=0, int end=8)
        {
            if (start >= end)// если прошли весь массив то выходим
                return;

            int opora = m[r.Next(start,end)];//Случайное опорное значение
            int i = start;
            int j = end;
            while(i<=j)//делим массив на подмассивы
            {
                while (m[i] < opora)
                    i++;
                while (m[j] > opora)
                    j--;
                if(i<=j)//меняем значения местами
                {
                    int n = m[i];
                    m[i] = m[j];
                    m[j] = n;
                    i++;
                    j--;
                }
            }
            //Рекурсия для сортировки левой и правой части
            if (start < j)
                QuickSort(start,j);
            if (end > i)
                QuickSort(i,end);
        }
        //Вывод на экран массива
        public static void Print(string s)
        {
            Console.WriteLine(s);
            for (int i = 0; i < m.Length; i++)
            {
                Console.Write($"{m[i]} ");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Print("Пробный массив");
            QuickSort();
            Print("Массив после сортировки");
            Console.ReadLine();
        }
    }
}
