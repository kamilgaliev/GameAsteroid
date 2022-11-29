using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HomeWork
{
    /// <summary>
    /// Логика взаимодействия для EditDepWindow.xaml
    /// </summary>
    public partial class EditDepWindow : Window
    {
        MyDB db;
        public DataRow resultRow { get; set; }
        public Department NewRow { get; set; }

        //public EditDepWindow(DataRow row)
        //{
        //    InitializeComponent();
        //    db = MainWindow.db;
        //    resultRow = row;
        //}

        public EditDepWindow(Department newRow)
        {
            InitializeComponent();
            db = MainWindow.db;
            NewRow = newRow;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            NewRow.Name = DepName.Text;
            int id = NewRow.Id;
            db.UpdateDep(id, DepName.Text);
            DialogResult = true;
            
        }


        private void GetDep()
        {
            DepName.Text = NewRow.Name;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetDep();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
