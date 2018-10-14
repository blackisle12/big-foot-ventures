using BigFootVentures.Business.Objects.Management;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace BigFootVentures.Business.DataAccess.Mapping.Management
{
    public sealed class LegalCaseMapper : IMapper
    {
        #region "Public Methods"

        public ICollection<object> ParseData(MySqlDataReader dataReader)
        {
            var entities = new List<object>();

            while (dataReader.Read())
            {
                var entity = new LegalCase
                {
                    ID = (int)dataReader["ID"],
                    TypeOfCase = dataReader["TypeOfCase"] as string,
                    TypeOfCaseExternalClients = dataReader["TypeOfCaseExternalClients"] as string,
                    Trademark = dataReader["Trademark"] as string,
                    TrademarkNumber = dataReader["TrademarkNumber"] as string,
                    TobeAssignedTo = dataReader["TobeAssignedTo"] as string,
                    Opposition = dataReader["Opposition"] as string,
                    CancellationExecution = dataReader["CancellationExecution"] as string,
                    Keywords = dataReader["Keywords"] as string,
                    DateAssigned = dataReader["DateAssigned"] as string,
                    CourtUrl = dataReader["CourtUrl"] as string,
                    Plantiff = dataReader["Plantiff"] as string,
                    Defendant = dataReader["Defendant"] as string,
                    PlantiffRepresentative = dataReader["PlantiffRepresentative"] as string,
                    DefendantRepsentative = dataReader["DefendantRepsentative"] as string,
                    InChangeOfTracking = dataReader["InChangeOfTracking"] as string,
                    DeletionRequest = ((dataReader["DeletionRequest"] as sbyte? ?? 0) == 1),
                    DeletionRequestReason = dataReader["DeletionRequestReason"] as string,
                };

                entities.Add(entity);
            }

            return entities;
        }

        public MySqlParameter[] CreateParameters(object model)
        {
            var entity = (LegalCase)model;
            var parameters = new List<MySqlParameter>();

            parameters.AddRange(new MySqlParameter[]
            {
                new MySqlParameter("pTypeOfCase", MySqlDbType.VarChar, 100) { Value = entity.TypeOfCase, Direction = ParameterDirection.Input },
                new MySqlParameter("pTypeOfCaseExternalClients", MySqlDbType.VarChar, 100) { Value = entity.TypeOfCaseExternalClients, Direction = ParameterDirection.Input },
                new MySqlParameter("pTrademark", MySqlDbType.VarChar, 100) { Value = entity.Trademark, Direction = ParameterDirection.Input },
                new MySqlParameter("pTrademarkNumber", MySqlDbType.VarChar, 255) { Value = entity.TrademarkNumber, Direction = ParameterDirection.Input },
                new MySqlParameter("pTobeAssignedTo", MySqlDbType.VarChar, 100) { Value = entity.TobeAssignedTo, Direction = ParameterDirection.Input },
                new MySqlParameter("pOpposition", MySqlDbType.VarChar, 100) { Value = entity.Opposition, Direction = ParameterDirection.Input },
                new MySqlParameter("pCancellationExecution", MySqlDbType.VarChar, 100) { Value = entity.CancellationExecution, Direction = ParameterDirection.Input },
                new MySqlParameter("pKeywords", MySqlDbType.VarChar, 100) { Value = entity.Keywords, Direction = ParameterDirection.Input },
                new MySqlParameter("pDateAssigned", MySqlDbType.VarChar, 100) { Value = entity.DateAssigned, Direction = ParameterDirection.Input },
                new MySqlParameter("pCourtUrl", MySqlDbType.VarChar, 100) { Value = entity.CourtUrl, Direction = ParameterDirection.Input },
                new MySqlParameter("pPlantiff", MySqlDbType.VarChar, 100) { Value = entity.Plantiff, Direction = ParameterDirection.Input },
                new MySqlParameter("pDefendant", MySqlDbType.VarChar, 100) { Value = entity.Defendant, Direction = ParameterDirection.Input },
                new MySqlParameter("pPlantiffRepresentative", MySqlDbType.VarChar, 100) { Value = entity.PlantiffRepresentative, Direction = ParameterDirection.Input },
                new MySqlParameter("pDefendantRepsentative", MySqlDbType.VarChar, 100) { Value = entity.DefendantRepsentative, Direction = ParameterDirection.Input },
                new MySqlParameter("pInChangeOfTracking", MySqlDbType.VarChar, 100) { Value = entity.InChangeOfTracking, Direction = ParameterDirection.Input },
                new MySqlParameter("pDeletionRequest", entity.DeletionRequest ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pDeletionRequestReason", MySqlDbType.VarChar, 100) { Value = entity.DeletionRequestReason, Direction = ParameterDirection.Input },
            });

            return parameters.ToArray();
        }

        #endregion
    }
}
