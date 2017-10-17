using System.Collections.Generic;
using System.IO;
using System.Text;
using DataAccess.Context;
using Domain.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccess.Context.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }


        protected override void Seed(DataContext context)
        {
            //if (context.Groups.Any()) return;

            Group group = new Group()
            {
                Name = "ALUS"
            };

            context.Groups.AddOrUpdate(group);

            Event newEvent = new Event()
            {
                Attendances= new List<UserEventAttendance>(),
                DateOfOccurance = new DateTime(1997, 11, 24, 15, 25, 25),
                Description = "TESTASSS",
                Location = "Snekutis",
                Title = "BeerPong",
                OfGroup = group,
            };

            context.Events.AddOrUpdate(newEvent);

            User user1, user2;
            CreateTestUsers(context, out user1, out user2);


            context.SaveChanges();
            base.Seed(context);
        }

        private static void CreateTestUsers(DataContext context, out User user, out User user2)
        {
            var store = new UserStore<User>(context);
            var userManager = new UserManager<User>(store);

            user = new User
            {
                UserName = "admin",
                Email = "admin@admin.com"
            };
            const string password = "admin";

            userManager.Create(user, password);

            user2 = new User
            {
                UserName = "guest",
                Email = "guest@guest.com"
            };
            const string password2 = "guest";

            userManager.Create(user2, password2);
        }
    }
}
