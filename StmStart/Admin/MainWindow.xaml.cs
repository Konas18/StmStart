using StmStart.Admin;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using StmStartBibl;

namespace StmStart
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Page NewClientPage;
        public Page AllClientPage;
        public Page AppointmentPage;
        public Page NewEmployeePage;
        public Page AllEmployeePage;
        public static Personal person;
        public MainWindow(Personal personal)
        {
            InitializeComponent();
            person = personal;
            AddPage();
            WindowState = WindowState.Maximized;
        }

        public void AddPage()
        {
            NewClientPage = new NewClientPage();
            AllClientPage = new AllClientPage(View);
            AppointmentPage = new AppointmentPage();
            AllEmployeePage = new AllEmployeePage(View);
        }
        private void ButtonClickAllClient(object sender, RoutedEventArgs e)
        {
            View.Navigate(new AllClientPage(View));
            NewClientBtn.BorderBrush = Brushes.Black;
            AllClientBtn.BorderBrush = Brushes.Red;
            AppointmentBtn.BorderBrush = Brushes.Black;
            AllEmployeeBtn.BorderBrush = Brushes.Black;
        }
        private void ButtonClickNewClient(object sender, RoutedEventArgs e)
        {
            View.Navigate(NewClientPage);
            NewClientBtn.BorderBrush = Brushes.Red;
            AllClientBtn.BorderBrush = Brushes.Black;
            AppointmentBtn.BorderBrush = Brushes.Black;
            AllEmployeeBtn.BorderBrush = Brushes.Black;
        }


        private void ButtonClickAppointment(object sender, RoutedEventArgs e)
        {
            View.Navigate(AppointmentPage);
            NewClientBtn.BorderBrush = Brushes.Black;
            AllClientBtn.BorderBrush = Brushes.Black;
            AppointmentBtn.BorderBrush = Brushes.Red;
            AllEmployeeBtn.BorderBrush = Brushes.Black;
        }

        private void ButtonClickAllEmployee(object sender, RoutedEventArgs e)
        {
            View.Navigate(new AllEmployeePage(View));
            NewClientBtn.BorderBrush = Brushes.Black;
            AllClientBtn.BorderBrush = Brushes.Black;
            AppointmentBtn.BorderBrush = Brushes.Black;
            AllEmployeeBtn.BorderBrush = Brushes.Red;
        }
    }
}
