﻿using System;
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
    public partial class ClientPage : Page
    {
        private readonly char[] _phonesymb = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        public Page NewAppointmentPage;


        public ClientPage(Client client) 
        { 

            _client = client;
            InitializeComponent();

            PhoneBox.Text = _client.Phone;
            LastnameBox.Text = _client.Lastname;
            NameBox.Text = _client.Name;
            SurnameBox.Text = _client.Surname;
            PasportBox.Text = _client.Pasport;
            DateOfBirthBox.SelectedDate = _client.Date_of_birth;
            AdresBox.Text = _client.Addres;
            IDmedBox.Text = _client.ID.ToString();
            Medical_historyBox.Text = _client.Medical_history;
        }
        private readonly Client _client;
        private void textBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            var index = textBox.CaretIndex;
            var text = textBox.Text.Where(c => _phonesymb.Contains(c)).Aggregate("", (current, c) => current + c);

            textBox.Text = text;
            textBox.CaretIndex = index;
        }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if ((PhoneBox.Text == "") && (PhoneBox.Text.Length != 12)) return;
            _client.Phone = PhoneBox.Text;

            if (SurnameBox.Text == "") return;
            _client.Surname = SurnameBox.Text;

            if (NameBox.Text == "") return;
            _client.Name = NameBox.Text;

            if (LastnameBox.Text == "") return;
            _client.Lastname = LastnameBox.Text;

            if (PasportBox.Text == "") return;
            _client.Pasport = PasportBox.Text;

            if (DateOfBirthBox.SelectedDate is null) return;
            _client.Date_of_birth = DateOfBirthBox.SelectedDate.Value;

            if (DateOfBirthBox.SelectedDate is null) return;
            _client.Addres = AdresBox.Text;

            _client.Medical_history = Medical_historyBox.Text  ;

            Client.Save();
            MessageBox.Show("Даные изменены");
        }
        public void AddPage()
        {
            NewAppointmentPage = new NewAppointmentPage(_client);
        }
        private void NewAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            AddPage();
            View.Navigate(NewAppointmentPage);
        }
    }
}
