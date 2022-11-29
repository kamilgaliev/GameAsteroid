using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        MainWindow mainW;
        Employee.Employee empl = new Employee.Employee();
        ObservableCollection<Department.Department> itemsDept = new ObservableCollection<Department.Department>();

        public AddEmpl()
        {
            InitializeComponent();
            
            
        }

        /// <summary>
        /// Получение списка отделов
        /// </summary>
        public void GetListDep()
        {
            //mainW = Owner as MainWindow;
            ////itemsDept = mainW.itemsDept;
            //DeptBox.ItemsSource = itemsDept;
        }

        /// <summary>
        /// Сохраннение нового сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            //mainW = Owner as MainWindow;
            //int n = 0;
            //foreach(var elem in mainW.items)
            //{
            //    if (n < elem.Id)
            //        n = elem.Id;
            //}
            //empl.Id = n+1;
            //empl.Name = NewEmplName.Text;
            //empl.Age = Convert.ToInt32(NewEmplAge.Text);
            //empl.IdDep = itemsDept[DeptBox.SelectedIndex].Id;
            //mainW.items.Add(empl);

            //this.Close();
        }
    }
}
