
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using StmStartBibl;


namespace StmStart.Admin
{
    /// <summary>
    /// Логика взаимодействия для AllEmployeePage.xaml
    /// </summary>
    public partial class AllEmployeePage : Page
    {
        public Page NewEmployeePage;

        public AllEmployeePage(Frame PersonalFrame1)
        {
            PersonalFrame = PersonalFrame1;
            InitializeComponent();
            AddDataGridRow();
        }
        private Frame PersonalFrame;
        public void AddPage()
        {
            NewEmployeePage = new NewEmployeePage();
        }
        private void ButtonClickNewEmployee(object sender, RoutedEventArgs e)
        {
            AddPage();
            View.Navigate(NewEmployeePage);
        }
        private void AddDataGridRow()
        {
            AllPersonal.ItemsSource = Personal.GetAll();
        }
        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            AddDataGridRow();
        }
        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            var Personal = AllPersonal.SelectedValue as Personal;
            PersonalFrame.Navigate(new EmployeePage(Personal));
        }
        

    }
}
