using System;

namespace AthleticsSocialWeb.Core.Entities
{
    public class FolderFile
    {
        #region Primitive Properties
        public long FolderFileId { get; set; }

        public long FolderId { get; set; }


        public long FileId { get; set; }


        public string AccountId { get; set; }


        public DateTime? CreateDate { get; set; }


        public byte[] Timestamp { get; set; }

        #endregion

        #region Navigation Properties

        public virtual File File { get; set; }


        public virtual Folder Folder { get; set; }


        public virtual Account Account { get; set; }

        #endregion
    }
}