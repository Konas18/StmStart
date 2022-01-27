using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using StmStartBibl;

namespace StmStart.Admin
{
    /// <summary>
    /// Логика взаимодействия для NewEmpoleePage.xaml
    /// </summary>
    public partial class NewEmployeePage : Page
    {
        public NewEmployeePage()
        {
            InitializeComponent();
        }
        private readonly char[] _phonesymb = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private void AddPersonBtn_Click(object sender, RoutedEventArgs e)
        {

            var Personal = new Personal();
            if ((PhoneBox.Text == "") && (PhoneBox.Text.Length != 12)) { MessageBox.Show("Должы быть заполены все поля!"); return; }
            Personal.Phone = PhoneBox.Text;

            if (SurnameBox.Text == "") { MessageBox.Show("Должы быть заполены все поля!"); return; }
            Personal.Surname = SurnameBox.Text;

            if (NameBox.Text == "") { MessageBox.Show("Должы быть заполены все поля!"); return; }
            Personal.Name = NameBox.Text;

            if (LastnameBox.Text == "") { MessageBox.Show("Должы быть заполены все поля!"); return; }
            Personal.Lastname = LastnameBox.Text;

            if (PasportBox.Text == "") { MessageBox.Show("Должы быть заполены все поля!"); return; }
            Personal.Pasport = PasportBox.Text;

            if (DateOfBirthBox.SelectedDate is null) { MessageBox.Show("Должы быть заполены все поля!"); return; }
            Personal.Date_of_birth = DateOfBirthBox.SelectedDate.Value;

            if (DateOfBirthBox.SelectedDate is null) { MessageBox.Show("Должы быть заполены все поля!"); return; }
            Personal.Addres = AdresBox.Text;

            if (ExperienceBox.Text == "") { MessageBox.Show("Должы быть заполены все поля!"); return; }
            Personal.Experience = int.Parse(ExperienceBox.Text);

            Personal.PostName = PostCmBox.Text;

            if (LoginBox.Text == "") { MessageBox.Show("Должы быть заполены все поля!"); return; }
            Personal.Login = LoginBox.Text;

            if ((PasswordBox.Password == "") || (RepitPasswordBox.Password != RepitPasswordBox.Password)) { MessageBox.Show("Должы быть заполены все поля!"); return; }
            Personal.Password = PasswordBox.Password;

            Personal.Add(Personal);
            MessageBox.Show("Сотрудник добавлен");
        }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Content = null;
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
