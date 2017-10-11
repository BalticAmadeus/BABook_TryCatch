using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BaBookApi.ViewModels;
using Domain.Models;

namespace BaBookApi.Mapping
{
    public static class ViewModelToDomainMapping
    {
        public static Event MapEvent(EventViewModel model)
        {
            return new Event()
            {
                EventId = model.EventId,
                Attendances= new List<UserEventAttendance>(),
                OfGroup = new Group(),
                OwnerUser = new User(),
                DateOfOccurance = model.DateOfOccurance,
                Location = model.Location,
                Title = model.Title,
            };
        }

        public static Event MapEvent(CreateEventViewModel model)
        {
            return new Event()
            {
                EventId = model.EventId,
                Attendances = new List<UserEventAttendance>(),
                OfGroup = new Group(),
                OwnerUser = new User(),
                DateOfOccurance = model.DateOfOccurance,
                Location = model.Location,
                Title = model.Title,
            };
        }
    }
}