using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using BaBookApi.Mapping;
using BaBookApi.ViewModels;
using DataAccess.Repositories;
using Microsoft.AspNet.Identity;

namespace BaBookApi.Controllers
{
    [EnableCors("*", "*", "*")]
    public class CommentController : ApiController
    {

        private readonly CommentRepository _repository;

        public CommentController()
        {
            _repository = new CommentRepository();
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

        [HttpDelete]
        [Route("api/comments/{commentId}")]
        public IHttpActionResult DeleteComment(int commentId)
        {
            _repository.Remove(_repository.SingleOrDefault(x => x.CommentId == commentId));
            return Ok();
        }
    }
}