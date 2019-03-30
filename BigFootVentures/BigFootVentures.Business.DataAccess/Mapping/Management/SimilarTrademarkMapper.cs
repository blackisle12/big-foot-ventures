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

                if (int.TryParse((dataReader["TrademarkID"] as int?)?.ToString(), out int trademarkID))
                {
                    if (trademarkID > 0)
                    {
                        entity.Trademark = new Trademark
                        {
                            ID = trademarkID,
                            Name = dataReader["TrademarkName"] as string,
                            TrademarkNumber = dataReader["TrademarkNumber"] as string,
                            Brand = new Brand
                            {
                                Name = dataReader["TrademarkBrandName"] as string
                            },
                            FilingDateValue = dataReader["TrademarkFilingDate"] as string,
                            PublicationDate = dataReader["TrademarkPublicationDate"] as string,
                            PriorityDate = dataReader["TrademarkPriorityDate"] as string,
                            PriorityCountryAndPriorityTMNumber = dataReader["TrademarkPriorityCountry"] as string,
                            //SixMonthsAnniversary = dataReader["TrademarkSixMonthsAnniversary"] as string,
                            Office = new Office
                            {
                                OfficeName = dataReader["TrademarkOfficeName"] as string
                            },
                            BigfootGroupOwned = dataReader["TrademarkBigFootGroupOwned"] as string,
                            OwnerName = dataReader["TrademarkOwnerName"] as string
                        };
                    }
                }

                if (int.TryParse((dataReader["TrademarkSimilarID"] as int?)?.ToString(), out int trademarkSimilarID))
                {
                    if (trademarkSimilarID > 0)
                    {
                        entity.TrademarkSimilar = new Trademark
                        {
                            ID = trademarkID,
                            Name = dataReader["TrademarkSimilarName"] as string,
                            TrademarkNumber = dataReader["TrademarkSimilarNumber"] as string,
                            Brand = new Brand
                            {
                                Name = dataReader["TrademarkSimilarBrandName"] as string
                            },
                            FilingDateValue = dataReader["TrademarkSimilarFilingDate"] as string,
                            PublicationDate = dataReader["TrademarkSimilarPublicationDate"] as string,
                            PriorityDate = dataReader["TrademarkSimilarPriorityDate"] as string,
                            PriorityCountryAndPriorityTMNumber = dataReader["TrademarkSimilarPriorityCountry"] as string,
                            //SixMonthsAnniversary = dataReader["TrademarkSimilarSixMonthsAnniversary"] as string,
                            Office = new Office
                            {
                                OfficeName = dataReader["TrademarkSimilarOfficeName"] as string
                            },
                            BigfootGroupOwned = dataReader["TrademarkSimilarBigFootGroupOwned"] as string,
                            OwnerName = dataReader["TrademarkSimilarOwnerName"] as string
                        };
                    }
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
                var entity = new SimilarTrademark
                {
                    ID = (int)dataReader["ID"],

                    Trademark = new Trademark
                    {
                        ID = Convert.ToInt32(dataReader["TrademarkID"]),
                        Name = dataReader["TrademarkName"] as string
                    },
                    TrademarkSimilar = new Trademark
                    {
                        ID = Convert.ToInt32(dataReader["TrademarkSimilarID"]),
                        Name = dataReader["TrademarkSimilarName"] as string
                    }
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
