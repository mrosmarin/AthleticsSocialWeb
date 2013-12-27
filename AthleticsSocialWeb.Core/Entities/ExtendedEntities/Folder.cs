namespace AthleticsSocialWeb.Core.Entities
{
    //CHAPTER 7
    public partial class Folder
    {
        public enum Types
        {
            Photo = 1,
            Video = 2,
            Audio = 3,
            File = 4
        }

        public string FullPathToCoverImage { get; set; }
        public string Username { get; set; }
    }
}
