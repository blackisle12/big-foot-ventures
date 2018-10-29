using BigFootVentures.Business.Objects.Management;
using System.Collections.Generic;
using System.Linq;

namespace BigFootVentures.Service.BusinessService.Validators
{
    public static class SimilarTrademarkValidator
    {
        #region "Public Methods"

        public static bool IsValid(SimilarTrademark similarTrademark, out Dictionary<string, string> validationResult)
        {
            validationResult = new Dictionary<string, string>();
           
            if (similarTrademark.Trademark == null || string.IsNullOrWhiteSpace(similarTrademark.Trademark.Name))
            {
                validationResult.Add("Record.Trademark.Name", ValidationMessages.REQUIRED);
            }

            if (similarTrademark.TrademarkSimilar == null || string.IsNullOrWhiteSpace(similarTrademark.TrademarkSimilar.Name))
            {
                validationResult.Add("Record.TrademarkSimilar.Name", ValidationMessages.REQUIRED);
            }
            
            return !validationResult.Any();
        }

        #endregion
    }
}
