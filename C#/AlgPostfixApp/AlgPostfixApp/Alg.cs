using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgPostfixApp
{
    class Alg
    {
        Stack<char> MyStack = new Stack<char>();//стэк
        Queue<char> MyQueue = new Queue<char>();//очередь
        char [] str;//массив для сиволов
        string s; //Входящая строка - выражение 

        public Alg(string s)
        {
            this.s = s;
            str = new char[s.Length];
            SetList();
            Print();

            GetPostfix();
        }

        //Из строки делаем массив символов
        public void SetList()
        {
            for (int i = 0; i < s.Length; i++)
            {
                str[i] = s[i];
            }
        }

        public void GetPostfix()
        {
            // Перебираем массив символов
            for (int i = 0; i < str.Length; i++)
            {
                int num;
                //Если входящий элемент '(' - добавляем в стэк
                if (str[i] == '(')
                {
                    MyStack.Push(str[i]);
                }
                //Если входящий элемент ')' - то убираем из стэк
                if (str[i] == ')')
                {
                    if (str.Contains('('))
                    {
                        AddQue();
                    }
                }
                //Если число то добавляем в очередь
                if (Int32.TryParse(str[i].ToString(),out num))
                {
                    MyQueue.Enqueue(str[i]);
                }
                if (str[i] == '+' || str[i] == '-')
                {
                    if (MyStack.Count() == 0 || MyStack.Peek() == '(') MyStack.Push(str[i]);
                    /* если на вершине стека оператор имеющий больший
                    * приоритет, то делаем проверку на (, и потом добавляем в стэк*/
                    else if (MyStack.Peek() == '*' || MyStack.Peek() == '/')
                    {
                        AddQue();
                        MyStack.Push(str[i]);
                    }
                    // Иначе добавляем в стэк
                    else
                    {
                        MyQueue.Enqueue(MyStack.Peek());
                        MyStack.Pop();
                        MyStack.Push(str[i]);
                    }
                }
                // если * или / то добавляем в очередь
                if (str[i] == '*' || str[i] == '/')
                {
                    if (MyStack.Count() > 0 && (MyStack.Peek() == '*' || MyStack.Peek() == '/'))
                    {
                        AddQue();

                    }
                    MyStack.Push(str[i]);
                }
            }
            // Когда перебрали все элементы выражения, то добавляем из стека элементы в очередь
            if (MyStack.Count() > 0)
            {
                for (int i = MyStack.Count - 1; i >= 0; i--)
                {
                    if (MyStack.ElementAt(i) != '(')
                    {
                        MyQueue.Enqueue(MyStack.ElementAt(i));
                    }
                }
            }
            // Выводим на экран Постфиксное выражение
            Console.WriteLine("Постфикс: ");
            foreach (var item in MyQueue)
            {
                Console.Write(item);
            }
            Console.WriteLine();
        }

        public void AddQue()
        {
            // Выгружаем стек в очередь пока не найдем левую скобку, потом удаляем скобку из стека
            if (MyStack.Count() > 0)
            {
                for (int i = MyStack.Count - 1; i >= 0; i--)
                {
                    if (MyStack.Peek() == '(')
                    {
                        MyStack.Pop();
                        break;
                    }
                    else
                    {
                        MyQueue.Enqueue(MyStack.Pop());
                    }
                }
            }
            
          
        }
        // Вывод сиволльного массива
        public void Print()
        {
            for (int i = 0; i < s.Length; i++)
            {
                Console.Write($"{str[i]} ");
            }
            Console.WriteLine();
        }
    }
}
