using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Utility;

namespace Domain.Models
{
    public class Invitation
    {
        public int InvitationId { get; set; }
        public virtual Event Event { get; set; }
        public virtual User User { get; set; }
        public Enums.EventResponse EventResponse { get; set; }
    }
}
