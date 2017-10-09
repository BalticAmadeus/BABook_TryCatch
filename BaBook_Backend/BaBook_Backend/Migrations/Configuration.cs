using System.Collections.Generic;
using BaBook_Backend.Context;
using BaBook_Backend.Models;

namespace BaBook_Backend.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataContext context)
        {

            Group group = new Group()
            {
                Name = "ALUS"
            };

            context.Groups.AddOrUpdate(group);

            User user1 = new User()
            {
                Name = "admin"

            };

            User user2 = new User()
            {
                Name = "guest"
            };

            context.Users.AddOrUpdate(user1);
            context.Users.AddOrUpdate(user2);


            Event newEvent = new Event()
            {
                AttendingUsers = new List<User>(),
                DateOfOccurance = new DateTime(1997,11,24, 15,25,25),
                Description = "TESTASSS",
                Location = "Snekutis",
                Title = "BeerPong",
                OfGroup = group,
                OwnerUser = user1
            };

            context.Events.AddOrUpdate(newEvent);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
