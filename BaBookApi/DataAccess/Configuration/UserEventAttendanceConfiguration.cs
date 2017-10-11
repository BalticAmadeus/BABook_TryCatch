using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace DataAccess.Configuration
{
    public class UserEventAttendanceConfiguration : EntityTypeConfiguration<UserEventAttendance>
    {
        public UserEventAttendanceConfiguration()
        {
            ToTable(nameof(UserEventAttendance));
            HasKey(x => x.AttendanceId);
        }
    }
}
