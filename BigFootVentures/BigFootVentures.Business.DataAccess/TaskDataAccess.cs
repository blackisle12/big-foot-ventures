using BigFootVentures.Business.Objects.Management;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace BigFootVentures.Business.DataAccess
{
    public interface ITaskDataAccess
    {
        #region "Factory Methods"

        ICollection<Task> Get(int objectID, string objectName);

        #endregion
    }

    public sealed class TaskDataAccess : ITaskDataAccess, IDisposable
    {
        #region "Private Members"

        private readonly MySqlConnection _connection = null;

        #endregion

        #region "Constructors"

        public TaskDataAccess(string connectionString)
        {
            this._connection = new MySqlConnection(connectionString);
        }

        #endregion

        #region "Factory Methods"

        public ICollection<Task> Get(int objectID, string objectName)
        {
            try
            {
                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();

                var entities = new List<Task>();

                using (var command = new MySqlCommand("Task_GetByObjectNameAndObjectID", this._connection) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new MySqlParameter("pObjectID", MySqlDbType.Int32) { Value = objectID, Direction = ParameterDirection.Input });
                    command.Parameters.Add(new MySqlParameter("pObjectName", MySqlDbType.VarChar, 45) { Value = objectName, Direction = ParameterDirection.Input });

                    var dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        entities.Add(new Task
                        {
                            ID = (int)dataReader["ID"],

                            CompletionDate = dataReader["CompletionDate"] as DateTime?,
                            IssueDate = dataReader["IssueDate"] as DateTime?,
                            DueDate = dataReader["DueDate"] as DateTime?,
                            Status = dataReader["Status"] as string,
                            Subject = dataReader["Subject"] as string,
                            RelatedToObjectID = dataReader["RelatedToObjectID"] as int?,
                            RelatedToObjectName = dataReader["RelatedToObjectName"] as string,
                            RelatedToObjectValue = dataReader["RelatedToObjectValue"] as string,
                            AssignedTo = new UserAccount
                            {
                                ID = dataReader["AssignedToID"] as int? ?? 0,
                                DisplayName = dataReader["DisplayName"] as string
                            },
                            OwnerName = dataReader["OwnerName"] as string
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

        #endregion

        #region "Public Methods"

        public void Dispose()
        {
            this._connection.Dispose();
        }

        #endregion
    }
}
