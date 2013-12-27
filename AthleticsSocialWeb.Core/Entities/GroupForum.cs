using System;

namespace AthleticsSocialWeb.Core.Entities
{
    public class GroupForum
    {
        #region Primitive Properties

        public long GroupForumId { get; set; }


        public int GroupId { get; set; }


        public int BoardForumId { get; set; }


        public DateTime CreateDate { get; set; }


        public byte[] Timestamp { get; set; }

        #endregion

        #region Navigation Properties
        public virtual BoardForum BoardForum { get; set; }
        public virtual Group Group { get; set; }
        #endregion
    }
}