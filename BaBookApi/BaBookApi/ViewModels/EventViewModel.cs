using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Models;
using Newtonsoft.Json;

namespace BaBookApi.ViewModels
{
    public class EventViewModel
    {
        [JsonProperty("eventId")]
        public int EventId { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("dateOfOccurance")]
        public DateTime DateOfOccurance { get; set; }
        [JsonProperty("location")]
        public string Location { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("attendances")]
        public List<UserEventAttendance> Attendances { get; set; }
        [JsonProperty("comments")]
        public List<Comment> Comments { get; set; }
    }
}