using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BaBook_Backend.Models;
using BaBook_Backend.ViewModels;

namespace BaBook_Backend.Mapper
{
    public static class ViewModelToDomainMapping
    {
        public static Event MapEvent(EventViewModel model)
        {
            return new Event()
            {
                AttendingUsers = new List<User>(),
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
                AttendingUsers = new List<User>(),
                OfGroup = new Group(),
                OwnerUser = new User(),
                DateOfOccurance = model.DateOfOccurance,
                Location = model.Location,
                Title = model.Title,
            };
        }
    }
}