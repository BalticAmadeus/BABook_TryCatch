using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using BaBook_Backend.Models;

namespace BaBook_Backend.Configurations
{
    public class EventConfiguration : EntityTypeConfiguration<Event>
    {
        public EventConfiguration()
        {
            ToTable(nameof(Event));
            HasKey(x => x.EventId);
            HasMany(x => x.AttendingUsers);
        }
    }
}