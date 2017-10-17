using System.Collections.Generic;
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

            //try
            //{
            //    context.SaveChanges();
            //}
            //catch (System.Data.Entity.Validation.DbEntityValidationException e)
            //{
            //    var outputLines = new List<string>();
            //    foreach (var eve in e.EntityValidationErrors)
            //    {
            //        outputLines.Add(string.Format(
            //            "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:",
            //            DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State));
            //        foreach (var ve in eve.ValidationErrors)
            //        {
            //            outputLines.Add(string.Format(
            //                "- Property: \"{0}\", Error: \"{1}\"",
            //                ve.PropertyName, ve.ErrorMessage));
            //        }
            //    }
            //    //Write to file
            //    System.IO.File.AppendAllLines(@"c:\temp\errors.txt", outputLines);
            //    throw;

            //    // Showing it on screen
            //    throw new Exception(string.Join(",", outputLines.ToArray()));

            //}


            base.Seed(context);
        }

        private static void CreateTestUsers(DataContext context, out User user, out User user2)
        {
            var store = new UserStore<User>(context);
            var userManager = new UserManager<User>(store);

     
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var role = new IdentityRole { Name = "Admin" };
            roleManager.Create(role);
            

            user = new User
            {
                UserName = "admin",
                Email = "admin@admin.com"
            };
            const string password = "admin";

            userManager.Create(user, password);
            //userManager.AddToRole(user.Id, "Admin");

            user2 = new User
            {
                UserName = "guest",
                Email = "guest@guest.com"
            };
            const string password2 = "guest";

            userManager.Create(user2, password2);
            context.Users.Add(user);
            context.Users.Add(user2);
        }
    }
}
