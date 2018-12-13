using BigFootVentures.Business.DataAccess;
using BigFootVentures.Business.DataAccess.Mapping;
using BigFootVentures.Business.Objects;
using BigFootVentures.Business.Objects.Wrapper;
using BigFootVentures.Service.BusinessService.DataAccessMapping;
using System.Collections.Generic;

namespace BigFootVentures.Service.BusinessService
{
    public interface IManagementService<TModel> where TModel : BusinessBase
    {
        #region "Factory Methods"

        ICollection<TModel> Get(int startIndex, int rowCount, out int total);

        ICollection<TModel> GetByKeyword(string keyword, int startIndex, int rowCount, out int total);

        TModel Get(int ID);

        ICollection<AutocompleteWrapper> GetAutocomplete(string keyword);

        ICollection<TModel> GetByEmailAddress(string emailAddress);

        ICollection<TModel> GetByUsername(string username);

        #endregion

        #region "Persistence"

        void Insert(TModel model);

        void Update(TModel model);

        void Delete(int ID);

        #endregion
    }

    public sealed class ManagementService<TModel> : IManagementService<TModel> where TModel : BusinessBase
    {
        #region "Private Members"
        
        private readonly string _connectionString = null;
        private readonly IMapper _mapper = null;

        #endregion

        #region "Constructors"

        public ManagementService(string connectionString)
        {
            this._connectionString = connectionString;
            this._mapper = ManagementMapper.GetMapper(typeof(TModel));
        }

        #endregion

        #region "Factory Methods"

        public ICollection<TModel> Get(int startIndex, int rowCount, out int total)
        {
            using (var repository = new Repository<TModel>(this._connectionString, this._mapper))
            {
                return repository.Get(startIndex, rowCount, out total);
            }
        }

        public ICollection<TModel> GetByKeyword(string keyword, int startIndex, int rowCount, out int total)
        {
            using (var repository = new Repository<TModel>(this._connectionString, this._mapper))
            {
                return repository.GetByKeyword(keyword, startIndex, rowCount, out total);
            }
        }

        public TModel Get(int ID)
        {
            using (var repository = new Repository<TModel>(this._connectionString, this._mapper))
            {
                return repository.Get(ID);
            }
        }

        public ICollection<AutocompleteWrapper> GetAutocomplete(string keyword)
        {
            using (var repository = new Repository<TModel>(this._connectionString, this._mapper))
            {
                return repository.GetAutocomplete(keyword);
            }
        }

        public ICollection<TModel> GetByEmailAddress(string emailAddress)
        {
            using (var repository = new Repository<TModel>(this._connectionString, this._mapper))
            {
                return repository.GetByEmailAddress(emailAddress);
            }
        }

        public ICollection<TModel> GetByUsername(string username)
        {
            using (var repository = new Repository<TModel>(this._connectionString, this._mapper))
            {
                return repository.GetByUsername(username);
            }
        }

        #endregion

        #region "Persistence"

        public void Insert(TModel model)
        {
            using (var repository = new Repository<TModel>(this._connectionString, this._mapper))
            {
                repository.Insert(model);
            }
        }

        public void Update(TModel model)
        {
            using (var repository = new Repository<TModel>(this._connectionString, this._mapper))
            {
                repository.Update(model);
            }
        }

        public void Delete(int ID)
        {
            using (var repository = new Repository<TModel>(this._connectionString, this._mapper))
            {
                repository.Delete(ID);
            }
        }

        #endregion
    }
}
