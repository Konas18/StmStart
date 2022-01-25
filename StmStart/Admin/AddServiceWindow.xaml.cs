using StmStartBibl;
using System;
using System.Windows;
using System.Windows.Controls;

namespace StmStart.Admin
{
    /// <summary>
    /// Логика взаимодействия для AddServiceWindow.xaml
    /// </summary>
    public partial class AddServiceWindow : Window
    {
        private DataGrid dg1;
        public Tooth_History s1;
        public AddServiceWindow(DataGrid dg)
        {
            dg1 = dg;
            InitializeComponent();
            WindowState = WindowState.Normal;
            double screenHeight = SystemParameters.FullPrimaryScreenHeight;
            this.Top = 0;
            AddDataGridRow();
        }
        private void AddDataGridRow()
        {
            AllService.ItemsSource = Services.GetAll();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            s1 = new Tooth_History();
            var s2 = AllService.SelectedValue as Services;
            s1.ToothNumber = 0;
            s1.Services = s2;
            s1.DateTimeService = DateTime.Now;
            int[] Tooths = new int[49];
            int[] ServiceId = { 3, 4, 6, 7, 8, 10, 11 };

            for (int i = 11; i < 49; i++)
                if (i == 19 || i == 20 || i == 29 || i == 30 || i == 39 || i == 40)
                    continue;
                else Tooths[i-11] = i;

            Boolean check = false;

            for (int i = 0; i < 7; i++)
                if (ServiceId[i] == s2.ID)
                    if (ToothNumberBox.Text != "")
                    {
                        for (int j = 0; j < Tooths.Length; j++)
                            if (Tooths[j] == int.Parse(ToothNumberBox.Text))
                            {
                                s1.ToothNumber = int.Parse(ToothNumberBox.Text);
                                check = true;
                                break;
                            }
                        if (!check)
                        {
                            MessageBox.Show("ОШИБКА: Неправильный номер зуба");
                            s1 = null;
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("ОШИБКА: Введите номер зуба");
                        s1 = null;
                        return;
                    }

            dg1.Items.Add(s1);
            ToothNumberBox.Text = "";
            MessageBox.Show("Услуга добавлена");
        }
    }
}
