using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BaBookApi.ViewModels
{
    public class UserViewModel
    {
        [JsonProperty("id")]
        public string UserId { get; set; }
        [JsonProperty("name")]
        public string Username { get; set; }
    }
}