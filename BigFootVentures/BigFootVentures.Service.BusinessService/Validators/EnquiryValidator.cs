using BigFootVentures.Business.Objects.Enumerators;
using BigFootVentures.Business.Objects.Extensions;
using BigFootVentures.Business.Objects.Management;
using System.Collections.Generic;
using System.Linq;

namespace BigFootVentures.Service.BusinessService.Validators
{
    public static class EnquiryValidator
    {
        #region "Public Methods"

        public static bool IsValid(Enquiry enquiry, out Dictionary<string, string> validationResult)
        {
            validationResult = new Dictionary<string, string>();

            if (enquiry.RecordType == ManagementEnums.Enquiry.RecordType.DomainEnquiry.ToDescription())
            {
                if (string.IsNullOrWhiteSpace(enquiry.Status))
                {
                    validationResult.Add("Record.Status", ValidationMessages.REQUIRED);
                }
            }

            return !validationResult.Any();
        }

        #endregion
    }
}
