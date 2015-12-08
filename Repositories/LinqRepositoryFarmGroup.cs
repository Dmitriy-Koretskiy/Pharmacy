using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Pharmacy.Repositories
{
    public class LinqRepositoryFarmGroup 
    {
        PharmContext context = new PharmContext();

    
        public IEnumerable<FarmGroup> FarmGroups
        {
            get
            {
                return context.FarmGroups.ToList();
            }
        }


        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

    }
}
