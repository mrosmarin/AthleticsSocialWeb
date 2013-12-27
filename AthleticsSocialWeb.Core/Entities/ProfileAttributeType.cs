using System.Collections.Generic;

namespace AthleticsSocialWeb.Core.Entities
{
    public class ProfileAttributeType
    {
        #region Primitive Properties

        public int ProfileAttributeTypeId { get; set; }


        public string AttributeType { get; set; }


        public int SortOrder { get; set; }


        public int PrivacyFlagTypeId { get; set; }

        #endregion

        #region Navigation Properties

        public virtual ICollection<ProfileAttribute> ProfileAttributes { get; set; }

        #endregion
    }
}