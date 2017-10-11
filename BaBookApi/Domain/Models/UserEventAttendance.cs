using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Utility;

namespace Domain.Models
{
    public class UserEventAttendance
    {
        public int AttendanceId { get; set; }
        public virtual User User { get; set; }
        public virtual Event Event { get; set; }
        public Enums.EventResponse Response { get; set; } = Enums.EventResponse.Unanswered;
    }
}
