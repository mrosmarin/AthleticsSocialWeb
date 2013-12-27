
using System.Collections.Generic;

namespace AthleticsSocialWeb.Core.Entities
{

    public partial class BoardForum
    {
        #region Primitive Properties
    
        
       
        public int ForumId{ get; set; }
    
        
       
        public string Name{ get; set; }
    
        
     
        public string Subject{ get; set; }


        public long ThreadCount{ get; set; }
      
    
        
        
        public long PostCount{ get; set; }
    
        
        
        public System.DateTime CreateDate{ get; set; }
    
        
        
        public System.DateTime UpdateDate{ get; set; }
    
        
        
        public System.DateTime LastPostDate{ get; set; }
    
        
        
        public int LastPostByAccountId{ get; set; }
    
        
        
        public string LastPostByUsername{ get; set; }
    
        
        
        public byte[] Timestamp{ get; set; }


        public int BoardCategoryId { get; set; }
      
        public string PageName{ get; set; }

        #endregion
        #region Navigation Properties
    
        
     
        public virtual BoardCategory BoardCategory{ get; set; }
    
        

        public virtual ICollection<GroupForum> GroupForums{ get; set; }
    
        

        public virtual ICollection<BoardPost> BoardPosts{ get; set; }

        #endregion

    }
}
