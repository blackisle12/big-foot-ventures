using BigFootVentures.Business.DataAccess.Mapping;
using BigFootVentures.Business.DataAccess.Mapping.EmailNotification;
using BigFootVentures.Business.Objects.Management;
using System;

namespace BigFootVentures.Service.BusinessService.DataAccessMapping
{
    internal static class EmailNotificationMapper
    {
        #region "Public Methods"

        public static IEmailNotificationMapper GetMapper(Type type)
        {
            if (type == typeof(LegalCase))
            {
                return new LegalCaseMapper();
            }            
            else
            {
                return null;
            }
        }

        #endregion
    }
}
