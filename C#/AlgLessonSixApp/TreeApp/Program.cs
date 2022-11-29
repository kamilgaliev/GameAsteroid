using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeApp
{
    class Program
    {
        
        public static int[] MyMass;
        public static Random r= new Random();
        public static int[] CreateMassiv( int n)
        {
            
            int[] massive = new int[n];
            
            for (int i = 0; i < n; i++)
            {
                massive[i] = r.Next(0, 10);
            }
            return massive;
        }
        public static void UpdateMass(int [] m)
        {
            int n = m.Length+1;
            MyMass = new int[n];
            MyMass[0] = m.Length;
            for (int i = 1; i < n; i++)
            {
                MyMass[i] = m[i - 1];
            }
        }

        public static void CreateTree(int MyIndex = 1)
        {
            int n = MyMass.Length;
            if (MyIndex < n && MyMass[MyIndex]!=0)
            {
                Console.Write($"{MyMass[MyIndex]} ");
                if((2*MyIndex < n && MyMass[2 * MyIndex]!= 0) || (2 * MyIndex + 1< n && MyMass[2 * MyIndex + 1] != 0))
                {
                    Console.Write("( ");
                    if (2 * MyIndex < n && MyMass[2 * MyIndex] != 0)
                    {
                        CreateTree(2 * MyIndex);
                    }
                    else
                        Console.Write("NULL");
                    if (2 * MyIndex + 1 < n && MyMass[2 * MyIndex + 1] != 0)
                    {
                        CreateTree(2 * MyIndex + 1);
                    }
                    else
                        Console.Write("NULL");
                    Console.Write(") ");
                }
            }
        }
        public static void CreateTreeLeftRootRight(int MyIndex = 1)
        {
            int n = MyMass.Length;
            if (MyIndex < n && MyMass[MyIndex] != 0)
            {
                
                
                    if (2 * MyIndex < n && MyMass[2 * MyIndex] != 0)
                    {
                        CreateTreeLeftRootRight(2 * MyIndex);
                    }
                    

                    Console.Write($"{MyMass[MyIndex]} > ");

                    if (2 * MyIndex + 1 < n && MyMass[2 * MyIndex + 1] != 0)
                    {
                        CreateTreeLeftRootRight(2 * MyIndex + 1);
                    }
                    
                    
            }
            
        }
        public static void CreateTreeLeftRightRoot(int MyIndex = 1)
        {
            int n = MyMass.Length;
            if (MyIndex < n && MyMass[MyIndex] != 0)
            {


                if (2 * MyIndex < n && MyMass[2 * MyIndex] != 0)
                {
                    CreateTreeLeftRootRight(2 * MyIndex);
                }

                if (2 * MyIndex + 1 < n && MyMass[2 * MyIndex + 1] != 0)
                {
                    CreateTreeLeftRootRight(2 * MyIndex + 1);
                }
                Console.Write($"{MyMass[MyIndex]} > ");

            }

        }
        static void Main(string[] args)
        {
            int n = 10;
            int[] massive = CreateMassiv(n);

            for (int i = 0; i < n; i++)
            {
                Console.Write($"{massive[i]} ");
            }
            Console.WriteLine();
            UpdateMass(massive);
            Console.WriteLine("корень–левый–правый");
            CreateTree();
            Console.WriteLine("\nлевый–корень–правый");
            CreateTreeLeftRootRight();
            Console.WriteLine("\nлевый–правый–корень");
            CreateTreeLeftRightRoot();
            Console.ReadLine();
        }
    }
}
