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
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        MainWindow mainW;
        Employee.Employee empl;
        ObservableCollection<Department.Department> itemsDept = new ObservableCollection<Department.Department>();
        MyDB.MyDB db;

        public EditWindow()
        {
            InitializeComponent();
            db = new MyDB.MyDB();

            EditGrid.DataContext = db;

        }
        
        

        /// <summary>
        /// Вывод данных на экран
        /// </summary>
        public void ShowViewModel()
        {
            //GetEmpl();
            
            EmplName.Text = empl.Name;
            EmplAge.Text = empl.Age.ToString();
            DepBox.ItemsSource = db.DepDb;
            DepBox.SelectedIndex = db.DepDb.IndexOf(db.DepDb.First(x => x.Id == empl.IdDep));
        }

        /// <summary>
        /// Сохранение изменении
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        public EditWindow(MainWindow w): this()
        {
            EditGrid.DataContext = w.Prop;
            mainW = w;
            empl = w.Prop;
        }

        public EditWindow(Employee.Employee w) : this()
        {
            EditGrid.DataContext = w;
            empl = w;
        }
        private void SaveBTN_Click(object sender, RoutedEventArgs e)
        {
            
            empl.Name = EmplName.Text;
            empl.Age = Convert.ToInt32(EmplAge.Text);
            Department.Department d = DepBox.Items[DepBox.SelectedIndex] as Department.Department;
            empl.IdDep = d.Id;
            mainW.Prop = empl;

            this.Close();
        }
    }
}
