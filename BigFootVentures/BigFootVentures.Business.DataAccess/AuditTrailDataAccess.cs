using BigFootVentures.Business.Objects.Logs;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace BigFootVentures.Business.DataAccess
{
    public interface IAuditTrailDataAccess
    {
        #region "Factory Methods"

        ICollection<AuditTrail> Get(string objectName, int startIndex, int rowCount, out int total);

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

        public ICollection<AuditTrail> Get(string objectName, int startIndex, int rowCount, out int total)
        {
            try
            {
                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();

                var entities = new List<AuditTrail>();

                using (var command = new MySqlCommand("AuditTrail_Get", this._connection) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new MySqlParameter("objectName", MySqlDbType.VarChar, 45) { Value = objectName, Direction = ParameterDirection.Input });
                    command.Parameters.Add(new MySqlParameter("startIndex", MySqlDbType.Int32) { Value = startIndex, Direction = ParameterDirection.Input });
                    command.Parameters.Add(new MySqlParameter("rowCount", MySqlDbType.Int32) { Value = rowCount, Direction = ParameterDirection.Input });
                    command.Parameters.Add(new MySqlParameter("total", MySqlDbType.Int32) { Direction = ParameterDirection.Output });

                    var dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {

                    }

                    dataReader.Close();

                    total = (int)command.Parameters["total"].Value;
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
