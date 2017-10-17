using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Domain.Models
{
    public class User : IdentityUser
    {
        public int UserId { get; set; }
        public string Name { get; set; }

        public virtual List<Event> CreatedEvents { get; set; }
        public virtual List<UserEventAttendance> AttendedEvents { get; set; }
        public virtual List<Comment> Comments { get; set; }
    }
}
