using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmogReshit
{
    class Program
    {
        static int[,] matr;
        static int max(int a, int b)
        {
            return a > b ? a : b;
        }

        static void lcs_length(string A, string B)
        {
           

            for (int i = 1; i <=A.Length; i++)
            {
                for (int j = 1; j <= B.Length ; j++)
                {
                    if (A[i - 1] == B[j - 1])
                        matr[i, j] = matr[i - 1, j - 1] + 1;
                    else
                        matr[i, j] = max(matr[i - 1, j], matr[i, j - 1]);
                }
               
            }
        
        }

        public static void Print(int n, int m, int[,] matr,string a,string b)
        {
            Console.Write($"{" ",-6}");
            for (int j = 0; j < a.Length; j++)
            {
                Console.Write($"{a[j],-3}");
            }
            Console.WriteLine();
            for (int i = 0; i <=n; i++)
            {
                if (i > 0)
                    Console.Write($"{b[i - 1],-3}");
                else if (i == 0)
                    Console.Write($"{" ",-3}");
                for (int j = 0; j <= m; j++)
                {
                   
                    Console.Write($"{matr[i, j],-3}");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            string a = "geekbrains";
            string b = "geekminds";
            matr = new int[b.Length+1, a.Length+1];
            lcs_length(b,a);
            Print(b.Length, a.Length, matr,a,b);
            Console.ReadLine();
        }
    }
}
