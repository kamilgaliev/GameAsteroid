using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Mail;
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
using WpfTestMailSender.Model;
using WpfTestMailSender.ViewModel;

namespace WpfTestMailSender
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class WpfMailSender : Window
    {
        public WpfMailSender()
        {
            InitializeComponent();
            cbSenderSelect.ItemsSource = VariablesClass.Senders;
            cbSenderSelect.DisplayMemberPath = "Key";
            cbSenderSelect.SelectedValuePath = "Value";

            cbSmtpSelect.ItemsSource = VariablesClass.SmtpServers;
            cbSmtpSelect.DisplayMemberPath = "Key";
            cbSmtpSelect.SelectedValuePath = "Value";


        }

        private void FillData()
        {
            SetStaticSettings();
        }
        private void SetStaticSettings()
        {

            tbServer.Text = StaticSettingsForTest.Host;
            tbPort.Text = Convert.ToString(StaticSettingsForTest.Port);
            tbUserName.Text = StaticSettingsForTest.User;
            tbPassword.Password = StaticSettingsForTest.Pass;
            
        }
       

      

        private void itemClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnClock_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedItem = tabPlanner;
        }

        private void btnSendPlanner_Click(object sender, RoutedEventArgs e)
        {
            SchedulerClass sc = new SchedulerClass();
            TimeSpan tsSendTime = sc.GetSendTime(tbTimePicker.Text);
            if (tsSendTime == new TimeSpan())
            {
                MessageBox.Show("Некорректный формат даты");
                return;
            }
            DateTime dtSendDateTime = (cldSchedulDateTimes.SelectedDate ?? DateTime.Today).Add(tsSendTime);
            if (dtSendDateTime < DateTime.Now)
            {
                MessageBox.Show("Дата и время отправки писем не могут быть раньше, чем настоящее время");
                return;
            }
            EmailSender emailSender = new EmailSender(cbSenderSelect.Text, cbSenderSelect.SelectedValue.ToString());
            sc.SendEmails(dtSendDateTime, emailSender, (ObservableCollection<Email>)cbSenderSelect.ItemsSource);
        }

        private void TabSwitcherControl_btnNextClick(object sender, RoutedEventArgs e)
        {
            if (tabControl.Items.Count != tabControl.SelectedIndex +1)
                tabControl.SelectedIndex = tabControl.SelectedIndex + 1;
            else
                tabControl.SelectedIndex = 0;



        }

        private void TabSwitcherControl_btnPreviousClick(object sender, RoutedEventArgs e)
        {
            if (tabControl.SelectedIndex != 0)
                tabControl.SelectedIndex = tabControl.SelectedIndex - 1;
            else
                tabControl.SelectedIndex = tabControl.Items.Count - 1;

        }

        private void btnSendAtOnce_Click(object sender, RoutedEventArgs e)
        {
            string strLogin = cbSenderSelect.Text;
            string strPassword = cbSenderSelect.SelectedValue.ToString();
            if (string.IsNullOrEmpty(strLogin))
            {
                MessageBox.Show("Выберите отправителя");
                return;
            }
            if (string.IsNullOrEmpty(strPassword))
            {
                MessageBox.Show("Укажите пароль отправителя");
                return;
            }

            EmailSender emailSender = new EmailSender(strLogin, strPassword);
            emailSender.SendMails((ObservableCollection<Email>)cbSenderSelect.ItemsSource);
            var locator = (ViewModelLocator)FindResource("Locator");
            emailSender.SendMails(locator.Main.Emails);


        }
    }
}
