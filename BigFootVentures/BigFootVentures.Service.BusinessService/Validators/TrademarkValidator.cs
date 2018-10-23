using BigFootVentures.Business.Objects.Management;
using System.Collections.Generic;
using System.Linq;

namespace BigFootVentures.Service.BusinessService.Validators
{
    public static class TrademarkValidator
    {
        #region "Public Methods"

        public static bool IsValid(Trademark trademark, out Dictionary<string, string> validationResult)
        {
            validationResult = new Dictionary<string, string>();

            if (string.IsNullOrWhiteSpace(trademark.Name))
            {
                validationResult.Add("Record.Name", ValidationMessages.REQUIRED);
            }

            if (trademark.Office == null || string.IsNullOrWhiteSpace(trademark.Office.OfficeName))
            {
                validationResult.Add("Record.Office.OfficeName", ValidationMessages.REQUIRED);
            }

            if (string.IsNullOrWhiteSpace(trademark.TrademarkNumber))
            {
                validationResult.Add("Record.TrademarkNumber", ValidationMessages.REQUIRED);
            }

            if (string.IsNullOrWhiteSpace(trademark.FilingNumber))
            {
                validationResult.Add("Record.FilingNumber", ValidationMessages.REQUIRED);
            }

            if (trademark.Brand == null || string.IsNullOrWhiteSpace(trademark.Brand.Name))
            {
                validationResult.Add("Record.Brand.Name", ValidationMessages.REQUIRED);
            }

            if (string.IsNullOrWhiteSpace(trademark.FilingDateValue))
            {
                validationResult.Add("Record.FilingDateValue", ValidationMessages.REQUIRED);
            }

            if (string.IsNullOrWhiteSpace(trademark.TrademarkType))
            {
                validationResult.Add("Record.TrademarkType", ValidationMessages.REQUIRED);
            }

            if (string.IsNullOrWhiteSpace(trademark.LanguageFiling))
            {
                validationResult.Add("Record.LanguageFiling", ValidationMessages.REQUIRED);
            }

            if (string.IsNullOrWhiteSpace(trademark.BigfootGroupOwned))
            {
                validationResult.Add("Record.BigfootGroupOwned", ValidationMessages.REQUIRED);
            }

            return !validationResult.Any();
        }

        #endregion
    }
}
