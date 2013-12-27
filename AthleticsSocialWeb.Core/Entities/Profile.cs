using System;
using System.Collections.Generic;

namespace AthleticsSocialWeb.Core.Entities
{
    public class Profile
    {
        #region Primitive Properties

        public int ProfileId { get; set; }

        public string AccountId { get; set; }

        public string ProfileName { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        public int YearOfFirstTank { get; set; }

        public int NumberOfTanksOwned { get; set; }

        public int NumberOfFishOwned { get; set; }

        public int LevelOfExperienceTypeId { get; set; }

        public string Immsn { get; set; }

        public string Imaol { get; set; }


        public string Imgim { get; set; }

        public string Imyim { get; set; }

        public string Imicq { get; set; }

        public string ImSkype { get; set; }

        public string Signature { get; set; }

        public byte[] Timestamp { get; set; }

        public byte[] Avatar { get; set; }

        public string AvatarMimeType { get; set; }

        public int UseGravatar { get; set; }

        #endregion

        #region Navigation Properties

      //  public virtual LevelOfExperienceType LevelOfExperienceType { get; set; }

       // public virtual ICollection<PrivacyFlag> PrivacyFlags { get; set; }

       // public virtual ICollection<ProfileAttribute> ProfileAttributes { get; set; }

        public virtual Account Account { get; set; }

        #endregion
    }
}