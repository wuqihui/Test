using NHibernate;
using VPN.Core.Entities;
using VPN.Core.IRepositories;

namespace VPN.Core.Repositories
{
    public class VpnRepository : RepositoryBase<VpnInfo,int>, IVpnRepository
    {
        public VpnRepository(ISession session) : base(session)
        {
        }
    }
}
