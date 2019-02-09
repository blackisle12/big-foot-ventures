using BigFootVentures.Business.Objects.Management;
using System.Collections.Generic;
using System.Linq;

namespace BigFootVentures.Service.BusinessService.Validators
{
    public static class OppositionValidator
    {
        #region "Public Methods"

        public static bool IsValid(Opposition opposition, out Dictionary<string, string> validationResult)
        {
            validationResult = new Dictionary<string, string>();

            if (string.IsNullOrWhiteSpace(opposition.TrademarkRoleA))
            {
                validationResult.Add("Record.TrademarkRoleA", ValidationMessages.REQUIRED);
            }

            if (string.IsNullOrWhiteSpace(opposition.TrademarkRoleD))
            {
                validationResult.Add("Record.TrademarkRoleD", ValidationMessages.REQUIRED);
            }

            return !validationResult.Any();
        }

        #endregion
    }
}
