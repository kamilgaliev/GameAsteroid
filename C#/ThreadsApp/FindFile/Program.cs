using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь к папке где храниться файл(Например C:\\Users)\nЕсли путь не указан то по умолчанию будет папка приложения");
            string path = Console.ReadLine();
            Console.WriteLine("Введите название файла для поиска. \nЕсли нужно искть несколько файлов то введите название файлов через запятую(Например: файл1,файл2)");
            string fileName = Console.ReadLine();
            string[] fn = fileName.Split(',');
            if (path != "")
            {
                SearchFile sf = new SearchFile(path, fn);
                sf.StartSearch();
            }
            else
            {
                SearchFile sf = new SearchFile(fn);
                sf.StartSearch();
            }
            Console.ReadLine();
        }
    }
}
