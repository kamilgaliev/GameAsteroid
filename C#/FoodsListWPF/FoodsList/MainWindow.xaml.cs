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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;
using Model;
using System.Data;

namespace FoodsList
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DatabaseContainer _dbContainer;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadFoods();

           
        }

        private void LoadFoods()
        {

            _dbContainer = new DatabaseContainer();
            _dbContainer.Foods.Load();
            dgData.ItemsSource = _dbContainer.Foods.Local;
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
                if (vis is DataGridRow)
                {
                    var row = (DataGridRow)vis;
                    if ((row.Item as Food) != null)
                    {
                        int id = (row.Item as Food).FoodId;
                        //SampleContext context = new SampleContext();

                        Food food = _dbContainer.Foods
                            .Where(o => o.FoodId == id)
                            .FirstOrDefault();

                        _dbContainer.Foods.Remove(food);

                        _dbContainer.SaveChanges();
                    }
                    break;
                }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
                if (vis is DataGridRow)
                {
                    var row = (DataGridRow)vis;
                    
                   
                        int id = (row.Item as Food).FoodId;
                    Food food = _dbContainer.Foods
                            .Where(o => o.FoodId == id)
                            .FirstOrDefault();
                    //SampleContext context = new SampleContext();
                    if (food != null)
                    {
                        

                        food.Name = (row.Item as Food).Name;
                        food.Count = (row.Item as Food).Count;
                        food.Price = (row.Item as Food).Price;
                        food.Date = (row.Item as Food).Date;
                        food.Buy = (row.Item as Food).Buy;

                        _dbContainer.Foods.Attach(food);
                        _dbContainer.Entry(food).Property("Count").IsModified = true;
                        _dbContainer.Entry(food).Property("Name").IsModified = true;
                        _dbContainer.Entry(food).Property("Price").IsModified = true;
                        _dbContainer.Entry(food).Property("Date").IsModified = true;
                        _dbContainer.Entry(food).Property("Buy").IsModified = true;
                        //_dbContainer.SaveChanges();
                        MessageBox.Show(Convert.ToString("Успешно"));
                        break;
                    }
                    else
                    {
                        _dbContainer.Foods.Add(new Food
                        {
                            Name = (row.Item as Food).Name,
                            Count = (row.Item as Food).Count,
                            Price = (row.Item as Food).Price,
                            Date = (row.Item as Food).Date,
                            Buy = (row.Item as Food).Buy,
                        });
                        //_dbContainer.SaveChanges();
                        //LoadFoods();
                        break;
                    }    
                }
            _dbContainer.SaveChanges();
        }
    }
}
