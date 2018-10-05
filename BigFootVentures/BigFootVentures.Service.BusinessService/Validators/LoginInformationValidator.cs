using BigFootVentures.Business.Objects.Management;
using System.Collections.Generic;
using System.Linq;

namespace BigFootVentures.Service.BusinessService.Validators
{
    public static class LoginInformationValidator
    {
        #region "Public Methods"

        public static bool IsValid(LoginInformation loginInformation, out Dictionary<string, string> validationResult)
        {
            validationResult = new Dictionary<string, string>();

            return !validationResult.Any();
        }

        #endregion
    }
}
