using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ObhodGlubina
{
    class Program
    {
        public static int n;//Количество вершин
        public static Stack<int> st = new Stack<int>();//Стек смежных вершин
        public static int[] glub;//раскраска

        //Чтения графа из файла
        public static int[,] ReadFile(string path)
        {
            StreamReader sr = new StreamReader(path);
            n = Convert.ToInt32(sr.ReadLine());
            int[,] g = new int[n, n];
            glub = new int[n];
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

        //раскраска
        public static void GlubTest(int[,] m, int i = 0)
        {
            
            
            for (int j = 0; j < n; j++)
            {

                if (i == 0 && j == 0 && glub[i]==0)//Добавляем первую вершину
                { 
                    glub[i] = 1;
                    st.Push(i);
                }
                if(m[i,j]!=0 && glub[j]==0)//Если есть путь к другой вершине то добавляем в стек
                {
                    glub[j] = 1;
                    st.Push(j);

                }
            }
            if (st.Count > 0)
                GlubTest(m, st.Pop());
        }
        //Распечатка графа
        public static void Print(int[,] m)
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
        //Результат алгоритма Глубина графа
        public static void PrintGlub()
        {
            Console.WriteLine("\nв глубину");
            
            Console.WriteLine("A B C D");
            for (int i = 0; i < n; i++)
            {
                
                Console.Write($"{glub[i]} ");
               
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            string path = @"graf.txt";
            int[,] g = ReadFile(path);

            Print(g);
            GlubTest(g);
            PrintGlub();
            Console.ReadLine();
        }
    }
}
