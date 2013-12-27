using System;
using System.Collections.Generic;

namespace AthleticsSocialWeb.Core.Entities
{
    public class Friend
    {
        #region Primitive Properties

        public int FriendId { get; set; }


        public string AccountId { get; set; }


        public int MyFriendsAccountId { get; set; }


        public DateTime CreateDate { get; set; }


        public byte[] Timestamp { get; set; }

        #endregion

        #region Navigation Properties

        public virtual ICollection<FriendshipDefinition> FriendshipDefinitions { get; set; }

        public virtual Account Account { get; set; }


        public virtual Account MyFriendsAccount { get; set; }

        #endregion
    }
}