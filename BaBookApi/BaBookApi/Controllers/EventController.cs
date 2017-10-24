using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Routing;
using BaBookApi.Mapping;
using BaBookApi.ViewModels;
using DataAccess.Repositories;
using Domain.Models;
using Microsoft.AspNet.Identity;
using WebGrease.Css.Extensions;

namespace BaBookApi.Controllers
{
    [EnableCors("*", "*", "*")]
    public class EventController : ApiController
    {
        private readonly EventRepository _eventRepository;
        private readonly GroupRepository _groupRepository;


        public EventController()
        {
            _groupRepository = new GroupRepository();
            _eventRepository = new EventRepository();
        }

        [HttpGet]
        [Route("api/events/group/{groupId}")]
        public IHttpActionResult GetEventsByGroupId(int groupId)
        {
            var toReturn = new List<EventListItemViewModel>();

            try
            {
                var events = _groupRepository.GetLoadedGroup(groupId).GroupEvents.ToList();

                events.ForEach(x => toReturn
                .Add(DomainToViewModelMapping.MapEventListItemViewModel(x, HttpContext.Current.User.Identity.GetUserId())));
            }

            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }

            return Ok(toReturn);
        }

        [HttpGet]
        [Route("api/events")]
        public IHttpActionResult GetAllEvents()
        {
            var toReturn = new List<EventListItemViewModel>();

            try
            {
                var events = _eventRepository.GetLoadedList();

                events.ForEach(x => toReturn
                    .Add(DomainToViewModelMapping.MapEventListItemViewModel(x, HttpContext.Current.User.Identity.GetUserId())));
            }

            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }

            return Ok(toReturn);
        }


       
        [Route("api/events/myevents")]
        public IHttpActionResult GetEventsByOwnerId()
        {
            var toReturn = new List<EventListItemViewModel>();
            try
            {
                var currentUserId = HttpContext.Current.User.Identity.GetUserId();
                var events = _eventRepository.GetEventsByOwnerId(currentUserId);
                
                events.ForEach(x => toReturn
                    .Add(DomainToViewModelMapping.MapEventListItemViewModel(x, currentUserId)));
            }
            catch(Exception ex)
            {
                BadRequest(ex.Message);
            }
            return Ok(toReturn);
        }


        [HttpGet]
        [Route("api/events/{eventId}")]
        public IHttpActionResult GetEventById(int eventId)
        {
            try
            {
                var vm = DomainToViewModelMapping.MapEventListItemViewModel(
                    _eventRepository.GetLoadedEvent(eventId),
                    HttpContext.Current.User.Identity.GetUserId());
                return Ok(vm);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPost]
        [Route("api/events")]
        public IHttpActionResult CreateEvent(NewEventViewModel model)
        {
            try
            {
                var newEvent = ViewModelToDomainMapping.NewEventViewModelToModel(model);

                if (model.GroupId != 0)
                {
                    _eventRepository.Add(newEvent, HttpContext.Current.User.Identity.GetUserId(), model.GroupId);
                }
            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPut]
        [Route("api/events")]
        public IHttpActionResult UpdateEvent(UpdateEventViewModel model)
        {
            var newEvent = new Event();

            try
            {
                var currentEvent = _eventRepository.GetLoadedEvent(model.EventId);
           
                newEvent = ViewModelToDomainMapping.UpdateEventViewModelToModel(model);
                
                if (currentEvent.OwnerUser.Id == HttpContext.Current.User.Identity.GetUserId())
                {
                    _eventRepository.Update(currentEvent, newEvent);
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return BadRequest("Owner who tries to change event is not event Owner");
        }

        [HttpDelete]
        [Route("api/events/{id}")]
        public IHttpActionResult DeleteEvent(int id)
        {
            _eventRepository.Remove(_eventRepository.SingleOrDefault(x => x.EventId == id));
            return Ok();
        }
    }
}