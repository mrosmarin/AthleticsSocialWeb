using System;

namespace AthleticsSocialWeb.Core.Entities
{
    public class SystemObjectTag
    {
        #region Primitive Properties

        public long SystemObjectTagId { get; set; }


        public byte[] Timestamp { get; set; }


        public long TagId { get; set; }


        public long SystemObjectRecordId { get; set; }


        public int SystemObjectId { get; set; }


        public DateTime CreateDate { get; set; }


        public string AccountId { get; set; }


        public string CreatedByUsername { get; set; }

        #endregion

        #region Navigation Properties

        public virtual SystemObject SystemObject { get; set; }


        public virtual Tag Tag { get; set; }


        public virtual Account Account { get; set; }

        #endregion
    }
}