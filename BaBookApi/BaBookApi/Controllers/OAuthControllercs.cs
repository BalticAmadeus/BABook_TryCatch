using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using BaBookApi.Mapping;
using BaBookApi.Providers;
using BaBookApi.ViewModels;
using Domain.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Provider;

namespace BaBookApi.Controllers
{
    public class OAuthController : ApiController
    {
        private readonly AuthRepository _repo;

        public OAuthController()
        {
            _repo = new AuthRepository();
        }

        // POST api/Account/Register
        [AllowAnonymous]
        [HttpPost]
        [Route("api/register")]
        public async Task<IHttpActionResult> Register(RegisterViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _repo.RegisterUser(model);

            var errorResult = GetErrorResult(result);

            return errorResult ?? Ok();
        }

        [Authorize]
        [HttpGet]
        [Route("api/user")]
        public IHttpActionResult GetUser()
        {
            try
            {
                var user = _repo.FindUser(HttpContext.Current.User.Identity.GetUserId());

                var userVm = DomainToViewModelMapping.MapUserViewModel(user.Result);
                return Ok(userVm);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repo.Dispose();
            }

            base.Dispose(disposing);
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}