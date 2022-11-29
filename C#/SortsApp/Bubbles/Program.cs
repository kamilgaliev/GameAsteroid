using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bubbles
{
    class Program
    {
        //Галиев Камиль
        //1. Попробовать оптимизировать пузырьковую сортировку.Сравнить количество операций сравнения
        //оптимизированной и не оптимизированной программы. Написать функции сортировки, которые
        //возвращают количество операций.
        //2. *Реализовать шейкерную сортировку.
        //4. *Подсчитать количество операций для каждой из сортировок и сравнить его с асимптотической
        //сложностью алгоритма.


        public static int [] Mass(int n)
        {
            Random r = new Random();
            int[] a = new int[n];

            for (int i = 0; i < n; i++)
            {
                a[i] = r.Next(1,n);
            }
            
            return a;

        }

        public static int Bls(int [] a)
        {
            int count = 0;
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a.Length -1; j++)
                {
                    count++;
                    if (a[j] > a[j + 1])
                    {
                        count++;
                        int num = a[j + 1];
                        a[j + 1] = a[j];
                        a[j] = num;
                    }
                }
            }
            //Print(a, "Пузырьковая");
            return count;
        }

        public static int BlsTwo(int[] a)
        {
            int count = 0;
            bool b = true;
            while (b)
            {
                int r = 0;
                for (int j = 0; j < a.Length - 1; j++)
                {
                    count++;
                    if (a[j] > a[j + 1])
                    {
                        count++;
                        r++;
                        int num = a[j + 1];
                        a[j + 1] = a[j];
                        a[j] = num;
                    }
                }
                if (r==0)
                {
                    b = false;
                }
            }
           // Print(a, "Пузырьковая Оптимизированная");
            return count;
        }

        public static int Sheik(int[] a)
        {
            int count = 0;
            int left = 0;
            int right = a.Length - 1;
            while (left < right)
            {
                for (int i = 0; i < right; i++)
                {
                    count++;
                    if (a[i] > a[i + 1])
                    {
                        count++;
                        int num = a[i + 1];
                        a[i + 1] = a[i];
                        a[i] = num;
                    }
                }
                right--;
                for (int j = right; j > left; j--)
                {
                    count++;
                    if (a[j] < a[j - 1])
                    {
                        count++;
                        int num = a[j - 1];
                        a[j - 1] = a[j];
                        a[j] = num;
                    }
                }
                left++;
            }
            //Print(a,"Шейкерная");
            return count;
        }

        public static int SheikTwo(int[] a)
        {
            int count = 0;
            int left = 0;
            int right = a.Length - 1;
            while (left < right)
            {
                int r = 0;
                for (int i = 0; i < right; i++)
                {
                    count++;
                    if (a[i] > a[i + 1])
                    {
                        r++;
                        count++;
                        int num = a[i + 1];
                        a[i + 1] = a[i];
                        a[i] = num;
                    }
                }
                right--;
                for (int j = right; j > left; j--)
                {
                    count++;
                    if (a[j] < a[j - 1])
                    {
                        r++;
                        count++;
                        int num = a[j - 1];
                        a[j - 1] = a[j];
                        a[j] = num;
                    }
                }
                left++;
                if (r==0)
                {
                    break;
                }
            }
            //Print(a, "Шейкерная Оптимизированная");
            return count;
        }

        public static void Print(int [] a,string str)
        {
            Console.WriteLine(str);
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write($"{a[i]} ");
            }
            Console.WriteLine("\n");
        }
        static void Main(string[] args)
        {
            int n1 = 100;
            int n2 = 1000;
            int n3 = 10000;
            int[,] matr = new int [4,6];

            //int[] a = Mass(n1);
            for (int j = 0; j < 6; j ++)
            {
                if (j < 2)
                {
                    int[] a = Mass(n1);
                    matr[0, j] = Bls(a);
                    matr[1, j] = BlsTwo(a);
                    matr[2, j] = Sheik(a);
                    matr[3, j] = SheikTwo(a);
                }
                if (j > 1 && j < 4)
                {
                    int[] a = Mass(n2);
                    matr[0, j] = Bls(a);
                    matr[1, j] = BlsTwo(a);
                    matr[2, j] = Sheik(a);
                    matr[3, j] = SheikTwo(a);
                }
                if (j > 3)
                {
                    int[] a = Mass(n3);
                    matr[0, j] = Bls(a);
                    matr[1, j] = BlsTwo(a);
                    matr[2, j] = Sheik(a);
                    matr[3, j] = SheikTwo(a);
                }
            }
            //Print(a,"Основной массив");
            Console.WriteLine($"Количество операции Пузырьковая-1");
            Console.WriteLine($"Количество операции Пузырьковая Оптимизированная-2");
            Console.WriteLine($"Количество операции Шейкерная-3");
            Console.WriteLine($"Количество операции Шейкерная Оптимизированная-4\n");
            Console.WriteLine($"\n  n|{n1,-12}|{n1,-12}|{n2,-12}|{n2,-12}|{n3,-12}|{n3,-10}\n");
            for (int i = 0; i < 4; i++)
            {
                Console.Write($"{i+1} ");
                for (int j = 0; j < 6; j++)
                {
                    Console.Write($" | {matr[i,j],-10}");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\nасимптотическая сложность алгоритма");
            Console.WriteLine($"\n  n|{n1,-12}|{n2,-12}|{n3,-10}\n");
            for (int i = 0; i < 4; i++)
            {
                Console.Write($"{i + 1} ");
                for (int j = 0; j < 6; j++)
                {
                    if (j < 2)
                        Console.Write($" | {Convert.ToDouble(matr[i, j] + matr[i, j+1])/n1,-10}");
                    if (j > 1 && j < 4)
                        Console.Write($" | {Convert.ToDouble(matr[i, j] + matr[i, j + 1]) / n2,-10}");
                    if (j > 3)
                        Console.Write($" | {Convert.ToDouble(matr[i, j] + matr[i, j + 1]) / n2,-10}");
                    j++;
                }
                Console.WriteLine();
            }


            //Console.WriteLine($"Количество операции Пузырьковая- {Bls(a)}\n\n");
            //Console.WriteLine($"Количество операции Пузырьковая Оптимизированная - {BlsTwo(a)}\n\n");
            //Console.WriteLine($"Количество операции Шейкерная - {Sheik(a)}\n\n");
            //Console.WriteLine($"Количество операции Шейкерная Оптимизированная - {SheikTwo(a)}\n\n");
            Console.ReadLine();
        }
    }
}
