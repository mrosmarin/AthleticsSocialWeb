using System;
using System.Collections.Generic;

namespace AthleticsSocialWeb.Core.Entities
{
    public class Tag
    {
        public enum CloudSortOrder
        {
            Ascending,
            Descending,
            Random
        }

        #region Primitive Properties

        public decimal InitialValue { get; set; }
        public decimal MinimumOffset { get; set; }
        public decimal Ranged { get; set; }
        public decimal PreCalculatedValue { get; set; }
        public decimal FinalCalculatedValue { get; set; }
        public int FontSize { get; set; }

        public long TagId { get; set; }


        public string Name { get; set; }


        public int Count { get; set; }


        public byte[] Timestamp { get; set; }


        public DateTime CreateDate { get; set; }

        #endregion

        #region Navigation Properties

        public virtual ICollection<SystemObjectTag> SystemObjectTags { get; set; }

        #endregion
    }
}