using System;
using System.Collections.Generic;

#nullable disable

namespace MarketAPI.Models
{
    public partial class Product
    {
        public Product()
        {
            SaleConcepts = new HashSet<SaleConcept>();
        }

        public long Id { get; set; }
        public string ProductName { get; set; }
        public decimal ProductUnitValue { get; set; }
        public decimal ProductFinalCost { get; set; }
        public int ProductStock { get; set; }
        public bool? ProductStatus { get; set; }

        public virtual ICollection<SaleConcept> SaleConcepts { get; set; }
    }
}
