using VPN.Core.Entities;

namespace VPN.Core.IRepositories
{
    public interface IUserRepository : IBaseRepository<User,int>
    {
        int SaveOrders(Order order);
    }
}
