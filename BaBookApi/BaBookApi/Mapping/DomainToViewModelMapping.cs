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
        public static AttendanceViewModel AttendanceModelToViewModel(UserEventAttendance attendance)
        {
            var attendanceViewModel = new AttendanceViewModel
            {
                UserId = attendance.User.UserId,
                EventId = attendance.Event.EventId,
                Status = attendance.Response
            };

            return attendanceViewModel;
        }
        public static EventListItemViewModel MapEventListItemViewModel(Event model, int userId)
        {
            var vm = new EventListItemViewModel()
            {
                EventId = model.EventId,
                GroupName = model.OfGroup.Name,
                OwnerName = model.OwnerUser.Name,
                Date = model.DateOfOccurance,
                Location = model.Location,
                Description = model.Description,
                Title = model.Title,
            };

            var attendance = model.Attendances.SingleOrDefault(x => x.User.UserId == userId);
            if (attendance != null) vm.AttendanceStatus = attendance.Response;

            return vm;
        }

        public static ParticipantViewModel MapParticipantViewModel(UserEventAttendance model)
        {
            return new ParticipantViewModel()
            {
                Name = model.User.Name,
                AttendanceStatus = model.Response
            };
        }

        public static GetCommentsViewModel MapGetCommentsViewModel(Comment model)
        {
            return new GetCommentsViewModel()
            {
                OwnerUser = model.OwnerUser.Name,
                Text = model.CommentText
            };
        }
    }
}