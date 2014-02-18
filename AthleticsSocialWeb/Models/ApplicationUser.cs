using AthleticsSocialWeb.Core.Entities;

namespace AthleticsSocialWeb.Models
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
}