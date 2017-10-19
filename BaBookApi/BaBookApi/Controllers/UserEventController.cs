using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using BaBookApi.Mapping;
using BaBookApi.ViewModels;
using Domain.Models;
using DataAccess.Repositories;
using Domain.Utility;
using Microsoft.AspNet.Identity;

namespace BaBookApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
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
            var eventUsersVM = new List<ParticipantViewModel>();

            try
            {
                var eventUsers = _repository.GetEventParticipants(eventId);

                eventUsers.ForEach(x => eventUsersVM.Add(DomainToViewModelMapping.MapParticipantViewModel(x)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(eventUsersVM);
        }

        [Route("api/userevent/invite/{eventId}/{userId}")]
        [HttpPost]
        public IHttpActionResult SendInvitation(int eventId, string userId)
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

        [HttpPost]
        [Route("api/userevent")]
        public IHttpActionResult ChangeResponse(AttendanceViewModel model)
        {
            try
            {
                var attendance = ViewModelToDomainMapping.AttendanceViewModelToModel(model);
                _repository.AddResponse(attendance, model.EventId, model.UserId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPost]
        [Route("api/comments/{eventId}")]
        public IHttpActionResult AddComment(int eventId, NewCommentViewModel model)
        {
            try
            {
                var comment = ViewModelToDomainMapping.CommentViewModelToModel(model);
                _repository.AddComment(comment, eventId,
                    HttpContext.Current.User.Identity.GetUserId());
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
            var commentsVM = new List<GetCommentsViewModel>();
            try
            {
                var comments = _repository.GetEventComments(eventId);
                comments.ForEach(x => commentsVM.Add(DomainToViewModelMapping.MapGetCommentsViewModel(x)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(commentsVM);
        }

    }
}
