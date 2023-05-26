using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Santa_Final_ASP.Models.Entities;
using Santa_Final_ASP.Models.Identity;

namespace Santa_Final_ASP.Models.Contexts
{
    public class IdentityContext : IdentityDbContext<AppUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
        }

        public DbSet<AddressEntity> AspNetAddresses { get; set; }

        public DbSet<UserAddressEntity> AspNetUsersAddresses { get; set; }

    }
}
