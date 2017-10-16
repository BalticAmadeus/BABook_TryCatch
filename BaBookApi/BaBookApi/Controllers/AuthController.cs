using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.UI.WebControls;
using DotNetOpenAuth.Messaging;
using DotNetOpenAuth.OpenId;
using DotNetOpenAuth.OpenId.Extensions.SimpleRegistration;
using DotNetOpenAuth.OpenId.RelyingParty;

namespace BaBookApi.Controllers
{
    public class AuthController : ApiController
    {
        protected void openidValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // This catches common typos that result in an invalid OpenID Identifier.
            args.IsValid = Identifier.IsValid(args.Value);
        }

        public IHttpActionResult LogIn(string token)
        {
            try
            {
                using (OpenIdRelyingParty openid = new OpenIdRelyingParty())
                {
                    IAuthenticationRequest request = openid.CreateRequest(token);

                    // This is where you would add any OpenID extensions you wanted
                    // to include in the authentication request.
                    request.AddExtension(new ClaimsRequest
                    {
                        Email = DemandLevel.Request,
                        FullName = DemandLevel.Request,
                        BirthDate = DemandLevel.Request
                    });

                    // Send your visitor to their Provider for authentication.
                    request.RedirectToProvider();

                    return Ok();
                }
            }
            catch (ProtocolException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}