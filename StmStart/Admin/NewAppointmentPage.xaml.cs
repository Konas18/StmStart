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

namespace StmStart.Admin
{
    /// <summary>
    /// Логика взаимодействия для NewAppointmentPage.xaml
    /// </summary>
    public partial class NewAppointmentPage : Page
    {
        public Window AddServiceWindow;
        private readonly Client _client;

        public NewAppointmentPage(Client client)
        {
            _client = client;
            InitializeComponent();
            IDmed.Text = _client.ID.ToString();
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        public void ButtonClickAddService(object sender, RoutedEventArgs e)
        {
            AddServiceWindow AddServWin = new AddServiceWindow(ServiceGrid);
            AddServWin.ShowDialog();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach (var a in ServiceGrid.Items)
            {
                var temp = a as Tooth_History;
                temp.Client = _client;
                Tooth_History.Add(temp);
            }
            MessageBox.Show("Приём добавлен");
        }
    }
}
