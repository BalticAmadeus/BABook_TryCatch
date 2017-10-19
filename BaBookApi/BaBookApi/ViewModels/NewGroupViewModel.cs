using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace BaBookApi.ViewModels
{
    public class NewGroupViewModel
    {
        [JsonProperty("name")]
        public string GroupName { get; set; }
    }
}