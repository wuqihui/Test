
using FluentNHibernate.Mapping;
using VPN.Core.Entities;

namespace VPN.Core.Mapping
{
    public class VpnInfoMap:ClassMap<VpnInfo>
    {
        public VpnInfoMap()
        {
            Table("VpnInfos");
            Id(x => x.Id, "VpnInfoId").GeneratedBy.Identity();
            Map(x => x.Speed);
            Map(x => x.IpAddress);
            Map(x => x.CreateTime);
            //Map(x => x.Timestamp);
            Map(x => x.IsDeleted);
        }
    }
}
