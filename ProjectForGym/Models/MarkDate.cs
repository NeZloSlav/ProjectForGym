using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectForGym.Models
{
    public class MarkDate
    {
        public DateTime DateMark { get; set; }
        public int IDClient { get; set; }
        public virtual ICollection<Client> Clients { get; private set; } = new ObservableCollection<Client>();

    }
}
