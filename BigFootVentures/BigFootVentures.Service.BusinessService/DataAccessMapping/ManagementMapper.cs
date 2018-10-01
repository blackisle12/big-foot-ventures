using BigFootVentures.Business.DataAccess.Mapping;
using BigFootVentures.Business.DataAccess.Mapping.Management;
using BigFootVentures.Business.Objects.Management;
using System;

namespace BigFootVentures.Service.BusinessService.DataAccessMapping
{
    internal static class ManagementMapper
    {
        #region "Public Methods"

        public static IMapper GetMapper(Type type)
        {
            if (type == typeof(Brand))
            {
                return new BrandMapper();
            }
            else if (type == typeof(Company))
            {
                return new CompanyMapper();
            }
            else if (type == typeof(Register))
            {
                return new RegisterMapper();
            }
            else
            {
                return null;
            }                
        }

        #endregion
    }
}
