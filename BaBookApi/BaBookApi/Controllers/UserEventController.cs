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
        private UserEventRepository _repository;

        public UserEventController()
        {
                _repository = new UserEventRepository();
        }

        [Route("api/userevent/{eventId}/{userId}")]
        [HttpPost]
        public IHttpActionResult AddUserToEvent(int eventId, int userId)
        {
            try
            {
                _repository.AddUserToEvent(eventId, userId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [Route("api/userevent/{eventId}")]
        [HttpGet]
        public IHttpActionResult GetEventParticipants(int eventId)
        {
            var eventUsersVM = new List<UserViewModel>();

            try
            {
                var eventUsers = _repository.GetEventParticipants(eventId);

                eventUsers.ForEach(x => eventUsersVM.Add(DomainToViewModelMapping.MapUserViewModel(x)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(eventUsersVM);
        }

        [Route("api/userevent/send/{eventId}/{userId}")]
        [HttpPost]
        public IHttpActionResult SendInvitation(int eventId, int userId)
        {
            try
            {
                _repository.SendInvitation(eventId, userId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

    }
}
