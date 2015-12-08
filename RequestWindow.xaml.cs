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
using System.Windows.Shapes;
using Pharmacy.Repositories;
using Pharmacy.Helpers;
using System.Data.Entity;
using System.Data;

namespace Pharmacy
{
    /// <summary>
    /// Interaction logic for Request.xaml
    /// </summary>
    public partial class RequestWindow : Window
    {
        private int idMed;
        public RequestWindow(int id)
        {
            InitializeComponent();
            idMed = id;
        }

        private void B_Confirm_Click(object sender, RoutedEventArgs e)
        {
            PharmContext context = new PharmContext();
            LinqRepository lrep = new LinqRepository(context);
            Helper helper = new Helper(lrep);
            helper.AddRequestFromForm(TB_Name.Text, idMed, byte.Parse(TB_Amount.Text));
            this.Close();
        }
    }
}
