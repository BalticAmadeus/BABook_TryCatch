using System;
using System.Collections.Generic;
using System.Linq;
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
#if DEBUG
            var userId = 1;
#endif
            var toReturn = new List<EventListItemViewModel>();
            var events = _repository.GetLoadedList(userId);

            try
            {
                foreach (var e in events)
                {
                    var eVm = DomainToViewModelMapping.MapEventListItemViewModel(e);
                    var attendance = e.Attendances.SingleOrDefault(x => x.User.UserId == userId);
                    if (attendance != null) eVm.AttendanceStatus = attendance.Response;


                    toReturn.Add(eVm);
                }

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
            return Ok(DomainToViewModelMapping.MapEventListItemViewModel(_repository.Get(id)));
        }

        [HttpPost]
        [Route("api/events")]
        public IHttpActionResult CreateEvent(NewEventViewModel model)
        {
            var newEvent = ViewModelToDomainMapping.NewEventViewModelToModel(model);

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
        public IHttpActionResult UpdateEvent(NewEventViewModel model)
        {
            try
            {
                _repository.Update(ViewModelToDomainMapping.NewEventViewModelToModel(model));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpDelete]
        [Route("api/events/{id}")]
        public IHttpActionResult DeleteEvent(int id)
        {
            _repository.Remove(_repository.SingleOrDefault(x => x.EventId == id));
            return Ok();
        }
    }
}