
using VPN.Core.Entities;
using VPN.Core.IRepositories;
using VPN.Core.IServices;

namespace VPN.Core.Services
{
    public class OrderService:ServiceBase<Order,int>,IOrderService
    {
        public OrderService(IOrderRepostitory currentRepository) : base(currentRepository)
        {
        }
    }
}
