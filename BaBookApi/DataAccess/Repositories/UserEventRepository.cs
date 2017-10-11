using System;
using System.Collections.Generic;
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
        private DataContext _context;

        public UserEventRepository()
        {
            _context = new DataContext();
        }

        public void AddUserToEvent(int eventId, int userId)
        {
            var User = _context.Users.Find(userId);
            var Event = _context.Events.Include(x => x.AttendingUsers).FirstOrDefault(x => x.EventId == eventId);

            Event.AttendingUsers.Add(User);

            _context.Events.AddOrUpdate(Event);
            _context.SaveChanges();
        }

        public List<User> GetEventParticipants(int eventId)
        {
            var Event = _context.Events.Include(x => x.AttendingUsers).FirstOrDefault(x => x.EventId == eventId);
            return Event.AttendingUsers;
        }

        public void SendInvitation(int eventId, int userId)
        {
            var user = _context.Users.Include(x => x.Invitations).FirstOrDefault(x => x.UserId == userId);

            if (user == null)
            {
                throw new Exception("There is no such user!");
            }

            var invitation = new Invitation()
            {
                Event = _context.Events.Find(eventId),
                EventResponse = Enums.EventResponse.Unanswered,
                User = user
            };

            user.Invitations.Add(invitation);

            _context.Users.AddOrUpdate(user);
            _context.SaveChanges();
        }
    }
}
