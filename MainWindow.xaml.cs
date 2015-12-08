using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Pharmacy.Repositories;
using Pharmacy.Helpers;
using System.Data.SqlClient;

namespace Pharmacy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PharmContext db;
        IRepository repository;

        public MainWindow()
        {
            InitializeComponent();
            db = new PharmContext();
            repository = new SQLRepository(db);
            List<String> list = new List<string>();
            List<FarmGroup> relList = repository.FarmGroups.ToList();
            var parameters = new[] {

            new SqlParameter("@Max", 6),
            new SqlParameter("@Min", 2)};
           
           string d = db.generateRandomInt(1, 4).ToString();
            int a = db.SQLRandomInt(4, 2);
            foreach (FarmGroup rel in relList)
            {
                list.Add(rel.Name);
            }

            Grid_Medicine.ItemsSource = repository.GetViewMedicines();
           
            DataContext = new ComboBoxContent(list);
        }
      

        private void B_Request_Click(object sender, RoutedEventArgs e)
        {
            ViewMedicine vm = (ViewMedicine)Grid_Medicine.SelectedItem;            
            RequestWindow rw = new RequestWindow(vm.Id);
            rw.Show();
        }

        private void B_Admin_Click(object sender, RoutedEventArgs e)
        {
            Window w = new Admin();
            w.Show();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string currentFarmGroup= CBox.SelectedItem.ToString();
            Helper help = new Helper(repository);
            Grid_Medicine.ItemsSource = repository.GetViewMedicinesOfFarmGroup(currentFarmGroup);
        }

        private void B_Clear_Click(object sender, RoutedEventArgs e)
        {
            Grid_Medicine.ItemsSource = repository.GetViewMedicines();
        }

        private void B_Test_Click(object sender, RoutedEventArgs e)
        {
            TestingQuery wTest = new TestingQuery();
            wTest.Show();
        }
    }
}
