
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketAPI.Models.Request
{
    public class ClientRequest
    {
        public long id { get; set; }
        public string clientName { get; set; }
        public string clientEmail { get; set; }
        public string clientAddress { get; set; }
        public string clientPhone { get; set; }
        public bool clientStatus { get; set; }
    }
}