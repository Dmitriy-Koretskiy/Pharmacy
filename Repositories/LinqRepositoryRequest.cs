using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Pharmacy.Repositories
{
    public class LinqRepositoryRequest 
    {
        PharmContext context = new PharmContext();

      
        public IEnumerable<Request> Requests
        {
            get
            {
                return context.Requests.ToList();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

    
    }
}
