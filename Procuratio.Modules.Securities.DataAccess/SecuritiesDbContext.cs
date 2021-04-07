using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Securities.Domain.Entities;
using Procuratio.Modules.Securities.Domain.Entities.MicrosoftIdentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Securities.DataAccess
{
    public class SecuritiesDbContext : IdentityDbContext<User, Role, int, UserClaim,
                                       UserRole, UserLogin, RoleClaim, UserToken>
    {
        //public DbSet<Role> Role { get; set; }
        //public DbSet<RoleClaim> RoleClaim { get; set; }
        //public DbSet<User> User { get; set; }
        //public DbSet<UserClaim> UserClaim { get; set; }
        //public DbSet<UserLogin> UserLogin { get; set; }
        //public DbSet<UserRole> UserRole { get; set; }
        //public DbSet<UserToken> UserToken { get; set; }
        public DbSet<Restaruant> Restaruant { get; set; }

        public SecuritiesDbContext(DbContextOptions<SecuritiesDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Securities");

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
