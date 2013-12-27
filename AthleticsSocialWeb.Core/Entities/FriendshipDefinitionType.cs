using System.Collections.Generic;

namespace AthleticsSocialWeb.Core.Entities
{
    public class FriendshipDefinitionType
    {
        #region Primitive Properties

        public int FriendshipDefinitionTypeId { get; set; }


        public string Name { get; set; }

        #endregion

        #region Navigation Properties

        public virtual ICollection<FriendshipDefinition> FriendshipDefinitions { get; set; }

        #endregion
    }
}