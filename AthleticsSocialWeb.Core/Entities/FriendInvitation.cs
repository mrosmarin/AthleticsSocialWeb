using System;

namespace AthleticsSocialWeb.Core.Entities
{
    public class FriendInvitation
    {
        #region Primitive Properties

        public int InvitationId { get; set; }


        public string AccountId { get; set; }


        public string Email { get; set; }


        public Guid Guid { get; set; }


        public DateTime CreateDate { get; set; }


        public string BecameAccountId { get; set; }


        public byte[] Timestamp { get; set; }

        #endregion

        #region Navigation Properties

        public virtual Account Account { get; set; }

        #endregion
    }
}