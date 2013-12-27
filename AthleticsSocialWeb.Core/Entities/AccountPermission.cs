namespace AthleticsSocialWeb.Core.Entities
{
    public class AccountPermission
    {
        #region Primitive Properties

        public int AccountPermissionId { get; set; }


        public string AccountId { get; set; }


        public int PermissionId { get; set; }


        public byte[] Timestamp { get; set; }

        #endregion

        #region Navigation Properties

        public virtual Permission Permission { get; set; }


        public virtual Account Account { get; set; }

        #endregion
    }
}