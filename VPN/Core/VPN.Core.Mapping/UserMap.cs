using FluentNHibernate.Mapping;
using VPN.Core.Entities;

namespace VPN.Core.Mapping
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("Users");
            Id(x => x.Id, "UserId").GeneratedBy.Identity();
            Map(x => x.UserName);
            Map(x => x.Password);
            Map(x => x.Sex).CustomType<EntityEnums.Sex>(); 
            Map(x => x.CreateTime);
           // Map(x => x.Timestamp);
            Map(x => x.IsDeleted);
            HasMany(x => x.Orders).KeyColumn("UserId");
        }
    }
}
