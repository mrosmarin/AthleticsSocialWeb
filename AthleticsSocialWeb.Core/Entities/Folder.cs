using System;
using System.Collections.Generic;

namespace AthleticsSocialWeb.Core.Entities
{
    public class Folder
    {
        public enum Types
        {
            Photo = 1,
            Video = 2,
            Audio = 3,
            File = 4
        }

        #region Primitive Properties

        public long FolderId { get; set; }


        public string Name { get; set; }


        public bool IsPublicResource { get; set; }


        public DateTime CreateDate { get; set; }


        //public int AccountId { get; set; }


        public string Description { get; set; }


        public string Location { get; set; }


        public byte[] Timestamp { get; set; }


        public int? FolderTypeId { get; set; }

        #endregion

        #region Navigation Properties

      //  public virtual ICollection<AccountFolder> AccountFolders { get; set; }


        public virtual ICollection<File> Files { get; set; }


       // public virtual ICollection<FolderFile> FolderFiles { get; set; }


        public virtual FolderType FolderType { get; set; }


       // public virtual Account Account { get; set; }

        #endregion
    }
}