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
        }
        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            var Client = AllClient.SelectedValue as Client;
            ClientFrame.Navigate(new ClientPage(Client));
        }
    }
}
