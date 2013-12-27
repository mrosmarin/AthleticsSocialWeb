

using System.Collections.Generic;

namespace AthleticsSocialWeb.Core.Entities
{
    public class AlertType
    {
     

        #region Primitive Properties

        public int AlertTypeId{ get; set; }
    
        public string Name{ get; set; }

        #endregion
        #region Navigation Properties
   
        public virtual ICollection<Alert> Alerts{ get; set; }

        #endregion

    }
}
