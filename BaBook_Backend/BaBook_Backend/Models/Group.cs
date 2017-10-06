using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaBook_Backend.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        public string Name { get; set; }

        public virtual List<Event> GroupEvents { get; set; }
    }
}