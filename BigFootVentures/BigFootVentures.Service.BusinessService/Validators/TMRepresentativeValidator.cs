using BigFootVentures.Business.Objects.Management;
using System.Collections.Generic;
using System.Linq;

namespace BigFootVentures.Service.BusinessService.Validators
{
    public static class TMRepresentativeValidator
    {
        #region "Public Methods"

        public static bool IsValid(TMRepresentative TMRepresentative, out Dictionary<string, string> validationResult)
        {
            validationResult = new Dictionary<string, string>();

            if (TMRepresentative.Trademark == null || string.IsNullOrWhiteSpace(TMRepresentative.Trademark.Name))
            {
                validationResult.Add("Record.Trademark.Name", ValidationMessages.REQUIRED);
            }

            if (TMRepresentative.Representative == null || string.IsNullOrWhiteSpace(TMRepresentative.Representative.DisplayName))
            {
                validationResult.Add("Record.Representative.DisplayName", ValidationMessages.REQUIRED);
            }

            return !validationResult.Any();
        }

        #endregion
    }
}
