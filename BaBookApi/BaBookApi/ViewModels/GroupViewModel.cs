using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BaBookApi.ViewModels
{
    public class GroupViewModel
    {
        [JsonProperty("groupId")]
        public int GroupId { get; set; }
        [JsonProperty("name")]
        public string GroupName { get; set; }
    }
}