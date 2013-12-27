

using System.Collections.Generic;

namespace AthleticsSocialWeb.Core.Entities
{
    public partial class MessageType
    {
        public enum MessageTypes
        {
            FriendRequest = 1,
            FriendConfirm = 2,
            Message = 3
        }


        #region Primitive Properties
    
        
        public int MessageTypeId{ get; set; }
    
        
        public string Name{ get; set; }
    
        
        public byte[] Timestamp{ get; set; }

        #endregion
        #region Navigation Properties
    
        
        public virtual ICollection<Message> Messages{ get; set; }

        #endregion
     
    }
}
