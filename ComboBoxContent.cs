using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy
{
    public class ComboBoxContent
    {
        public ObservableCollection<string> CBoxContent { get; private set; }

        public ComboBoxContent(List<String> list)
        {
            CBoxContent = new ObservableCollection<string>(list);                 
        }
    }
}

