using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.SqlClient;

namespace Pharmacy.Repositories
{
    class SQLRepository : IRepository 
    {
        
        PharmContext context;

        public SQLRepository(PharmContext phCon) {
            this.context = phCon;
        }

        public IEnumerable<Client> Clients
        {
            get
            {
                return context.Database.SqlQuery<Client>("SELECT * FROM Client").ToList();
            }
        }

        public IEnumerable<FarmGroup> FarmGroups
        {
            get
            {
                return context.Database.SqlQuery<FarmGroup>("SELECT * FROM FarmGroup").ToList();
            }
        }

        public IEnumerable<Medicine> Medicines
        {
            get
            {
                return context.Database.SqlQuery<Medicine>("SELECT * FROM Medicine").ToList();
            }
        }

        public IEnumerable<ReleaseForm> ReleaseForms
        {
            get
            {
                return context.Database.SqlQuery<ReleaseForm>("SELECT * FROM ReleaseForm").ToList();
            }
        }

        public IEnumerable<Request> Requests
        {
            get
            {
                return context.Database.SqlQuery<Request>("SELECT * FROM Request").ToList();
            }
        }

        public IEnumerable<ViewMedicine> GetViewMedicines()
        {
            return context.Database.SqlQuery<ViewMedicine>("SELECT m.Id Id, m.Name Name, m.Price Price, f.Name FarmGroup, r.Name ReleaseForm " +
            "FROM Medicine m INNER JOIN FarmGroup f on m.Id_FarmGroup=f.Id INNER JOIN ReleaseForm r on m.Id_ReleaseForm=r.Id").ToList();
        }

        public IEnumerable<ViewMedicine> GetViewMedicinesOfFarmGroup(string farmGroup)
        {

            var farmParam = new SqlParameter("@farmGroup", farmGroup);

            return context.Database.SqlQuery<ViewMedicine>("SELECT m.Id Id, m.Name Name, m.Price Price, f.Name FarmGroup, r.Name ReleaseForm " +
             "FROM Medicine m INNER JOIN FarmGroup f on m.Id_FarmGroup=f.Id INNER JOIN ReleaseForm r on m.Id_ReleaseForm=r.Id Where f.Name = @farmGroup", farmParam).ToList();
        } 

        public void Add<T>(T entity) where T : class
        {
            this.context.Set<T>().Add(entity);
        }


        public void Delete<T>(T entity) where T : class
        {
            this.context.Set<T>().Remove(entity);
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
             
    }
}
