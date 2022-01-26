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
using StmStart;
using StmStartBibl;

namespace StmStart.Doctor
{
    /// <summary>
    /// Логика взаимодействия для AppointmentPage.xaml
    /// </summary>
    public partial class AppointmentPage : Page
    {
        public AppointmentPage()
        {
            InitializeComponent();
            ShowDoctors();
            AddDataGridRow();
        }
        private void AddDataGridRow()
        {
            AllAppointment.ItemsSource = Reception.GetAll();
        }

        private void AllAppointment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            AddDataGridRow();
            List<Reception> items = new List<Reception>();
            List<Reception> receptions = Reception.GetAll();
            if (SortClientSurname.Text != "")
            {
                receptions = receptions.Where(r => r.Client.GetFullName.Equals(SortClientSurname.Text)).ToList();
            }
            if (SortDoctorSurname.SelectedIndex != -1)
            {
                receptions = receptions.Where(r => r.Personal.Surname == SortDoctorSurname.Text).ToList();
            }
            if (SortDate.SelectedDate != null)
            {
                receptions = receptions.Where(r => r.GetDateOfAppointment.Equals(SortDate.Text)).ToList();
            }
            foreach (var reception in receptions)
            {
               items.Add(reception.GetReceptionById(reception.ID));
            }
            AllAppointment.ItemsSource = items;
        }
        private void ShowDoctors()
        {
            foreach (var person in Personal.GetAll())
            {
                if (person.PostName == "Врач")
                SortDoctorSurname.Items.Add(person.Surname);
            }
        }
        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            SortClientSurname.Text = "";
            SortDoctorSurname.Text = "";
            SortDate.Text = "";
            AddDataGridRow();
        }
    }
}
