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
                EventId = model.EventId,
                Title = model.Title,
                Location = model.Location,
                DateOfOccurance = model.DateOfOccurance,
                Description = model.Description
            };

            model.Attendances
                .ForEach(x => eventVm.Attendances.Add(x));
            model.Comments
                .ForEach(x => eventVm.Comments.Add(x));

            return eventVm;
        }

        public static CommentViewModel MapCommentViewModel(Comment model)
        {
            var commentVm = new CommentViewModel
            {
                commentId = model.CommentId,
                CommentText = model.CommentText,
                CommentTime = model.CommentTime,
            };

            return commentVm;
        }

        public static UserViewModel MapUserViewModel(User model)
        {
            return new UserViewModel
            {
                UserId = model.UserId,
                Name = model.Name
            };
        }
    }
}