using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AthleticsSocialWeb.Core.Entities
{
    public class Account : IdentityUser
    {

        #region Constructor
        public Account()
        {
            
        }

        public Account(string username):base(username)
        {
            
        }
        #endregion

        #region Primitive Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public bool EmailVerified { get; set; }
        public string Zip { get; set; }
        public DateTime? BirthDate { get; set; }
   
        public int TermId { get; set; }
        public DateTime? AgreedToTermsDate { get; set; }
        public int Score { get; set; }

    //    public int ProfileId { get; set; }

        //TODO should be in base class
        public DateTime? CreateDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public byte[] Timestamp { get; set; }


        #endregion
        #region Navigation Properties
     //   public virtual Profile Profile { get; set; }
        public virtual ICollection<AccountFile> AccountFiles { get; set; }
   //     public virtual ICollection<AccountFolder> AccountFolders { get; set; }
        public virtual ICollection<AccountPermission> AccountPermissions { get; set; }
    //    public virtual Term Term { get; set; }
        public virtual ICollection<Alert> Alerts { get; set; }
        //public virtual ICollection<Blog> Blogs { get; set; }
        //public virtual ICollection<BoardPost> BoardPosts { get; set; }
        //public virtual ICollection<Comment> Comments { get; set; }
        //public virtual ICollection<ContentFilter> ContentFilters { get; set; }
        //public virtual ICollection<File> Files { get; set; }
        //public virtual ICollection<FolderFile> FolderFiles { get; set; }
        //public virtual ICollection<Folder> Folders { get; set; }
        //public virtual ICollection<FriendInvitation> FriendInvitations { get; set; }
        //public virtual ICollection<Friend> Friends { get; set; }
        //public virtual ICollection<Gag> Gags { get; set; }
        //public virtual ICollection<GroupMember> GroupMembers { get; set; }
        //public virtual ICollection<Group> Groups { get; set; }
        //public virtual ICollection<Message> Messages { get; set; }
        //public virtual ICollection<Moderation> Moderations { get; set; }
        ////public virtual ICollection<Profile> Profiles { get; set; }
        //public virtual ICollection<Rating> Ratings { get; set; }
        //public virtual ICollection<StatusUpdate> StatusUpdates { get; set; }
        //public virtual ICollection<SystemObjectTag> SystemObjectTags { get; set; }

        #endregion


    }
}
