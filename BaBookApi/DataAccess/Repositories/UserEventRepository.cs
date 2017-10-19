using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Management.Instrumentation;
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


        public List<UserEventAttendance> GetEventParticipants(int eventId)
        {
            var Event = _context.Events
                .Include(x => x.Attendances.Select(y => y.User))
                .SingleOrDefault(x => x.EventId == eventId);
            
 	        if(Event == null) throw new Exception("There is no such Event!");

            return Event.Attendances.ToList();           
        }

        
        public void ChangeResponse(UserEventAttendance attendance, int eventId, string userId)
        {
            var currentAttendance =
                _context.UserEventAttendances.
                SingleOrDefault(x => x.Event.EventId == eventId && x.User.Id == userId);

            if (currentAttendance != null)
            {
                if (attendance.Response!=Enums.EventResponse.Unanswered) currentAttendance.Response = attendance.Response;
                else if(currentAttendance.Response!=Enums.EventResponse.Unanswered) throw new Exception("This user has already decided go or not to");
                else throw new Exception("This user has already been invited");
            }
            else
            { 
                var user = _context.Users.Find(userId);
                var currentEvent = _context.Events.Find(eventId);
                currentAttendance = new UserEventAttendance()
                {
                    Event = currentEvent ?? throw new Exception("There is no such event!"),
                    User = user ?? throw new Exception("There is no such user!"),
                    Response = attendance.Response
                };
            }
            _context.UserEventAttendances.AddOrUpdate(currentAttendance);
            _context.SaveChanges();
        }

        public IEnumerable<User> getInvitable(int eventId)
        {
            var list = _context.Users.
                Where(user => !_context.UserEventAttendances.
                Any(x => x.User.Id == user.Id)).
                ToList();
            if (list == null)
            {
                throw new Exception("No one can be invited!");
            }
            return list;
        }
        
    }
}
