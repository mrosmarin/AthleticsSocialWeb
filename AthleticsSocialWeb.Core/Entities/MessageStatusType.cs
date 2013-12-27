

using System.Collections.Generic;

namespace AthleticsSocialWeb.Core.Entities
{

    public partial class MessageStatusType
    {
        public enum MessageStatusTypes
        {
            Unread = 1,
            Read = 2,
            Replied = 3,
            Forwarded = 4,
            Spam = 5,
            Filtered = 6
        }


        #region Primitive Properties
    
        
        public int MessageStatusTypeId{ get; set; }
    
        
        public string Name{ get; set; }
    
        
        public byte[] Timestamp{ get; set; }

        #endregion
        #region Navigation Properties
    
        
        public virtual ICollection<MessageRecipient> MessageRecipients{ get; set; }

        #endregion
    }
}
