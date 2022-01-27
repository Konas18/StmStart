using StmStartBibl;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using StmStart.Doctor;
using StmStart.Admin;



namespace StmStart
{
    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Window
    {
        public Autorization()
        {
            InitializeComponent();
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            Personal personal = Personal.GetPerson(TextBoxLogin.Text.Trim(), GetHash(PasswordBox.Password.Trim()));
            if (personal != null)
            {
                switch (personal.PostName)
                {
                    case "Админ":
                        AdminWindow mainWindow1 = new AdminWindow(personal);
                        mainWindow1.Show();
                        this.Close();
                        break;
                    case "Врач":
                        DoctorWindow mainWindow2 = new DoctorWindow(personal);
                        mainWindow2.Show();
                        this.Close();
                        break;
                    default:
                        MessageBox.Show("Сотруднику не задана роль, текущая: " + personal.PostName);
                        break;
                }
            }
            else MessageBox.Show("C таким логином и паролем сотрудник не найден");
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