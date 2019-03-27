using BigFootVentures.Business.Objects.Management;
using System;

namespace BigFootVentures.Business.Objects.Logs
{
    public sealed class AuditTrail : BusinessBase
    {
        #region "Properties"

        public string ObjectName { get; set; }
        public int ObjectID { get; set; }
        public string Message { get; set; }
        public UserAccount UserAccount { get; set; }

        public DateTime CreateDate { get; set; }

        #endregion
    }
}
