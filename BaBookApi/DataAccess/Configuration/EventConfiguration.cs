using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace DataAccess.Configuration
{
    public class EventConfiguration : EntityTypeConfiguration<Event>
    {
        public EventConfiguration()
        {
            ToTable(nameof(Event));
            HasKey(x => x.EventId);
            HasMany(x => x.AttendingUsers).WithMany(u => u.AttendedEvents);
            HasMany(x => x.SentInvitations);
        }
    }
}
