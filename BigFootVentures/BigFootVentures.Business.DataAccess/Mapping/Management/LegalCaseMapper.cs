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
                    TrademarkNumber = dataReader["TrademarkNumber"] as string,
                    Keywords = dataReader["Keywords"] as string,
                    DateAssigned = dataReader["DateAssigned"] as string,
                    CourtURL = dataReader["CourtURL"] as string,
                    DeletionRequest = (dataReader["DeletionRequest"] as sbyte? ?? 0) == 1,
                    DeletionRequestReason = dataReader["DeletionRequestReason"] as string
                };

                if (int.TryParse((dataReader["TrademarkID"] as int?)?.ToString(), out int trademarkID))
                {
                    entity.Trademark = new Trademark
                    {
                        ID = trademarkID,
                        Name = dataReader["TrademarkName"] as string
                    };
                }

                if (int.TryParse((dataReader["PlainTiffID"] as int?)?.ToString(), out int plainTiffID))
                {
                    entity.Plaintiff = new Company
                    {
                        ID = plainTiffID,
                        DisplayName = dataReader["PlaintiffName"] as string
                    };
                }

                if (int.TryParse((dataReader["DefendantID"] as int?)?.ToString(), out int defendantID))
                {
                    entity.Defendant = new Company
                    {
                        ID = defendantID,
                        DisplayName = dataReader["DefendantName"] as string
                    };
                }

                if (int.TryParse((dataReader["PlaintiffRepresentativeID"] as int?)?.ToString(), out int plaintiffRepresentativeID))
                {
                    entity.PlaintiffRepresentative = new Company
                    {
                        ID = plaintiffRepresentativeID,
                        DisplayName = dataReader["PlaintiffRepresentativeName"] as string
                    };
                }

                if (int.TryParse((dataReader["DefendantRepresentativeID"] as int?)?.ToString(), out int defendantRepresentativeID))
                {
                    entity.DefendantRepresentative = new Company
                    {
                        ID = defendantRepresentativeID,
                        DisplayName = dataReader["DefendantRepresentativeName"] as string
                    };
                }

                entities.Add(entity);
            }

            return entities;
        }

        public ICollection<object> ParseDataMin(MySqlDataReader dataReader)
        {
            var entities = new List<object>();

            while (dataReader.Read())
            {
                var entity = new LegalCase
                {
                    ID = (int)dataReader["ID"],

                    TypeOfCase = dataReader["TypeOfCase"] as string,
                    TrademarkNumber = dataReader["TrademarkNumber"] as string
                };

                if (int.TryParse((dataReader["TrademarkID"] as int?)?.ToString(), out int trademarkID))
                {
                    entity.Trademark = new Trademark
                    {
                        ID = trademarkID,
                        Name = dataReader["TrademarkName"] as string
                    };
                }

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
                new MySqlParameter("pTypeOfCase", MySqlDbType.VarChar, 45) { Value = entity.TypeOfCase, Direction = ParameterDirection.Input },
                new MySqlParameter("pTypeOfCaseExternalClients", MySqlDbType.VarChar, 45) { Value = entity.TypeOfCaseExternalClients, Direction = ParameterDirection.Input },
                new MySqlParameter("pTrademarkID", MySqlDbType.Int32) { Value = entity.Trademark?.ID, Direction = ParameterDirection.Input },
                new MySqlParameter("pTrademarkNumber", MySqlDbType.VarChar, 45) { Value = entity.TrademarkNumber, Direction = ParameterDirection.Input },
                new MySqlParameter("pCancellationExecutionID", MySqlDbType.Int32) { Value = 0, Direction = ParameterDirection.Input },
                new MySqlParameter("pKeywords", MySqlDbType.VarChar, 255) { Value = entity.Keywords, Direction = ParameterDirection.Input },
                new MySqlParameter("pDateAssigned", MySqlDbType.VarChar, 45) { Value = entity.DateAssigned, Direction = ParameterDirection.Input },
                new MySqlParameter("pCourtURL", MySqlDbType.VarChar, 255) { Value = entity.CourtURL, Direction = ParameterDirection.Input },
                new MySqlParameter("pPlainTiffID", MySqlDbType.Int32) { Value = entity.Plaintiff?.ID, Direction = ParameterDirection.Input },
                new MySqlParameter("pDefendantID", MySqlDbType.Int32) { Value = entity.Defendant?.ID, Direction = ParameterDirection.Input },
                new MySqlParameter("pPlaintiffRepresentativeID", MySqlDbType.Int32) { Value = entity.PlaintiffRepresentative?.ID, Direction = ParameterDirection.Input },
                new MySqlParameter("pDefendantRepresentativeID", MySqlDbType.Int32) { Value = entity.DefendantRepresentative?.ID, Direction = ParameterDirection.Input },
                new MySqlParameter("pDeletionRequest", entity.DeletionRequest ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pDeletionRequestReason", MySqlDbType.VarChar, 255) { Value = entity.DeletionRequestReason, Direction = ParameterDirection.Input },
            });

            return parameters.ToArray();
        }

        #endregion
    }
}
