using BigFootVentures.Business.Objects.Management;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BigFootVentures.Business.DataAccess.Mapping.Management
{
    public sealed class TaskMapper : IMapper
    {
        #region "Public Methods"

        public ICollection<object> ParseData(MySqlDataReader dataReader)
        {
            var entities = new List<object>();

            while (dataReader.Read())
            {
                var entity = new Task
                {
                    ID = (int)dataReader["ID"],

                   Subject = dataReader["Subject"] as string,
                   Comments = dataReader["Comments"] as string,
                   IssueDate = dataReader["IssueDate"] as DateTime?,
                   DueDate = dataReader["DueDate"] as DateTime?,
                   Priority = dataReader["Priority"] as string,
                   CompletionDate = dataReader["CompletionDate"] as DateTime?,
                   CreationDate = dataReader["CreationDate"] as DateTime?,
                   ReasonForClose = dataReader["ReasonForClose"] as string,
                   AssignedTo = new UserAccount
                   {
                       ID = (int)dataReader["AssignedToID"]
                   },
                   Status = dataReader["Status"] as string,
                   RelatedToObjectID = dataReader["RelatedToObjectID"] as int?,
                   RelatedToObjectName = dataReader["RelatedToObjectName"] as string,
                   RelatedToObjectValue = dataReader["RelatedToObjectValue"] as string,
                   CloseTask = ((dataReader["CloseTask"] as sbyte? ?? 0) == 1),

                   MessageDate = dataReader["MessageDate"] as DateTime?,

                   CreateRecurringSeriesOfTasks = ((dataReader["CreateRecurringSeriesOfTasks"] as sbyte? ?? 0) == 1),

                   Reminder = ((dataReader["Reminder"] as sbyte? ?? 0) == 1),
                   ReminderDate = dataReader["ReminderDate"] as string,
                   ReminderTime = dataReader["ReminderTime"] as string,

                   OwnerName = dataReader["OwnerName"] as string
                };

                entities.Add(entity);
            }

            return entities;
        }

        public ICollection<object> ParseDataMin(MySqlDataReader dataReader)
        {
            var entities = new List<object>();

            while (dataReader.Read())
            {
                var entity = new Task
                {
                    ID = (int)dataReader["ID"],

                    CompletionDate = dataReader["CompletionDate"] as DateTime?,
                    IssueDate = dataReader["IssueDate"] as DateTime?,
                    Status = dataReader["Status"] as string,
                    Subject = dataReader["Subject"] as string,
                    RelatedToObjectID = dataReader["RelatedToObjectID"] as int?,
                    RelatedToObjectName = dataReader["RelatedToObjectName"] as string,
                    RelatedToObjectValue = dataReader["RelatedToObjectValue"] as string,
                };

                entities.Add(entity);
            }

            return entities;
        }

        public StringBuilder ExportData(MySqlDataReader dataReader)
        {
            var file = new StringBuilder();

            while (dataReader.Read())
            {
                //file.AppendLine($@"{dataReader["Name"] as string} 
                //    {(dataReader["BigFootOwned"] as sbyte? ?? 0) == 1} 
                //    {dataReader["RegistrantName"] as string} 
                //    {dataReader["ExpirationDate"] as string} 
                //    {dataReader["RegistrarName"] as string}");
            }

            return file;
        }

        public MySqlParameter[] CreateParameters(object model)
        {
            var entity = (Task)model;
            var parameters = new List<MySqlParameter>();

            parameters.AddRange(new MySqlParameter[]
            {
                new MySqlParameter("pSubject", MySqlDbType.VarChar, 100) { Value = entity.Subject, Direction = ParameterDirection.Input },
                new MySqlParameter("pComments", MySqlDbType.VarChar, 255) { Value = entity.Comments, Direction = ParameterDirection.Input },
                new MySqlParameter("pIssueDate", MySqlDbType.Date) { Value = entity.IssueDate, Direction = ParameterDirection.Input },
                new MySqlParameter("pDueDate", MySqlDbType.Date) { Value = entity.DueDate, Direction = ParameterDirection.Input },
                new MySqlParameter("pPriority", MySqlDbType.VarChar, 25) { Value = entity.Priority, Direction = ParameterDirection.Input },
                new MySqlParameter("pCompletionDate", MySqlDbType.DateTime) { Value = entity.CompletionDate, Direction = ParameterDirection.Input },
                new MySqlParameter("pCreationDate", MySqlDbType.DateTime) { Value = entity.CreationDate, Direction = ParameterDirection.Input },
                new MySqlParameter("pReasonForClose", MySqlDbType.VarChar, 255) { Value = entity.ReasonForClose, Direction = ParameterDirection.Input },
                new MySqlParameter("pAssignedToID", MySqlDbType.Int32) { Value = entity.AssignedTo.ID, Direction = ParameterDirection.Input },
                new MySqlParameter("pStatus", MySqlDbType.VarChar, 25) { Value = entity.Status, Direction = ParameterDirection.Input },
                new MySqlParameter("pRelatedToObjectID", MySqlDbType.Int32) { Value = entity.RelatedToObjectID, Direction = ParameterDirection.Input },
                new MySqlParameter("pRelatedToObjectName", MySqlDbType.VarChar, 45) { Value = entity.RelatedToObjectName, Direction = ParameterDirection.Input },
                new MySqlParameter("pRelatedToObjectValue", MySqlDbType.VarChar, 100) { Value = entity.RelatedToObjectValue, Direction = ParameterDirection.Input },
                new MySqlParameter("pCloseTask", entity.CloseTask ? 1 : 0) { Direction = ParameterDirection.Input },

                new MySqlParameter("pRelatedToContactsID", MySqlDbType.VarChar, 50) { Value = null, Direction = ParameterDirection.Input },
                new MySqlParameter("pMessageDate", MySqlDbType.DateTime) { Value = entity.MessageDate, Direction = ParameterDirection.Input },

                new MySqlParameter("pCreateRecurringSeriesOfTasks", entity.CreateRecurringSeriesOfTasks ? 1 : 0) { Direction = ParameterDirection.Input },

                new MySqlParameter("pReminder", entity.Reminder ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pReminderDate", MySqlDbType.VarChar, 45) { Value = entity.ReminderDate, Direction = ParameterDirection.Input },
                new MySqlParameter("pReminderTime", MySqlDbType.VarChar, 45) { Value = entity.ReminderTime, Direction = ParameterDirection.Input },

                new MySqlParameter("pOwnerName", MySqlDbType.VarChar, 100) { Value = entity.OwnerName, Direction = ParameterDirection.Input },
            });

            return parameters.ToArray();
        }

        #endregion
    }
}
