using System;

namespace AthleticsSocialWeb.Core.Entities
{
    public class FriendshipDefinition
    {
        #region Primitive Properties

        public int FriendshipDefinitionId { get; set; }


        public int FriendId { get; set; }


        public int FriendshipDefinitionTypeId { get; set; }


        public DateTime CreateDate { get; set; }


        public string Description { get; set; }


        public DateTime? DateFrom { get; set; }


        public DateTime? DateTo { get; set; }


        public string OptionalText1 { get; set; }


        public string OptionalText2 { get; set; }


        public bool Approved { get; set; }


        public byte[] Timestamp { get; set; }

        #endregion

        #region Navigation Properties

        public virtual Friend Friend { get; set; }


        public virtual FriendshipDefinitionType FriendshipDefinitionType { get; set; }

        #endregion
    }
}