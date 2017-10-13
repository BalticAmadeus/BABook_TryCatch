using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Utility;
using Newtonsoft.Json;

namespace BaBookApi.ViewModels
{
    public class EventListItemViewModel
    {
        [JsonProperty("eventId")]
        public int EventId { get; set; }
        [JsonProperty("creatorName")]
        public string OwnerName { get; set; }
        [JsonProperty("groupName")]
        public string GroupName { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("comment")]
        public string Description { get; set; }
        [JsonProperty("location")]
        public string Location { get; set; }
        [JsonProperty("status")]
        public Enums.EventResponse AttendanceStatus { get; set; }

    }
}