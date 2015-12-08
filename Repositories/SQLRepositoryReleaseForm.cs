using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Pharmacy.Repositories
{
    class SQLRepositoryReleaseForm
    {
        PharmContext context = new PharmContext();

       
        public IEnumerable<ReleaseForm> ReleaseForms
        {
            get
            {
                return context.Database.SqlQuery<ReleaseForm>("SELECT * FROM ReleaseForm").ToList();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}
