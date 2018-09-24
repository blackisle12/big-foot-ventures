//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Text;

//namespace BigFootVentures.Business.Objects.Extensions.Attributes.Management.Company
//{
//    public sealed class IsCompanyNameRequired : ValidationAttribute
//    {
//        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
//        {
//            var isValid = true;
//            var obj = (Business.Objects.Management.Company)validationContext.ObjectInstance;

//            if (obj.AccountType == AccountType.Individual && !obj.UseLicenseNumber && string.IsNullOrWhiteSpace(value as String))
//                isValid = false;

//            return isValid
//                ? ValidationResult.Success
//                : new ValidationResult(this.ErrorMessage, new string[] { validationContext.MemberName });
//        }
//    }
//}
