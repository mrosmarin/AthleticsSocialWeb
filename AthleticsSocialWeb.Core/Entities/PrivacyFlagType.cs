using System.Collections.Generic;

namespace AthleticsSocialWeb.Core.Entities
{
    public class PrivacyFlagType
    {
        #region Primitive Properties

        public int PrivacyFlagTypeId { get; set; }


        public string FieldName { get; set; }


        public byte[] TimeStamp { get; set; }


        public int SortOrder { get; set; }

        #endregion

        #region Navigation Properties

        public virtual ICollection<PrivacyFlag> PrivacyFlags { get; set; }

        #endregion
    }
}