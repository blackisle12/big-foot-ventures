using BigFootVentures.Business.Objects.Management;
using System.Collections.Generic;
using System.Linq;

namespace BigFootVentures.Service.BusinessService.Validators
{
    public static class UserAccountValidator
    {
        #region "Public Methods"

        public static bool IsValid(UserAccount userAccount, out Dictionary<string, string> validationResult)
        {
            validationResult = new Dictionary<string, string>();

            if (string.IsNullOrWhiteSpace(userAccount.FirstName))
            {
                validationResult.Add("Record.FirstName", ValidationMessages.REQUIRED);
            }

            if (string.IsNullOrWhiteSpace(userAccount.LastName))
            {
                validationResult.Add("Record.LastName", ValidationMessages.REQUIRED);
            }

            if (string.IsNullOrWhiteSpace(userAccount.EmailAddress))
            {
                validationResult.Add("Record.EmailAddress", ValidationMessages.REQUIRED);
            }

            return !validationResult.Any();
        }

        #endregion
    }
}
