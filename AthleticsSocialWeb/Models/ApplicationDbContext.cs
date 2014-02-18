using System.Data.Entity;
using AthleticsSocialWeb.Core.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AthleticsSocialWeb.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Profile> Profile { get; set; }

        public ApplicationDbContext() : base("DefaultConnection") { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
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
}