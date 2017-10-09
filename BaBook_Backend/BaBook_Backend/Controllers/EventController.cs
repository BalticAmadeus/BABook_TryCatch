using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using BaBook_Backend.Mapper;
using BaBook_Backend.Models;
using BaBook_Backend.Repositories;
using BaBook_Backend.ViewModels;

namespace BaBook_Backend.Controllers
{
    public class EventController : ApiController
    {

        [Route("api/events")]
        public IHttpActionResult GetEvents()
        {
            using (var repository = new EventRepository())
            {
                var toReturn = new List<EventViewModel>();
                var models = repository.Get();
                models.ForEach(x => toReturn.Add(DomainToViewModelMapping.MapEventViewModel(x)));
                
                return Ok(toReturn);
            }
        }

        [HttpPut]
        [Route("api/events")]
        public IHttpActionResult CreateEvent(CreateEventViewModel model)
        {
            using (var repository = new EventRepository())
            {
                var newEvent = ViewModelToDomainMapping.MapEvent(model);
                repository.Add(newEvent, model.OwnerId, model.GroupId);
                return Ok();
            }
        }
    }
}