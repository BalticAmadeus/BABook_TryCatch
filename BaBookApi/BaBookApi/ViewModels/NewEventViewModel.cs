using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace BaBookApi.ViewModels
{
    public class NewEventViewModel
    {
        [JsonProperty("groupId")]
        public int GroupId { get; set; }
        [JsonProperty("userId")]
        public int OwnerId { get; set; }
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