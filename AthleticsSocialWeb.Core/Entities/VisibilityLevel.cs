using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AthleticsSocialWeb.Core.Entities
{
    public partial class VisibilityLevel
    {
        #region Primitive Properties
        public enum VisibilityLevels
        {
            Private = 1,
            Friends = 2,
            Public = 3
        }

        public VisibilityLevels VisibilityLevelId { get; set; }

        public string Name { get; set; }

        #endregion
        #region Navigation Properties

        public ICollection<PrivacyFlag> PrivacyFlags { get; set; }

        #endregion
    }
}
