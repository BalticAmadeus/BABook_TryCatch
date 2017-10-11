using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace DataAccess.Configuration
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable(nameof(User));
            HasKey(x => x.UserId);
            HasMany(x => x.CreatedEvents);
            HasMany(x => x.AttendedEvents);
            HasMany(x => x.Comments);
        }
    }
}
