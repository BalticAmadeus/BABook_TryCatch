using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Models;
using Newtonsoft.Json;

namespace BaBookApi.ViewModels
{
    public class CommentViewModel
    {
        [JsonProperty("commentId")]
        public int CommentId { get; set; }
        [JsonProperty("commentText")]
        public string CommentText { get; set; }
        [JsonProperty("commentTime")]
        public DateTime CommentTime { get; set; }
        [JsonProperty("ownerUser")]
        public UserViewModel OwnerUser { get; set; }
    }
}