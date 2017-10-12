using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BaBookApi.ViewModels;
using Domain.Models;

namespace BaBookApi.Mapping
{
    public static class DomainToViewModelMapping
    {
        public static EventViewModel MapEventViewModel(Event model)
        {
            var eventVm = new EventViewModel
            {
                eventId = model.EventId,
                title = model.Title,
                location = model.Location,
                dateOfOccurance = model.DateOfOccurance,
                description = model.Description
            };

            model.Attendances
                .ForEach(x => eventVm.attendances.Add(x));
            model.Comments
                .ForEach(x => eventVm.comments.Add(x));

            return eventVm;
        }

        public static CommentViewModel MapCommentViewModel(Comment model)
        {
            var commentVm = new CommentViewModel
            {
                commentId = model.CommentId,
                commentText = model.CommentText,
                commentTime = model.CommentTime,
            };

            return commentVm;
        }

        public static UserViewModel MapUserViewModel(User model)
        {
            return new UserViewModel
            {
                userId = model.UserId,
                name = model.Name
            };
        }
    }
}