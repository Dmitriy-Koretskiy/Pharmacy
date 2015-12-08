using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Pharmacy.Repositories
{
    public interface IRepository
    {
        IEnumerable<Client> Clients { get; }
        IEnumerable<FarmGroup> FarmGroups { get; }
        IEnumerable<Medicine> Medicines { get; }
        IEnumerable<ReleaseForm> ReleaseForms { get; }
        IEnumerable<Request> Requests { get; }
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void SaveChanges();
        IEnumerable<ViewMedicine> GetViewMedicines();
        IEnumerable<ViewMedicine> GetViewMedicinesOfFarmGroup(string farmGroup);
    }
}
