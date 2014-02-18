using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace AthleticsSocialWeb.Models
{
    public class AppUserManager:UserManager<ApplicationUser>
    {
        public UserStore<ApplicationUser> UserStore
        {
            get { return Store as UserStore<ApplicationUser>; }
        }

        public ApplicationDbContext UserContext
        {
            get { return UserStore.Context as ApplicationDbContext; }
        }


        public AppUserManager(IUserStore<ApplicationUser> store) : base(store)
        {
        }
    }
}