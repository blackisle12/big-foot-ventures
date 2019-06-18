using BigFootVentures.Business.DataAccess;
using BigFootVentures.Business.DataAccess.Mapping;
using BigFootVentures.Business.DataAccess.Mapping.Management;
using BigFootVentures.Business.Objects;
using BigFootVentures.Business.Objects.Management;
using BigFootVentures.Business.Objects.Wrapper;
using BigFootVentures.Service.BusinessService.DataAccessMapping;
using System.Collections.Generic;
using System.Text;

namespace BigFootVentures.Service.BusinessService
{
    public interface IManagementService<TModel> where TModel : BusinessBase
    {
        #region "Factory Methods"

        ICollection<TModel> Get(int startIndex, int rowCount, out int total);

        ICollection<TModel> Get(int startIndex, int rowCount, string sortBy, string sortOrder, out int total);

        ICollection<TModel> GetByKeyword(string keyword, int startIndex, int rowCount, out int total);

        ICollection<TModel> GetByKeyword(string keyword, int startIndex, int rowCount, string sortBy, string sortOrder, out int total);

        ICollection<TModel> GetByQuery(string query, string queryTotal, out int total);

        StringBuilder ExportByKeyword(string keyword);

        StringBuilder ExportByQuery(string query);

        TModel Get(int ID);

        TModel GetLast();

        ICollection<AutocompleteWrapper> GetAutocomplete(string keyword);

        ICollection<TModel> GetByEmailAddress(string emailAddress);

        ICollection<TModel> GetByUsername(string username);

        ICollection<TModel> GetAssigned(int assignedToID, int startIndex, int rowCount, out int total);

        ICollection<TRelatedModel> GetRelated<TRelatedModel>(int objectID) where TRelatedModel : BusinessBase;

        #endregion

        #region "Persistence"

        void Insert(TModel model);

        void Update(TModel model);

        void UpdateUserAccount(UserAccount model);

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

        public ICollection<TModel> Get(int startIndex, int rowCount, string sortBy, string sortOrder, out int total)
        {
            using (var repository = new Repository<TModel>(this._connectionString, this._mapper))
            {
                return repository.Get(startIndex, rowCount, sortBy, sortOrder, out total);
            }
        }

        public ICollection<TModel> GetByKeyword(string keyword, int startIndex, int rowCount, out int total)
        {
            using (var repository = new Repository<TModel>(this._connectionString, this._mapper))
            {
                return repository.GetByKeyword(keyword, startIndex, rowCount, out total);
            }
        }

        public ICollection<TModel> GetByKeyword(string keyword, int startIndex, int rowCount, string sortBy, string sortOrder, out int total)
        {
            using (var repository = new Repository<TModel>(this._connectionString, this._mapper))
            {
                return repository.GetByKeyword(keyword, startIndex, rowCount, sortBy, sortOrder, out total);
            }
        }

        public ICollection<TModel> GetByQuery(string query, string queryTotal, out int total)
        {
            using (var repository = new Repository<TModel>(this._connectionString, this._mapper))
            {
                return repository.GetByQuery(query, queryTotal, out total);
            }
        }

        public StringBuilder ExportByKeyword(string keyword)
        {
            using (var repository = new Repository<TModel>(this._connectionString, this._mapper))
            {
                return repository.ExportByKeyword(keyword);
            }
        }

        public StringBuilder ExportByQuery(string query)
        {
            using (var repository = new Repository<TModel>(this._connectionString, this._mapper))
            {
                return repository.ExportByQuery(query);
            }
        }

        public TModel Get(int ID)
        {
            using (var repository = new Repository<TModel>(this._connectionString, this._mapper))
            {
                return repository.Get(ID);
            }
        }

        public TModel GetLast()
        {
            using (var repository = new Repository<TModel>(this._connectionString, this._mapper))
            {
                return repository.GetLast();
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

        public ICollection<TModel> GetAssigned(int assignedToID, int startIndex, int rowCount, out int total)
        {
            using (var repository = new Repository<TModel>(this._connectionString, this._mapper))
            {
                return repository.GetAssigned(assignedToID, startIndex, rowCount, out total);
            }
        }

        public ICollection<TRelatedModel> GetRelated<TRelatedModel>(int objectID) where TRelatedModel : BusinessBase
        {
            IMapper mapper = null;

            if (typeof(TRelatedModel) == typeof(Brand))
                mapper = new BrandMapper();
            else if (typeof(TRelatedModel) == typeof(Cancellation))
                mapper = new CancellationMapper();
            if (typeof(TRelatedModel) == typeof(Contact))
                mapper = new ContactMapper();
            else if (typeof(TRelatedModel) == typeof(LegalCase))
                mapper = new LegalCaseMapper();
            else if (typeof(TRelatedModel) == typeof(Opposition))
                mapper = new OppositionMapper();
            else if (typeof(TRelatedModel) == typeof(TMRepresentative))
                mapper = new TMRepresentativeMapper();
            else if (typeof(TRelatedModel) == typeof(Trademark))
                mapper = new TrademarkMapper();
            else if (typeof(TRelatedModel) == typeof(TrademarkOwner))
                mapper = new TrademarkOwnerMapper();

            using (var repository = new Repository<TModel>(this._connectionString, mapper))
            {
                return repository.GetRelated<TRelatedModel>(objectID, mapper);
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

        public void UpdateUserAccount(UserAccount model)
        {
            using (var repository = new Repository<UserAccount>(this._connectionString, this._mapper))
            {
                repository.UpdateUserAccount(model);
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
