using MarketAPI.Models;
using MarketAPI.Models.Request;
using MarketAPI.Models.Response;
using MarketAPI.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketAPI.Services
{
    public class ServiceUser : InterfaceUserService
    {
        
        public UserResponse Auth(AuthRequest model)
        {
            UserResponse userResponse = null;
            using (var db = new MarketManagementContext())
            {
                string spassword = Encrypt.GetSHA256(model.UserPassword);
                var user = db.Users.Where(d => d.UserMail == model.UserMail &&
                                          d.UserPassword == spassword).FirstOrDefault();
                if (user == null) return null;
                userResponse.userMail = user.UserMail;
            }
            return userResponse;
        }
    }
}
