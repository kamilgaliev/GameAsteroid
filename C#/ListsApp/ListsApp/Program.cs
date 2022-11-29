using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListsApp
{
    class Program
    {
        public static int FindCount(int elem,List<int> list)
        {
            int count = 0;
            foreach (var item in list)
            {
                if (elem == item)
                    count++;
            }
            return count;
        }

        public static int FindCountElem<T>(List<T> list, T elem)
        {
            int count = 0;
            foreach (var item in list)
            {
                if (elem.Equals(item))
                    count++;
            }
            return count;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("сколько раз каждый элемент встречается в данной коллекции: для целых чисел");
            List<int> listOne = new List<int>() { 4, 5, 3, 5, 3, 2, 1, 7, 6, 0 };
            foreach (var item in listOne)
            {
                int count = FindCount(item, listOne);
                Console.WriteLine($"{item} - {count}");
            }

            Console.WriteLine("\nсколько раз каждый элемент встречается в данной коллекции: для обобщенной коллекции");
            List<string> listTwo = new List<string>() { "ab", "vb", "jhj","ab","jhdjh","ab"};
            var resListTwo = listTwo.GroupBy(e => e);
            foreach (var item in resListTwo)
            {
                
                Console.WriteLine($"{item.Key} - {item.Count()}");
            }

            Console.WriteLine();
            var resListOne = listOne.GroupBy(e => e);
            foreach (var item in resListOne)
            {

                Console.WriteLine($"{item.Key} - {item.Count()}");
            }

            Console.WriteLine("\nсколько раз каждый элемент встречается в данной коллекции: используя Linq");

            var res = from n in listTwo
                      group n by n into g
                      select new { Name = g.Key, Count = g.Count() };

            foreach (var group in res)
                Console.WriteLine($"{group.Name} : {group.Count}");

            Console.ReadLine();
        }
    }
}
