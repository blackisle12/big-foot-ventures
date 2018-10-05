using BigFootVentures.Business.Objects.Enumerators;
using BigFootVentures.Business.Objects.Extensions;
using BigFootVentures.Business.Objects.Management;
using System.Collections.Generic;
using System.Linq;

namespace BigFootVentures.Service.BusinessService.Validators
{
    public static class CompanyValidator
    {
        #region "Public Methods"

        public static bool IsValid(Company company, out Dictionary<string, string> validationResult)
        {
            validationResult = new Dictionary<string, string>();

            if (company.AccountRecordType == ManagementEnums.Company.AccountRecordType.BusinessAccount.ToDescription())
            {
                if (string.IsNullOrWhiteSpace(company.CompanyName))
                {
                    validationResult.Add("Record.CompanyName", ValidationMessages.REQUIRED);
                }
            }
            else if (company.AccountRecordType == ManagementEnums.Company.AccountRecordType.ExternalClient.ToDescription())
            {
                if (string.IsNullOrWhiteSpace(company.CompanyName))
                {
                    validationResult.Add("Record.CompanyName", ValidationMessages.REQUIRED);
                }
            }
            else if (company.AccountRecordType == ManagementEnums.Company.AccountRecordType.PersonAccount.ToDescription())
            {
                if (string.IsNullOrWhiteSpace(company.LastName))
                {
                    validationResult.Add("Record.LastName", ValidationMessages.REQUIRED);
                }
            }

            return !validationResult.Any();
        }

        #endregion
    }
}
