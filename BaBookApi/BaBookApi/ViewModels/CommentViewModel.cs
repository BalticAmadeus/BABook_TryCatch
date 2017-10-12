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
        public string CommentText { get; set; }
        public DateTime CommentTime { get; set; }

        public UserViewModel OwnerUser { get; set; }
    }
}