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
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class NewClientPage : Page
    {
        public NewClientPage()
        {
            InitializeComponent();

        }

        private readonly char[] _phonesymb = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
        private void AddClientBtn_Click(object sender, RoutedEventArgs e)
        {

            var Client = new Client();
            if ((PhoneBox.Text == "") && (PhoneBox.Text.Length != 12)) return;
                Client.Phone = PhoneBox.Text;

            if (SurnameBox.Text == "") return; 
            Client.Surname = SurnameBox.Text;

            if (NameBox.Text == "") return; 
            Client.Name = NameBox.Text;

            if (LastnameBox.Text == "") return;
            Client.Lastname = LastnameBox.Text;

            if (PasportBox.Text == "") return;
            Client.Pasport = PasportBox.Text;

            if (DateOfBirthBox.SelectedDate is null) return;
            Client.Date_of_birth = DateOfBirthBox.SelectedDate.Value;


            if (AdresBox.Text == "") return;
            Client.Addres = AdresBox.Text;

            Client.Medical_history = Medical_historyBox.Text;

            Client.Add(Client);
            MessageBox.Show("Клиент добавлен");
        }
        private void textBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            var index = textBox.CaretIndex;
            var text = textBox.Text.Where(c => _phonesymb.Contains(c)).Aggregate("", (current, c) => current + c);

            textBox.Text = text;
            textBox.CaretIndex = index;
        }
    }
}
