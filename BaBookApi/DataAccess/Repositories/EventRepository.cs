﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public List<Event> GetLoadedList()
        {
            return _context.Events
                .Include(x => x.OfGroup)
                .Include(x => x.OwnerUser)
                .Include(x => x.Attendances.Select(y => y.User))
                .ToList();
        }

        public Event GetLoadedEvent(int eventId)
        {
            return _context.Events
                .Include(x => x.OfGroup)
                .Include(x => x.OwnerUser)
                .Include(x => x.Attendances.Select(y => y.User))
                .SingleOrDefault(x => x.EventId == eventId);
        }

        public void Update(Event model,int eventId)
        {   
            var eventToUpdate = SingleOrDefault(x => x.EventId == eventId);

            eventToUpdate.Title = model.Title;
            eventToUpdate.DateOfOccurance = model.DateOfOccurance;
            eventToUpdate.Location = model.Location;
            eventToUpdate.Description = model.Description;

            _context.SaveChanges();
        }
    }
}
