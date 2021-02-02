using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketAPI.Models.Request
{
    public class ProductRequest
    {
        public long id { get; set; }
        public string productName { get; set; }
        public decimal productUnitValue { get; set; }
        public decimal productFinalCost { get; set; }
        public int productStock { get; set; }
        public bool? productStatus { get; set; }
    }
}