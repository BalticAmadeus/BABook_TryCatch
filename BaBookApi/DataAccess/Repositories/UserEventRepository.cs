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
            var user = _context.Users.Find(userId);
            var activeEvent = _context.Events.Find(eventId);

            var attendance = new UserEventAttendance()
            {
                Event = activeEvent,
                User = user,
            };

            _context.UserEventAttendances.Add(attendance);
            _context.SaveChanges();
        }

        public List<User> GetEventParticipants(int eventId)
        {
            var Event = _context.Events.Include(x => x.Attendances).FirstOrDefault(x => x.EventId == eventId);
            return Event.Attendances.Select(x => x.User).ToList();
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
    }
}
