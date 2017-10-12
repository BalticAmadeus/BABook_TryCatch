using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Models;

namespace BaBookApi.ViewModels
{
    public class EventViewModel
    {
        public int eventId { get; set; }
        public string title { get; set; }
        public DateTime dateOfOccurance { get; set; }
        public string location { get; set; }
        public string description { get; set; }

        public List<UserEventAttendance> attendances { get; set; }
        public List<Comment> comments { get; set; }
    }
}