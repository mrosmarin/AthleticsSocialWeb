using System;
using System.Collections.Generic;

namespace AthleticsSocialWeb.Core.Entities
{
    public class Message
    {
        public enum MessageTypes
        {
            FriendRequest = 1,
            FriendConfirm = 2,
            Message = 3
        }

        #region Primitive Properties

        public long MessageId { get; set; }


        public string SentByAccountId { get; set; }


        public string Subject { get; set; }


        public string Body { get; set; }


        public DateTime CreateDate { get; set; }


        public byte[] Timestamp { get; set; }


        public int MessageTypeId { get; set; }

        #endregion

        #region Navigation Properties

        public virtual ICollection<MessageRecipient> MessageRecipients { get; set; }


        public virtual MessageTypes MessageType { get; set; }


        public virtual Account SentByAccount { get; set; }

        #endregion
    }
}