using System;
using System.Collections.Generic;

#nullable disable

namespace MarketAPI.Models
{
    public partial class Client
    {
        public Client()
        {
            Sales = new HashSet<Sale>();
        }

        public long Id { get; set; }
        public string ClientName { get; set; }
        public string ClientEmail { get; set; }
        public string ClientAddress { get; set; }
        public string ClientPhone { get; set; }
        public bool? ClientStatus { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
