using System;
using System.Collections.Generic;

namespace AthleticsSocialWeb.Core.Entities
{
    public class Group
    {
        public enum GroupType
        {
        }

        #region Primitive Properties

        public int GroupId { get; set; }

        public string Name { get; set; }

        public DateTime CreateDate { get; set; }


        public DateTime UpdateDate { get; set; }


        public int MemberCount { get; set; }


        public string PageName { get; set; }


        public string Description { get; set; }


        public string AccountId { get; set; }


        public byte[] Timestamp { get; set; }


        public long FileId { get; set; }


        public bool IsPublic { get; set; }


        public string Body { get; set; }

        public string ParentGroupId { get; set; }
        

        #endregion

        #region Navigation Properties    

        public virtual ICollection<GroupForum> GroupForums { get; set; }
        public virtual ICollection<GroupMember> GroupMembers { get; set; }
        public virtual ICollection<GroupToGroupType> GroupToGroupTypes { get; set; }
        public virtual ICollection<GroupType> GroupTypes { get; set; }
        public virtual ICollection<Folder> Folders { get; set; }
        public virtual ICollection<BoardForum> Forums { get; set; }
        public virtual ICollection<Account> Members { get; set; }
        public virtual ICollection<Group> RelatedGroups { get; set; }
        public virtual Account Account { get; set; }

        #endregion
    }
}