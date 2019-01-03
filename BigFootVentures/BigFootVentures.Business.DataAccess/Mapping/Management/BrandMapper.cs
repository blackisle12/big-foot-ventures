using BigFootVentures.Business.Objects.Management;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Text;

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
                var entity = new Brand
                {
                    ID = (int)dataReader["ID"],

                    OwnerName = dataReader["Owner_Name"] as string,

                    Name = dataReader["NAME"] as string,
                    Purpose = dataReader["PURPOSE"] as string,
                    Value = dataReader["VALUE"] as string,
                    HVT = dataReader["HVT"] as string,
                    EMV = dataReader["EMV"] as string,
                    Category = dataReader["CATEGORY"] as string,

                    DeletionRequest = dataReader["DELETION_REQUEST"] as string,
                    DeletionRequestReason = dataReader["DELETION_REQUEST_REASON"] as string,

                    Premium = dataReader["PREMIUM__C"] as string,
                    CharacterCount = dataReader["CHARACTER_COUNT__C"] as string,
                    BNF = dataReader["BNF__C"] as string
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
                var entity = new Brand
                {
                    ID = (int)dataReader["ID"],

                    Name = dataReader["NAME"] as string,
                    Purpose = dataReader["PURPOSE"] as string,
                    Value = dataReader["VALUE"] as string,
                    HVT = dataReader["HVT"] as string,
                    EMV = dataReader["EMV"] as string,
                    Category = dataReader["CATEGORY"] as string,
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
            var entity = (Brand)model;
            var parameters = new List<MySqlParameter>();

            parameters.AddRange(new MySqlParameter[]
            {
                new MySqlParameter("pName", MySqlDbType.VarChar, 100) { Value = entity.Name, Direction = ParameterDirection.Input },
                new MySqlParameter("pPurpose", MySqlDbType.VarChar, 100) { Value = entity.Purpose, Direction = ParameterDirection.Input },
                new MySqlParameter("pValue", MySqlDbType.VarChar, 100) { Value = entity.Value, Direction = ParameterDirection.Input },
                new MySqlParameter("pHVT", MySqlDbType.VarChar, 100) { Value = entity.HVTChk.ToString(), Direction = ParameterDirection.Input },
                new MySqlParameter("pEMV", MySqlDbType.VarChar, 100) { Value = entity.EMV, Direction = ParameterDirection.Input },
                new MySqlParameter("pCategory", MySqlDbType.VarChar, 255) { Value = entity.Category, Direction = ParameterDirection.Input },

                new MySqlParameter("pDeletionRequest", MySqlDbType.VarChar, 100) { Value = entity.DeletionRequestChk, Direction = ParameterDirection.Input },
                new MySqlParameter("pDeletionRequestReason", MySqlDbType.VarChar, 255) { Value = entity.DeletionRequestReason, Direction = ParameterDirection.Input }
            });

            return parameters.ToArray();
        }

        #endregion
    }
}
