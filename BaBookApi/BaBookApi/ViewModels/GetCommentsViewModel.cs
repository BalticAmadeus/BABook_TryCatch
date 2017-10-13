using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace BaBookApi.ViewModels
{
    public class GetCommentsViewModel
    {
        [JsonProperty("name")]
        public int OwnerUser { get; set; }
        [JsonProperty("comment")]
        public string Text { get; set; }
    }
}