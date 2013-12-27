

using System.Collections.Generic;

namespace AthleticsSocialWeb.Core.Entities
{

    public partial class SystemObjectRatingOption
    {
        #region Primitive Properties
    
        
       
        public int SystemObjectRatingOptionId{ get; set; }
    
        
       
        public string Name{ get; set; }
    
        
        
        public string Description{ get; set; }
    
        
       
        public byte[] Timestamp{ get; set; }
    
        
       
        public int SystemObjectId{ get; set; }

        #endregion
        #region Navigation Properties
    
        
      
        public virtual ICollection<Rating> Ratings{ get; set; }



        public virtual SystemObject SystemObject { get; set; }

        #endregion
      
    }
}
