using System;

namespace AthleticsSocialWeb.Core.Entities
{
    public class GroupMember
    {
        #region Primitive Properties

        public long GroupMemberId { get; set; }


        public int GroupId { get; set; }


        public string AccountId { get; set; }


        public DateTime CreateDate { get; set; }


        public byte[] Timestamp { get; set; }


        public bool IsAdmin { get; set; }


        public bool IsApproved { get; set; }

        #endregion

        #region Navigation Properties

        public virtual Group Group { get; set; }


        public virtual Account Account { get; set; }

        #endregion
    }
}