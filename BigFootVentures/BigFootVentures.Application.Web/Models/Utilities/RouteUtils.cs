using BigFootVentures.Business.Objects.Management;
using System;

namespace BigFootVentures.Application.Web.Models.Utilities
{
    public static class RouteUtils
    {
        #region "Public Methods"

        public static dynamic GetRouteMapping(Type type, object model)
        {
            if (type == typeof(Brand))
            {
                var brand = (Brand)model;

                return new { ID = brand.ID };
            }
            else if (type == typeof(Company))
            {
                var company = (Company)model;

                return new { recordType = company.AccountRecordType, ID = company.ID };
            }
            else if (type == typeof(Contact))
            {
                var contact = (Contact)model;

                return new { ID = contact.ID };
            }
            else if (type == typeof(DomainN))
            {
                var domain = (DomainN)model;

                return new { ID = domain.ID };
            }
            else if (type == typeof(Enquiry))
            {
                var enquiry = (Enquiry)model;

                return new { ID = enquiry.ID };
            }
            else if (type == typeof(LoginInformation))
            {
                var loginInformation = (LoginInformation)model;

                return new { ID = loginInformation.ID };
            }
            else if (type == typeof(OfficeStatus))
            {
                var officeStatus = (OfficeStatus)model;

                return new { ID = officeStatus.ID };
            }
            else if (type == typeof(Register))
            {
                var register = (Register)model;

                return new { ID = register.ID };
            }
            else
            {
                return null;
            }
        }

        #endregion
    }
}