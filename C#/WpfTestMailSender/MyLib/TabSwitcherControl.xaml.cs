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

namespace MyLib
{
    /// <summary>
    /// Логика взаимодействия для TabSwitcherControl.xaml
    /// </summary>
    public partial class TabSwitcherControl : UserControl
    {
        
        public TabSwitcherControl()
        {
            InitializeComponent();
        }
        
        public event RoutedEventHandler btnNextClick;
        public event RoutedEventHandler btnPreviousClick;
        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            btnPreviousClick?.Invoke(sender, e);
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            btnNextClick?.Invoke(sender, e);
        }
    }
}
