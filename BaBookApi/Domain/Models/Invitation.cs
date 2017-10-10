using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Invitation
    {
        public int InvitationId { get; set; }
        public int EventId { get; set; }
        public int UserId { get; set; }
    }
}
