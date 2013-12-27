namespace AthleticsSocialWeb.Core.Entities
{
    public class MessageWithRecipient
    {
        public Account Sender { get; set; }
        public Message Message { get; set; }
        public MessageRecipient MessageRecipient{ get; set; }
    }
}
