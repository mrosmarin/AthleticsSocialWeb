using System;

namespace AthleticsSocialWeb.Core.Entities
{
    public class Comment
    {
        #region Primitive Properties

        public long CommentId { get; set; }


        public byte[] Timestamp { get; set; }


        public string Body { get; set; }


        public DateTime CreateDate { get; set; }


        public string AccountId { get; set; }


        public string CommentByUsername { get; set; }


        public int SystemObjectId { get; set; }


        public long SystemObjectRecordId { get; set; }

        #endregion

        #region Navigation Properties

        public virtual SystemObject SystemObject { get; set; }


        public virtual Account Account { get; set; }

        #endregion
    }
}