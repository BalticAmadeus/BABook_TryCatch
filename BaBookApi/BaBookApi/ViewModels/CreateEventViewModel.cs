using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaBookApi.ViewModels
{
    public class CreateEventViewModel
    {
        public int eventId { get; set; }
        public string title { get; set; }
        public DateTime dateOfOccurance { get; set; }
        public string location { get; set; }
        public string description { get; set; }

        public int groupId { get; set; }
        public int ownerId { get; set; }
    }
}