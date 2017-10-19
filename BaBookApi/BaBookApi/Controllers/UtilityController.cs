using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using BaBookApi.Providers;
using BaBookApi.ViewModels;
using DataAccess.Context;
using Domain.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace BaBookApi.Controllers
{
    public class UtilityController : ApiController
    {
        private readonly DataContext _context;
        private readonly AuthRepository _authRepository;

        public UtilityController()
        {
            _context = new DataContext();
            _authRepository = new AuthRepository();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/seed")]
        public async Task<IHttpActionResult> SeedDatabase()
        {
            if (_context.Users.Any(x => x.UserName == "admin")) return BadRequest("Already seed'ed");

            var user = new RegisterViewModel()
            {
                Email = "admin",
                Password = "adminas"
            };

            IdentityResult result = await _authRepository.RegisterUser(user);

            var user2 = new RegisterViewModel()
            {
                Email = "guest",
                Password = "guestas"
            };

            IdentityResult result2 = await _authRepository.RegisterUser(user2);

            Group group = new Group()
            {
                Name = "ALUS"
            };

            _context.Groups.AddOrUpdate(group);
            _context.SaveChanges();

            Event newEvent = new Event()
            {
                Attendances = new List<UserEventAttendance>(),
                DateOfOccurance = new DateTime(1997, 11, 24, 15, 25, 25),
                Description = "TESTASSS",
                Location = "Snekutis",
                Title = "BeerPong",
                OfGroup = group,
                OwnerUser = _context.Users.SingleOrDefault(x => x.UserName == "admin")
            };

            _context.Events.AddOrUpdate(newEvent);

            _context.SaveChanges();

            return Ok();
        }
    }
}