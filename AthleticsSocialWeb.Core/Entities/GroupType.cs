
using System.Collections.Generic;

namespace AthleticsSocialWeb.Core.Entities
{

    public class GroupType
    {
        #region Primitive Properties
    
        
        public long GroupTypeId{ get; set; }
    
        
        public string Name{ get; set; }
    
        
        public byte[] Timestamp{ get; set; }

        #endregion
        #region Navigation Properties
    
        
        public virtual ICollection<GroupToGroupType> GroupToGroupTypes{ get; set; }

        #endregion
     
    }
}
