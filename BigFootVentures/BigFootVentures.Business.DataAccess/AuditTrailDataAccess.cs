using BigFootVentures.Business.Objects.Logs;
using BigFootVentures.Business.Objects.Management;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace BigFootVentures.Business.DataAccess
{
    public interface IAuditTrailDataAccess
    {
        #region "Factory Methods"

        ICollection<AuditTrail> Get(int objectID, string objectName);

        AuditTrail Get(int ID);

        #endregion

        #region "Persistence"

        void Insert(AuditTrail entity);

        #endregion
    }

    public sealed class AuditTrailDataAccess : IAuditTrailDataAccess, IDisposable
    {
        #region "Private Members"

        private readonly MySqlConnection _connection = null;

        #endregion

        #region "Constructors"

        public AuditTrailDataAccess(string connectionString)
        {
            this._connection = new MySqlConnection(connectionString);
        }

        #endregion

        #region "Factory Methods"

        public ICollection<AuditTrail> Get(int objectID, string objectName)
        {
            try
            {
                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();

                var entities = new List<AuditTrail>();

                using (var command = new MySqlCommand("AuditTrail_Get", this._connection) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new MySqlParameter("pObjectID", MySqlDbType.Int32) { Value = objectID, Direction = ParameterDirection.Input });
                    command.Parameters.Add(new MySqlParameter("pObjectName", MySqlDbType.VarChar, 45) { Value = objectName, Direction = ParameterDirection.Input });

                    var dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        entities.Add(new AuditTrail
                        {
                            ID = (int)dataReader["ID"],

                            ObjectID = (int)dataReader["ObjectID"],
                            ObjectName = dataReader["Object"] as string,
                            Message = dataReader["Message"] as string,
                            UserAccount = new UserAccount
                            {
                                ID = (int)dataReader["UserAccountID"],
                                FirstName = dataReader["FirstName"] as string,
                                LastName = dataReader["LastName"] as string
                            },

                            CreateDate = Convert.ToDateTime(dataReader["CreateDate"])
                        });
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

        public AuditTrail Get(int ID)
        {
            try
            {
                AuditTrail entity = null;

                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();

                using (var command = new MySqlCommand("AuditTrail_GetByID", this._connection) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new MySqlParameter("ID", MySqlDbType.Int32) { Value = ID, Direction = ParameterDirection.Input });

                    var dataReader = command.ExecuteReader();
                    
                    while (dataReader.Read())
                    {

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

        public void Insert(AuditTrail entity)
        {
            try
            {
                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();

                using (var command = new MySqlCommand("AuditTrail_Insert", this._connection) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new MySqlParameter("pObjectName", MySqlDbType.VarChar, 45) { Value = entity.ObjectName, Direction = ParameterDirection.Input });
                    command.Parameters.Add(new MySqlParameter("pObjectID", MySqlDbType.Int32) { Value = entity.ObjectID, Direction = ParameterDirection.Input });
                    command.Parameters.Add(new MySqlParameter("pMessage", MySqlDbType.VarChar, 500) { Value = entity.Message, Direction = ParameterDirection.Input });
                    command.Parameters.Add(new MySqlParameter("pUserAccountID", MySqlDbType.Int32) { Value = entity.UserAccount.ID, Direction = ParameterDirection.Input });

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
