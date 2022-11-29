using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetBufferSize(80,25);
            //Point p1 = new Point(1,3,'*');
            //p1.Draw();

            //Point p2 = new Point(4,5,'#');
            //p2.Draw();

            Walls wals = new Walls(80, 25);
            wals.Draw();

            Point p = new Point(4,5,'*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();
           
            FoodCreater foodCreater = new FoodCreater(80,25,'$');
            Point food = foodCreater.CreateFood();
            food.Draw();

            while (true)
            {
                if(wals.IsHit(snake) || snake.IsHitTail())
                {
                    break;
                }
                if(snake.Eat(food))
                {
                    food = foodCreater.CreateFood();
                    food.Draw();
                }
                else
                    snake.Move();

                Thread.Sleep(100);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
                
               
            }
            WriteGameOver();
            Console.ReadLine();

        }

        static void WriteGameOver()
        {
            int xOffset = 25;
            int yOffset = 8;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("============================", xOffset, yOffset++);
            WriteText("И Г Р А    О К О Н Ч Е Н А", xOffset + 1, yOffset++);
            yOffset++;
            WriteText("Автор: Галиев Камиль", xOffset + 4, yOffset++);
            WriteText("============================", xOffset, yOffset++);
        }

        static void WriteText(String text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }
    }
}
