using System;

namespace AthleticsSocialWeb.Core.Entities
{
    public enum AlertType
    {
        AccountCreated = 1,
        ProfileCreated = 2,
        AccountModified = 3,
        ProfileModified = 4,
        NewAvatar = 5,
        AddedFriend = 6,
        AddedPicture = 7,
        //CHAPTER 5
        FriendAdded = 8,
        FriendRequest = 9,
        StatusUpdate = 10,
        //CHAPTER 8
        NewBlogPost = 11,
        UpdatedBlogPost = 12,
        //CHAPTER 9
        NewBoardPost = 13,
        NewBoardThread = 14,
        //CHAPTER 10
        MembershipRequest = 15,
        MembershipApproved = 16
    }

    public class Alert
    {
        #region Primitive Properties

        public long AlertId { get; set; }


        public string AccountId { get; set; }


        public DateTime CreateDate { get; set; }


        public byte[] Timestamp { get; set; }


  //      public int AlertTypeId { get; set; }


        public bool IsHidden { get; set; }


        public string Message { get; set; }

        public AlertType AlertType { get; set; }

        #endregion

        #region Navigation Properties

        public virtual Account Account { get; set; }

        #endregion
    }
}