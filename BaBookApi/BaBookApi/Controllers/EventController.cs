using System.Collections.Generic;
using System.Web.Http;
using BaBookApi.Mapping;
using BaBookApi.ViewModels;
using DataAccess.Repositories;
using WebGrease.Css.Extensions;

namespace BaBookApi.Controllers
{
    public class EventController : ApiController
    {
        private readonly EventRepository _repository;

        public EventController()
        {
            _repository = new EventRepository();
        }

        [AllowAnonymous]
        [Route("api/events")]
        public IHttpActionResult GetEvents()
        {
            var toReturn = new List<EventViewModel>();
            var models = _repository.GetAll();

            models.ForEach(x => toReturn.Add(DomainToViewModelMapping.MapEventViewModel(x)));

            return Ok(toReturn);
        }

        [Route("api/events/{id}")]
        public IHttpActionResult GetEventById(int id)
        {
            return Ok(DomainToViewModelMapping.MapEventViewModel(_repository.Get(id)));
        }

        [HttpPost]
        [Route("api/events")]
        public IHttpActionResult CreateEvent(CreateEventViewModel model)
        {
            var newEvent = ViewModelToDomainMapping.MapEvent(model);
            _repository.Add(newEvent, model.OwnerId, model.GroupId);
            return Ok();
        }

        [HttpPut]
        [Route("api/events")]
        public IHttpActionResult UpdateEvent(CreateEventViewModel model)
        {
            _repository.Update(ViewModelToDomainMapping.MapEvent(model));
            return Ok();
        }

        [HttpDelete]
        [Route("api/events/{id}")]
        public IHttpActionResult UpdateEvent(int id)
        {
            _repository.Remove(_repository.FirstOrDefault(x => x.EventId == id));
            return Ok();
        }
    }
}