using Microsoft.AspNet.Identity.EntityFramework;

namespace VPN.Web.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection2")
        {
        }
        public System.Data.Entity.DbSet<VPN.Core.Entities.VpnInfo> VpnInfoes { get; set; }
    }
}