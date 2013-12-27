

using System.Collections.Generic;

namespace AthleticsSocialWeb.Core.Entities
{

    public partial class MessageFolder
    {
        public enum MessageFolders
        {
            Inbox = 1,
            Sent = 2,
            Trash = 3,
            Spam = 4
        }

        #region Primitive Properties
    
        
        public int MessageFolderId{ get; set; }
    
        
        public string FolderName{ get; set; }
    
        
        public bool IsSystem{ get; set; }
    
        
        public byte[] Timestamp{ get; set; }
    
        
        public string AccountId{ get; set; }

        #endregion
        #region Navigation Properties
    
        
        public virtual ICollection<MessageRecipient> MessageRecipients{ get; set; }

        #endregion
      
    }
}
