using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaBookApi.ViewModels
{
    public class CreateCommentViewModel
    {
        public int userId { get; set; }
        public string text { get; set; }
    }
}