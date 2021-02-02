using System;
using System.Collections.Generic;

#nullable disable

namespace MarketAPI.Models
{
    public partial class Sale
    {
        public Sale()
        {
            SaleConcepts = new HashSet<SaleConcept>();
        }

        public long Id { get; set; }
        public long ClientId { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal? SaleTotal { get; set; }
        public bool? SaleStatus { get; set; }

        public virtual Client Client { get; set; }
        public virtual ICollection<SaleConcept> SaleConcepts { get; set; }
    }
}
