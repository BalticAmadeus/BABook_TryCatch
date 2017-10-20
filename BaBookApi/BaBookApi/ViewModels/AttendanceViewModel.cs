using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BaBookApi.ViewModels
{
    public class AttendanceViewModel
    {
        [JsonProperty("eventId")]
        public int EventId { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("status")]
        public Enums.EventResponse Status { get; set; }
    }
}