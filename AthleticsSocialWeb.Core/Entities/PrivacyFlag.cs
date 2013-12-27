using System;

namespace AthleticsSocialWeb.Core.Entities
{
    public class PrivacyFlag
    {
        public enum PrivacyFlagTypes
        {
            IM = 1,
            TankInfo = 2,
            AccountInfo = 3,
            Interests = 4,
            AboutYou = 5,
            Occupation = 6,
            YourSetup = 7,
            AnythingElse = 8
        }

        #region Primitive Properties

        public int PrivacyFlagId { get; set; }


        public int PrivacyFlagTypeId { get; set; }


        public int ProfileId { get; set; }


        public int VisibilityLevelId { get; set; }


        public byte[] TimeStamp { get; set; }


        public DateTime CreateDate { get; set; }

        #endregion

        #region Navigation Properties

        public virtual PrivacyFlagType PrivacyFlagType { get; set; }


        public virtual Profile Profile { get; set; }


        public virtual VisibilityLevel VisibilityLevel { get; set; }

        #endregion
    }
}