using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Pharmacy.Repositories
{
    public class LinqRepositoryReleaseForm
    {
       PharmContext context = new PharmContext();

        //public void Add<T>(T newItem) where T : class
        //{
        //    db.Set<T>().Add(newItem);
        //}
        public IEnumerable<ReleaseForm> ReleaseForms
        {
            get
            {
                return context.ReleaseForms.ToList();
            }
        }

        public ReleaseForm GetReleaseForm(int id)
        {
            return ReleaseForms.First(x => x.Id == id);
        }

        public void Add(ReleaseForm entity)
        {
            this.context.Entry(entity).State = EntityState.Added;
            this.context.SaveChanges();
        }

        public void Delete(ReleaseForm entity)
        {
            this.context.Entry(entity).State = EntityState.Deleted;
            this.context.SaveChanges();
        }

        public void Update(ReleaseForm entity)
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
