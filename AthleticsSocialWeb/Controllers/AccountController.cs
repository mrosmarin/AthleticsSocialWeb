using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using AthleticsSocialWeb.Common.Helpers;
using AthleticsSocialWeb.Common.Logging;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using AthleticsSocialWeb.Models;
using AthleticsSocialWeb.Providers;
using AthleticsSocialWeb.Results;
using Postal;

namespace AthleticsSocialWeb.Controllers
{
    [Authorize]
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private const string LocalLoginProvider = "Local";

        private ILogger Logger { set; get; }

        //public AccountController()
        //{
        //        UserManager = Startup.UserManagerFactory();
        //        AccessTokenFormat = Startup.OAuthOptions.AccessTokenFormat;
        //}

        public AccountController(AppUserManager userManager,
            ISecureDataFormat<AuthenticationTicket> accessTokenFormat, ILogger logger)
        {
            UserManager = userManager;
            AccessTokenFormat = accessTokenFormat;
            Logger = logger;
        }

        public AppUserManager UserManager { get; private set; }
        public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; private set; }

        // GET api/Account/UserInfo
        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("UserInfo")]
        public async Task<UserInfoViewModel> GetUserInfo()
        {
            ExternalLoginData externalLogin = ExternalLoginData.FromIdentity(User.Identity as ClaimsIdentity);

            Func<Task<bool>> isConfirmAsync = async () =>
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                return user.EmailVerified;
            };

            var u =  new UserInfoViewModel
            {
                UserName = User.Identity.GetUserName(),
                IsConfirmed = await isConfirmAsync(),
                HasRegistered = externalLogin == null,
                LoginProvider = externalLogin != null ? externalLogin.LoginProvider : null
            };

            return u;
        }

        // POST api/Account/Logout
        [Route("Logout")]
        public IHttpActionResult Logout()
        {
            Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
            return Ok();
        }

        // GET api/Account/ManageInfo?returnUrl=%2F&generateState=true
        [Route("ManageInfo")]
        public async Task<ManageInfoViewModel> GetManageInfo(string returnUrl, bool generateState = false)
        {
            IdentityUser user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

            if (user == null)
            {
                return null;
            }

            var logins = new List<UserLoginInfoViewModel>();

            foreach (IdentityUserLogin linkedAccount in user.Logins)
            {
                logins.Add(new UserLoginInfoViewModel
                {
                    LoginProvider = linkedAccount.LoginProvider,
                    ProviderKey = linkedAccount.ProviderKey
                });
            }

            if (user.PasswordHash != null)
            {
                logins.Add(new UserLoginInfoViewModel
                {
                    LoginProvider = LocalLoginProvider,
                    ProviderKey = user.UserName,
                });
            }

            return new ManageInfoViewModel
            {
                LocalLoginProvider = LocalLoginProvider,
                UserName = user.UserName,
                Logins = logins,
                ExternalLoginProviders = GetExternalLogins(returnUrl, generateState)
            };
        }

        // POST api/Account/ChangePassword
        [Route("ChangePassword")]
        public async Task<IHttpActionResult> ChangePassword(ChangePasswordBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword,
                model.NewPassword);
            IHttpActionResult errorResult = GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            return Ok();
        }

        // POST api/Account/SetPassword
        [Route("SetPassword")]
        public async Task<IHttpActionResult> SetPassword(SetPasswordBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await UserManager.AddPasswordAsync(User.Identity.GetUserId(), model.NewPassword);
            IHttpActionResult errorResult = GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            return Ok();
        }

        // POST api/Account/AddExternalLogin
        [Route("AddExternalLogin")]
        public async Task<IHttpActionResult> AddExternalLogin(AddExternalLoginBindingModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var ticket = AccessTokenFormat.Unprotect(model.ExternalAccessToken);

            if (ticket == null || ticket.Identity == null || (ticket.Properties != null
                                            && ticket.Properties.ExpiresUtc.HasValue
                                            && ticket.Properties.ExpiresUtc.Value < DateTimeOffset.UtcNow))
                return BadRequest("External login failure.");

            var externalData = ExternalLoginData.FromIdentity(ticket.Identity);
            if (externalData == null)
                return BadRequest("The external login is already associated with an account.");

            var result = await UserManager.AddLoginAsync(User.Identity.GetUserId(),
                new UserLoginInfo(externalData.LoginProvider, externalData.ProviderKey));

            var errorResult = GetErrorResult(result);
            return errorResult ?? Ok();
        }

        // POST api/Account/RemoveLogin
        [Route("RemoveLogin")]
        public async Task<IHttpActionResult> RemoveLogin(RemoveLoginBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result;

            if (model.LoginProvider == LocalLoginProvider)
            {
                result = await UserManager.RemovePasswordAsync(User.Identity.GetUserId());
            }
            else
            {
                result = await UserManager.RemoveLoginAsync(User.Identity.GetUserId(),
                    new UserLoginInfo(model.LoginProvider, model.ProviderKey));
            }

            IHttpActionResult errorResult = GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            return Ok();
        }

        // GET api/Account/ExternalLogin
        [OverrideAuthentication]
        [HostAuthentication(DefaultAuthenticationTypes.ExternalCookie)]
        [AllowAnonymous]
        [Route("ExternalLogin", Name = "ExternalLogin")]
        public async Task<IHttpActionResult> GetExternalLogin(string provider, string error = null)
        {
            if (error != null)
            {
                return Redirect(Url.Content("~/") + "#error=" + Uri.EscapeDataString(error));
            }

            if (!User.Identity.IsAuthenticated)
            {
                return new ChallengeResult(provider, this);
            }

            ExternalLoginData externalLogin = ExternalLoginData.FromIdentity(User.Identity as ClaimsIdentity);

            if (externalLogin == null)
            {
                return InternalServerError();
            }

            if (externalLogin.LoginProvider != provider)
            {
                Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);
                return new ChallengeResult(provider, this);
            }

            var user = await UserManager.FindAsync(new UserLoginInfo(externalLogin.LoginProvider,
                externalLogin.ProviderKey));

            bool hasRegistered = user != null;

            if (hasRegistered)
            {
                Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);
                var oAuthIdentity = await UserManager.CreateIdentityAsync(user,
                    OAuthDefaults.AuthenticationType);
                var cookieIdentity = await UserManager.CreateIdentityAsync(user,
                    CookieAuthenticationDefaults.AuthenticationType);
                var properties = ApplicationOAuthProvider.CreateProperties(user.UserName,user.EmailVerified);
                Authentication.SignIn(properties, oAuthIdentity, cookieIdentity);
            }
            else
            {
                IEnumerable<Claim> claims = externalLogin.GetClaims();
                var identity = new ClaimsIdentity(claims, OAuthDefaults.AuthenticationType);
                Authentication.SignIn(identity);
            }

            return Ok();
        }

        // GET api/Account/ExternalLogins?returnUrl=%2F&generateState=true
        [AllowAnonymous]
        [Route("ExternalLogins")]
        public IEnumerable<ExternalLoginViewModel> GetExternalLogins(string returnUrl, bool generateState = false)
        {
            IEnumerable<AuthenticationDescription> descriptions = Authentication.GetExternalAuthenticationTypes();
            List<ExternalLoginViewModel> logins = new List<ExternalLoginViewModel>();

            string state;

            if (generateState)
            {
                const int strengthInBits = 256;
                state = RandomOAuthStateGenerator.Generate(strengthInBits);
            }
            else
            {
                state = null;
            }

            foreach (AuthenticationDescription description in descriptions)
            {
                var login = new ExternalLoginViewModel
                {
                    Name = description.Caption,
                    Url = Url.Route("ExternalLogin", new
                    {
                        provider = description.AuthenticationType,
                        response_type = "token",
                        client_id = Startup.PublicClientId,
                        redirect_uri = new Uri(Request.RequestUri, returnUrl).AbsoluteUri, state
                    }),
                    State = state
                };
                logins.Add(login);
            }

            //Dumpy data
            logins.Add(new ExternalLoginViewModel { Name = "Facebook", Url = "/"});
            logins.Add(new ExternalLoginViewModel { Name = "Twitter", Url = "/" });
            logins.Add(new ExternalLoginViewModel { Name = "LinkedIn", Url = "/" });
            logins.Add(new ExternalLoginViewModel { Name = "Tumblr", Url = "/" });
            logins.Add(new ExternalLoginViewModel { Name = "Instagram", Url = "/" });
            logins.Add(new ExternalLoginViewModel { Name = "LinkedIn", Url = "/" });
            return logins;
        }

        // POST api/Account/ResendEmail
        [Route("ResendEmail")]
        public async Task<bool> ResendEmailConfirmation()
        {
            var userinfo = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            return await SendEmailConfirmation(userinfo.UserName, userinfo.UserName, userinfo.ConfirmationToken);
        }


        //Generate Password Token
  //      public RNGCryptoServiceProvider()
   // Member of System.Security.Cryptography.RNGCryptoServiceProvider
        //private static string GenerateToken()
        //{
        //    using (var prng = new RNGCryptoServiceProvider())
        //    {
        //        return GenerateToken(prng);
        //    }
        //}
        //
        //
        //internal static string GenerateToken(RandomNumberGenerator generator)
        //{
        //    byte[] tokenBytes = new byte[TokenSizeInBytes];
        //    generator.GetBytes(tokenBytes);
        //    return HttpServerUtility.UrlTokenEncode(tokenBytes);
        //}




        // POST api/Account/VerifyEmail

        [OverrideAuthentication]
        [AllowAnonymous]
        [Route("VerifyEmail")]
        [HttpPost]
        public async Task<bool> VerifyToken([FromBody]string token)
        {
            var user = await UserManager.UserContext.Users.SingleOrDefaultAsync(u => u.ConfirmationToken == token);
            if (user != null){
                user.EmailVerified = true;
                var result = await UserManager.UpdateAsync(user);
                return result.Succeeded;
            }
            return false;
        }

        // POST api/Account/Register
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(RegisterBindingModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            string confirmationToken = CreateConfirmationToken();
            var user = new ApplicationUser
            {
                UserName = model.UserName,
                ConfirmationToken = confirmationToken,
                EmailVerified = false
            };

            var result = await UserManager.CreateAsync(user, model.Password);
            var errorResult = GetErrorResult(result);
            if (result.Succeeded)
                await SendEmailConfirmation(model.UserName, model.UserName, confirmationToken);

            return errorResult ?? Ok();
        }

        // POST api/Account/RegisterExternal
        [OverrideAuthentication]
        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("RegisterExternal")]
        public async Task<IHttpActionResult> RegisterExternal(RegisterExternalBindingModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var externalLogin = ExternalLoginData.FromIdentity(User.Identity as ClaimsIdentity);

            if (externalLogin == null)
                return InternalServerError();

            var user = new ApplicationUser
            {
                UserName = model.UserName
            };
            user.Logins.Add(new IdentityUserLogin
            {
                LoginProvider = externalLogin.LoginProvider,
                ProviderKey = externalLogin.ProviderKey
            });
            var result = await UserManager.CreateAsync(user);
            var errorResult = GetErrorResult(result);

            return errorResult ?? Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                UserManager.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Helpers


        private async Task<bool> SendEmailConfirmation(string to, string username, string confirmationToken)
        {
            try
            {
                dynamic email = new Email("ConfirmEmail");
                email.To = to;
                email.UserName = username;
                email.ConfirmationToken = confirmationToken;
                await ((Email)email).SendAsync();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        private string CreateConfirmationToken()
        {
            return ShortGuid.NewGuid();
        }

        private IAuthenticationManager Authentication
        {
            get { return Request.GetOwinContext().Authentication; }
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

        private class ExternalLoginData
        {
            public string LoginProvider { get; private set; }
            public string ProviderKey { get; private set; }
            private string UserName { get; set; }

            public IEnumerable<Claim> GetClaims()
            {
                var claims = new List<Claim> {new Claim(ClaimTypes.NameIdentifier, ProviderKey, null, LoginProvider)};

                if (UserName != null)
                {
                    claims.Add(new Claim(ClaimTypes.Name, UserName, null, LoginProvider));
                }

                return claims;
            }

            public static ExternalLoginData FromIdentity(ClaimsIdentity identity)
            {
                if (identity == null)
                {
                    return null;
                }

                Claim providerKeyClaim = identity.FindFirst(ClaimTypes.NameIdentifier);

                if (providerKeyClaim == null || String.IsNullOrEmpty(providerKeyClaim.Issuer)
                    || String.IsNullOrEmpty(providerKeyClaim.Value))
                {
                    return null;
                }

                if (providerKeyClaim.Issuer == ClaimsIdentity.DefaultIssuer)
                {
                    return null;
                }

                return new ExternalLoginData
                {
                    LoginProvider = providerKeyClaim.Issuer,
                    ProviderKey = providerKeyClaim.Value,
                    UserName = identity.FindFirstValue(ClaimTypes.Name)
                };
            }
        }

        private static class RandomOAuthStateGenerator
        {
            private static readonly RandomNumberGenerator Random = new RNGCryptoServiceProvider();

            public static string Generate(int strengthInBits)
            {
                const int bitsPerByte = 8;

                if (strengthInBits % bitsPerByte != 0)
                {
                    throw new ArgumentException("strengthInBits must be evenly divisible by 8.", "strengthInBits");
                }

                int strengthInBytes = strengthInBits / bitsPerByte;

                var data = new byte[strengthInBytes];
                Random.GetBytes(data);
                return HttpServerUtility.UrlTokenEncode(data);
            }
        }

        #endregion
    }
}
