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
using Domain.Utility;

namespace BaBookApi.Controllers
{
    public class UserEventController : ApiController
    {
        private readonly UserEventRepository _repository;

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

        [Route("api/userevent/invite/{eventId}/{userId}")]
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

        [HttpPut]
        [Route("api/userevent/{eventId}/{userId}/{response}")]
        public IHttpActionResult ChangeResponse(int eventId, int userId, Enums.EventResponse response)
        {
            try
            {
                _repository.ChangeResponse(eventId, userId, response);
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        //TODO: MAKE IT WORK WITH COMMENTVIEWMODEL
        [HttpPost]
        [Route("api/comments/{eventId}")]
        public IHttpActionResult AddComment(int eventId, CreateCommentViewModel model)
        {
            try
            {
                _repository.AddComment(eventId, userId, commentText);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpGet]
        [Route("api/comments/{eventId}")]
        public IHttpActionResult GetEventComments(int eventId)
        {
            var commentsVM = new List<CommentViewModel>();
            try
            {
                var comments = _repository.GetEventComments(eventId);
                comments.ForEach(x => commentsVM.Add(DomainToViewModelMapping.MapCommentViewModel(x)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(commentsVM);
        }

    }
}
