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

            if (trademarkOwner.Trademark == null || string.IsNullOrWhiteSpace(trademarkOwner.Trademark.Name))
            {
                validationResult.Add("Record.Trademark.Name", ValidationMessages.REQUIRED);
            }

            if (trademarkOwner.Company == null || string.IsNullOrWhiteSpace(trademarkOwner.Company.DisplayName))
            {
                validationResult.Add("Record.Company.DisplayName", ValidationMessages.REQUIRED);
            }

            return !validationResult.Any();
        }

        #endregion
    }
}
