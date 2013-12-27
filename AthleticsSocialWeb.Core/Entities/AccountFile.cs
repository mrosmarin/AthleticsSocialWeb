namespace AthleticsSocialWeb.Core.Entities
{
    public class AccountFile
    {
        #region Primitive Properties
        public string AccountFileId { get; set; }

        public string AccountId { get; set; }

        public long FileId { get; set; }

        public byte[] Timestamp { get; set; }

        #endregion

        #region Navigation Properties

        public virtual File File { get; set; }

        public virtual Account Account { get; set; }

        #endregion
    }
}