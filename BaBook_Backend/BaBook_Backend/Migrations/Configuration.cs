using BaBook_Backend.Models;

namespace BaBook_Backend.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BaBook_Backend.Context.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BaBook_Backend.Context.DataContext context)
        {
            Group group = new Group()
            {
                GroupId = 1,
                Name = "ALUS"
            };

            context.Groups.Add((group));

            base.Seed(context);
        }
    }
}
