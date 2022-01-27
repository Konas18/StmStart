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
using StmStartBibl;

namespace StmStart.Doctor
{
    /// <summary>
    /// Логика взаимодействия для NewAppointmentPage.xaml
    /// </summary>
    public partial class NewAppointmentPage : Page
    {
        public Window AddServiceWindow;
        private readonly Client _client;
        public decimal Sum;

        public NewAppointmentPage(Client client)
        {
            _client = client;
            InitializeComponent();
            IDmed.Text = _client.ID.ToString();
        }
        public void Add(Tooth_History th)
        {
            ServiceGrid.Items.Add(th);
            Sum += th.Services.Price;
            TotalSumBox.Text = Sum.ToString();
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var service = ServiceGrid.SelectedItem as Tooth_History;
            if (service != null)
            {
                Sum -= service.Services.Price;
                TotalSumBox.Text = Sum.ToString();
                ServiceGrid.Items.Remove(service);
                ServiceGrid.Items.Refresh();
            }
        }
        public void ButtonClickAddService(object sender, RoutedEventArgs e)
        {
            AddServiceWindow AddServWin = new AddServiceWindow(this);
            AddServWin.ShowDialog();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Sum == 0) { MessageBox.Show("Нет ни одной оказаной услуги"); return; }
            foreach (var a in ServiceGrid.Items)
            {
                var temp = a as Tooth_History;
                temp.Client = _client;
                temp.DateTimeService = DateTime.Now;
                Tooth_History.Add(temp);
            }
            var reception = new Reception();
            reception.Sum = Sum;
            reception.DateTimeService = DateTime.Now;
            reception.Client = _client;
            reception.Personal = DoctorWindow.person;
            Reception.Add(reception);
            MessageBox.Show("Приём добавлен");
            ServiceGrid = null;
        }
    }
}
