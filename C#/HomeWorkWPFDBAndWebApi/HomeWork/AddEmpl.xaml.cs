using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для AddEmpl.xaml
    /// </summary>
    public partial class AddEmpl : Window
    {
        //Employee empl = new Employee();
        //MainWindow mainW;
        MyDB db;

        public AddEmpl()
        {
            InitializeComponent();
            db = MainWindow.db;
            AddEmplGrid.DataContext = db;

        }

        ///// <summary>
        ///// Получение списка отделов
        ///// </summary>
        public void GetListDep()
        {
            
            DeptBox.ItemsSource = db.DepList().DefaultView;
        }

        ///// <summary>
        ///// Сохраннение нового сотрудника
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            string name = NewEmplName.Text;
            int age = Convert.ToInt32(NewEmplAge.Text);
            DataRowView newRow = (DataRowView)DeptBox.SelectedItem;
            int idDep = Convert.ToInt32(newRow["ID"].ToString());
            
            db.AddEmpl(name, age, idDep);
            DialogResult = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetListDep();
        }
    }
}
