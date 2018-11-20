using BigFootVentures.Business.DataAccess;
using BigFootVentures.Business.DataAccess.Mapping;
using BigFootVentures.Business.Objects;
using BigFootVentures.Service.BusinessService.DataAccessMapping;
using System.Collections.Generic;

namespace BigFootVentures.Service.BusinessService
{
    public interface IEmailNotificationService<TModel> where TModel : BusinessBase
    {
        #region "Factory Methods"

        ICollection<TModel> Get(int week);

        #endregion
    }

    public sealed class EmailNotificationService<TModel> : IEmailNotificationService<TModel> where TModel : BusinessBase
    {
        #region "Private Members"

        private readonly string _connectionString = null;
        private readonly IEmailNotificationMapper _mapper = null;

        #endregion

        #region "Constructors"

        public EmailNotificationService(string connectionString)
        {
            this._connectionString = connectionString;
            this._mapper = EmailNotificationMapper.GetMapper(typeof(TModel));
        }

        #endregion

        #region "Factory Methods"

        public ICollection<TModel> Get(int week)
        {
            using (var repository = new Repository<TModel>(this._connectionString, this._mapper))
            {
                return repository.GetForEmailNotification(week);
            }
        }

        #endregion
    }
}
