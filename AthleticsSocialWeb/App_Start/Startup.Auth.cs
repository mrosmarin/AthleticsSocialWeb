using System;
using System.Data.Entity;
using AthleticsSocialWeb.Core.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Owin;
using AthleticsSocialWeb.Providers;

namespace AthleticsSocialWeb
{
    public partial class Startup
    {

        public class ApplicationUser : Account
        {
            public ApplicationUser() { }
            public ApplicationUser(string userName)
                : base(userName)
            {

            }

            public string DisplayName { get; set; }
         //   public string Email { get; set; }
            public string ConfirmationToken { get; set; }
        //    public bool IsConfirmed { get; set; }
        }


        public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
        {
            public DbSet<Profile> Profile { get; set; }

            public ApplicationDbContext() : base("DefaultConnection") { }
            protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<IdentityUser>().ToTable("AppUsers");// .Property(p => p.Id).HasColumnName("UserId");
                modelBuilder.Entity<Account>().ToTable("AppUsers");//.Property(p => p.Id).HasColumnName("UserId");
                modelBuilder.Entity<ApplicationUser>().ToTable("AppUsers");//.Property(p => p.Id).HasColumnName("UserId");
                modelBuilder.Entity<IdentityUserRole>().ToTable("AppUserRoles");
                modelBuilder.Entity<IdentityUserLogin>().ToTable("AppUserLogins");
                modelBuilder.Entity<IdentityUserClaim>().ToTable("AppUserClaims");
                modelBuilder.Entity<IdentityRole>().ToTable("AppRoles");


              //  modelBuilder.Entity<UserInfo>().ToTable("MyUserInfo").HasRequired(i => i.User).WithMany(u => u.Goals).HasForeignKey(i => i.UserId);

            }

        }


        static Startup()
        {
            PublicClientId = "self";
            
            UserManagerFactory = () => new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new ApplicationOAuthProvider(PublicClientId, UserManagerFactory),
                AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                AllowInsecureHttp = true
            };
        }

        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public static Func<UserManager<ApplicationUser>> UserManagerFactory { get; set; }

        public static string PublicClientId { get; private set; }

        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {

            // Enable the application to use a cookie to store information for the signed in user
          //  app.UseCookieAuthentication(new CookieAuthenticationOptions
           // {
            //    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
             //   LoginPath = new PathString("/Account/Login")
            //});




            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Enable the application to use bearer tokens to authenticate users
            app.UseOAuthBearerTokens(OAuthOptions);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //    consumerKey: "",
            //    consumerSecret: "");

            //app.UseFacebookAuthentication(
            //    appId: "",
            //    appSecret: "");

            //app.UseGoogleAuthentication();
        }
    }
}
