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
        public static Event MapEvent(CreateEventViewModel model)
        {
            var currentEvent = new Event
            {
                EventId = model.EventId,
                DateOfOccurance = model.DateOfOccurance,
                Location = model.Location,
                Title = model.Title,
                Description = model.Description
            };

            currentEvent.Attendances = new List<UserEventAttendance>();
            currentEvent.Comments = new List<Comment>();

            currentEvent.OfGroup = new Group();
            currentEvent.OwnerUser = new User();

            return currentEvent;
        }
    }
}