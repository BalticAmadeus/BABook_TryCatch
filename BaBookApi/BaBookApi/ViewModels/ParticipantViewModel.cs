using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BaBookApi.ViewModels
{
    public class ParticipantViewModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("status")]
        public Enums.EventResponse AttendanceStatus { get; set; }
    }
}