using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BaBook_Backend.Models;
using BaBook_Backend.ViewModels;

namespace BaBook_Backend.Mapper
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
                DateOfOccurance = model.DateOfOccurance
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
                GroupId = model.OfGroup.GroupId,
                OwnerId = model.OwnerUser.UserId
            };
        }
    }
}