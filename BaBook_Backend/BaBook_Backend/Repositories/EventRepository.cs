using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaBook_Backend.Models;
using System.Web.Http;
using BaBook_Backend.ViewModels;

namespace BaBook_Backend.Repositories
{
    public class EventRepository : BaseRepository
    {
        public void Add(Event model, int ownerId, int groupId)
        {
            model.OfGroup = _context.Groups.FirstOrDefault(x => x.GroupId == groupId);
            model.OwnerUser = _context.Users.FirstOrDefault(x => x.UserId == ownerId);
            _context.Events.Add(model);
        }

        public List<Event> Get()
        {
            return _context.Events.ToList();
        }
        
    }
}