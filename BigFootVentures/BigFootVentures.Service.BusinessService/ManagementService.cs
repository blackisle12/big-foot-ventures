using BigFootVentures.Business.DataAccess;
using BigFootVentures.Business.DataAccess.Mapping.Management;
using BigFootVentures.Business.Objects.Management;
using System.Collections.Generic;

namespace BigFootVentures.Service.BusinessService
{
    public interface IManagementService
    {
        #region "Factory Methods"

        ICollection<Brand> Brand_Get(int startIndex, int rowCount, out int total);

        Brand Brand_Get(int ID);

        #endregion

        #region "Persistence"

        void Brand_Insert(Brand brand);

        void Brand_Update(Brand brand);

        void Brand_Delete(int ID);

        #endregion
    }

    public sealed class ManagementService : IManagementService
    {
        #region "Private Members"

        private readonly IRepository<Brand> _brandRepository = null;

        #endregion

        #region "Constructors"

        public ManagementService(string connectionString)
        {
            this._brandRepository = new Repository<Brand>(connectionString, new BrandMapper());
        }

        #endregion

        #region "Factory Methods"

        public ICollection<Brand> Brand_Get(int startIndex, int rowCount, out int total)
        {
            return this._brandRepository.Get(startIndex, rowCount, out total);
        }

        public Brand Brand_Get(int ID)
        {
            return this._brandRepository.Get(ID);
        }

        #endregion

        #region "Persistence"

        public void Brand_Insert(Brand brand)
        {
            this._brandRepository.Insert(brand);
        }

        public void Brand_Update(Brand brand)
        {
            this._brandRepository.Update(brand);
        }

        public void Brand_Delete(int ID)
        {
            this._brandRepository.Delete(ID);
        }

        #endregion
    }
}
