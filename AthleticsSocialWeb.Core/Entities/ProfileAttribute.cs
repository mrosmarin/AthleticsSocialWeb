using System;

namespace AthleticsSocialWeb.Core.Entities
{
    public class ProfileAttribute
    {
        #region Primitive Properties

        public int ProfileAttributeId { get; set; }


        public int ProfileId { get; set; }


        public int ProfileAttributeTypeId { get; set; }


        public string Response { get; set; }


        public DateTime CreateDate { get; set; }


        public byte[] TimeStamp { get; set; }

        #endregion

        #region Navigation Properties

        public virtual ProfileAttributeType ProfileAttributeType { get; set; }

        public virtual Profile Profile { get; set; }

        #endregion
    }
}