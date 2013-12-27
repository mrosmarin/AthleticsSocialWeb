namespace AthleticsSocialWeb.Core.Entities
{
    public partial class BoardPost
    {
        public enum ScoreInput
        {
            ReplyPost = 1,
            VoteUseful = 2,
            VoteNotUseful = 3,
            MarkedAsAnswer = 4
        }
    }
}
