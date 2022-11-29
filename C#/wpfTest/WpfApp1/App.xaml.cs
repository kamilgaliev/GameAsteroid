using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //Создаем первое окно

            MainWindow mnd = new MainWindow();

            ////Определяем свойства

            //mnd.Title = "Hello, WPF!";

            if(e.Args.Length == 1)
                MessageBox.Show("Параметр: \n\n" + e.Args[0]);

            //Отображаем окно

            mnd.Show();
        }
    }
}
