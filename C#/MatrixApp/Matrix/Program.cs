using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 200; //размер матрицы NxN
            Matrix m = new Matrix(n);//Первая матрица
            m.CreateMatr();//Заполняем матрицу
            //m.Print();

            Matrix m2 = new Matrix(n);//Вторая матрица
            m2.CreateMatr();//Заполняем матрицу
            //m2.Print();

            Matrix multySimple = new Matrix(n);//Матрица после простого умножения двух матриц m * m2
            Matrix multyParallel = new Matrix(n);// Матрица после параллельногт умножения двух матриц m* m2
            Stopwatch stopwatch = new Stopwatch();//Таймер

            int start = 0,end = n;//Значения для цика Parallel.For
            stopwatch.Start();//Запускаем таймер
            
            Parallel.For(start,end,(g)=>
            {
                //Параллеьное умножение
                multyParallel = Matrix.MultyParallel(m, m2, start, end);
            });
            
            stopwatch.Stop();//Остановка таймера
            //multy.Print();
            Console.WriteLine($"\n Параллельный: {stopwatch.ElapsedMilliseconds} мс");

            stopwatch.Reset();//Сброс таймера
            stopwatch.Start();//Запуск таймера для протсого умножения
            multySimple = m * m2;
            stopwatch.Stop();
            //multy.Print();
            Console.WriteLine($"\n Простой: {stopwatch.ElapsedMilliseconds} мс");

            Console.ReadLine();
        }
    }
}
