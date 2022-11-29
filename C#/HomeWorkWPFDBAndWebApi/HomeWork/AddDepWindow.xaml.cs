using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для AddDepWindow.xaml
    /// </summary>
    public partial class AddDepWindow : Window
    {
        MyDB db;

        //Department dep = new Department();
        public AddDepWindow()
        {
            InitializeComponent();
            db = MainWindow.db;
            AddDepGrid.DataContext = db;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            string name = DepName.Text;
            db.AddDep(name);
            DialogResult = true;
            //db.DepDb.Add(dep);
            //this.Close();
        }
    }
}
