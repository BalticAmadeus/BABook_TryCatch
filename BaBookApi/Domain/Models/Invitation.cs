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
        public int EventId { get; set; }
        public int UserId { get; set; }
        public Enums.EventResponse EventResponse { get; set; }
    }
}
