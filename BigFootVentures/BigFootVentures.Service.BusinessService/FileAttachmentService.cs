using BigFootVentures.Business.DataAccess;
using BigFootVentures.Business.Objects.Management;
using System.Collections.Generic;

namespace BigFootVentures.Service.BusinessService
{
    public interface IFileAttachmentService
    {
        #region "Factory Methods"

        ICollection<FileAttachment> Get(int objectID, string objectName);

        FileAttachment GetByID(int ID, string objectName);

        #endregion

        #region "Persistence"

        void Insert(FileAttachment model, string objectName);

        #endregion
    }

    public class FileAttachmentService : IFileAttachmentService
    {
        #region "Private Members"

        private readonly string _connectionString = null;

        #endregion

        #region "Constructors"

        public FileAttachmentService(string connectionString)
        {
            this._connectionString = connectionString;
        }

        #endregion

        #region "Factory Methods"

        public ICollection<FileAttachment> Get(int objectID, string objectName)
        {
            using (var dataAccess = new FileAttachmentDataAccess(_connectionString))
            {
                return dataAccess.Get(objectID, objectName);
            }
        }

        public FileAttachment GetByID(int ID, string objectName)
        {
            using (var dataAccess = new FileAttachmentDataAccess(_connectionString))
            {
                return dataAccess.GetByID(ID, objectName);
            }
        }

        #endregion

        #region "Persistence"

        public void Insert(FileAttachment model, string objectName)
        {
            using (var dataAccess = new FileAttachmentDataAccess(_connectionString))
            {
                dataAccess.Insert(model, objectName);
            }
        }

        #endregion
    }
}
