using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketAPI.Models.Request
{
    public class AuthRequest
    {
        [Required]
        public string UserMail { get;set; }
        [Required]
        public string UserPassword { get; set; }
    }
}
