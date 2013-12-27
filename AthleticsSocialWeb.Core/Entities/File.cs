using System;
using System.Collections.Generic;

namespace AthleticsSocialWeb.Core.Entities
{
    public class File
    {
        public enum Sizes
        {
            T,
            S,
            M,
            L,
            O
        }

        public enum FileTypes
        {
            JPG = 1,
            GIF = 2,
            WAV = 3,
            MP3 = 4,
            WMV = 5,
            FLV = 6,
            JPEG = 7,
            SWF = 8
        }

        #region Primitive Properties

        public string Extension { get; set; }

        public long FileId { get; set; }


        public Guid FileSystemName { get; set; }


        public int FileSystemFolderId { get; set; }


        public string FileName { get; set; }


       // public int FileTypeId { get; set; }


        public DateTime CreateDate { get; set; }


      //  public string AccountId { get; set; }


        public bool IsPublicResource { get; set; }


        public long FolderId { get; set; }


        public string Description { get; set; }


        public byte[] Timestamp { get; set; }


        public long Size { get; set; }

        #endregion

        #region Navigation Properties

        public virtual ICollection<AccountFile> AccountFiles { get; set; }


        public virtual FileSystemFolder FileSystemFolder { get; set; }


        public virtual FileTypes FileType { get; set; }


        public virtual Folder Folder { get; set; }


   //     public virtual ICollection<FolderFile> FolderFiles { get; set; }


      //  public virtual Account Account { get; set; }

        #endregion
    }
}