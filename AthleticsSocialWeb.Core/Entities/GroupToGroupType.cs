

namespace AthleticsSocialWeb.Core.Entities
{
  

    public class GroupToGroupType
    {
        #region Primitive Properties


        public long GroupToGroupTypeId { get; set; }
    
        
        public int GroupId{ get; set; }
    
        
        public long GroupTypeId{ get; set; }
    
        
        public byte[] Timestamp{ get; set; }

        #endregion
        #region Navigation Properties


        public virtual Group Group { get; set; }


        public virtual GroupType GroupType { get; set; }

        #endregion
      
    }
}
