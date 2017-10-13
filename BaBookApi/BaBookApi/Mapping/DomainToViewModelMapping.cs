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
        public static EventListItemViewModel MapEventListItemViewModel(Event model)
        {
            return new EventListItemViewModel()
            {
                EventId = model.EventId,
                GroupName = model.OfGroup.Name,
                OwnerName = model.OwnerUser.Name,
                Date = model.DateOfOccurance,
                Location = model.Location,
                Description = model.Description,
                Title = model.Title,
            };
        }

        public static ParticipantViewModel MapParticipantViewModel(UserEventAttendance model)
        {
            return new ParticipantViewModel()
            {
                Name = model.User.Name,
                AttendanceStatus = model.Response
            };
        }
    }
}