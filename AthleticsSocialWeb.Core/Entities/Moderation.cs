using System;

namespace AthleticsSocialWeb.Core.Entities
{
    public class Moderation
    {
        #region Primitive Properties

        public long ModerationId { get; set; }


        public int? AccountId { get; set; }


        public string AccountUsername { get; set; }


        public int SystemObjectId { get; set; }


        public long SystemObjectRecordId { get; set; }


        public byte[] TimeStamp { get; set; }


        public DateTime CreateDate { get; set; }


        public bool? IsApproved { get; set; }


        public bool? IsDenied { get; set; }


        public int? ActionByAccountId { get; set; }


        public string ActionByUsername { get; set; }

        #endregion

        #region Navigation Properties

        public virtual SystemObject SystemObject { get; set; }


        public virtual Account Account { get; set; }

        #endregion
    }
}