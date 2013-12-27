

namespace AthleticsSocialWeb.Core.Entities
{
    //CHAPTER 11
public class SystemObjectTagWithObject
    {
        public SystemObjectTag SystemObjectTag { get; set; }
        public Account Account { get; set; }
        public Profile Profile { get; set; }
        public Blog Blog { get; set; }
        public BoardPost BoardPost { get; set; }
        public File File { get; set; }
        public Folder Folder { get; set; }
        public Group Group { get; set; }
    }
}
