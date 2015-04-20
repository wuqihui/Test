using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using VPN.Core.Entities;

namespace VPN.Core.IServices
{
    public interface IUserService : IServiceBase<User,int>
    {
        ClaimsIdentity CreateIdentity(User user, string authenticationType);
        int SaveOrders(Order order);

    }
}
