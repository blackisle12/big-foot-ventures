using BigFootVentures.Business.Objects.Management;
using System.Collections.Generic;
using System.Linq;

namespace BigFootVentures.Service.BusinessService.Validators
{
    public static class UserAccountValidator
    {
        #region "Public Methods"

        public static bool IsValid(UserAccount userAccount, IManagementService<UserAccount> service, out Dictionary<string, string> validationResult)
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
            else
            {
                var existingAccount = service.GetByEmailAddress(userAccount.EmailAddress).FirstOrDefault();

                if ((existingAccount != null && userAccount.ID == 0) || (existingAccount != null && userAccount.ID != existingAccount.ID))
                {
                    validationResult.Add("Record.EmailAddress", ValidationMessages.EMAILADDRESS_EXISTS);
                }
            }

            if (string.IsNullOrWhiteSpace(userAccount.Roles))
            {
                validationResult.Add("Record.Roles", ValidationMessages.ROLES_REQUIRED);
            }

            return !validationResult.Any();
        }

        #endregion
    }
}
