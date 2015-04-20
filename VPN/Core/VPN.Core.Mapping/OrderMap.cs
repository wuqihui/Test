using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using VPN.Core.Entities;

namespace VPN.Core.Mapping
{
    public class OrderMap:ClassMap<Order>
    {
        public OrderMap()
        {
            Table("Orders");
            Id(x => x.Id, "OrderId").GeneratedBy.Identity();
            Map(x => x.CreateTime);
            Map(x => x.IsDeleted);
            References(x => x.User).Column("UserId");
            References(x => x.Vpn).Column("VpnId");
        }

    }
}
