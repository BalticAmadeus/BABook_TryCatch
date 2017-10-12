using System;
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

            try
            {
                models.ForEach(x => toReturn.Add(DomainToViewModelMapping.MapEventViewModel(x)));
            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }

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

            try
            {
                _repository.Add(newEvent, model.OwnerId, model.GroupId);
            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPut]
        [Route("api/events")]
        public IHttpActionResult UpdateEvent(CreateEventViewModel model)
        {
            try
            {
                _repository.Update(ViewModelToDomainMapping.MapEvent(model));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpDelete]
        [Route("api/events/{id}")]
        public IHttpActionResult UpdateEvent(int id)
        {
            _repository.Remove(_repository.SingleOrDefault(x => x.EventId == id));
            return Ok();
        }
    }
}