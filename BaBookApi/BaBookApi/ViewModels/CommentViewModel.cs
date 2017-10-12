using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Models;

namespace BaBookApi.ViewModels
{
    public class CommentViewModel
    {
        public int CommentId { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentTime { get; set; }

        public User OwnerUser { get; set; }
    }
}