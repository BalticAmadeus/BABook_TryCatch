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
        public static NewCommentViewModel NewCommentModelToViewModel(Comment comment)
        {
            var commentViewModel = new NewCommentViewModel
            {
                UserId = comment.OwnerUser.UserId,
                CommentText = comment.CommentText
            };

            return commentViewModel;
        }

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
    }
}