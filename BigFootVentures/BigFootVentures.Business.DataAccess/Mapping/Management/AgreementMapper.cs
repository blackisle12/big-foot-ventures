using BigFootVentures.Business.Objects.Management;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BigFootVentures.Business.DataAccess.Mapping.Management
{
    public sealed class AgreementMapper : IMapper
    {
        #region "Public Methods"

        public ICollection<object> ParseData(MySqlDataReader dataReader)
        {
            var entities = new List<object>();

            while (dataReader.Read())
            {
                var entity = new AgreementT
                {
                    ID = (int)dataReader["ID"],

                    OwnerName = dataReader["OwnerName"] as string,

                    Name = dataReader["Name"] as string,
                    ObjectOfAgreement = dataReader["ObjectOfAgreement"] as string,
                    OtherRelatedTrademarks = dataReader["OtherRelatedTrademarks"] as string,
                    Type = dataReader["Type"] as string,
                    Applicability = dataReader["Applicability"] as string,
                    DateOfSignature = dataReader["DateOfSignature"] as string,
                    Comments = dataReader["Comments"] as string
                };

                if (int.TryParse((dataReader["BFCompanyID"] as int?)?.ToString(), out int BFCompanyID))
                {
                    entity.BFCompany = new Company { ID = BFCompanyID };
                }

                if (int.TryParse((dataReader["counterpartID"] as int?)?.ToString(), out int counterpartID))
                {
                    entity.Counterpart = new Company { ID = counterpartID };
                }

                //trademark

                entities.Add(entity);
            }

            return entities;
        }

        public ICollection<object> ParseDataMin(MySqlDataReader dataReader)
        {
            var entities = new List<object>();

            while (dataReader.Read())
            {
                var entity = new AgreementT
                {
                    ID = (int)dataReader["ID"],

                    Name = dataReader["Name"] as string,
                    BFCompany = new Company
                    {
                        CompanyName = dataReader["BFCompanyName"] as string
                    },
                    Counterpart = new Company
                    {
                        CompanyName = dataReader["CounterpartCompanyName"] as string
                    },
                    Applicability = dataReader["Applicability"] as string,
                    ObjectOfAgreement = dataReader["ObjectOfAgreement"] as string,
                    Type = dataReader["Type"] as string,
                    DateOfSignature = dataReader["DateOfSignature"] as string,

                    OwnerName = dataReader["OwnerName"] as string
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
            var entity = (AgreementT)model;
            var parameters = new List<MySqlParameter>();

            parameters.AddRange(new MySqlParameter[]
            {
                new MySqlParameter("pOwnerName", MySqlDbType.VarChar, 100) { Value = entity.OwnerName, Direction = ParameterDirection.Input },

                new MySqlParameter("pName", MySqlDbType.VarChar, 100) { Value = entity.Name, Direction = ParameterDirection.Input },
                new MySqlParameter("pBFCompanyID", MySqlDbType.Int32) { Value = entity.BFCompany?.ID, Direction = ParameterDirection.Input },
                new MySqlParameter("pCounterpartID", MySqlDbType.Int32) { Value = entity.Counterpart?.ID, Direction = ParameterDirection.Input },
                new MySqlParameter("pObjectOfAgreement", MySqlDbType.VarChar, 45) { Value = entity.ObjectOfAgreement, Direction = ParameterDirection.Input },
                //trademark
                new MySqlParameter("pOtherRelatedTrademarks", MySqlDbType.VarChar, 100) { Value = entity.OtherRelatedTrademarks, Direction = ParameterDirection.Input },
                new MySqlParameter("pType", MySqlDbType.VarChar, 45) { Value = entity.Type, Direction = ParameterDirection.Input },
                new MySqlParameter("pApplicability", MySqlDbType.VarChar, 255) { Value = entity.Applicability, Direction = ParameterDirection.Input },
                new MySqlParameter("pDateOfSignature", MySqlDbType.VarChar, 45) { Value = entity.DateOfSignature, Direction = ParameterDirection.Input },
                new MySqlParameter("pComments", MySqlDbType.VarChar, 255) { Value = entity.Comments, Direction = ParameterDirection.Input },
            });

            return parameters.ToArray();
        }

        #endregion
    }
}
