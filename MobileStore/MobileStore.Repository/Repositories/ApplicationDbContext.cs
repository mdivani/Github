using MobileStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileStore.Repository.Migrations;

namespace MobileStore.Repository.Repositories
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("DbMobileStore") {
            Database.SetInitializer<ApplicationDbContext>(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration >());
        }

        internal IDbSet<User> Users { get; set; }
        internal IDbSet<Role> Roles { get; set; }
        internal IDbSet<Phone> Phones { get; set; }
        internal IDbSet<Post> Posts { get; set; }
        internal IDbSet<Comment> Comments { get; set; }
        internal IDbSet<Manufacturer> Manufacturers { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            //modelBuilder.Configurations.Add(new UserConfiguration());
            //modelBuilder.Configurations.Add(new RoleConfiguration());
            ////modelBuilder.Configurations.Add(new ExternalLoginConfiguration());
            //modelBuilder.Configurations.Add(new ClaimConfiguration());
        }
    }
}
