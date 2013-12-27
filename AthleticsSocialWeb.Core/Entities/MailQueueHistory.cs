
namespace AthleticsSocialWeb.Core.Entities
{
 
    public partial class MailQueueHistory
    {
        #region Primitive Properties
    
        
        public long MailQueueId{ get; set; }
    
        
        public string SerializedMailMessage{ get; set; }
    
        
        public System.DateTime CreateDate{ get; set; }
    
        
        public System.DateTime SendDate{ get; set; }

        #endregion
       
    }
}
