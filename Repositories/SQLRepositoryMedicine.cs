using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Pharmacy.Repositories
{
    class SQLRepositoryMedicine
    {
        PharmContext context = new PharmContext();

       
        public IEnumerable<Medicine> Medicines
        {
            get
            {
                return context.Database.SqlQuery<Medicine>("SELECT * FROM Medicine").ToList();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }     
    }
}
