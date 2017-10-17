using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
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
        private ApplicationUserManager _userManager;

        public UtilityController()
        {
            _context = new DataContext();
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [HttpPost]
        [Route("api/seed")]
        public IHttpActionResult SeedDatabase()
        {
            if (_context.Users.Any(x => x.UserName == "admin")) return BadRequest("Already seed'ed");

            var user = new User
            {
                UserName = "admin",
                Email = "admin@admin.com"
            };
            const string password = "adminas";

            UserManager.Create(user, password);

            var user2 = new User
            {
                UserName = "guest",
                Email = "guest@guest.com"
            };
            const string password2 = "guestas";

            UserManager.Create(user2, password2);

            return Ok();
        }
    }
}