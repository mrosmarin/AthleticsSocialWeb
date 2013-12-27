

using System.Collections.Generic;

namespace AthleticsSocialWeb.Core.Entities
{

    public partial class MessageRecipientType
    {
        public enum MessageRecipientTypes
        {
            TO = 1,
            CC = 2,
            BCC = 3
        }

        #region Primitive Properties
    
        
        public int MessageRecipientTypeId{ get; set; }
    
        
        public string Name{ get; set; }

        #endregion
        #region Navigation Properties
    
        
        public virtual ICollection<MessageRecipient> MessageRecipients{ get; set; }

        #endregion
     
    }
}
