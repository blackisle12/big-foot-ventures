using BigFootVentures.Business.Objects.Management;
using System.Collections.Generic;
using System.Linq;

namespace BigFootVentures.Service.BusinessService.Validators
{
    public static class TrademarkOwnerValidator
    {
        #region "Public Methods"

        public static bool IsValid(TrademarkOwner trademarkOwner, out Dictionary<string, string> validationResult)
        {
            validationResult = new Dictionary<string, string>();

            if (trademarkOwner.Trademark == null)
            {
                validationResult.Add("Record.Trademark", ValidationMessages.REQUIRED);
            }

            if (trademarkOwner.Company == null)
            {
                validationResult.Add("Record.Company", ValidationMessages.REQUIRED);
            }

            return !validationResult.Any();
        }

        #endregion
    }
}
