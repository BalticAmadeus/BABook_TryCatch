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
                GroupId = 1,
                Name = "ALUS"
            };

            context.Groups.Add((group));

            User user1 = new User()
            {
                Name = "admin"

            };

            context.Users.Add((user1));

            User user2 = new User()
            {
                Name = "guest"
            };

            context.Users.Add((user2));


            Event newEvent = new Event()
            {
                OfGroup = new Group(),
                OwnerUser = new User(),
                AttendingUsers = new List<User>(),
                DateOfOccurance = new DateTime(1997,11,24, 15,25,25),
                Location = "Snekutis",
                Title = "BeerPong"
            };

            context.Events.Add(newEvent);

            base.Seed(context);
        }
    }
}
