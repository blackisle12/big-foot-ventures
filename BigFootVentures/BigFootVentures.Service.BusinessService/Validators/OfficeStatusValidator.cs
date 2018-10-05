using BigFootVentures.Business.Objects.Management;
using System.Collections.Generic;
using System.Linq;

namespace BigFootVentures.Service.BusinessService.Validators
{
    public static class OfficeStatusValidator
    {
        #region "Public Methods"

        public static bool IsValid(OfficeStatus officeStatus, out Dictionary<string, string> validationResult)
        {
            validationResult = new Dictionary<string, string>();

            if (string.IsNullOrWhiteSpace(officeStatus.Name))
            {
                validationResult.Add("Record.Name", ValidationMessages.REQUIRED);
            }

            return !validationResult.Any();
        }

        #endregion
    }
}
