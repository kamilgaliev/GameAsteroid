using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HomeWork.Department;
using HomeWork.Employee;

namespace HomeWork
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MyDB.MyDB db;

        public Employee.Employee Prop { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            db = new MyDB.MyDB();
            
            MyGrid.DataContext = db;
            FillList();
            //FillList();
        }

        /// <summary>
        /// Добавление элементов в список
        /// </summary>
        void FillList()
        {



            EmplList.ItemsSource = db.EmplDb;
            DepList.ItemsSource = db.DepDb;
        }

       


        private void EmplList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
           
        }

        /// <summary>
        /// Изменение данных по сотруднику
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (EmplList.SelectedItem != null)
            {
                Prop = EmplList.SelectedItem as Employee.Employee;
                int n = EmplList.SelectedIndex;
                Employee.Employee ne = EmplList.Items[n] as Employee.Employee;
                //MessageBox.Show(ne.Id.ToString());

                EditWindow EditWindow = new EditWindow(this);
                EditWindow.Owner = this;
                //EditWindow.ViewModel = n.ToString();
                
                EditWindow.ShowViewModel();
                EditWindow.ShowDialog();
                //UpdateEmplList();


            }

        }

        /// <summary>
        /// Добавление нвого сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEmpl addEmpl = new AddEmpl();
            addEmpl.Owner = this;
            addEmpl.GetListDep();
            addEmpl.ShowDialog();

            //UpdateEmplList();
        }
    }
}
