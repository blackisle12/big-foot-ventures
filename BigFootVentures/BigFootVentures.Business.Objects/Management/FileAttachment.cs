using System;

namespace BigFootVentures.Business.Objects.Management
{
    public sealed class FileAttachment : BusinessBase
    {
        #region "Properties"

        public int ObjectID { get; set; }
        public string FileName { get; set; }
        public byte[] File { get; set; }

        public DateTime CreateDate { get; set; }

        #endregion
    }
}
