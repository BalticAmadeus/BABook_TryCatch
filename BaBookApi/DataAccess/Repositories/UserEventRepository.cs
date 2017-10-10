using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Context;
using Domain.Models;

namespace DataAccess.Repositories
{
    public class UserEventRepository
    {
        private DataContext _context;

        public UserEventRepository()
        {
            _context = new DataContext();
        }

        public void addUserToEvent(int eventId, int userId)
        {
            var User = _context.Users.Find(userId);
            var Event = _context.Events.Include(x => x.AttendingUsers).FirstOrDefault(x => x.EventId == eventId);

            Event.AttendingUsers.Add(User);

            _context.Events.AddOrUpdate(Event);
            _context.SaveChanges();
        }

        public List<User> getAllParticipants(int eventId)
        {
            var Event = _context.Events.Include(x => x.AttendingUsers).FirstOrDefault(x => x.EventId == eventId);
            return Event.AttendingUsers;
        }

    }
}
