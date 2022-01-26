using StmStartBibl;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace StmStart.Doctor
{
    /// <summary>
    /// Логика взаимодействия для AllClientPage.xaml
    /// </summary>
    public partial class AllClientPage : Page
    {
        public AllClientPage(Frame ClientFrame1)
        {
            ClientFrame = ClientFrame1;
            InitializeComponent();
            AddDataGridRow();
        }

        private Frame ClientFrame;

        private void AddDataGridRow()
        {
            AllClient.ItemsSource = Client.GetAll();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            AddDataGridRow();
            
            List<Client> items = new List<Client>();
            List<Client> clients = Client.GetAll();
            if (SortSurename.Text != "")
            {
                clients = clients.Where(c => c.Surname.Equals(SortSurename.Text)).ToList();
            }
            if (SortName.Text != "")
            {
                clients = clients.Where(c => c.Name.Equals(SortName.Text)).ToList();
            }
            if (SortLastname.Text != "")
            {
                clients = clients.Where(c => c.Lastname.Equals(SortLastname.Text)).ToList();
            }
            foreach (var client in clients)
            {
                items.Add(Client.GetClientById(client.ID));
            }
            AllClient.ItemsSource = items;
        }
        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            SortSurename.Text = "";
            SortName.Text = "";
            SortLastname.Text = "";
            AddDataGridRow();
        }
        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            var Client = AllClient.SelectedValue as Client;
            ClientFrame.Navigate(new ClientPage(Client));
        }
    }
}
