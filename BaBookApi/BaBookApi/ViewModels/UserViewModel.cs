using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Utility;
using Newtonsoft.Json;

namespace BaBookApi.ViewModels
{
    public class UserViewModel
    {
        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}