using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaBookApi.ViewModels
{
    public class CreateCommentViewModel
    {
        public int UserId { get; set; }
        public string Text { get; set; }
    }
}