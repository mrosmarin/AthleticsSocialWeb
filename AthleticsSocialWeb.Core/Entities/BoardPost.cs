using System;
using System.Collections.Generic;

namespace AthleticsSocialWeb.Core.Entities
{
    public class BoardPost
    {
        public enum ScoreInput
        {
            ReplyPost = 1,
            VoteUseful = 2,
            VoteNotUseful = 3,
            MarkedAsAnswer = 4
        }

        #region Primitive Properties

        public long PostId { get; set; }


        public bool IsThread { get; set; }


        public string Name { get; set; }


        public string Post { get; set; }


        public DateTime CreateDate { get; set; }


        public DateTime UpdateDate { get; set; }


        public string AccountId { get; set; }


        public string Username { get; set; }


        public int ReplyCount { get; set; }


        public string ReplyByUsername { get; set; }


        public int ViewCount { get; set; }


        public int BoardForumId { get; set; }


        public string PageName { get; set; }


        public long? ThreadId { get; set; }


        public int? ReplyByAccountId { get; set; }


        public int VoteCount { get; set; }


        public bool IsAnswer { get; set; }

        #endregion

        #region Navigation Properties

        public virtual Account Account { get; set; }

        public virtual BoardForum BoardForum { get; set; }

        public virtual BoardPost Thead { get; set; }

        public virtual ICollection<BoardPost> TheadPosts { get; set; }

        #endregion
    }
}