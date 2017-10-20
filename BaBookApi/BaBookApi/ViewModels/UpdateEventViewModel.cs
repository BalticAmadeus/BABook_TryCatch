using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace BaBookApi.ViewModels
{
    public class UpdateEventViewModel
    {
        [JsonProperty("eventId")]
        public int EventId { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("date")]
        public DateTime DateOfOccurance { get; set; }
        [JsonProperty("comment")]
        public string Description { get; set; }
        [JsonProperty("location")]
        public string Location { get; set; }
    }
}