using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheiker
{
    class Program
    {
        public static int[] Mass(int n)
        {
            Random r = new Random();
            int[] a = new int[n];

            for (int i = 0; i < n; i++)
            {
                a[i] = r.Next(1, n);
            }

            return a;

        }

        public static int Sheik(int[] a)
        {
            int count = 0;
            int left = 0;
            int right = a.Length - 1;
            while (left < right)
            {
                for (int i = 0; i< right; i++)
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
            Print(a);
            return count;
        }

        //public static int SheikTwo(int[] a)
        //{
        //    int count = 0;
        //    bool b = true;
        //    while (b)
        //    {
        //        int r = 0;
        //        for (int j = 0; j < a.Length - 1; j++)
        //        {
        //            count++;
        //            if (a[j] > a[j + 1])
        //            {
        //                count++;
        //                r++;
        //                int num = a[j + 1];
        //                a[j + 1] = a[j];
        //                a[j] = num;
        //            }
        //        }
        //        if (r == 0)
        //        {
        //            b = false;
        //        }
        //    }
        //    Print(a);
        //    return count;
        //}

        public static void Print(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write($"{a[i]} ");
            }
            Console.WriteLine("\n\n");
        }
        static void Main(string[] args)
        {
            int n = 20;
            int[] a = Mass(n);

            Print(a);



            Console.WriteLine($"Количество операции - {Sheik(a)}\n");
            //Console.WriteLine($"Количество операции Оптимизированная - {SheikTwo(a)}");
            Console.ReadLine();
        }
    }
}
