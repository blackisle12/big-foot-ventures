using BigFootVentures.Business.Objects.Management;
using System.Collections.Generic;
using System.Linq;

namespace BigFootVentures.Service.BusinessService.Validators
{
    public static class LegalCaseValidator
    {
        #region "Public Methods"

        public static bool IsValid(LegalCase legalCase, out Dictionary<string, string> validationResult)
        {
            validationResult = new Dictionary<string, string>();
            return !validationResult.Any();
        }

        #endregion
    }
}
