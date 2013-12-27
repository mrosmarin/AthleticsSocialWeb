namespace AthleticsSocialWeb.Core.Entities
{
    //CHAPTER 7
    public partial class File
    {
        //CHAPTER 10
        public enum Sizes
        {
            T,
            S,
            M,
            L,
            O
        }
        public enum Types
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

        public string Extension { get; set; }
    }
}
