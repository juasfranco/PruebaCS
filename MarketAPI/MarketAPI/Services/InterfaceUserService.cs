using MarketAPI.Models.Request;
using MarketAPI.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketAPI.Services
{
    interface InterfaceUserService
    {
        UserResponse Auth(AuthRequest model);

    }
}
