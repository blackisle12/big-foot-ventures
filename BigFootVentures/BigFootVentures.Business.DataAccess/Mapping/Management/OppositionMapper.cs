using BigFootVentures.Business.Objects.Management;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BigFootVentures.Business.DataAccess.Mapping.Management
{
    public sealed class OppositionMapper : IMapper
    {
        #region "Public Methods"

        public ICollection<object> ParseData(MySqlDataReader dataReader)
        {
            var entities = new List<object>();

            while (dataReader.Read())
            {
                var entity = new Opposition
                {
                    ID = (int)dataReader["ID"],

                    OppositionName = dataReader["OppositionName"] as string,

                    TrademarkRoleA = dataReader["TrademarkRoleA"] as string,
                    TrademarkRoleD = dataReader["TrademarkRoleD"] as string,
                    ClassDescriptionsAttacking = dataReader["ClassDescriptionsAttacking"] as string,
                    ClassDescriptionsDefending = dataReader["ClassDescriptionsDefending"] as string,
                    OppositionStatus = dataReader["OppositionStatus"] as string,
                    InternalCaseNumber = dataReader["InternalCaseNumber"] as string,
                    DeletionRequest = (dataReader["DeletionRequest"] as sbyte? ?? 0) == 1,
                    DeletionRequestReason = dataReader["DeletionRequestReason"] as string,

                    OppositionDeadline = dataReader["OppositionDeadline"] as string,
                    OppositionCost = dataReader["OppositionCost"] as string,
                    CeaseAndDesistLetterPreApproval = dataReader["CeaseAndDesistLetterPreApproval"] as string,
                    CeaseAndDesistLetterPreApprovedBy = dataReader["CeaseAndDesistLetterPreApprovedBy"] as string,
                    CeaseAndDesistLetterPreApprovedOn = dataReader["CeaseAndDesistLetterPreApprovedOn"] as string,
                    CeaseAndDesistLetterApproval = dataReader["CeaseAndDesistLetterApproval"] as string,
                    CeaseAndDesistLetterApprovedBy = dataReader["CeaseAndDesistLetterApprovedBy"] as string,
                    CeaseAndDesistLetterApprovedOn = dataReader["CeaseAndDesistLetterApprovedOn"] as string,
                    CeaseAndDesistLetterReference = dataReader["CeaseAndDesistLetterReference"] as string,
                    CeaseAndDesistLetterOrigin = dataReader["CeaseAndDesistLetterOrigin"] as string,
                    CeaseAndDesistLetterSendingMethod = dataReader["CeaseAndDesistLetterSendingMethod"] as string,
                    CeaseAndDesistLetterSentOn = dataReader["CeaseAndDesistLetterSentOn"] as string,
                    CeaseAndDesistLetterOutcome = dataReader["CeaseAndDesistLetterOutcome"] as string,
                    IPOOppositionApproval = dataReader["IPOOppositionApproval"] as string,
                    IPOOppositionApprovedBy = dataReader["IPOOppositionApprovedBy"] as string,
                    IPOOppositionApprovedOn = dataReader["IPOOppositionApprovedOn"] as string,
                    IPOOppositionNumber = dataReader["IPOOppositionNumber"] as string,
                    IPOOppositionLanguage = dataReader["IPOOppositionLanguage"] as string,
                    IPOOppositionLink = dataReader["IPOOppositionLink"] as string,
                    IPOOppositionStatus = dataReader["IPOOppositionStatus"] as string,
                    OppositionComments = dataReader["OppositionComments"] as string
                };

                if (int.TryParse((dataReader["TrademarkNameA"] as int?)?.ToString(), out int trademarkNameA))
                {
                    if (trademarkNameA > 0)
                    {
                        entity.TrademarkNameA = new Trademark
                        {
                            ID = trademarkNameA,
                            Name = dataReader["TrademarkNameAName"] as string,
                            TrademarkNumber = dataReader["TrademarkNameATrademarkNumber"] as string,
                            Brand = new Brand
                            {
                                Name = dataReader["TrademarkNameABrand"] as string,
                                Purpose = dataReader["TrademarkNameAPurpose"] as string,
                                Value = dataReader["TrademarkNameAValue"] as string,
                                Category = dataReader["TrademarkNameACategory"] as string,
                                HVT = dataReader["TrademarkNameAHVT"] as string
                            },
                            FilingDateValue = dataReader["TrademarkNameAFilingDate"] as string,
                            PublicationDate = dataReader["TrademarkNameAPublicationDate"] as string,
                            PriorityDate = dataReader["TrademarkNameAPriorityDate"] as string,
                            //SixMonthsAnniversary = dataReader["TrademarkNameASixMonthsAnniversary"] as string,
                            Office = new Office
                            {
                                OfficeName = dataReader["TrademarkNameAOfficeName"] as string
                            },
                            BigfootGroupOwned = dataReader["TrademarkNameABigFootGroupOwned"] as string,
                            PriorityCountryAndPriorityTMNumber = dataReader["TrademarkNameAPriorityCountry"] as string,
                            OwnerName = dataReader["TrademarkNameAOwnerName"] as string
                        };
                    }
                }

                if (int.TryParse((dataReader["TrademarkNameD"] as int?)?.ToString(), out int trademarkNameD))
                {
                    if (trademarkNameD > 0)
                    {
                        entity.TrademarkNameD = new Trademark
                        {
                            ID = trademarkNameD,
                            Name = dataReader["TrademarkNameDName"] as string,
                            TrademarkNumber = dataReader["TrademarkNameDTrademarkNumber"] as string,
                            Brand = new Brand
                            {
                                Name = dataReader["TrademarkNameDBrand"] as string,
                                Purpose = dataReader["TrademarkNameDPurpose"] as string,
                                Value = dataReader["TrademarkNameDValue"] as string,
                                Category = dataReader["TrademarkNameDCategory"] as string,
                                HVT = dataReader["TrademarkNameDHVT"] as string
                            },
                            FilingDateValue = dataReader["TrademarkNameDFilingDate"] as string,
                            PublicationDate = dataReader["TrademarkNameDPublicationDate"] as string,
                            PriorityDate = dataReader["TrademarkNameDPriorityDate"] as string,
                            //SixMonthsAnniversary = dataReader["TrademarkNameDSixMonthsAnniversary"] as string,
                            Office = new Office
                            {
                                OfficeName = dataReader["TrademarkNameDOfficeName"] as string
                            },
                            BigfootGroupOwned = dataReader["TrademarkNameDBigFootGroupOwned"] as string,
                            PriorityCountryAndPriorityTMNumber = dataReader["TrademarkNameDPriorityCountry"] as string,
                            OwnerName = dataReader["TrademarkNameDOwnerName"] as string
                        };
                    }
                }

                if (int.TryParse((dataReader["OwnerApplicantsRepresentative"] as int?)?.ToString(), out int ownerApplicantsRepresentative))
                {
                    if (ownerApplicantsRepresentative > 0)
                    {
                        entity.OwnerApplicantsRepresentative = new Company
                        {
                            ID = ownerApplicantsRepresentative,
                            CompanyName = dataReader["OwnerApplicantsRepresentativeName"] as string
                        };
                    }
                }

                if (int.TryParse((dataReader["OpponentsRepresentative"] as int?)?.ToString(), out int opponentsRepresentative))
                {
                    if (opponentsRepresentative > 0)
                    {
                        entity.OpponentsRepresentative = new Company
                        {
                            ID = opponentsRepresentative,
                            CompanyName = dataReader["OpponentsRepresentativeName"] as string
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
                var entity = new Opposition
                {
                    ID = (int)dataReader["ID"],

                    OppositionName = dataReader["OppositionName"] as string,

                    TrademarkRoleA = dataReader["TrademarkRoleA"] as string,
                    TrademarkRoleD = dataReader["TrademarkRoleD"] as string
                };

                if (int.TryParse((dataReader["TrademarkNameA"] as int?)?.ToString(), out int trademarkNameA))
                {
                    if (trademarkNameA > 0)
                    {
                        entity.TrademarkNameA = new Trademark
                        {
                            ID = trademarkNameA,
                            Name = dataReader["TrademarkNameAName"] as string,
                            TrademarkNumber = dataReader["TrademarkNameATrademarkNumber"] as string,
                            Office = new Office
                            {
                                OfficeName = dataReader["TrademarkNameAOfficeName"] as string
                            },
                            BigfootGroupOwned = dataReader["TrademarkNameABigFootGroupOwned"] as string
                        };
                    }
                }

                if (int.TryParse((dataReader["TrademarkNameD"] as int?)?.ToString(), out int trademarkNameD))
                {
                    if (trademarkNameD > 0)
                    {
                        entity.TrademarkNameD = new Trademark
                        {
                            ID = trademarkNameD,
                            Name = dataReader["TrademarkNameDName"] as string,
                            TrademarkNumber = dataReader["TrademarkNameDTrademarkNumber"] as string,
                            Office = new Office
                            {
                                OfficeName = dataReader["TrademarkNameDOfficeName"] as string
                            },
                            BigfootGroupOwned = dataReader["TrademarkNameDBigFootGroupOwned"] as string
                        };
                    }
                }

                if (int.TryParse((dataReader["OwnerApplicantsRepresentative"] as int?)?.ToString(), out int ownerApplicantsRepresentative))
                {
                    if (ownerApplicantsRepresentative > 0)
                    {
                        entity.OwnerApplicantsRepresentative = new Company
                        {
                            ID = ownerApplicantsRepresentative,
                            CompanyName = dataReader["OwnerApplicantsRepresentativeName"] as string
                        };
                    }
                }

                if (int.TryParse((dataReader["OpponentsRepresentative"] as int?)?.ToString(), out int opponentsRepresentative))
                {
                    if (opponentsRepresentative > 0)
                    {
                        entity.OpponentsRepresentative = new Company
                        {
                            ID = opponentsRepresentative,
                            CompanyName = dataReader["OpponentsRepresentativeName"] as string
                        };
                    }
                }

                entities.Add(entity);
            }

            return entities;
        }

        public StringBuilder ExportData(MySqlDataReader dataReader)
        {
            return null;
        }

        public MySqlParameter[] CreateParameters(object model)
        {
            var entity = (Opposition)model;
            var parameters = new List<MySqlParameter>();

            parameters.AddRange(new MySqlParameter[]
            {
                new MySqlParameter("pOppositionName", MySqlDbType.VarChar, 45) { Value = entity.OppositionName, Direction = ParameterDirection.Input },

                new MySqlParameter("pTrademarkRoleA", MySqlDbType.VarChar, 45) { Value = entity.TrademarkRoleA, Direction = ParameterDirection.Input },
                new MySqlParameter("pTrademarkRoleD", MySqlDbType.VarChar, 45) { Value = entity.TrademarkRoleD, Direction = ParameterDirection.Input },
                new MySqlParameter("pTrademarkNameA", MySqlDbType.Int32) { Value = entity.TrademarkNameA?.ID, Direction = ParameterDirection.Input },
                new MySqlParameter("pTrademarkNameD", MySqlDbType.Int32) { Value = entity.TrademarkNameD?.ID, Direction = ParameterDirection.Input },
                new MySqlParameter("pClassDescriptionsAttacking", MySqlDbType.VarChar, 10000) { Value = entity.ClassDescriptionsAttacking, Direction = ParameterDirection.Input },
                new MySqlParameter("pClassDescriptionsDefending", MySqlDbType.VarChar, 10000) { Value = entity.ClassDescriptionsDefending, Direction = ParameterDirection.Input },
                new MySqlParameter("pOppositionStatus", MySqlDbType.VarChar, 45) { Value = entity.OppositionStatus, Direction = ParameterDirection.Input },
                new MySqlParameter("pInternalCaseNumber", MySqlDbType.VarChar, 45) { Value = entity.InternalCaseNumber, Direction = ParameterDirection.Input },
                new MySqlParameter("pDeletionRequest", entity.DeletionRequest ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pDeletionRequestReason", MySqlDbType.VarChar, 255) { Value = entity.DeletionRequestReason, Direction = ParameterDirection.Input },

                new MySqlParameter("pOppositionDeadline", MySqlDbType.VarChar, 45) { Value = entity.OppositionDeadline, Direction = ParameterDirection.Input },
                new MySqlParameter("pOppositionCost", MySqlDbType.VarChar, 45) { Value = entity.OppositionCost, Direction = ParameterDirection.Input },
                new MySqlParameter("pCeaseAndDesistLetterPreApproval", MySqlDbType.VarChar, 45) { Value = entity.CeaseAndDesistLetterPreApproval, Direction = ParameterDirection.Input },
                new MySqlParameter("pCeaseAndDesistLetterPreApprovedBy", MySqlDbType.VarChar, 45) { Value = entity.CeaseAndDesistLetterPreApprovedBy, Direction = ParameterDirection.Input },
                new MySqlParameter("pCeaseAndDesistLetterPreApprovedOn", MySqlDbType.VarChar, 45) { Value = entity.CeaseAndDesistLetterPreApprovedOn, Direction = ParameterDirection.Input },
                new MySqlParameter("pCeaseAndDesistLetterApproval", MySqlDbType.VarChar, 45) { Value = entity.CeaseAndDesistLetterApproval, Direction = ParameterDirection.Input },
                new MySqlParameter("pCeaseAndDesistLetterApprovedBy", MySqlDbType.VarChar, 45) { Value = entity.CeaseAndDesistLetterApprovedBy, Direction = ParameterDirection.Input },
                new MySqlParameter("pCeaseAndDesistLetterApprovedOn", MySqlDbType.VarChar, 45) { Value = entity.CeaseAndDesistLetterApprovedOn, Direction = ParameterDirection.Input },
                new MySqlParameter("pCeaseAndDesistLetterReference", MySqlDbType.VarChar, 45) { Value = entity.CeaseAndDesistLetterReference, Direction = ParameterDirection.Input },
                new MySqlParameter("pCeaseAndDesistLetterOrigin", MySqlDbType.VarChar, 45) { Value = entity.CeaseAndDesistLetterOrigin, Direction = ParameterDirection.Input },
                new MySqlParameter("pCeaseAndDesistLetterSendingMethod", MySqlDbType.VarChar, 45) { Value = entity.CeaseAndDesistLetterSendingMethod, Direction = ParameterDirection.Input },
                new MySqlParameter("pCeaseAndDesistLetterSentOn", MySqlDbType.VarChar, 45) { Value = entity.CeaseAndDesistLetterSentOn, Direction = ParameterDirection.Input },
                new MySqlParameter("pCeaseAndDesistLetterOutcome", MySqlDbType.VarChar, 45) { Value = entity.CeaseAndDesistLetterOutcome, Direction = ParameterDirection.Input },
                new MySqlParameter("pIPOOppositionApproval", MySqlDbType.VarChar, 45) { Value = entity.IPOOppositionApproval, Direction = ParameterDirection.Input },
                new MySqlParameter("pIPOOppositionApprovedBy", MySqlDbType.VarChar, 45) { Value = entity.IPOOppositionApprovedBy, Direction = ParameterDirection.Input },
                new MySqlParameter("pIPOOppositionApprovedOn", MySqlDbType.VarChar, 45) { Value = entity.IPOOppositionApprovedOn, Direction = ParameterDirection.Input },
                new MySqlParameter("pOwnerApplicantsRepresentative", MySqlDbType.Int32) { Value = entity.OwnerApplicantsRepresentative?.ID, Direction = ParameterDirection.Input },
                new MySqlParameter("pOpponentsRepresentative", MySqlDbType.Int32) { Value = entity.OpponentsRepresentative?.ID, Direction = ParameterDirection.Input },
                new MySqlParameter("pIPOOppositionNumber", MySqlDbType.VarChar, 45) { Value = entity.IPOOppositionNumber, Direction = ParameterDirection.Input },
                new MySqlParameter("pIPOOppositionLanguage", MySqlDbType.VarChar, 45) { Value = entity.IPOOppositionLanguage, Direction = ParameterDirection.Input },
                new MySqlParameter("pIPOOppositionDate", MySqlDbType.DateTime) { Value = entity.IPOOppositionDate, Direction = ParameterDirection.Input },
                new MySqlParameter("pIPOOppositionLink", MySqlDbType.VarChar, 45) { Value = entity.IPOOppositionLink, Direction = ParameterDirection.Input },
                new MySqlParameter("pIPOOppositionStatus", MySqlDbType.VarChar, 45) { Value = entity.IPOOppositionStatus, Direction = ParameterDirection.Input },
                new MySqlParameter("pIPOOppositionOutcomeDate", MySqlDbType.DateTime) { Value = entity.IPOOppositionOutcomeDate, Direction = ParameterDirection.Input },
                new MySqlParameter("pOwnerResponseDeadline", MySqlDbType.DateTime) { Value = entity.OwnerResponseDeadline, Direction = ParameterDirection.Input },
                new MySqlParameter("pOppositionComments", MySqlDbType.VarChar, 5000) { Value = entity.OppositionComments, Direction = ParameterDirection.Input }
            });

            return parameters.ToArray();
        }

        #endregion
    }
}
