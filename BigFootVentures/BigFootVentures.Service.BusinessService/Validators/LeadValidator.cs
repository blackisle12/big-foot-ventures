using BigFootVentures.Business.Objects.Management;
using System.Collections.Generic;
using System.Linq;

namespace BigFootVentures.Service.BusinessService.Validators
{
    public static class LeadValidator
    {
        #region "Public Methods"

        public static bool IsValid(Lead lead, out Dictionary<string, string> validationResult)
        {
            validationResult = new Dictionary<string, string>();

            if (string.IsNullOrWhiteSpace(lead.Status))
            {
                validationResult.Add("Record.Status", ValidationMessages.REQUIRED);
            }

            if (string.IsNullOrWhiteSpace(lead.LastName))
            {
                validationResult.Add("Record.LastName", ValidationMessages.REQUIRED);
            }

            if (string.IsNullOrWhiteSpace(lead.Company))
            {
                validationResult.Add("Record.Company", ValidationMessages.REQUIRED);
            }

            return !validationResult.Any();
        }

        #endregion
    }
}
