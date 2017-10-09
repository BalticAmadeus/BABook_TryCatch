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
    }
}