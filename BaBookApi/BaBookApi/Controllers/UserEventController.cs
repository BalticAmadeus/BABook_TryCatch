using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain.Models;
using DataAccess.Repositories;

namespace BaBookApi.Controllers
{
    public class UserEventController : ApiController
    {
        [AllowAnonymous]
        [Route("api/userevent/{eventId}/{userId}")]
        [HttpPost]
        public IHttpActionResult AddUserToEvent(int eventId, int userId)
        {
            var repository = new UserEventRepository();

            repository.addUserToEvent(eventId,userId);

            return Ok();
        }
    }
}
