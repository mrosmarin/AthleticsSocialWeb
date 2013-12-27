namespace AthleticsSocialWeb.Core.Entities
{
    public class AccountFolder
    {
        #region Primitive Properties

        public string AccountId { get; set; }


        public long FolderId { get; set; }


        public byte[] Timestamp { get; set; }

        #endregion

        #region Navigation Properties

        public virtual Folder Folder { get; set; }


        public virtual Account Account { get; set; }

        #endregion
    }
}