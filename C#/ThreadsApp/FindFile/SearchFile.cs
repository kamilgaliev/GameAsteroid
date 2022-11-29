using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FindFile
{
    class SearchFile
    {
        string path = Directory.GetCurrentDirectory();
        string [] nameFile;

        public SearchFile(string myPath,string [] myFile)
        {
            path = myPath;
            nameFile = myFile;
        }
        public SearchFile(string [] myFile)
        {
            nameFile = myFile;
        }

        public string SearchMyFile()
        {
            string result = "";
            string[] allFoundFiles = Directory.GetFiles(path, nameFile + "*", SearchOption.AllDirectories);
            foreach (string file in allFoundFiles)
            {
                result += Convert.ToString(file) + "\n";
            }

            return result;
        }
        public void Print()
        {
            Console.WriteLine(SearchMyFile());
        }
        public void StartSearch()
        {
            int n = nameFile.Length;
            for (int i = 0; i < n; i++)
            {
                string namefile = nameFile[i];
                Thread thread = new Thread(new ParameterizedThreadStart(SearchMyFileThread)) { Name = i.ToString() };
                thread.Start(namefile);
            }

        }
        public void SearchMyFileThread(Object name)
        {
            int count = 0;
            string namefile = Convert.ToString(name);
            string[] allFoundFiles = Directory.GetFiles(path, namefile + "*", SearchOption.AllDirectories);
            foreach (string file in allFoundFiles)
            {
                count++;
                Console.WriteLine("Поток {0} нашел файл: {1}", Thread.CurrentThread.Name, Convert.ToString(file) + "\n");

                Thread.Sleep(2000);
               
            }
            if(count==0)
                Console.WriteLine("Поток {0} не нашел файл: {1}", Thread.CurrentThread.Name, namefile + "\n");


        }
    }
}
