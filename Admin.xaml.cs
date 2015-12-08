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
using System.Windows.Shapes;
using Pharmacy.Repositories;
using Pharmacy.Helpers;
using System.Data.Entity;
using System.Data;

namespace Pharmacy
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        private string currentTable;
        private Delegates userDelegates;
        public static PharmContext mainCont = new PharmContext();
        public IRepository mainRep = new LinqRepository(mainCont);


        public Admin()
        {
            InitializeComponent();
            userDelegates = new Delegates();
        }
 
        private void B_update_Click(object sender, RoutedEventArgs e)
        {
            mainCont.SaveChanges();
        }

        private void B_insert_Click(object sender, RoutedEventArgs e)
        {

            Helper help = new Helper(mainRep);
            userDelegates.AddUniversal[currentTable](help);
              
            userDelegates.FillFromTable[currentTable](TablesDataGrid, mainRep);
         
        }

        private void B_delete_Click(object sender, RoutedEventArgs e)
        {
            Helper help = new Helper(mainRep);
            userDelegates.DeleteUniversal[currentTable](TablesDataGrid, help);
            userDelegates.FillFromTable[currentTable](TablesDataGrid, mainRep);
           
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentTable = ((ComboBoxItem)CBox.SelectedItem).Content.ToString();//получение текущей таблицы
            userDelegates.FillFromTable[currentTable](TablesDataGrid, mainRep);
        }       
    }
}
