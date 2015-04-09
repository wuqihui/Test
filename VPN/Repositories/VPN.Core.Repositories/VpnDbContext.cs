using System.Data.Entity;
using VPN.Core.Entities;

namespace VPN.Core.Repositories
{
    public class VpnDbContext : DbContext
    {
        public VpnDbContext()
            : base("DefaultConnection")
        {
        }
        public DbSet<VpnInfo> VpnInfos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<UserConfig> UserConfig { get; set; }
    }
}
