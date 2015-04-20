using System;

namespace VPN.Core.Entities
{
    public class VpnInfo:EntityBase<int>
    {
        public virtual int Speed { get; set; }
        public virtual string IpAddress { get; set; }
    }
}
