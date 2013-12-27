

using System.Collections.Generic;

namespace AthleticsSocialWeb.Core.Entities
{
    public partial class FileType
    {
        #region Primitive Properties
    
        
        public int FileTypeId{ get; set; }
    
        
        public string Name{ get; set; }

        #endregion
        #region Navigation Properties
    
        
        public virtual ICollection<File> Files{ get; set; }

        #endregion
        
    }
}
