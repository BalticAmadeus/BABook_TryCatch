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
        public void Add(Event model)
        {
            _context.Events.Add(model);
        }
        
    }
}