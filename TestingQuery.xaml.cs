using Pharmacy.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Pharmacy
{
    /// <summary>
    /// Interaction logic for TestingQuery.xaml
    /// </summary>
    public partial class TestingQuery : Window
    {
       private int numberOfRepeats;
       private int value;
     

       public TestingQuery()
        {
            InitializeComponent();
        }

       public void CountTime(int numberOfRepeats, int max)
       {
            PharmContext context = new PharmContext();
            LinqRepository linqRep = new LinqRepository(context);
            SQLRepository sqlRep = new SQLRepository(context);
            List<Result> list= new List<Result>();
            string linqTime;
            string sqlTime;

           
            Stopwatch linqStopwatch = new Stopwatch();
            Stopwatch sqlStopwatch = new Stopwatch();
            for (int i = 1; i <= numberOfRepeats; i++)
            {
                linqStopwatch.Restart();
                linqRep.GetViewMedicines();
                linqStopwatch.Stop();
                sqlStopwatch.Start();
                sqlRep.GetViewMedicines();
                linqTime = "" + linqStopwatch.ElapsedTicks;
                sqlTime = "" + sqlStopwatch.ElapsedTicks;
                list.Add(new Result(i,linqTime,sqlTime));
            }

            Grid_Result.ItemsSource = list;
           
        }

      public class Result {
          public int currentStep { get; set; }
          public string linq { get; set; }
          public string sql { get; set; }

            public   Result(int step, string t1, string t2) {
                currentStep = step;
                linq = t1;
                sql = t2;
            }
        }

      private void B_Execute_Click(object sender, RoutedEventArgs e)
      {
          numberOfRepeats = int.Parse(TB_Step.Text);
          value = int.Parse(TB_MaxValue.Text);
          CountTime(numberOfRepeats, value);
      }
    }

}
