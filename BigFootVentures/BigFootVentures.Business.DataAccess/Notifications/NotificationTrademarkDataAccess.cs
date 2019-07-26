using BigFootVentures.Business.Objects.Notifications.Trademark;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace BigFootVentures.Business.DataAccess.Notifications
{
    public interface INotificationTrademarkDataAccess
    {
        ICollection<ProofOfUse> GetProofOfUse(string iteration = "");
    }

    public sealed class NotificationTrademarkDataAccess : INotificationTrademarkDataAccess, IDisposable
    {
        #region "Private Members"

        private readonly MySqlConnection _connection = null;

        #endregion

        #region "Constructors"

        public NotificationTrademarkDataAccess(string connectionString)
        {
            this._connection = new MySqlConnection(connectionString);
        }

        #endregion

        #region "Factory Methods"

        public ICollection<ProofOfUse> GetProofOfUse(string iteration = "")
        {
            try
            {
                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();

                var proofOfUseList = new List<ProofOfUse>();

                using (var command = new MySqlCommand($"Notifications_Trademark_ProofOfUse{iteration}_Get", this._connection) { CommandType = CommandType.StoredProcedure })
                {
                    var dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        var proofOfUse = new ProofOfUse
                        {
                            OfficeName = dataReader["OfficeName"] as string,
                            TrademarkName = dataReader["Name"] as string,
                            TrademarkNumber = dataReader["TrademarkNumber"] as string,
                            DeadlineForSubmission = dataReader[$"DeadlineForSubmission{iteration}"] as string,
                            StaffName = dataReader["StaffName"] as string,
                            StaffEmailAddress = dataReader["StaffEmailAddress"] as string,
                            SupervisorName = dataReader["SupervisorName"] as string,
                            SupervisorEmailAddress = dataReader["SupervisorEmailAddress"] as string
                        };

                        proofOfUseList.Add(proofOfUse);
                    }

                    dataReader.Close();
                }

                return proofOfUseList;
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
