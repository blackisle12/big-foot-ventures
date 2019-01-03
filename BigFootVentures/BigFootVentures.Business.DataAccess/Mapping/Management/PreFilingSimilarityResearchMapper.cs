using BigFootVentures.Business.Objects.Management;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BigFootVentures.Business.DataAccess.Mapping.Management
{
    public sealed class PreFilingSimilarityResearchMapper : IMapper
    {
        public ICollection<object> ParseData(MySqlDataReader dataReader)
        {
            var entities = new List<object>();

            while (dataReader.Read())
            {
                var entity = new PreFilingSimilarityResearch
                {
                    ID = (int)dataReader["ID"],

                    OwnerName = dataReader["OwnerName"] as string,

                    ResearchedBrand = new Brand
                    {
                        ID = Convert.ToInt32(dataReader["ResearchedBrandID"]),
                        Name = dataReader["ResearchedBrandName"] as string
                    },
                    Office = new Office
                    {
                        ID = Convert.ToInt32(dataReader["OfficeID"]),
                        OfficeName = dataReader["OfficeName"] as string
                    },
                    DateOfResearch = dataReader["DateOfResearch"] as string,
                    Comments = dataReader["Comments"] as string,

                    SimilarityLevel = dataReader["SimilarityLevel"] as string,
                    SimilarityLevel2 = dataReader["SimilarityLevel2"] as string,
                    Class1 = dataReader["Class1"] as string,
                    Class1_2 = dataReader["Class1_2"] as string,
                    Class2 = dataReader["Class2"] as string,
                    Class2_2 = dataReader["Class2_2"] as string,
                    Class3 = dataReader["Class3"] as string,
                    Class3_2 = dataReader["Class3_2"] as string,
                    Class4 = dataReader["Class4"] as string,
                    Class4_2 = dataReader["Class4_2"] as string,
                    Class5 = dataReader["Class5"] as string,
                    Class5_2 = dataReader["Class5_2"] as string,
                    Class6 = dataReader["Class6"] as string,
                    Class6_2 = dataReader["Class6_2"] as string,
                    Class7 = dataReader["Class7"] as string,
                    Class7_2 = dataReader["Class7_2"] as string,
                    Class8 = dataReader["Class8"] as string,
                    Class8_2 = dataReader["Class8_2"] as string,
                    Class9 = dataReader["Class9"] as string,
                    Class9_2 = dataReader["Class9_2"] as string,
                    Class10 = dataReader["Class10"] as string,
                    Class10_2 = dataReader["Class10_2"] as string,
                    Class11 = dataReader["Class11"] as string,
                    Class11_2 = dataReader["Class11_2"] as string,
                    Class12 = dataReader["Class12"] as string,
                    Class12_2 = dataReader["Class12_2"] as string,
                    Class13 = dataReader["Class13"] as string,
                    Class13_2 = dataReader["Class13_2"] as string,
                    Class14 = dataReader["Class14"] as string,
                    Class14_2 = dataReader["Class14_2"] as string,
                    Class15 = dataReader["Class15"] as string,
                    Class15_2 = dataReader["Class15_2"] as string,
                    Class16 = dataReader["Class16"] as string,
                    Class16_2 = dataReader["Class16_2"] as string,
                    Class17 = dataReader["Class17"] as string,
                    Class17_2 = dataReader["Class17_2"] as string,
                    Class18 = dataReader["Class18"] as string,
                    Class18_2 = dataReader["Class18_2"] as string,
                    Class19 = dataReader["Class19"] as string,
                    Class19_2 = dataReader["Class19_2"] as string,
                    Class20 = dataReader["Class20"] as string,
                    Class20_2 = dataReader["Class20_2"] as string,
                    Class21 = dataReader["Class21"] as string,
                    Class21_2 = dataReader["Class21_2"] as string,
                    Class22 = dataReader["Class22"] as string,
                    Class22_2 = dataReader["Class22_2"] as string,
                    Class23 = dataReader["Class23"] as string,
                    Class23_2 = dataReader["Class23_2"] as string,
                    Class24 = dataReader["Class24"] as string,
                    Class24_2 = dataReader["Class24_2"] as string,
                    Class25 = dataReader["Class25"] as string,
                    Class25_2 = dataReader["Class25_2"] as string,
                    Class26 = dataReader["Class26"] as string,
                    Class26_2 = dataReader["Class26_2"] as string,
                    Class27 = dataReader["Class27"] as string,
                    Class27_2 = dataReader["Class27_2"] as string,
                    Class28 = dataReader["Class28"] as string,
                    Class28_2 = dataReader["Class28_2"] as string,
                    Class29 = dataReader["Class29"] as string,
                    Class29_2 = dataReader["Class29_2"] as string,
                    Class30 = dataReader["Class30"] as string,
                    Class30_2 = dataReader["Class30_2"] as string,
                    Class31 = dataReader["Class31"] as string,
                    Class31_2 = dataReader["Class31_2"] as string,
                    Class32 = dataReader["Class32"] as string,
                    Class32_2 = dataReader["Class32_2"] as string,
                    Class33 = dataReader["Class33"] as string,
                    Class33_2 = dataReader["Class33_2"] as string,
                    Class34 = dataReader["Class34"] as string,
                    Class34_2 = dataReader["Class34_2"] as string,
                    Class35 = dataReader["Class35"] as string,
                    Class35_2 = dataReader["Class35_2"] as string,
                    Class36 = dataReader["Class36"] as string,
                    Class36_2 = dataReader["Class36_2"] as string,
                    Class37 = dataReader["Class37"] as string,
                    Class37_2 = dataReader["Class37_2"] as string,
                    Class38 = dataReader["Class38"] as string,
                    Class38_2 = dataReader["Class38_2"] as string,
                    Class39 = dataReader["Class39"] as string,
                    Class39_2 = dataReader["Class39_2"] as string,
                    Class40 = dataReader["Class40"] as string,
                    Class40_2 = dataReader["Class40_2"] as string,
                    Class41 = dataReader["Class41"] as string,
                    Class41_2 = dataReader["Class41_2"] as string,
                    Class42 = dataReader["Class42"] as string,
                    Class42_2 = dataReader["Class42_2"] as string,
                    Class43 = dataReader["Class43"] as string,
                    Class43_2 = dataReader["Class43_2"] as string,
                    Class44 = dataReader["Class44"] as string,
                    Class44_2 = dataReader["Class44_2"] as string,
                    Class45 = dataReader["Class45"] as string,
                    Class45_2 = dataReader["Class45_2"] as string
                };

                if (int.TryParse((dataReader["OfficeID"] as int?)?.ToString(), out int officeID))
                {
                    entity.Office = new Office { ID = officeID };
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
                var entity = new PreFilingSimilarityResearch
                {
                    ID = (int)dataReader["ID"],

                    ResearchedBrand = new Brand
                    {
                        ID = Convert.ToInt32(dataReader["ResearchedBrandID"]),
                        Name = dataReader["ResearchedBrandName"] as string
                    },
                    Office = new Office
                    {
                        ID = Convert.ToInt32(dataReader["OfficeID"]),
                        OfficeName = dataReader["OfficeName"] as string
                    },
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
            var entity = (PreFilingSimilarityResearch)model;
            var parameters = new List<MySqlParameter>();

            parameters.AddRange(new MySqlParameter[]
            {
                new MySqlParameter("pOwnerName", MySqlDbType.VarChar, 100) { Value = entity.OwnerName, Direction = ParameterDirection.Input },

                new MySqlParameter("pResearchedBrandID", MySqlDbType.Int32) { Value = entity.ResearchedBrand.ID, Direction = ParameterDirection.Input },
                new MySqlParameter("pOfficeID", MySqlDbType.Int32) { Value = entity.Office.ID, Direction = ParameterDirection.Input },
                new MySqlParameter("pDateOfResearch", MySqlDbType.VarChar, 45) { Value = entity.DateOfResearch, Direction = ParameterDirection.Input },
                new MySqlParameter("pComments", MySqlDbType.VarChar, 255) { Value = entity.Comments, Direction = ParameterDirection.Input },

                new MySqlParameter("pSimilarityLevel", MySqlDbType.VarChar, 45) { Value = entity.SimilarityLevel, Direction = ParameterDirection.Input },
                new MySqlParameter("pSimilarityLevel2", MySqlDbType.VarChar, 45) { Value = entity.SimilarityLevel2, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass1", MySqlDbType.VarChar, 45) { Value = entity.Class1, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass1_2", MySqlDbType.VarChar, 45) { Value = entity.Class1_2, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass2", MySqlDbType.VarChar, 45) { Value = entity.Class2, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass2_2", MySqlDbType.VarChar, 45) { Value = entity.Class2_2, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass3", MySqlDbType.VarChar, 45) { Value = entity.Class3, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass3_2", MySqlDbType.VarChar, 45) { Value = entity.Class3_2, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass4", MySqlDbType.VarChar, 45) { Value = entity.Class4, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass4_2", MySqlDbType.VarChar, 45) { Value = entity.Class4_2, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass5", MySqlDbType.VarChar, 45) { Value = entity.Class5, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass5_2", MySqlDbType.VarChar, 45) { Value = entity.Class5_2, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass6", MySqlDbType.VarChar, 45) { Value = entity.Class6, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass6_2", MySqlDbType.VarChar, 45) { Value = entity.Class6_2, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass7", MySqlDbType.VarChar, 45) { Value = entity.Class7, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass7_2", MySqlDbType.VarChar, 45) { Value = entity.Class7_2, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass8", MySqlDbType.VarChar, 45) { Value = entity.Class8, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass8_2", MySqlDbType.VarChar, 45) { Value = entity.Class8_2, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass9", MySqlDbType.VarChar, 45) { Value = entity.Class9, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass9_2", MySqlDbType.VarChar, 45) { Value = entity.Class9_2, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass10", MySqlDbType.VarChar, 45) { Value = entity.Class10, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass10_2", MySqlDbType.VarChar, 45) { Value = entity.Class10_2, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass11", MySqlDbType.VarChar, 45) { Value = entity.Class11, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass11_2", MySqlDbType.VarChar, 45) { Value = entity.Class11_2, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass12", MySqlDbType.VarChar, 45) { Value = entity.Class12, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass12_2", MySqlDbType.VarChar, 45) { Value = entity.Class12_2, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass13", MySqlDbType.VarChar, 45) { Value = entity.Class13, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass13_2", MySqlDbType.VarChar, 45) { Value = entity.Class13_2, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass14", MySqlDbType.VarChar, 45) { Value = entity.Class14, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass14_2", MySqlDbType.VarChar, 45) { Value = entity.Class14_2, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass15", MySqlDbType.VarChar, 45) { Value = entity.Class15, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass15_2", MySqlDbType.VarChar, 45) { Value = entity.Class15_2, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass16", MySqlDbType.VarChar, 45) { Value = entity.Class16, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass16_2", MySqlDbType.VarChar, 45) { Value = entity.Class16_2, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass17", MySqlDbType.VarChar, 45) { Value = entity.Class17, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass17_2", MySqlDbType.VarChar, 45) { Value = entity.Class17_2, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass18", MySqlDbType.VarChar, 45) { Value = entity.Class18, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass18_2", MySqlDbType.VarChar, 45) { Value = entity.Class18_2, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass19", MySqlDbType.VarChar, 45) { Value = entity.Class19, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass19_2", MySqlDbType.VarChar, 45) { Value = entity.Class19_2, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass20", MySqlDbType.VarChar, 45) { Value = entity.Class20, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass20_2", MySqlDbType.VarChar, 45) { Value = entity.Class20_2, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass21", MySqlDbType.VarChar, 45) { Value = entity.Class21, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass21_2", MySqlDbType.VarChar, 45) { Value = entity.Class21_2, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass22", MySqlDbType.VarChar, 45) { Value = entity.Class22, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass22_2", MySqlDbType.VarChar, 45) { Value = entity.Class22_2, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass23", MySqlDbType.VarChar, 45) { Value = entity.Class23, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass23_2", MySqlDbType.VarChar, 45) { Value = entity.Class23_2, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass24", MySqlDbType.VarChar, 45) { Value = entity.Class24, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass24_2", MySqlDbType.VarChar, 45) { Value = entity.Class24_2, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass25", MySqlDbType.VarChar, 45) { Value = entity.Class25, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass25_2", MySqlDbType.VarChar, 45) { Value = entity.Class25_2, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass26", MySqlDbType.VarChar, 45) { Value = entity.Class26, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass26_2", MySqlDbType.VarChar, 45) { Value = entity.Class26_2, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass27", MySqlDbType.VarChar, 45) { Value = entity.Class27, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass27_2", MySqlDbType.VarChar, 45) { Value = entity.Class27_2, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass28", MySqlDbType.VarChar, 45) { Value = entity.Class28, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass28_2", MySqlDbType.VarChar, 45) { Value = entity.Class28_2, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass29", MySqlDbType.VarChar, 45) { Value = entity.Class29, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass29_2", MySqlDbType.VarChar, 45) { Value = entity.Class29_2, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass30", MySqlDbType.VarChar, 45) { Value = entity.Class30, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass30_2", MySqlDbType.VarChar, 45) { Value = entity.Class30_2, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass31", MySqlDbType.VarChar, 45) { Value = entity.Class31, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass31_2", MySqlDbType.VarChar, 45) { Value = entity.Class31_2, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass32", MySqlDbType.VarChar, 45) { Value = entity.Class32, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass32_2", MySqlDbType.VarChar, 45) { Value = entity.Class32_2, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass33", MySqlDbType.VarChar, 45) { Value = entity.Class33, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass33_2", MySqlDbType.VarChar, 45) { Value = entity.Class33_2, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass34", MySqlDbType.VarChar, 45) { Value = entity.Class34, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass34_2", MySqlDbType.VarChar, 45) { Value = entity.Class34_2, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass35", MySqlDbType.VarChar, 45) { Value = entity.Class35, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass35_2", MySqlDbType.VarChar, 45) { Value = entity.Class35_2, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass36", MySqlDbType.VarChar, 45) { Value = entity.Class36, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass36_2", MySqlDbType.VarChar, 45) { Value = entity.Class36_2, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass37", MySqlDbType.VarChar, 45) { Value = entity.Class37, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass37_2", MySqlDbType.VarChar, 45) { Value = entity.Class37_2, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass38", MySqlDbType.VarChar, 45) { Value = entity.Class38, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass38_2", MySqlDbType.VarChar, 45) { Value = entity.Class38_2, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass39", MySqlDbType.VarChar, 45) { Value = entity.Class39, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass39_2", MySqlDbType.VarChar, 45) { Value = entity.Class39_2, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass40", MySqlDbType.VarChar, 45) { Value = entity.Class40, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass40_2", MySqlDbType.VarChar, 45) { Value = entity.Class40_2, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass41", MySqlDbType.VarChar, 45) { Value = entity.Class41, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass41_2", MySqlDbType.VarChar, 45) { Value = entity.Class41_2, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass42", MySqlDbType.VarChar, 45) { Value = entity.Class42, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass42_2", MySqlDbType.VarChar, 45) { Value = entity.Class42_2, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass43", MySqlDbType.VarChar, 45) { Value = entity.Class43, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass43_2", MySqlDbType.VarChar, 45) { Value = entity.Class43_2, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass44", MySqlDbType.VarChar, 45) { Value = entity.Class44, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass44_2", MySqlDbType.VarChar, 45) { Value = entity.Class44_2, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass45", MySqlDbType.VarChar, 45) { Value = entity.Class45, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass45_2", MySqlDbType.VarChar, 45) { Value = entity.Class45_2, Direction = ParameterDirection.Input },
            });

            return parameters.ToArray();
        }
    }
}
