using System;
using System.Collections.Generic;

namespace AthleticsSocialWeb.Core.Entities
{
    public class Term
    {
        #region Primitive Properties

        public int TermId { get; set; }

        public string Terms { get; set; }


        public DateTime CreateDate { get; set; }


        public byte[] Timestamp { get; set; }

        #endregion

        #region Navigation Properties

        public virtual ICollection<Account> Accounts { get; set; }

        #endregion
    }
}