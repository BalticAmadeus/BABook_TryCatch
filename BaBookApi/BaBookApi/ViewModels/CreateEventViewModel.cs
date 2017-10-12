using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace BaBookApi.ViewModels
{
    public class CreateEventViewModel
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
        [JsonProperty("groupId")]
        public int GroupId { get; set; }
        [JsonProperty("ownerId")]
        public int OwnerId { get; set; }
    }
}