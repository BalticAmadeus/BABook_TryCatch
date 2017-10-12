using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Models;

namespace BaBookApi.ViewModels
{
    public class CommentViewModel
    {
        public int commentId { get; set; }
        public string commentText { get; set; }
        public DateTime commentTime { get; set; }

        public UserViewModel ownerUser { get; set; }
    }
}