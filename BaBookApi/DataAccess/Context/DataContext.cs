using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Configuration;
using Domain.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DataAccess.Context
{
    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<UserEventAttendance> UserEventAttendances { get; set; }

        public DataContext() : base("DataContext", throwIfV1Schema: false)
        {
            Database.SetInitializer<DataContext>(null);
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public static DataContext Create()
        {
            return new DataContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove();

            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new GroupConfiguration());
            modelBuilder.Configurations.Add(new EventConfiguration());
            modelBuilder.Configurations.Add(new UserEventAttendanceConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
