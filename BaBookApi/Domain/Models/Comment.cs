using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentTime { get; set; }

        public virtual User OwnerUser { get; set; }
        public virtual Event OfEvent { get; set; }
    }
}