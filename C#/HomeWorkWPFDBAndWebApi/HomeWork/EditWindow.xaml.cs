using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
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
using System.Windows.Shapes;

namespace HomeWork
{
    /// <summary>
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        MyDB db;
        static HttpClient client = new HttpClient();
        //public DataRow resultRow { get; set; }
        public Employee NewRow { get; set; }

        //public EditWindow(DataRow row)
        //{
        //    InitializeComponent();
        //    db = MainWindow.db;
        //    resultRow = row;

        //}

        public EditWindow(Employee newRow)
        {
            InitializeComponent();
            client.BaseAddress = new Uri("https://localhost:44313/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //UpdateDepListAsync();
            db = MainWindow.db;
            NewRow = newRow;
        }

        private async void UpdateDepListAsync()
        {
            IEnumerable<Department> dep = await GetDepAsync(client.BaseAddress + "api/Department");
            var v = dep;
            DepBox.DataContext = v;


            var selDepName = db.DepOne(NewRow.IdDep);
            foreach (var dr in v)
            {
                if (dr.Name.ToString() == selDepName)
                    DepBox.SelectedItem = dr;
            }
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

        ///// <summary>
        ///// Получаем данные сотрудника
        ///// </summary>
        public void GetEmpl()
        {
            
            EmplName.Text = NewRow.Name;
            EmplAge.Text = NewRow.Age.ToString();

            UpdateDepListAsync();


        }

        private void SaveBTN_Click(object sender, RoutedEventArgs e)
        {
            NewRow.Name = EmplName.Text;
            NewRow.Age = Convert.ToInt32(EmplAge.Text);
            //DataRowView newRow = (DataRowView)DepBox.SelectedItem;
            //resultRow["IDDEP"] = newRow["ID"];
            //resultRow["DEP"] = newRow["NAME"];
            
           
            //db.UpdateEmpl(Convert.ToInt32(resultRow["ID"]), EmplName.Text, Convert.ToInt32(EmplAge.Text),Convert.ToInt32( newRow["ID"].ToString()));
            DialogResult = true;
            

            //this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetEmpl();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
