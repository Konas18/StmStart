using StmStartBibl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace StmStart.Admin
{
    /// <summary>
    /// Логика взаимодействия для ToothWindow.xaml
    /// </summary>
    public partial class ToothWindow : Window
    {
        private int tn1;
        private Client _client;

        public ToothWindow(Client client, int tn)
        {
            _client = client;
            tn1 = tn;
            InitializeComponent();
            WindowState = WindowState.Normal;
            double screenHeight = SystemParameters.FullPrimaryScreenHeight;
            this.Top = 0;
            AddDataGridRow();
        }
        private void AddDataGridRow()
        {
            List<Tooth_History> items = new List<Tooth_History>();
            List<Tooth_History> toothHistory = Tooth_History.GetAll();

            toothHistory = toothHistory.Where(th => th.ToothNumber == tn1).ToList();

            toothHistory = toothHistory.Where(th => th.Client == _client).ToList();

            foreach (var th in toothHistory)
            {
                items.Add(th);
            }
            ToothHistory.ItemsSource = items;
        }
    }
}
