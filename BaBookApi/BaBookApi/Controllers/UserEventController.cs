using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BaBookApi.Mapping;
using BaBookApi.ViewModels;
using Domain.Models;
using DataAccess.Repositories;

namespace BaBookApi.Controllers
{
    public class UserEventController : ApiController
    {
        [Route("api/userevent/{eventId}/{userId}")]
        [HttpPost]
        public IHttpActionResult AddUserToEvent(int eventId, int userId)
        {
            var repository = new UserEventRepository();

            repository.AddUserToEvent(eventId,userId);

            return Ok();
        }

        [Route("api/userevent/{eventId}")]
        [HttpGet]
        public IHttpActionResult GetEventParticipants(int eventId)
        {
            var repository = new UserEventRepository();
            var eventUsers = repository.GetEventParticipants(eventId);

            var eventUsersVM = new List<UserViewModel>();
            eventUsers.ForEach(x => eventUsersVM.Add(DomainToViewModelMapping.MapUserViewModel(x)));

            return Ok(eventUsersVM);
        }

        [Route("api/userevent/send/{eventId}/{userId}")]
        [HttpPost]
        public IHttpActionResult SendInvitation(int eventId, int userId)
        {
            var repository = new UserEventRepository();

            try
            {
                repository.SendInvitation(eventId, userId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

    }
}
