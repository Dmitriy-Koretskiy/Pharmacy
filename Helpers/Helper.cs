using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pharmacy.Repositories;
using System.Threading.Tasks;

namespace Pharmacy.Helpers
{
    public class Helper
    {
        public Helper(IRepository repository)
        {
            this.context = repository;
        }
        
       
        private IRepository context;

        public void AddClient(string name="", string address="")
        {
            var d = new Client() { Name = name, Address=address };
            context.Add(d);
            context.SaveChanges();
        }

        public void DeleteClient(int id)
        {
            var d = GetClient(id);
            context.Delete(d);
            context.SaveChanges();
        }

        public Client GetClient(int id)
        {
            return context.Clients.First(x => x.Id == id);
        }

        public void AddFarmGroup(string name = "")
        {
            var d = new FarmGroup() { Name = name};
            context.Add(d);
            context.SaveChanges();
        }

        public void DeleteFarmGroup(int id)
        {
            var d = GetFarmGroup(id);
            context.Delete(d);
            context.SaveChanges();
        }

        public FarmGroup GetFarmGroup(int id)
        {
            return context.FarmGroups.First(x => x.Id == id);
        }

        
        public void AddMedicine(string name = "", byte id_fgroup = 1, byte id_relform=1,decimal price=10)
        {
            var d = new Medicine() { Name = name, Id_FarmGroup = id_fgroup, Id_ReleaseForm= id_relform, Price=price };
            context.Add(d);
            context.SaveChanges();
        }

        public void DeleteMedicine(int id)
        {
            var d = GetMedicine(id);
            context.Delete(d);
            context.SaveChanges();
        }

        public Medicine GetMedicine(int id)
        {
            return context.Medicines.First(x => x.Id == id);
        }

        public void AddRequest(int id_cient = 1,int id_medicine= 1, byte amount=1 )
        {
            var d = new Request() { Id_Client=id_cient, Id_Medicine=id_medicine, Amount=amount, Time=DateTime.Now };
            context.Add(d);
            context.SaveChanges();
        }

        public void AddRequestFromForm(string client = "", int id_medicine = 1, byte amount = 1)
        {
            if (!context.Clients.Any(x => x.Name==client)) {
                this.AddClient(client);              
            }
            var rowClient = context.Clients.First(x => x.Name == client);
            var d = new Request() { Id_Client = rowClient.Id, Id_Medicine = id_medicine, Amount = amount, Time = DateTime.Now };
            context.Add(d);
            context.SaveChanges();
        }

        public void DeleteRequest(int id)
        {
            var d = GetRequest(id);
            context.Delete(d);
            context.SaveChanges();
        }

        public Request GetRequest(int id)
        {
            return context.Requests.First(x => x.Id == id);
        }

        public void AddReleaseForm(string name = "")
        {
            var d = new ReleaseForm() { Name = name };
            context.Add(d);
            context.SaveChanges();
        }

        public void DeleteReleaseForm(int id)
        {
            var d = GetReleaseForm(id);
            context.Delete(d);
            context.SaveChanges();
        }

        public ReleaseForm GetReleaseForm(int id)
        {
            return context.ReleaseForms.First(x => x.Id == id);
        }
    }
}
