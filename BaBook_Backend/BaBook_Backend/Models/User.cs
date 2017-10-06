﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaBook_Backend.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }

        public virtual List<Event> CreatedEvents { get; set; }
    }
}