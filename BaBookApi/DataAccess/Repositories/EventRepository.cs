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
            model.OfGroup = _context.Groups.FirstOrDefault(x => x.GroupId == groupId);
            model.OwnerUser = _context.Users.FirstOrDefault(x => x.UserId == ownerId);
            _context.Events.Add(model);
        }

        public void Update(Event model)
        {
            var eventToUpdate = FirstOrDefault(x => x.EventId == model.EventId);

            eventToUpdate.Title = model.Title;
            eventToUpdate.DateOfOccurance = model.DateOfOccurance;
            eventToUpdate.Location = model.Location;
            eventToUpdate.Description = model.Description;
        }

    }
}
