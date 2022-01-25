using StmStart.Admin;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace StmStart
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Page NewClientPage;
        public Page AllClientPage;
        //public Page NewAppointmentPage;
        public Page AppointmentPage;
        public Page NewEmployeePage;
        public Page AllEmployeePage;
        public MainWindow()
        {
            InitializeComponent();
            AddPage();
            WindowState = WindowState.Maximized;
        }

        public void AddPage()
        {
            NewClientPage = new NewClientPage();
            AllClientPage = new AllClientPage(View);
            //NewAppointmentPage = new NewAppointmentPage();
            AppointmentPage = new AppointmentPage();
            AllEmployeePage = new AllEmployeePage(View);
        }
        private void ButtonClickAllClient(object sender, RoutedEventArgs e)
        {
            View.Navigate(new AllClientPage(View));
            NewClientBtn.BorderBrush = Brushes.Black;
            AllClientBtn.BorderBrush = Brushes.Red;
            //NewAppointmentBtn.BorderBrush = Brushes.Black;
            AppointmentBtn.BorderBrush = Brushes.Black;
            AllEmployeeBtn.BorderBrush = Brushes.Black;
        }
        private void ButtonClickNewClient(object sender, RoutedEventArgs e)
        {
            View.Navigate(NewClientPage);
            NewClientBtn.BorderBrush = Brushes.Red;
            AllClientBtn.BorderBrush = Brushes.Black;
            //NewAppointmentBtn.BorderBrush = Brushes.Black;
            AppointmentBtn.BorderBrush = Brushes.Black;
            AllEmployeeBtn.BorderBrush = Brushes.Black;
        }


        private void ButtonClickAppointment(object sender, RoutedEventArgs e)
        {
            View.Navigate(AppointmentPage);
            NewClientBtn.BorderBrush = Brushes.Black;
            AllClientBtn.BorderBrush = Brushes.Black;
            //NewAppointmentBtn.BorderBrush = Brushes.Black;
            AppointmentBtn.BorderBrush = Brushes.Red;
            AllEmployeeBtn.BorderBrush = Brushes.Black;
        }

        private void ButtonClickAllEmployee(object sender, RoutedEventArgs e)
        {
            View.Navigate(new AllEmployeePage(View));
            NewClientBtn.BorderBrush = Brushes.Black;
            AllClientBtn.BorderBrush = Brushes.Black;
            //NewAppointmentBtn.BorderBrush = Brushes.Black;
            AppointmentBtn.BorderBrush = Brushes.Black;
            AllEmployeeBtn.BorderBrush = Brushes.Red;
        }
    }
}
