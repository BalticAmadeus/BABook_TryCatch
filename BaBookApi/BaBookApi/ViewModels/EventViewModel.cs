using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaBookApi.ViewModels
{
    public class EventViewModel
    {
        public int EventId { get; set; }
        public string Title { get; set; }
        public DateTime DateOfOccurance { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
    }
}