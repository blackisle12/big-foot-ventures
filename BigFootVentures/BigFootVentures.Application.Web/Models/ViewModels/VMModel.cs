using BigFootVentures.Business.Objects;
using BigFootVentures.Business.Objects.Logs;
using BigFootVentures.Business.Objects.Management;
using System.Collections.Generic;
using static BigFootVentures.Application.Web.Models.VMEnums;

namespace BigFootVentures.Application.Web.Models.ViewModels
{
    public sealed class VMModel<TModel> where TModel : BusinessBase
    {
        #region "Properties"

        public TModel Record { get; set; }
        public PageMode PageMode { get; set; }
        public string SuccessMessage { get { return $"<strong>Nicely done!</strong> {typeof(TModel).Name} has been saved successfully."; } }
        public string ErrorMessage { get { return "<strong>Oh no!</strong> An error has occured while processing your request. Please review your changes."; } }

        public string Name { get { return typeof(TModel).Name; } }

        public ICollection<FileAttachment> FileAttachments { get; set; }
        public ICollection<AuditTrail> AuditTrails { get; set; }

        #endregion
    }
}