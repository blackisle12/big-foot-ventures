using BigFootVentures.Business.Objects.Management;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BigFootVentures.Business.DataAccess.Mapping.Management
{
    public sealed class SimilarTrademarkMapper : IMapper
    {
        #region "Public Methods"

        public ICollection<object> ParseData(MySqlDataReader dataReader)
        {
            var entities = new List<object>();
            
            while (dataReader.Read())
            {
                var entity = new SimilarTrademark
                {
                    ID = (int)dataReader["ID"],

                    OwnerName = dataReader["OwnerName"] as string,

                    Trademark = new Trademark { ID = Convert.ToInt32(dataReader["TrademarkID"]) },
                    TrademarkSimilar = new Trademark { ID = Convert.ToInt32(dataReader["TrademarkSimilarID"]) },
                    Comment = dataReader["Comment"] as string,
                    Conflict = (dataReader["Conflict"] as sbyte? ?? 0) == 1,
                    CreateOppositionCheck = (dataReader["CreateOppositionCheck"] as sbyte? ?? 0) == 1,

                    ClassSummaryTM = dataReader["ClassSummaryTM"] as string,
                    ClassSummarySimilarTM = dataReader["ClassSummarySimilarTM"] as string,

                    Remarks = dataReader["Remarks"] as string,
                    RefilingEvaluation = dataReader["RefilingEvaluation"] as string,
                    RefilingComment = dataReader["RefilingComment"] as string,
                    OppositionEvaluation = dataReader["OppositionEvaluation"] as string,
                    OppositionComment = dataReader["OppositionComment"] as string
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
                var entity = new SimilarTrademark
                {
                    ID = (int)dataReader["ID"],

                    Trademark = new Trademark { Name = dataReader["TrademarkName"] as string },
                    TrademarkSimilar = new Trademark {  Name = dataReader["TrademarkSimilarName"] as string }
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
            var entity = (SimilarTrademark)model;
            var parameters = new List<MySqlParameter>();

            parameters.AddRange(new MySqlParameter[]
            {
                new MySqlParameter("pOwnerName", MySqlDbType.VarChar, 100) { Value = entity.OwnerName, Direction = ParameterDirection.Input },

                new MySqlParameter("pTrademarkID", MySqlDbType.Int32) { Value = entity.Trademark.ID, Direction = ParameterDirection.Input },
                new MySqlParameter("pTrademarkSimilarID", MySqlDbType.Int32) { Value = entity.TrademarkSimilar.ID, Direction = ParameterDirection.Input },
                new MySqlParameter("pComment", MySqlDbType.VarChar, 255) { Value = entity.Comment, Direction = ParameterDirection.Input },
                new MySqlParameter("pConflict", entity.Conflict ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pCreateOppositionCheck", entity.CreateOppositionCheck ? 1 : 0) { Direction = ParameterDirection.Input },

                new MySqlParameter("pClassSummaryTM", MySqlDbType.VarChar, 255) { Value = entity.ClassSummaryTM, Direction = ParameterDirection.Input },
                new MySqlParameter("pClassSummarySimilarTM", MySqlDbType.VarChar, 255) { Value = entity.ClassSummarySimilarTM, Direction = ParameterDirection.Input },

                new MySqlParameter("pRemarks", MySqlDbType.VarChar, 255) { Value = entity.Remarks, Direction = ParameterDirection.Input },
                new MySqlParameter("pRefilingEvaluation", MySqlDbType.VarChar, 45) { Value = entity.RefilingEvaluation, Direction = ParameterDirection.Input },
                new MySqlParameter("pRefilingComment", MySqlDbType.VarChar, 255) { Value = entity.RefilingComment, Direction = ParameterDirection.Input },
                new MySqlParameter("pOppositionEvaluation", MySqlDbType.VarChar, 45) { Value = entity.OppositionEvaluation, Direction = ParameterDirection.Input },
                new MySqlParameter("pOppositionComment", MySqlDbType.VarChar, 255) { Value = entity.OppositionComment, Direction = ParameterDirection.Input }
            });

            return parameters.ToArray();
        }

        #endregion
    }
}
