using System;
using System.Collections.Generic;

#nullable disable

namespace MarketAPI.Models
{
    public partial class User
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserMail { get; set; }
    }
}
