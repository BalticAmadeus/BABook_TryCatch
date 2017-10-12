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
            return new EventViewModel()
            {
                EventId = model.EventId,
                Title = model.Title,
                Location = model.Location,
                DateOfOccurance = model.DateOfOccurance,
                Description = model.Description
            };
        }
        public static CreateEventViewModel MapNewEventViewModel(Event model)
        {
            return new CreateEventViewModel()
            {
                EventId = model.EventId,
                Title = model.Title,
                Location = model.Location,
                DateOfOccurance = model.DateOfOccurance,
                Description = model.Description,
                GroupId = model.OfGroup.GroupId,
                OwnerId = model.OwnerUser.UserId
            };
        }

        public static UserViewModel MapUserViewModel(User model)
        {
            return new UserViewModel()
            {
                UserId = model.UserId,
                Name = model.Name
            };
        }

        public static CommentViewModel MapCommentViewModel(Comment model)
        {
            return new CommentViewModel()
            {
                OwnerUser = new UserViewModel()
                {
                    UserId = model.OwnerUser.UserId,
                    Name = model.OwnerUser.Name
                },
                CommentText = model.CommentText,
                CommentTime = model.CommentTime,
                CommentId = model.CommentId
            };
        }
    }
}