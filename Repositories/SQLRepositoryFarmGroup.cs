using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Pharmacy.Repositories
{
    class SQLRepositoryFarmGroup
    {
        PharmContext context = new PharmContext();

      
        public IEnumerable<FarmGroup> FarmGroups
        {
            get
            {
                return context.Database.SqlQuery<FarmGroup>("SELECT * FROM FarmGroup").ToList();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
             
    }
}
