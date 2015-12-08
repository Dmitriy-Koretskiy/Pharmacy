using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Pharmacy.Repositories
{
    class SQLRepositoryRequest
    {
        PharmContext context = new PharmContext();

      
        public IEnumerable<Request> Requests
        {
            get
            {
                return context.Database.SqlQuery<Request>("SELECT * FROM Request").ToList();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }    
    }
}
