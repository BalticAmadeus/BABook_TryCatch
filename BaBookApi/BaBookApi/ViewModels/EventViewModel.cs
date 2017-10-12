using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Models;

namespace BaBookApi.ViewModels
{
    public class EventViewModel
    {
        public int EventId { get; set; }
        public string Title { get; set; }
        public DateTime DateOfOccurance { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }

        public List<UserEventAttendance> Attendances { get; set; }
        public List<Comment> Comments { get; set; }
    }
}