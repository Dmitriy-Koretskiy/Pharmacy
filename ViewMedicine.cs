using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy
{
    public class ViewMedicine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string FarmGroup { get; set; }
        public string ReleaseForm { get; set; }

        public ViewMedicine() { }

        public ViewMedicine(int id, string name, decimal price, string farmGroup, string releaseForm) {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.FarmGroup = farmGroup;
            this.ReleaseForm = releaseForm;
        }
    }
}
