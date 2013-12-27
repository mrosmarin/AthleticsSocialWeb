using System.Collections.Generic;

namespace AthleticsSocialWeb.Core.Entities
{
    public class SystemObject
    {
        public enum Names
        {
            Accounts = 1,
            Profiles = 2,
            Blogs = 3,
            BoardPosts = 4,
            Files = 5,
            Groups = 6
        }

        #region Primitive Properties

        public int SystemObjectId { get; set; }


        public byte[] Timestamp { get; set; }


        public string Name { get; set; }

        #endregion

        #region Navigation Properties

        public virtual ICollection<Comment> Comments { get; set; }


        public virtual ICollection<Rating> Ratings { get; set; }


        public virtual ICollection<SystemObjectRatingOption> SystemObjectRatingOptions { get; set; }


        public virtual ICollection<SystemObjectTag> SystemObjectTags { get; set; }


        public virtual ICollection<Moderation> Moderations { get; set; }

        #endregion
    }
}