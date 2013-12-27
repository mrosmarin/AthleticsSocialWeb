using System;

namespace AthleticsSocialWeb.Core.Entities
{
    public class ContentFilter
    {
        #region Primitive Properties

        public int ContentFilterId { get; set; }


        public string StringToFilter { get; set; }


        public string ReplaceWith { get; set; }


        public string AccountId { get; set; }


        public DateTime CreateDate { get; set; }


        public byte[] TimeStamp { get; set; }

        #endregion

        #region Navigation Properties

        public virtual Account Account { get; set; }

        #endregion
    }
}