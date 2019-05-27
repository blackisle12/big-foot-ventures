using BigFootVentures.Business.DataAccess;
using BigFootVentures.Business.Objects.Logs;
using BigFootVentures.Business.Objects.Management;
using System.Collections.Generic;

namespace BigFootVentures.Service.BusinessService
{
    public interface ITaskService
    {
        #region "Factory Methods"

        ICollection<Task> Get(int objectID, string objectName);

        #endregion
    }

    public class TaskService : ITaskService
    {
        #region "Private Members"

        private readonly string _connectionString = null;

        #endregion

        #region "Constructors"

        public TaskService(string connectionString)
        {
            this._connectionString = connectionString;
        }

        #endregion

        #region "Factory Methods"

        public ICollection<Task> Get(int objectID, string objectName)
        {
            using (var dataAccess = new TaskDataAccess(_connectionString))
            {
                return dataAccess.Get(objectID, objectName);
            }
        }

        #endregion
    }
}
