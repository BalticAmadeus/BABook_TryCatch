using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using BaBookApi.Mapping;
using BaBookApi.ViewModels;
using DataAccess.Repositories;
using WebGrease.Css.Extensions;

namespace BaBookApi.Controllers
{
    public class EventController : ApiController
    {
        [AllowAnonymous]
        [Route("api/events")]
        public IHttpActionResult GetEvents()
        {
            using (var repository = new EventRepository())
            {
                var toReturn = new List<EventViewModel>();
                var models = repository.GetAll();
                models.ForEach(x => toReturn.Add(DomainToViewModelMapping.MapEventViewModel(x)));

                return Ok(toReturn);
            }
        }

        [Route("api/events/{id}")]
        public IHttpActionResult GetEventById(int id)
        {
            using (var repository = new EventRepository())
            {
                return Ok(DomainToViewModelMapping.MapEventViewModel(repository.Get(id)));
            }
        }

        [HttpPost]
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

        [HttpPut]
        [Route("api/events")]
        public IHttpActionResult UpdateEvent(CreateEventViewModel model)
        {
            using (var repository = new EventRepository())
            {
                repository.Update(ViewModelToDomainMapping.MapEvent(model));
                return Ok();
            }
        }

        [HttpDelete]
        [Route("api/events/{id}")]
        public IHttpActionResult UpdateEvent(int id)
        {
            using (var repository = new EventRepository())
            {
                repository.Remove(repository.FirstOrDefault(x => x.EventId == id));
                return Ok();
            }
        }
    }
}