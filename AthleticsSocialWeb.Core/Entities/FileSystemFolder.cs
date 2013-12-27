using System.Collections.Generic;

namespace AthleticsSocialWeb.Core.Entities
{
    public class FileSystemFolder
    {
        public enum Paths
        {
            Photos = 1,
            Videos = 2,
            Audios = 3
        }

        #region Primitive Properties

        public int FileSystemFolderId { get; set; }


        public string Path { get; set; }


        public byte[] Timestamp { get; set; }

        #endregion

        #region Navigation Properties

        public virtual ICollection<File> Files { get; set; }

        #endregion
    }
}