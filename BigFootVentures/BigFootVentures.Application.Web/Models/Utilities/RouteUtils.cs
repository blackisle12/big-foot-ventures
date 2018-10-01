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