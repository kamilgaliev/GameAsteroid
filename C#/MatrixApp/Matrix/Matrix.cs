using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Matrix
    {
        Random r;
        int n;
        int[,] matr;
        public Matrix(int n)
        {
            this.n = n;
            r = new Random();
            matr = new int[this.n,this.n];
        }
        /// <summary>
        /// Заполнение матрицы 
        /// </summary>
        public void CreateMatr()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matr[i, j] = r.Next(0, 10);
                }
            }
            
        }
        /// <summary>
        /// Доступ к идексу элементов матрицы
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public int this[int i, int j]
        {
            get
            {
                return matr[i, j];
            }
            set
            {
                matr[i, j] = value;
            }
        }
        /// <summary>
        /// Простое умножение двух матриц
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Matrix Multy(Matrix a, Matrix b)
        {
            int n = a.n;
            Matrix res = new Matrix(n);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < b.n; k++)
                    {
                        res[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return res;

        }
        /// <summary>
        /// Параллеьное умножения двух матриц
        /// </summary>
        /// <param name="a">Первая матрица</param>
        /// <param name="b">Вторая матрица</param>
        /// <param name="start">строка </param>
        /// <param name="end">количество столбцов</param>
        /// <returns></returns>
        public static Matrix MultyParallel(Matrix a, Matrix b,int start,int end)
        {
            int i = start;
            int n = end;

            Matrix res = new Matrix(n);
            for (int j = 0; j < n; j++)
            {
                for (int k = 0; k < n; k++)
                {
                    res[i, j] += a[i, k] * b[k, j];
                }
            }
            return res;
        }
        /// <summary>
        /// Перегрузка опертора умножения
        /// </summary>
        /// <param name="a">Первая матрица</param>
        /// <param name="b">Вторая матрица</param>
        /// <returns></returns>
        public static Matrix operator *(Matrix a, Matrix b)
        {
            return Matrix.Multy(a, b);
        }
        /// <summary>
        /// Распечатать матрицу
        /// </summary>
        public void Print()
        {
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{matr[i, j]} ");
                }
                Console.WriteLine();
            }
        }


    }
}
