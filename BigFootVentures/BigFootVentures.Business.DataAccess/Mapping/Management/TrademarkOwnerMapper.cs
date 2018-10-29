using BigFootVentures.Business.Objects.Management;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace BigFootVentures.Business.DataAccess.Mapping.Management
{
    public sealed class TrademarkOwnerMapper: IMapper
    {
        #region"Public Methods"

        public ICollection<object> ParseData(MySqlDataReader dataReader)
        {
            var entities = new List<object>();

            while (dataReader.Read())
            {
                var entity = new TrademarkOwner
                {
                    ID = (int)dataReader["ID"],

                    Trademark = new Trademark
                    {
                        ID = Convert.ToInt32(dataReader["TrademarkID"]),
                        Name = dataReader["TrademarkName"] as string
                    },
                    Company = new Company
                    {
                        ID = Convert.ToInt32(dataReader["CompanyID"]),
                        DisplayName = dataReader["CompanyName"] as string
                    }
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
                var entity = new TrademarkOwner
                {
                    ID = (int)dataReader["ID"],

                    Trademark = new Trademark
                    {
                        ID = Convert.ToInt32(dataReader["TrademarkID"]),
                        Name = dataReader["TrademarkName"] as string
                    },
                    Company = new Company
                    {
                        ID = Convert.ToInt32(dataReader["CompanyID"]),
                        DisplayName = dataReader["CompanyName"] as string
                    }
                };

                entities.Add(entity);
            }

            return entities;
        }

        public MySqlParameter[] CreateParameters(object model)
        {
            var entity = (TrademarkOwner)model;
            var parameters = new List<MySqlParameter>();

            parameters.AddRange(new MySqlParameter[]
            {
                new MySqlParameter("pTrademarkID", MySqlDbType.Int32) { Value = entity.Trademark.ID, Direction = ParameterDirection.Input },
                new MySqlParameter("pCompanyID", MySqlDbType.Int32) { Value = entity.Company.ID, Direction = ParameterDirection.Input }
            });

            return parameters.ToArray();
        }

        #endregion
    }
}
