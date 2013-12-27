using System.Collections.Generic;

namespace AthleticsSocialWeb.Core.Entities
{
    public class LevelOfExperienceType
    {
        #region Primitive Properties

        public int LevelOfExperienceTypeId { get; set; }


        public string LevelOfExperience { get; set; }


        public byte[] Timestamp { get; set; }


        public byte SortOrder { get; set; }

        #endregion

        #region Navigation Properties

        public virtual ICollection<Profile> Profiles { get; set; }

        #endregion
    }
}