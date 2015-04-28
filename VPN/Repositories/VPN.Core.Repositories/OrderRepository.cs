using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using VPN.Core.Entities;
using VPN.Core.IRepositories;

namespace VPN.Core.Repositories
{
    public class OrderRepository : RepositoryBase<Order, int>, IOrderRepostitory
    {
        public OrderRepository(ISession session) : base(session)
        {
        }
    }
}
