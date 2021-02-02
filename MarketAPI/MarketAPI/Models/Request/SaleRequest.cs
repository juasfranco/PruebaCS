using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketAPI.Models.Request
{
    public class SaleRequest
    {
        public long Id { get; set; }
        public long ClientId { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal? SaleTotal { get; set; }
        public bool? SaleStatus { get; set; }
    }
}
