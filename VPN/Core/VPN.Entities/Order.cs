using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPN.Core.Entities
{
    public class Order:EntityBase<int>
    {
        public virtual User User{ get; set; }
        public virtual VpnInfo Vpn { get; set; }
            
    }
}
