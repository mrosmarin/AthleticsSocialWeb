using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AthleticsSocialWeb.Core.Entities
{
    public partial class AlertType
    {
        public enum AlertTypes
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
    }
}
