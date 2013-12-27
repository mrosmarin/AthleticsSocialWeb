

using System.Collections.Generic;

namespace AthleticsSocialWeb.Core.Entities
{
    
    public partial class FolderType
    {
        #region Primitive Properties
    
        
        public int FolderTypeId{ get; set; }
    
        
        public string Name{ get; set; }

        #endregion
        #region Navigation Properties
    
        
        public virtual ICollection<Folder> Folders{ get; set; }

        #endregion
       
    }
}
