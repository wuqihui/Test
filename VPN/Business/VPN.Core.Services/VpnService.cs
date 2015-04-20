using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VPN.Core.Entities;
using VPN.Core.IRepositories;
using VPN.Core.IServices;

namespace VPN.Core.Services
{
    public class VpnService : ServiceBase<VpnInfo,int>, IVpnService
    {
        public VpnService(IVpnRepository currentRepository) : base(currentRepository)
        {
        }
    }
}
