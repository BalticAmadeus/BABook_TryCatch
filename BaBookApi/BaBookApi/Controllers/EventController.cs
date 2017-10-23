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
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EventController : ApiController
    {
        private readonly EventRepository _repository;
        private readonly GroupRepository _repo;


        public EventController()
        {
            _repo = new GroupRepository();
            _repository = new EventRepository();
        }

        [Route("api/events/{groupId}")]
        public IHttpActionResult GetEventsByGroupId(int groupId)
        {
            var toReturn = new List<EventListItemViewModel>();
            var events = _repository.GetLoadedList();
            
            

            try
            {
                var name = _repo.GetGroupName(groupId).Name;
                foreach (var e in events)
                {
                    var eVm = DomainToViewModelMapping.MapEventListItemViewModel(e, HttpContext.Current.User.Identity.GetUserId());
                    if (eVm.GroupName==name)toReturn.Add(eVm);
                }

            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }

            return Ok(toReturn);
        }


        [Route("api/event/{eventId}")]
        public IHttpActionResult GetEventById(int eventId)
        {
            try
            {
                var vm = DomainToViewModelMapping.MapEventListItemViewModel(
                    _repository.GetLoadedEvent(eventId),
                    HttpContext.Current.User.Identity.GetUserId());
                vm.IsOwner = HttpContext.Current.User.Identity.GetUserId() == _repository.GetLoadedEvent(eventId).OwnerUser.Id;
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
                    _repository.Add(newEvent, HttpContext.Current.User.Identity.GetUserId(), model.GroupId);
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
                var currentEvent = _repository.GetLoadedEvent(model.EventId);
           
                newEvent = ViewModelToDomainMapping.UpdateEventViewModelToModel(model);
                
                if (currentEvent.OwnerUser.Id == HttpContext.Current.User.Identity.GetUserId())
                {
                    _repository.Update(currentEvent, newEvent);
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
            _repository.Remove(_repository.SingleOrDefault(x => x.EventId == id));
            return Ok();
        }
    }
}