using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HWApp
{
    class Program
    {
        public static int n;
        public static int m;

        public static int[,] board;

        public static int SearchSolution(int n)
        {
            if (CheckBoard() == 0) return 0;
            // 9 ферзя не ставим. Решение найдено
            if (n == 9) return 1;
            
            for (int row = 0; row < n; row++)
                for(int col = 0; col < m; col++)
                {
                    if(board[row,col]==0)
                    {
                        board[row, col] = n;

                        if (SearchSolution(n + 1) == 1) return 1;

                        board[row, col] = 0;
                    }
                }
            return 0;
        }

        public static int CheckBoard()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (board[i,j] != 0)
                        if (CheckQueen(i,j)==0)
                        {
                            return 0;
                        }
                }
            }
            return 1;
        }

        public static int CheckQueen(int x,int y)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (board[i, j] != 0)
                    {
                        if (!(i == x && j == y))
                        {
                            if (i - x == 0)
                            {
                                return 0;
                            }
                            if (j - y == 0)
                            {
                                return 0;
                            }
                            if (Math.Abs(i - x) == Math.Abs(j - y))
                                return 0; 
                        }
                    }
                }
            }
            return 1;
        }

        public static void Print(int n, int m, int[,] a)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{a[i,j],-3}");
                }
                Console.WriteLine();
            }
        }
        public static void Zero(int n, int m, int[,] a)
        {

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    a[i, j] = 0;
                }
                
            }
        }
        static void Main(string[] args)
        {
            n = 8;
            m = 8;
            board = new int[n, m];
            Zero(n, m, board);
            SearchSolution(1);
            Print(n, m, board);
            Console.ReadLine();
        }
    }
}
