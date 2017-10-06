using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using BaBook_Backend.Models;

namespace BaBook_Backend.Configurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable(nameof(User));
            HasKey(x => x.UserId);
            HasMany(x => x.CreatedEvents);
        }
    }
}