using BigFootVentures.Business.Objects.Management;
using System.Collections.Generic;
using System.Linq;

namespace BigFootVentures.Service.BusinessService.Validators
{
    public static class CancellationValidator
    {
        #region "Public Methods"

        public static bool IsValid(Cancellation cancellation, out Dictionary<string, string> validationResult)
        {
            validationResult = new Dictionary<string, string>();

            if (string.IsNullOrWhiteSpace(cancellation.ReferenceInternal))
            {
                validationResult.Add("Record.ReferenceInternal", ValidationMessages.REQUIRED);
            }

            return !validationResult.Any();
        }

        #endregion
    }
}
