using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using VPN.Core.Entities;
using VPN.Core.IRepositories;
using VPN.Core.IServices;

namespace VPN.Core.Services
{
    public class UserService : ServiceBase<User,int>, IUserService
    {
        public UserService(IUserRepository currentRepository): base(currentRepository)
        {
        }

        public System.Security.Claims.ClaimsIdentity CreateIdentity(User user, string authenticationType)
        {
            ClaimsIdentity _identity = new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie);
            _identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
            _identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            _identity.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "ASP.NET Identity"));
            _identity.AddClaim(new Claim("DisplayName", user.UserName));
            return _identity;
        }

        public int SaveOrders(Order order)
        {
            return ((IUserRepository) CurrentRepository).SaveOrders(order);
        }
    }
}
