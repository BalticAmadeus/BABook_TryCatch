using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using BaBookApi.ViewModels;
using DataAccess.Context;
using Domain.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security.OAuth;

namespace BaBookApi.Providers
{
    public class WebApiAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            IdentityUser user;

            using (var _repo = new AuthRepository())
            {
                user = await _repo.FindUser(context.UserName, context.Password);

                if (user == null)
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return;
                }
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim("role", "user"));
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id));

            context.Validated(identity);
        }
    }

    public class AuthRepository : IDisposable
    {
        private readonly DataContext _ctx;

        private readonly UserManager<User> _userManager;

        public AuthRepository()
        {
            _ctx = new DataContext();
            _userManager = new UserManager<User>(new UserStore<User>(_ctx));
        }

        public async Task<IdentityResult> RegisterUser(RegisterViewModel model)
        {
            var user = new User
            {
                UserName = model.Email,
                DisplayName = model.Name
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            return result;
        }

        public async Task<User> FindUser(string userName, string password)
        {
            var user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public async Task<User> FindUser(string userId)
        {
            var user = _ctx.Users.FirstOrDefault(x => x.Id == userId);
            if (user == null)
            {
                throw new Exception("No user found");
            }

            return user;
        }

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();
        }
    }
}