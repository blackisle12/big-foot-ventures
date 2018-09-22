using BigFootVentures.Business.Objects.Management;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace BigFootVentures.Business.DataAccess.Mapping.Management
{
    public sealed class BrandMapper : IMapper
    {
        #region "Public Methods"

        public ICollection<object> ParseData(MySqlDataReader dataReader)
        {
            var entities = new List<object>();

            while (dataReader.Read())
            {
                entities.Add(new Brand
                {
                    ID = (int)dataReader["ID"],
                    Name = dataReader["NAME"] as string,
                    Purpose = dataReader["PURPOSE"] as string,
                    Value = dataReader["VALUE"] as string,
                    HVT = dataReader["HVT"] as string,
                    EMV = dataReader["EMV"] as string,
                    DeletionRequest = dataReader["DELETION_REQUEST"] as string,
                    DeletionRequestReason = dataReader["DELETION_REQUEST_REASON"] as string,
                    Category = dataReader["CATEGORY"] as string,
                    OwnerName = dataReader["Owner_Name"] as string,
                    Premium = dataReader["PREMIUM__C"] as string,
                    CharacterCount = dataReader["CHARACTER_COUNT__C"] as string,
                    BNF = dataReader["BNF__C"] as string
                });
            }

            return entities;
        }

        public MySqlParameter[] CreateParameters(object entity)
        {
            var brand = (Brand)entity;
            var parameters = new List<MySqlParameter>();

            parameters.AddRange(new MySqlParameter[]
            {
                new MySqlParameter("pName", MySqlDbType.VarChar, 100) { Value = brand.Name, Direction = ParameterDirection.Input },
                new MySqlParameter("pPurpose", MySqlDbType.VarChar, 100) { Value = brand.Purpose, Direction = ParameterDirection.Input },
                new MySqlParameter("pValue", MySqlDbType.VarChar, 100) { Value = brand.Value, Direction = ParameterDirection.Input },
                new MySqlParameter("pHVT", MySqlDbType.VarChar, 100) { Value = brand.HVTChk.ToString(), Direction = ParameterDirection.Input },
                new MySqlParameter("pEMV", MySqlDbType.VarChar, 100) { Value = brand.EMV, Direction = ParameterDirection.Input },
                new MySqlParameter("pDeletionRequest", MySqlDbType.VarChar, 100) { Value = brand.DeletionRequestChk, Direction = ParameterDirection.Input },
                new MySqlParameter("pDeletionRequestReason", MySqlDbType.VarChar, 255) { Value = brand.DeletionRequestReason, Direction = ParameterDirection.Input },
                new MySqlParameter("pCategory", MySqlDbType.VarChar, 255) { Value = brand.Category, Direction = ParameterDirection.Input }
            });

            return parameters.ToArray();
        }

        #endregion     
    }
}
