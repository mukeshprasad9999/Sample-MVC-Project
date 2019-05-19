using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("name=SecurityMVC")
        {
            //Database.SetInitializer<DatabaseContext>(new CreateDatabaseIfNotExists<DatabaseContext>());
        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Agent> Agents { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //remove it on all tables
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //m:m
            modelBuilder.Entity<User>().HasMany(u => u.Roles).WithMany(r => r.Users).Map(m =>
            {
                m.MapLeftKey("UserId");
                m.MapRightKey("RoleId");
                m.ToTable("UserRoles");
            });
        }
    }


}
