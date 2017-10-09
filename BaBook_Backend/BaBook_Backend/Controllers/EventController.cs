using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using BaBook_Backend.Mapper;
using BaBook_Backend.Repositories;
using BaBook_Backend.ViewModels;

namespace BaBook_Backend.Controllers
{
    public class EventController : ApiController
    {
        public IHttpActionResult CreateEvent(EventViewModel model)
        {
            using (var _repository = new EventRepository())
            {
                _repository.Add(ViewModelToDomainMapping.MapEvent(model));
                return Ok();
            }
        }
    }
}