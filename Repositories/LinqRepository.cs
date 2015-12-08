using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Repositories
{
  public  class LinqRepository:IRepository
    {

        PharmContext context;

        public LinqRepository(PharmContext phCon) {
            this.context = phCon;
        }

        public IEnumerable<Client> Clients
        {
            get
            {
                return context.Clients.ToList();
            }
        }

        public IEnumerable<FarmGroup> FarmGroups
        {
            get
            {
                return context.FarmGroups.ToList();
            }
        }

        public IEnumerable<Medicine> Medicines
        {
            get
            {
                return context.Medicines.ToList();
            }
        }

        public IEnumerable<ReleaseForm> ReleaseForms
        {
            get
            {
                return context.ReleaseForms.ToList();
            }
        }

        public IEnumerable<ViewMedicine> GetViewMedicines()
        {
            List<ViewMedicine> list = new List<ViewMedicine>();
            List<Medicine> medicines = context.Medicines.ToList(); ;
            foreach (Medicine curMed in medicines)
            {
                list.Add(new ViewMedicine(curMed.Id, curMed.Name, curMed.Price, curMed.FarmGroup.Name, curMed.ReleaseForm.Name));
            }
            return list;
        }

        public IEnumerable<ViewMedicine> GetViewMedicinesOfFarmGroup(string farmGroup)
        {
            List<ViewMedicine> list = new List<ViewMedicine>();
            List<Medicine> medicines = context.Medicines.Where(m => m.FarmGroup.Name == farmGroup).ToList();
            foreach (Medicine curMed in medicines)
            {
                list.Add(new ViewMedicine(curMed.Id, curMed.Name, curMed.Price, curMed.FarmGroup.Name, curMed.ReleaseForm.Name));
            }
            return list;
        } 

        public IEnumerable<Request> Requests
        {
            get
            {
                return context.Requests.ToList();
            }
        }

       public  void Add<T>(T entity) where T : class {
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
