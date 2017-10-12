using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace DataAccess.Repositories
{
    public class EventRepository : BaseRepository<Event>
    {
        public void Add(Event model, int ownerId, int groupId)
        {
            model.OfGroup = _context.Groups.SingleOrDefault(x => x.GroupId == groupId);
            model.OwnerUser = _context.Users.SingleOrDefault(x => x.UserId == ownerId);
            _context.Events.Add(model);
            _context.SaveChanges();
        }

        public void Update(Event model)
        {
            var eventToUpdate = SingleOrDefault(x => x.EventId == model.EventId);

            eventToUpdate.Title = model.Title;
            eventToUpdate.DateOfOccurance = model.DateOfOccurance;
            eventToUpdate.Location = model.Location;
            eventToUpdate.Description = model.Description;

            _context.SaveChanges();
        }
    }
}
