using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadsSync
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassWithSynchronizationAttribute obj = new ClassWithSynchronizationAttribute();
            for (int i = 0; i < 10; i++)
            {
                Thread thread = new Thread(obj.ThreadMethod) { Name = i.ToString() };
                thread.Start();
            }

            Console.ReadLine();
        }
        [Synchronization]
        public class ClassWithSynchronizationAttribute: ContextBoundObject
        {
            private int _value;
            public void ThreadMethod()
            {
                Console.WriteLine("  Поток {0}: _value = {1}", Thread.CurrentThread.Name, _value);
                _value++;
                Thread.Sleep(2000);
            }
        }

    }
}
