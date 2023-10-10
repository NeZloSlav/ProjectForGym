using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectForGym.Models
{
    public class Tariff
    {
        public int IDTariff { get; set; }
        public string Name { get; set; }
        public int CountOfDays { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Client> Clients { get; private set; } = new ObservableCollection<Client>();
    }
}
