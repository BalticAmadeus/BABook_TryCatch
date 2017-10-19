using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Utility;
using Newtonsoft.Json;

namespace BaBookApi.ViewModels
{
    public class InvitableViewModel
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}