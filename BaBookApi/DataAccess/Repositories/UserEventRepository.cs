using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Context;
using Domain.Models;
using Domain.Utility;

namespace DataAccess.Repositories
{
    public class UserEventRepository
    {
        private readonly DataContext _context;

        public UserEventRepository()
        {
            _context = new DataContext();
        }

        public void AddUserToEvent(int eventId, int userId)
        {
            var user = _context.Users.Find(userId);
            var activeEvent = _context.Events.Find(eventId);

            if(user == null) throw new Exception("There is no such User");
            if(activeEvent == null) throw new Exception("There is no such Event!");

            var attendance = new UserEventAttendance()
            {
                Event = activeEvent,
                User = user,
                Response = Enums.EventResponse.Going
            };

            _context.UserEventAttendances.Add(attendance);
            _context.SaveChanges();
        }

        public List<UserEventAttendance> GetEventParticipants(int eventId)
        {
            var Event = _context.Events
                .Include(x => x.Attendances.Select(y => y.User))
                .SingleOrDefault(x => x.EventId == eventId);
            
 	        if(Event == null) throw new Exception("There is no such Event!");

            return Event.Attendances.ToList();           
        }


        public void SendInvitation(int eventId, int userId)
        {
            var user = _context.Users.Find(userId);
            var activeEvent = _context.Events.Find(eventId);

            if (user == null) throw new Exception("There is no such User!");
            if (activeEvent == null) throw new Exception("There is no such Event!");
            
            var attendance = new UserEventAttendance()
            {
                User = user,
                Event = activeEvent
            };

            _context.UserEventAttendances.Add(attendance);
            _context.SaveChanges();
        }

        public void ChangeResponse(int eventId,int userId, Enums.EventResponse response)
        {
            var attendance =
                _context.UserEventAttendances.SingleOrDefault(
                    x => x.Event.EventId == eventId && x.User.UserId == userId);

            if(attendance == null) throw new Exception("Attendance not found");

            attendance.Response = response;
            _context.SaveChanges();
        }

        public void AddComment(int eventId, int userId, string commentText)
        {
            var user = _context.Users.Find(userId);
            _context.Entry(user).Collection(x => x.Comments).Load();
            var commentedEvent = _context.Events.Find(eventId);

            if (user == null) throw new Exception("There is no such User!");
            if (commentedEvent == null) throw new Exception("There is no such Event!");

            var comment = new Comment()
            {
                OwnerUser = user,
                OfEvent = commentedEvent,
                CommentText = commentText,
                CommentTime = DateTime.Now
            };
            
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
