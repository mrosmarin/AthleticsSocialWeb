using System.Collections.Generic;

namespace AthleticsSocialWeb.Core.Entities
{
    public class Permission
    {
        #region Primitive Properties

        public int PermissionId { get; set; }


        public string Name { get; set; }


        public byte[] Timestamp { get; set; }

        #endregion

        #region Navigation Properties

        public virtual ICollection<AccountPermission> AccountPermissions { get; set; }

        #endregion
    }
}