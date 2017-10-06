using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using BaBook_Backend.Models;

namespace BaBook_Backend.Configurations
{
    public class GroupConfiguration : EntityTypeConfiguration<Group>
    {
        public GroupConfiguration()
        {
            ToTable(nameof(Group));
            HasMany(x => x.GroupEvents);
        }
    }
}