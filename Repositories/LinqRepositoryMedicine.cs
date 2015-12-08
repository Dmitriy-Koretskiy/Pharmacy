using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Pharmacy.Repositories
{
    public class LinqRepositoryMedicine 
    {
        PharmContext context = new PharmContext();
        
      
        public IEnumerable<Medicine> Medicines
        {
            get
            {
                return context.Medicines.ToList();
            }
        }

        public IEnumerable<ViewMedicine> ViewMedicines(){
            List<ViewMedicine> list = new List<ViewMedicine>();
            var medicines = context.Medicines;
            foreach (Medicine curMed in medicines) {
                list.Add(new ViewMedicine(curMed.Id,curMed.Name,curMed.Price,curMed.FarmGroup.Name,curMed.ReleaseForm.Name));
            }
            return list;
        }
        public void SaveChanges()
        {
            this.context.SaveChanges();
        }      
    }
}
