using System.Collections.Generic;


namespace AthleticsSocialWeb.Core.Entities
{
  
    public partial class Friend
    {
        
        public virtual List<FriendshipDefinition> friendshipDefinitions { get; set; }
    }
 }
