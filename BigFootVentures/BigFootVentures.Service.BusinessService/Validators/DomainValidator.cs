using BigFootVentures.Business.Objects.Management;
using System.Collections.Generic;
using System.Linq;

namespace BigFootVentures.Service.BusinessService.Validators
{
    public static class DomainValidator
    {
        #region "Public Methods"

        public static bool IsValid(DomainN domain, out Dictionary<string, string> validationResult)
        {
            validationResult = new Dictionary<string, string>();

            if (string.IsNullOrWhiteSpace(domain.Name))
            {
                validationResult.Add("Record.Name", ValidationMessages.REQUIRED);
            }

            if (domain.Brand == null || string.IsNullOrWhiteSpace(domain.Brand.Name))
            {
                validationResult.Add("Record.Brand.Name", ValidationMessages.REQUIRED);
            }

            return !validationResult.Any();
        }

        #endregion
    }
}
