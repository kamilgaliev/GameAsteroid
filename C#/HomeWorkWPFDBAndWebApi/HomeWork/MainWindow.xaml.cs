using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Cache;
using System.Net.Http;
using System.Net.Http.Headers;
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


namespace HomeWork
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MyDB db;
        static HttpClient client = new HttpClient();
        public MainWindow()
        {
            InitializeComponent();
            client.BaseAddress = new Uri("https://localhost:44313/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            db = new MyDB();

            UpdateEmplListAsync();
            UpdateDepListAsync();
            //DepList.DataContext = db.DepList().DefaultView;

        }

        private async void UpdateEmplListAsync()
        {
            IEnumerable<Employee> empl = await GetEmplsAsync(client.BaseAddress + "api/Employee");
            EmplList.DataContext = empl;
        }

        private async Task<IEnumerable<Employee>> GetEmplsAsync(string path)
        {
            IEnumerable<Employee> empl = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    empl = await response.Content.ReadAsAsync<IEnumerable<Employee>>();
                }
            }
            catch (Exception)
            {
            }
            return empl;

        }

        private async void UpdateDepListAsync()
        {
            IEnumerable<Department> dep = await GetDepAsync(client.BaseAddress + "api/Department");
            DepList.DataContext = dep;
        }

        private async Task<IEnumerable<Department>> GetDepAsync(string path)
        {
            IEnumerable<Department> dep = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    dep = await response.Content.ReadAsAsync<IEnumerable<Department>>();
                }
            }
            catch (Exception)
            {
            }
            return dep;

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
                int n = EmplList.SelectedIndex;
                Employee newRow = (Employee)EmplList.SelectedItem;
                //newRow.BeginEdit();
                EditWindow EditWindow = new EditWindow(newRow);
                //EditWindow.Owner = this;
                
                EditWindow.ShowDialog();
                if (EditWindow.DialogResult.HasValue && EditWindow.DialogResult.Value)
                {
                    //newRow.EndEdit();
                    db.adapter.Update(db.EmplList());
                }
                else
                {
                    //newRow.CancelEdit();
                }
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
            
            addEmpl.ShowDialog();
            if (addEmpl.DialogResult.HasValue && addEmpl.DialogResult.Value)
            {
                
                db.adapter.Update(db.EmplList());
                UpdateEmplListAsync();
            }
        }

        private void BtnEditDep_Click(object sender, RoutedEventArgs e)
        {
            if (DepList.SelectedItem != null)
            {
                int n = DepList.SelectedIndex;
                Department newRow = (Department)DepList.SelectedItem;
                //newRow.BeginEdit();
                EditDepWindow EditDepWindow = new EditDepWindow(newRow);
                //EditWindow.Owner = this;

                EditDepWindow.ShowDialog();
                if (EditDepWindow.DialogResult.HasValue && EditDepWindow.DialogResult.Value)
                {
                    //newRow.EndEdit();
                    db.adapter.Update(db.DepList());
                    UpdateEmplListAsync();
                }
                else
                {
                    //newRow.CancelEdit();
                }
            }
        }

        private void BtnAddDep_Click(object sender, RoutedEventArgs e)
        {
            AddDepWindow addDep = new AddDepWindow();
            addDep.ShowDialog();
            if (addDep.DialogResult.HasValue && addDep.DialogResult.Value)
            {

                DepList.DataContext = db.DepList().DefaultView;
                UpdateEmplListAsync();
            }
        
        }
    }
}
