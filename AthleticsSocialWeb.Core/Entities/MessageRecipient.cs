
namespace AthleticsSocialWeb.Core.Entities
{

    public partial class MessageRecipient
    {
        #region Primitive Properties
    
        
        public long MessageRecipientId{ get; set; }
    
        
        public long MessageId{ get; set; }
    
        
        public int MessageRecipientTypeId{ get; set; }
    
        
        public string AccountId{ get; set; }
    
        
        public byte[] Timestamp{ get; set; }
    
        
        public int MessageFolderId{ get; set; }
    
        
        public int MessageStatusTypeId{ get; set; }

        #endregion
        #region Navigation Properties


        public virtual MessageFolder MessageFolder { get; set; }


        public virtual MessageRecipientType MessageRecipientType { get; set; }


        public virtual Message Message { get; set; }


        public virtual MessageStatusType MessageStatusType { get; set; }

        #endregion
       
    }
}
