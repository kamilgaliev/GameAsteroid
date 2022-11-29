using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GrafPrintApp
{
    class Program
    {
        //Галиев Камиль
        //1. Написать функции, которые считывают матрицу смежности из файла и выводят ее на экран.
        public static int n;
        public static int [,] ReadFile(string path)
        {
            StreamReader sr = new StreamReader(path);
            n = Convert.ToInt32(sr.ReadLine());
            int[,] g = new int[n, n];
            string line = String.Empty;
            int i = 0;
            while ((line = sr.ReadLine()) != null)
            {
                string[] str = line.Split(' ');
                for (int j = 0; j < n; j++)
                {
                    g[i, j] = Convert.ToInt32(str[j]);
                }
                i++;
            }
            return g;
        }
        public static void Print(int [,] m)
        {
            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{m[i, j]} ");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            string path = @"graf.txt";
            int[,] g = ReadFile(path);

            Print(g);

            Console.ReadLine();
        }
    }
}
