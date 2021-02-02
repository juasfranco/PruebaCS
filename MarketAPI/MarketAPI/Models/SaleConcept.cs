using System;
using System.Collections.Generic;

#nullable disable

namespace MarketAPI.Models
{
    public partial class SaleConcept
    {
        public long Id { get; set; }
        public long SaleId { get; set; }
        public int SaleConceptQuantity { get; set; }
        public decimal SaleConceptUnitValue { get; set; }
        public decimal SaleConceptCost { get; set; }
        public long ProductId { get; set; }
        public bool? SaleConceptStatus { get; set; }

        public virtual Product Product { get; set; }
        public virtual Sale Sale { get; set; }
    }
}
