using BigFootVentures.Business.Objects.Management;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace BigFootVentures.Business.DataAccess
{
    public interface IFileAttachmentDataAccess
    {
        #region "Factory Methods"

        ICollection<FileAttachment> Get(int objectID, string objectName);

        FileAttachment GetByID(int ID, string objectName);

        #endregion

        #region "Persistence"

        void Insert(FileAttachment entity, string objectName);

        #endregion
    }

    public sealed class FileAttachmentDataAccess : IFileAttachmentDataAccess, IDisposable
    {
        #region "Private Members"

        private readonly MySqlConnection _connection = null;

        #endregion

        #region "Constructors"

        public FileAttachmentDataAccess(string connectionString)
        {
            this._connection = new MySqlConnection(connectionString);
        }

        #endregion

        #region "Factory Methods"

        public ICollection<FileAttachment> Get(int objectID, string objectName)
        {
            try
            {
                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();

                var entities = new List<FileAttachment>();

                using (var command = new MySqlCommand($"{objectName}Attachment_Get", this._connection) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new MySqlParameter("pObjectID", MySqlDbType.Int32) { Value = objectID, Direction = ParameterDirection.Input });

                    var dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        var entity = new FileAttachment
                        {
                            ID = (int)dataReader["ID"],

                            ObjectID = (int)dataReader[$"{objectName}ID"],
                            FileName = dataReader["FileName"] as string,
                            //File = (byte[])dataReader["File"],

                            CreateDate = Convert.ToDateTime(dataReader["CreateDate"])
                        };

                        entities.Add(entity);
                    }

                    dataReader.Close();
                }

                return entities;
            }
            catch
            {
                throw;
            }
            finally
            {
                this._connection.Close();
            }
        }

        public FileAttachment GetByID(int ID, string objectName)
        {
            try
            {
                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();

                FileAttachment entity = null;

                using (var command = new MySqlCommand($"{objectName}Attachment_GetByID", this._connection) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new MySqlParameter("pID", MySqlDbType.Int32) { Value = ID, Direction = ParameterDirection.Input });

                    var dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        entity = new FileAttachment
                        {
                            ID = (int)dataReader["ID"],

                            ObjectID = (int)dataReader[$"{objectName}ID"],
                            FileName = dataReader["FileName"] as string,
                            File = (byte[])dataReader["File"],

                            CreateDate = Convert.ToDateTime(dataReader["CreateDate"])
                        };

                        break;
                    }

                    dataReader.Close();
                }

                return entity;
            }
            catch
            {
                throw;
            }
            finally
            {
                this._connection.Close();
            }
        }

        #endregion

        #region "Persistence"

        public void Insert(FileAttachment entity, string objectName)
        {
            try
            {
                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();

                using (var command = new MySqlCommand($"{objectName}Attachment_Insert", this._connection) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new MySqlParameter("pObjectID", MySqlDbType.Int32) { Value = entity.ObjectID, Direction = ParameterDirection.Input });
                    command.Parameters.Add(new MySqlParameter("pFileName", MySqlDbType.VarChar, 100) { Value = entity.FileName, Direction = ParameterDirection.Input });
                    command.Parameters.Add(new MySqlParameter("pFile", MySqlDbType.MediumBlob) { Value = entity.File, Direction = ParameterDirection.Input });

                    command.Parameters.Add(new MySqlParameter("pCreateDate", MySqlDbType.DateTime) { Value = entity.CreateDate, Direction = ParameterDirection.Input });

                    entity.ID = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                this._connection.Close();
            }
        }

        #endregion

        #region "Public Methods"

        public void Dispose()
        {
            this._connection.Dispose();
        }

        #endregion
    }
}
