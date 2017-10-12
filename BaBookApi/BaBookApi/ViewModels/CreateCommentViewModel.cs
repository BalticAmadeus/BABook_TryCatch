using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace BaBookApi.ViewModels
{
    public class CreateCommentViewModel
    {
        [JsonProperty("userId")]
        public int UserId { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}