using BigFootVentures.Business.Objects.Enumerators;
using System;
using System.ComponentModel.DataAnnotations;

namespace BigFootVentures.Business.Objects.Extensions.Attributes.Management.Company
{
    public sealed class IsCompanyNameRequired : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var isValid = true;
            var obj = (Objects.Management.Company)validationContext.ObjectInstance;

            if ((string.Equals(obj.AccountRecordType, ManagementEnums.Company.AccountRecordType.BusinessAccount.ToDescription(), StringComparison.InvariantCultureIgnoreCase) ||
                 string.Equals(obj.AccountRecordType, ManagementEnums.Company.AccountRecordType.ExternalClient.ToDescription(), StringComparison.InvariantCultureIgnoreCase)) && string.IsNullOrWhiteSpace(value as string))
            {
                isValid = false;
            }

            return isValid ? ValidationResult.Success : new ValidationResult(this.ErrorMessage, new string[] { validationContext.MemberName });
        }
    }

    public sealed class IsLastNameRequired : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var isValid = true;
            var obj = (Objects.Management.Company)validationContext.ObjectInstance;

            if (string.Equals(obj.AccountRecordType, ManagementEnums.Company.AccountRecordType.PersonAccount.ToDescription(), StringComparison.InvariantCultureIgnoreCase) && string.IsNullOrWhiteSpace(value as string))
            {
                isValid = false;
            }

            return isValid ? ValidationResult.Success : new ValidationResult(this.ErrorMessage, new string[] { validationContext.MemberName });
        }
    }
}
