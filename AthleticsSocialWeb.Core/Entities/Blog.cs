

namespace AthleticsSocialWeb.Core.Entities
{

    public class Blog
    {
        #region Primitive Properties
   
        public long BlogId{ get; set; }
    
        

        public string AccountId{ get; set; }
    
        
 
        public string Title{ get; set; }
    
        

        public string Subject{ get; set; }
    
        

        public string Post{ get; set; }
    
        
   
        public System.DateTime CreateDate{ get; set; }
    
        

        public System.DateTime UpdateDate{ get; set; }
    
        
        public bool IsPublished{ get; set; }
    
        public string PageName{ get; set; }

        #endregion
        #region Navigation Properties
    
        public virtual Account Account{ get; set; }

        #endregion
    }
}
