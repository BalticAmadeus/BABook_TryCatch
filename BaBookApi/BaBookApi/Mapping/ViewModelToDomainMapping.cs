using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BaBookApi.ViewModels;
using DataAccess.Repositories;
using Domain.Models;
using Microsoft.Ajax.Utilities;

namespace BaBookApi.Mapping
{
    public static class ViewModelToDomainMapping
    {
        public static Comment CommentViewModelToModel(NewCommentViewModel commentViewModel)
        {
            var comment = new Comment
            {
                CommentText = commentViewModel.CommentText,
                OwnerUser = new User(),
                OfEvent = new Event(),
                CommentTime = DateTime.Now
            };

            return comment;
        }

        public static UserEventAttendance AttendanceViewModelToModel(AttendanceViewModel attendanceViewModel)
        {
            var attendance = new UserEventAttendance
            {
                Event = new Event(),
                User = new User(),
                Response = attendanceViewModel.Status
            };

            return attendance;
        }

        public static Event NewEventViewModelToModel(NewEventViewModel model)
        {
            var currentEvent = new Event
            {
                Title = model.Title,
                DateOfOccurance = model.DateOfOccurance,
                Location = model.Location,
                Description = model.Description,
                OfGroup = new Group(),
                OwnerUser = new User(),
                Comments = new List<Comment>(),
                Attendances = new List<UserEventAttendance>()
            };

            return currentEvent;
        }

    }
}