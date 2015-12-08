using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Pharmacy.Repositories
{
    public class LinqRepositoryClient 
    {
        PharmContext context;

        public LinqRepositoryClient(PharmContext phCon) {
            this.context = phCon;
        }

        public IEnumerable<Client> Clients
        {
            get
            {
                return context.Clients.ToList();
            }
        }

        public Client GetClient(int id) { 
           return Clients.First(x => x.Id == id);
        }

        public void Add(Client entity) 
        {
            this.context.Entry(entity).State = EntityState.Added;
            this.context.SaveChanges();
        }

        public void Delete(Client entity) 
        {
            this.context.Entry(entity).State = EntityState.Deleted;
            this.context.SaveChanges();
        }

        public void Update(Client entity)
        {
           // this.context.Clients.Attach(entity);
            this.context.Entry(entity).State = EntityState.Modified;
            this.context.SaveChanges();
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}
