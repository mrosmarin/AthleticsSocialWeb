using System;

namespace AthleticsSocialWeb.Core.Entities
{
    public class StatusUpdate
    {
        #region Primitive Properties

        public long StatusUpdateId { get; set; }


        public DateTime CreateDate { get; set; }


        public string Status { get; set; }


        public int? AccountId { get; set; }


        public byte[] Timestamp { get; set; }

        #endregion

        #region Navigation Properties

        public virtual Account Account { get; set; }

        #endregion
    }
}