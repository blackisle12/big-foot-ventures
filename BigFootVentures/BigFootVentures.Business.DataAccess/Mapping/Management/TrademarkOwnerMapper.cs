using BigFootVentures.Business.Objects.Management;
using MySql.Data.MySqlClient;
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
                };

                if (int.TryParse((dataReader["TrademarkID"] as int?)?.ToString(), out int trademarkID))
                {
                    entity.Trademark = new Trademark { ID = trademarkID };
                }

                if (int.TryParse((dataReader["CompanyID"] as int?)?.ToString(), out int companyID))
                {
                    entity.Company = new Company { ID = companyID };
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
                var entity = new TrademarkOwner
                {
                    ID = (int)dataReader["ID"],
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
                new MySqlParameter("pTrademarkID", MySqlDbType.Int32) { Value = entity.Trademark?.ID, Direction = ParameterDirection.Input },
                new MySqlParameter("pCompanyID", MySqlDbType.Int32) { Value = entity.Company?.ID, Direction = ParameterDirection.Input }
            });

            return parameters.ToArray();
        }

        #endregion
    }
}
