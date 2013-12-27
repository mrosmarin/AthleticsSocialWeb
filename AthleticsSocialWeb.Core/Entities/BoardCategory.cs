

using System.Collections.Generic;

namespace AthleticsSocialWeb.Core.Entities
{

    public partial class BoardCategory
    {
        #region Primitive Properties



        public int BoardCategoryId { get; set; }
    
        

        public string Name{ get; set; }
    
        
  
        public string Subject{ get; set; }
    
        
   
        public int SortOrder{ get; set; }
    
        

        public byte[] Timestamp{ get; set; }
    
        
      
        public System.DateTime CreateDate{ get; set; }
    
        
      
        public System.DateTime UpdateDate{ get; set; }
    
        

        public int ThreadCount{ get; set; }
    
        
       
        public int PostCount{ get; set; }
    
        
        
        public System.DateTime LastPostDate{ get; set; }
    
        
    
        public int LastPostByAccountId{ get; set; }
    
        
   
        public string LastPostByUsername{ get; set; }
    
        
        public string PageName{ get; set; }

        #endregion
        #region Navigation Properties
        public virtual ICollection<BoardForum> BoardForums{ get; set; }

        #endregion

    }
}
