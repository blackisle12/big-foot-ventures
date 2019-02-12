using BigFootVentures.Business.Objects.Management;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BigFootVentures.Business.DataAccess.Mapping.Management
{
    public sealed class TMRepresentativeMapper : IMapper
    {
        #region "Public Methods"

        public ICollection<object> ParseData(MySqlDataReader dataReader)
        {
            var entities = new List<object>();

            while (dataReader.Read())
            {
                var entity = new TMRepresentative
                {
                    ID = (int)dataReader["ID"],

                    TMRepresentativeName = dataReader["TMRepresentativeName"] as string,

                    Trademark = new Trademark
                    {
                        ID = Convert.ToInt32(dataReader["TrademarkID"]),
                        Name = dataReader["TrademarkName"] as string
                    },
                    Representative = new Company
                    {
                        ID = Convert.ToInt32(dataReader["RepresentativeID"]),
                        DisplayName = dataReader["RepresentativeName"] as string
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
                var entity = new TMRepresentative
                {
                    ID = (int)dataReader["ID"],

                    TMRepresentativeName = dataReader["TMRepresentativeName"] as string,

                    Trademark = new Trademark
                    {
                        ID = Convert.ToInt32(dataReader["TrademarkID"]),
                        Name = dataReader["TrademarkName"] as string
                    },
                    Representative = new Company
                    {
                        ID = Convert.ToInt32(dataReader["RepresentativeID"]),
                        DisplayName = dataReader["RepresentativeName"] as string
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
            var entity = (TMRepresentative)model;
            var parameters = new List<MySqlParameter>();

            parameters.AddRange(new MySqlParameter[]
            {
                new MySqlParameter("pTMRepresentativeName", MySqlDbType.VarChar, 200) { Value = entity.TMRepresentativeName, Direction = ParameterDirection.Input },
                new MySqlParameter("pTrademarkID", MySqlDbType.Int32) { Value = entity.Trademark.ID, Direction = ParameterDirection.Input },
                new MySqlParameter("pRepresentativeID", MySqlDbType.Int32) { Value = entity.Representative.ID, Direction = ParameterDirection.Input },
            });

            return parameters.ToArray();
        }

        #endregion
    }
}
