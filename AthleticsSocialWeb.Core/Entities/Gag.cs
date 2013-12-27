using System;

namespace AthleticsSocialWeb.Core.Entities
{
    public class Gag
    {
        #region Primitive Properties

        public long GagId { get; set; }


        public string AccountId { get; set; }



        public DateTime CreateDate { get; set; }


        public byte[] TimeStamp { get; set; }


        public string Reason { get; set; }


        public DateTime? GagUntilDate { get; set; }


        public string GaggedByAccountId { get; set; }

        #endregion

        #region Navigation Properties

        public virtual Account Account { get; set; }


        public virtual Account GaggedByAccount { get; set; }

        #endregion
    }
}