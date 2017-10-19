using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace DataAccess.Repositories
{
    public class CommentRepository : BaseRepository<Comment>
    {

        public void AddComment(Comment comment, int eventId, string userId)
        {
            var user = _context.Users.Find(userId);
            _context.Entry(user).Collection(x => x.Comments).Load();
            var commentedEvent = _context.Events.Find(eventId);

            comment.OwnerUser = user ?? throw new Exception("There is no such User!");
            comment.OfEvent = commentedEvent ?? throw new Exception("There is no such Event!");

            user.Comments.Add(comment);
            _context.SaveChanges();
        }

        public List<Comment> GetEventComments(int eventId)
        {
            var Event = _context.Events
                .Include(x => x.Comments.Select(y => y.OwnerUser))
                .SingleOrDefault(x => x.EventId == eventId);

            if (Event == null) throw new Exception("There is no such Event!");

            return Event.Comments.ToList();
        }
    }
}
