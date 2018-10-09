using BigFootVentures.Business.Objects.Management;
using System.Collections.Generic;
using System.Linq;

namespace BigFootVentures.Service.BusinessService.Validators
{
    public static class AgreementValidator
    {
        #region "Public Methods"

        public static bool IsValid(Agreement agreement, out Dictionary<string, string> validationResult)
        {
            validationResult = new Dictionary<string, string>();

            if (string.IsNullOrWhiteSpace(agreement.Name))
            {
                validationResult.Add("Record.Name", ValidationMessages.REQUIRED);
            }

            if (string.IsNullOrWhiteSpace(agreement.ObjectOfAgreement))
            {
                validationResult.Add("Record.ObjectOfAgreement", ValidationMessages.REQUIRED);
            }

            if (string.IsNullOrWhiteSpace(agreement.Applicability))
            {
                validationResult.Add("Record.Applicability", ValidationMessages.REQUIRED);
            }

            return !validationResult.Any();
        }

        #endregion
    }
}
