using StmStartBibl;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace StmStart.Admin
{
    /// <summary>
    /// Логика взаимодействия для EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : Page
    {
        private readonly char[] _phonesymb = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        private Personal _personal;
        public EmployeePage(Personal personal)
        {
            _personal = personal;
            InitializeComponent();

            PhoneBox.Text = _personal.Phone;
            LastnameBox.Text = _personal.Lastname;
            NameBox.Text = _personal.Name;
            SurnameBox.Text = _personal.Surname;
            PasportBox.Text = _personal.Pasport;
            DateOfBirthBox.SelectedDate = _personal.Date_of_birth;
            AdresBox.Text = _personal.Addres;
            ExperienceBox.Text = _personal.Experience.ToString();
            PostCmBox.Text = _personal.PostName;
            LoginBox.Text = _personal.Login;
        }
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
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            Personal.Delete(_personal);
            ClearBox();
            MessageBox.Show("Сотрудник удалён");
        }
        private void ClearBox()
        {
            PhoneBox.Text = "";
            LastnameBox.Text = "";
            NameBox.Text = "";
            SurnameBox.Text = "";
            PasportBox.Text = "";
            DateOfBirthBox.SelectedDate = null;
            AdresBox.Text = "";
            ExperienceBox.Text = "";
            PostCmBox.Text = "";
            LoginBox.Text = "";
        }
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if ((PhoneBox.Text == "") && (PhoneBox.Text.Length != 12)) { MessageBox.Show("Должы быть заполены все поля!"); return; }
            _personal.Phone = PhoneBox.Text;

            if (SurnameBox.Text == "") { MessageBox.Show("Должы быть заполены все поля!"); return; }
            _personal.Surname = SurnameBox.Text;

            if (NameBox.Text == "") { MessageBox.Show("Должы быть заполены все поля!"); return; }
            _personal.Name = NameBox.Text;

            if (LastnameBox.Text == "") { MessageBox.Show("Должы быть заполены все поля!"); return; }
            _personal.Lastname = LastnameBox.Text;

            if (PasportBox.Text == "") { MessageBox.Show("Должы быть заполены все поля!"); return; }
            _personal.Pasport = PasportBox.Text;

            if (DateOfBirthBox.SelectedDate is null) { MessageBox.Show("Должы быть заполены все поля!"); return; }
            _personal.Date_of_birth = DateOfBirthBox.SelectedDate.Value;

            if (DateOfBirthBox.SelectedDate is null) { MessageBox.Show("Должы быть заполены все поля!"); return; }
            _personal.Addres = AdresBox.Text;

            if (ExperienceBox.Text == "") { MessageBox.Show("Должы быть заполены все поля!"); return; }
            _personal.Experience = int.Parse(ExperienceBox.Text);

            Personal.Save();
            MessageBox.Show("Даные изменены");
        }

        private void RemovePasswordBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LoginBox.Text != _personal.Login) { MessageBox.Show("Неверный логин"); return; }
            _personal.Login = LoginBox.Text;

            if ((OldPasswordBox.Password != _personal.Password) || (NewRepitPasswordBox.Password != NewPasswordBox.Password) || (NewPasswordBox.Password == "") || (NewPasswordBox.Password == _personal.Password))
            { MessageBox.Show("Неверно введён пароль"); return; }
            _personal.Password = GetHash(NewPasswordBox.Password);
            Personal.Save();
            MessageBox.Show("Пароль изменён"); 
        }
        private static string GetHash(string input)
        {
            byte[] data = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(input));
            var sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}
