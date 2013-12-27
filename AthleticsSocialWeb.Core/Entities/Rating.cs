using System;

namespace AthleticsSocialWeb.Core.Entities
{
    public class Rating
    {
        #region Primitive Properties

        public long RatingId { get; set; }


        public int Score { get; set; }


        public string AccountId { get; set; }


        public byte[] Timestamp { get; set; }


        public DateTime CreateDate { get; set; }


        public int SystemObjectId { get; set; }


        public long SystemObjectRecordId { get; set; }


        public int SystemObjectRatingOptionId { get; set; }

        #endregion

        #region Navigation Properties

        public virtual SystemObjectRatingOption SystemObjectRatingOption { get; set; }


        public virtual SystemObject SystemObject { get; set; }


        public virtual Account Account { get; set; }

        #endregion
    }
}