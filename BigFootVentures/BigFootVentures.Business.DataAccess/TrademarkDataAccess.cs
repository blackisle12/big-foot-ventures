using BigFootVentures.Business.DataAccess.Utilities;
using BigFootVentures.Business.Objects.Management;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BigFootVentures.Business.DataAccess
{
    public interface ITrademarkDataAccess
    {
        #region "Factory Methods"

        Trademark Get(int ID);

        StringBuilder Export(string query);

        #endregion
    }

    public sealed class TrademarkDataAccess : ITrademarkDataAccess, IDisposable
    {
        #region "Private Members"

        private readonly MySqlConnection _connection = null;

        #endregion

        #region "Constructors"

        public TrademarkDataAccess(string connectionString)
        {
            this._connection = new MySqlConnection(connectionString);
        }

        #endregion

        #region "Factory Methods"

        public Trademark Get(int ID)
        {
            try
            {
                Trademark trademark = null;

                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();

                using (var command = new MySqlCommand("Trademark_GetTrademark", this._connection) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new MySqlParameter("ID", MySqlDbType.Int32) { Value = ID, Direction = ParameterDirection.Input });

                    var dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        trademark = new Trademark
                        {
                            ID = (int)dataReader["ID"],

                            OwnerName = dataReader["OwnerName"] as string,

                            Name = dataReader["Name"] as string,
                            OfficeStatus = dataReader["OfficeStatus"] as string,

                            TrademarkNumber = dataReader["TrademarkNumber"] as string,
                            InternationalRegistrationNumber = dataReader["InternationalRegistrationNumber"] as string,
                            FilingNumber = dataReader["FilingNumber"] as string,
                            RegistrationNumber = dataReader["RegistrationNumber"] as string,
                            TMURL = dataReader["TMURL"] as string,
                            ReceiptDate = dataReader["ReceiptDate"] as string,
                            FilingDateValue = dataReader["FilingDateValue"] as string,
                            PublicationDate = dataReader["PublicationDate"] as string,
                            RegistrationDate = dataReader["RegistrationDate"] as string,
                            ExpiryDate = dataReader["ExpiryDate"] as string,
                            //SixMonthsAnniversary = dataReader["SixMonthsAnniversary"] as string,
                            PriorityDate = dataReader["PriorityDate"] as string,
                            PriorityCountryAndPriorityTMNumber = dataReader["PriorityCountryAndPriorityTMNumber"] as string,
                            SeniorityUsed = (dataReader["SeniorityUsed"] as sbyte? ?? 0) == 1,
                            SeniorityDetails = dataReader["SeniorityDetails"] as string,
                            DeletionRequest = (dataReader["DeletionRequest"] as sbyte? ?? 0) == 1,
                            DeletionRequestReason = dataReader["DeletionRequestReason"] as string,
                            DeletionDuplicate = dataReader["DeletionDuplicate"] as string,
                            RevocationTarget = (dataReader["RevocationTarget"] as sbyte? ?? 0) == 1,
                            UserStatusDescription = dataReader["UserStatusDescription"] as string,
                            Figurative = (dataReader["Figurative"] as sbyte? ?? 0) == 1,
                            TrademarkType = dataReader["TrademarkType"] as string,
                            FigurativeURL = dataReader["FigurativeURL"] as string,
                            LanguageFiling = dataReader["LanguageFiling"] as string,
                            LanguageSecond = dataReader["LanguageSecond"] as string,
                            Geography = dataReader["Geography"] as string,
                            InvolvedInRevocation = (dataReader["InvolvedInRevocation"] as sbyte? ?? 0) == 1,
                            BigfootGroupOwned = dataReader["BigfootGroupOwned"] as string,

                            OpenSimilarityResearchTask = dataReader["OpenSimilarityResearchTask"] as string,
                            InitialSubmitter = dataReader["InitialSubmitter"] as string,
                            LastSimilarityResearchCompletedOn = dataReader["LastSimilarityResearchCompletedOn"] as string,
                            OppositionResearch = dataReader["OppositionResearch"] as string,
                            SimilarTrademarkSpellings = dataReader["SimilarTrademarkSpellings"] as string,

                            WIPODesignatedProtection = dataReader["WIPODesignatedProtection"] as string,
                            ARIPODesignatedState = dataReader["ARIPODesignatedState"] as string,
                            TrademarkNameEnglishTranslation = dataReader["TrademarkNameEnglishTranslation"] as string,
                            WIPOBasicApplicationISO = dataReader["WIPOBasicApplicationISO"] as string,
                            WIPOBasicApplicationFilingDate = dataReader["WIPOBasicApplicationFilingDate"] as string,
                            WIPOBasicApplicationNumber = dataReader["WIPOBasicApplicationNumber"] as string,

                            PaymentStatusRegisteredLV = dataReader["PaymentStatusRegisteredLV"] as string,
                            AcceptanceDueDate = dataReader["AcceptanceDueDate"] as string,
                            CommentsLV = dataReader["CommentsLV"] as string,
                            LVAppealDeadline = dataReader["LVAppealDeadline"] as string,
                            ReasonForTheRefusalLV = dataReader["ReasonForTheRefusalLV"] as string
                        };

                        if (int.TryParse((dataReader["OfficeID"] as int?)?.ToString(), out int officeID))
                        {
                            trademark.Office = new Office { ID = officeID };
                        }

                        if (int.TryParse((dataReader["BrandID"] as int?)?.ToString(), out int brandID))
                        {
                            trademark.Brand = new Brand { ID = brandID };
                        }

                        if (int.TryParse((dataReader["OriginalOfficeID"] as int?)?.ToString(), out int originalOfficeID))
                        {
                            trademark.OriginalOffice = new Office { ID = originalOfficeID };
                        }

                        break;
                    }

                    dataReader.Close();
                }

                using (var command = new MySqlCommand("Trademark_GetTrademarkExtra", this._connection) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new MySqlParameter("ID", MySqlDbType.Int32) { Value = ID, Direction = ParameterDirection.Input });

                    var dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        trademark.Class1 = (dataReader["Class1"] as sbyte? ?? 0) == 1;
                        trademark.Class1Description = dataReader["Class1Description"] as string;
                        trademark.Class2 = (dataReader["Class2"] as sbyte? ?? 0) == 1;
                        trademark.Class2Description = dataReader["Class2Description"] as string;
                        trademark.Class3 = (dataReader["Class3"] as sbyte? ?? 0) == 1;
                        trademark.Class3Description = dataReader["Class3Description"] as string;
                        trademark.Class4 = (dataReader["Class4"] as sbyte? ?? 0) == 1;
                        trademark.Class4Description = dataReader["Class4Description"] as string;
                        trademark.Class5 = (dataReader["Class5"] as sbyte? ?? 0) == 1;
                        trademark.Class5Description = dataReader["Class5Description"] as string;
                        trademark.Class6 = (dataReader["Class6"] as sbyte? ?? 0) == 1;
                        trademark.Class6Description = dataReader["Class6Description"] as string;
                        trademark.Class7 = (dataReader["Class7"] as sbyte? ?? 0) == 1;
                        trademark.Class7Description = dataReader["Class7Description"] as string;
                        trademark.Class8 = (dataReader["Class8"] as sbyte? ?? 0) == 1;
                        trademark.Class8Description = dataReader["Class8Description"] as string;
                        trademark.Class9 = (dataReader["Class9"] as sbyte? ?? 0) == 1;
                        trademark.Class9Description = dataReader["Class9Description"] as string;
                        trademark.Class10 = (dataReader["Class10"] as sbyte? ?? 0) == 1;
                        trademark.Class10Description = dataReader["Class10Description"] as string;

                        break;
                    }

                    dataReader.Close();
                }

                using (var command = new MySqlCommand("Trademark_GetTrademarkExtra2", this._connection) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new MySqlParameter("ID", MySqlDbType.Int32) { Value = ID, Direction = ParameterDirection.Input });

                    var dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        trademark.Class11 = (dataReader["Class11"] as sbyte? ?? 0) == 1;
                        trademark.Class11Description = dataReader["Class11Description"] as string;
                        trademark.Class12 = (dataReader["Class12"] as sbyte? ?? 0) == 1;
                        trademark.Class12Description = dataReader["Class12Description"] as string;
                        trademark.Class13 = (dataReader["Class13"] as sbyte? ?? 0) == 1;
                        trademark.Class13Description = dataReader["Class13Description"] as string;
                        trademark.Class14 = (dataReader["Class14"] as sbyte? ?? 0) == 1;
                        trademark.Class14Description = dataReader["Class14Description"] as string;
                        trademark.Class15 = (dataReader["Class15"] as sbyte? ?? 0) == 1;
                        trademark.Class15Description = dataReader["Class15Description"] as string;
                        trademark.Class16 = (dataReader["Class16"] as sbyte? ?? 0) == 1;
                        trademark.Class16Description = dataReader["Class16Description"] as string;
                        trademark.Class17 = (dataReader["Class17"] as sbyte? ?? 0) == 1;
                        trademark.Class17Description = dataReader["Class17Description"] as string;
                        trademark.Class18 = (dataReader["Class18"] as sbyte? ?? 0) == 1;
                        trademark.Class18Description = dataReader["Class18Description"] as string;
                        trademark.Class19 = (dataReader["Class19"] as sbyte? ?? 0) == 1;
                        trademark.Class19Description = dataReader["Class19Description"] as string;
                        trademark.Class20 = (dataReader["Class20"] as sbyte? ?? 0) == 1;
                        trademark.Class20Description = dataReader["Class20Description"] as string;

                        break;
                    }

                    dataReader.Close();
                }

                using (var command = new MySqlCommand("Trademark_GetTrademarkExtra3", this._connection) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new MySqlParameter("ID", MySqlDbType.Int32) { Value = ID, Direction = ParameterDirection.Input });

                    var dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        trademark.Class21 = (dataReader["Class21"] as sbyte? ?? 0) == 1;
                        trademark.Class21Description = dataReader["Class21Description"] as string;
                        trademark.Class22 = (dataReader["Class22"] as sbyte? ?? 0) == 1;
                        trademark.Class22Description = dataReader["Class22Description"] as string;
                        trademark.Class23 = (dataReader["Class23"] as sbyte? ?? 0) == 1;
                        trademark.Class23Description = dataReader["Class23Description"] as string;
                        trademark.Class24 = (dataReader["Class24"] as sbyte? ?? 0) == 1;
                        trademark.Class24Description = dataReader["Class24Description"] as string;
                        trademark.Class25 = (dataReader["Class25"] as sbyte? ?? 0) == 1;
                        trademark.Class25Description = dataReader["Class25Description"] as string;
                        trademark.Class26 = (dataReader["Class26"] as sbyte? ?? 0) == 1;
                        trademark.Class26Description = dataReader["Class26Description"] as string;
                        trademark.Class27 = (dataReader["Class27"] as sbyte? ?? 0) == 1;
                        trademark.Class27Description = dataReader["Class27Description"] as string;
                        trademark.Class28 = (dataReader["Class28"] as sbyte? ?? 0) == 1;
                        trademark.Class28Description = dataReader["Class28Description"] as string;
                        trademark.Class29 = (dataReader["Class29"] as sbyte? ?? 0) == 1;
                        trademark.Class29Description = dataReader["Class29Description"] as string;
                        trademark.Class30 = (dataReader["Class30"] as sbyte? ?? 0) == 1;
                        trademark.Class30Description = dataReader["Class30Description"] as string;

                        break;
                    }

                    dataReader.Close();
                }

                using (var command = new MySqlCommand("Trademark_GetTrademarkExtra4", this._connection) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new MySqlParameter("ID", MySqlDbType.Int32) { Value = ID, Direction = ParameterDirection.Input });

                    var dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        trademark.Class31 = (dataReader["Class31"] as sbyte? ?? 0) == 1;
                        trademark.Class31Description = dataReader["Class31Description"] as string;
                        trademark.Class32 = (dataReader["Class32"] as sbyte? ?? 0) == 1;
                        trademark.Class32Description = dataReader["Class32Description"] as string;
                        trademark.Class33 = (dataReader["Class33"] as sbyte? ?? 0) == 1;
                        trademark.Class33Description = dataReader["Class33Description"] as string;
                        trademark.Class34 = (dataReader["Class34"] as sbyte? ?? 0) == 1;
                        trademark.Class34Description = dataReader["Class34Description"] as string;
                        trademark.Class35 = (dataReader["Class35"] as sbyte? ?? 0) == 1;
                        trademark.Class35Description = dataReader["Class35Description"] as string;
                        trademark.Class36 = (dataReader["Class36"] as sbyte? ?? 0) == 1;
                        trademark.Class36Description = dataReader["Class36Description"] as string;
                        trademark.Class37 = (dataReader["Class37"] as sbyte? ?? 0) == 1;
                        trademark.Class37Description = dataReader["Class37Description"] as string;
                        trademark.Class38 = (dataReader["Class38"] as sbyte? ?? 0) == 1;
                        trademark.Class38Description = dataReader["Class38Description"] as string;
                        trademark.Class39 = (dataReader["Class39"] as sbyte? ?? 0) == 1;
                        trademark.Class39Description = dataReader["Class39Description"] as string;
                        trademark.Class40 = (dataReader["Class40"] as sbyte? ?? 0) == 1;
                        trademark.Class40Description = dataReader["Class40Description"] as string;

                        break;
                    }

                    dataReader.Close();
                }

                using (var command = new MySqlCommand("Trademark_GetTrademarkExtra5", this._connection) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new MySqlParameter("ID", MySqlDbType.Int32) { Value = ID, Direction = ParameterDirection.Input });

                    var dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        trademark.Class41 = (dataReader["Class41"] as sbyte? ?? 0) == 1;
                        trademark.Class41Description = dataReader["Class41Description"] as string;
                        trademark.Class42 = (dataReader["Class42"] as sbyte? ?? 0) == 1;
                        trademark.Class42Description = dataReader["Class42Description"] as string;
                        trademark.Class43 = (dataReader["Class43"] as sbyte? ?? 0) == 1;
                        trademark.Class43Description = dataReader["Class43Description"] as string;
                        trademark.Class44 = (dataReader["Class44"] as sbyte? ?? 0) == 1;
                        trademark.Class44Description = dataReader["Class44Description"] as string;
                        trademark.Class45 = (dataReader["Class45"] as sbyte? ?? 0) == 1;
                        trademark.Class45Description = dataReader["Class45Description"] as string;

                        break;
                    }

                    dataReader.Close();
                }

                using (var command = new MySqlCommand("Trademark_GetTrademarkExtra6", this._connection) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new MySqlParameter("ID", MySqlDbType.Int32) { Value = ID, Direction = ParameterDirection.Input });

                    var dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        trademark.ResearcherName = dataReader["ResearcherName"] as string;
                        trademark.CancellationStrategy = dataReader["CancellationStrategy"] as string;
                        trademark.MarkUse = dataReader["MarkUse"] as string;
                        trademark.CompetingMarks = (dataReader["CompetingMarks"] as sbyte? ?? 0) == 1;
                        trademark.CompetingMark = dataReader["CompetingMark"] as string;
                        trademark.CancelResearcherComments = dataReader["CancelResearcherComments"] as string;
                        trademark.OwnerDefense = dataReader["OwnerDefense"] as string;

                        trademark.SourceName = dataReader["SourceName"] as string;
                        trademark.BFStrategy = dataReader["BFStrategy"] as string;
                        trademark.StrategyNotes = dataReader["StrategyNotes"] as string;
                        trademark.NameValue = dataReader["NameValue"] as string;
                        trademark.CancelBuyBudget = dataReader["CancelBuyBudget"] as string;

                        trademark.RevocationReferenceExternal = dataReader["RevocationReferenceExternal"] as string;

                        trademark.InvalidityNumber = dataReader["InvalidityNumber"] as string;
                        trademark.InvalidityInvokedGround = dataReader["InvalidityInvokedGround"] as string;
                        trademark.InvalidityDate = dataReader["InvalidityDate"] as string;
                        trademark.InvalidityActionOutcome = dataReader["InvalidityActionOutcome"] as string;

                        trademark.LetterReference = dataReader["LetterReference"] as string;
                        trademark.LetterOrigin = dataReader["LetterOrigin"] as string;
                        trademark.LetterSendingMethod = dataReader["LetterSendingMethod"] as string;
                        trademark.LetterSentOn = dataReader["LetterSentOn"] as string;
                        trademark.OwnerResponseDeadline = dataReader["OwnerResponseDeadline"] as string;
                        trademark.LetterOutcome = dataReader["LetterOutcome"] as string;

                        if (int.TryParse((dataReader["TMWebsiteID"] as int?)?.ToString(), out int TMWebsiteID))
                        {
                            trademark.TMWebsite = new DomainN { ID = TMWebsiteID };
                        }

                        if (int.TryParse((dataReader["OwnerWebsiteID"] as int?)?.ToString(), out int ownerWebsiteID))
                        {
                            trademark.OwnerWebsite = new DomainN { ID = ownerWebsiteID };
                        }

                        if (int.TryParse((dataReader["ComWebsiteID"] as int?)?.ToString(), out int comWebsiteID))
                        {
                            trademark.ComWebsite = new DomainN { ID = comWebsiteID };
                        }

                        if (int.TryParse((dataReader["InvalidityApplicantID"] as int?)?.ToString(), out int invalidityApplicantID))
                        {
                            trademark.InvalidityApplicant = new Company { ID = invalidityApplicantID };
                        }

                        break;
                    }

                    dataReader.Close();
                }

                return trademark;
            }
            catch
            {
                throw;
            }
            finally
            {
                this._connection.Close();
            }
        }

        public StringBuilder Export(string query)
        {
            try
            {
                var result = new StringBuilder();

                result.Append("Name,Owner Name,Office Name,Original Office Name,Brand Name,TM Website,Owner Website,Com Website,Office Status,Trademark Number,International Registration Number,Filing Number,Registration Number,TM URL,Receipt Date,Filing Date Value,");
                result.Append("Publication Date,Registration Date,Expiry Date,6 Months Anniversary,Priority Date,Priority Country and Priority TM Number,Seniority Used, Seniority Details,");
                result.Append("Deletion Request,Deletion Request Reason,Deletion Duplicate,Revocation Target,User Status Description,Figurative,Trademark Type,Figurative URL,Language Filing,");
                result.Append("Language Second,Geography,Involved in Revocation,BigFoot Group Owned,Open Similarity Research Task,Initial Submitter,Last Similarity Research Completed On,");
                result.Append("Opposition Research,Similar Trademark Spellings,WIPO Designated Protection,ARIPO Designated State,Trademark Name English Translation,WIPO Basic Application ISO,");
                result.Append("WIPO Basic Application Filing Date,WIPO Basic Application Number,Payment Status Registered LV,Acceptance Due Date,Comments LV,LV Appeal Deadline,Reason for the Refusal LV,");
                result.Append("Class1,Class1Description,Class2,Class2Description,Class3,Class3Description,Class4,Class4Description,Class5,Class5Description,Class6,Class6Description,Class7,Class7Description,");
                result.Append("Class8,Class8Description,Class9,Class9Description,Class10,Class10Description,Class11,Class11Description,Class12,Class12Description,Class13,Class13Description,Class14,Class14Description,");
                result.Append("Class15,Class15Description,Class16,Class16Description,Class17,Class17Description,Class18,Class18Description,Class19,Class19Description,Class20,Class20Description,Class21,Class21Description,");
                result.Append("Class22,Class22Description,Class23,Class23Description,Class24,Class24Description,Class25,Class25Description,Class26,Class26Description,Class27,Class27Description,Class28,Class28Description,");
                result.Append("Class29,Class29Description,Class30,Class30Description,Class31,Class31Description,Class32,Class32Description,Class33,Class33Description,Class34,Class34Description,Class35,Class35Description,");
                result.Append("Class36,Class36Description,Class37,Class37Description,Class38,Class38Description,Class39,Class39Description,Class40,Class40Description,Class41,Class41Description,Class42,Class42Description,");
                result.Append("Class43,Class43Description,Class44,Class44Description,Class45,Class45Description,Researcher Name,Cancellation Strategy,Mark Use,Competing Marks,Competing Mark,Cancel Researcher Comments,");
                result.Append("Researcher Name,Cancellation Strategy,Mark Use,Competing Marks,Competing Mark,Cancel Researcher Comments,");
                result.Append("Owner Defense,Source Name,BF Strategy,Strategy Notes,Name Value,Cancel Buy Budget,Revocation Reference External,Invalidity Number,Invalidity Invoked Ground,Invalidity Date,Invalidity Action Outcome,");
                result.Append("Letter Reference,Letter Origin,Letter Sending Method,Letter Sent On,Owner Response Deadline,Letter Outcome");
                result.Append(Environment.NewLine);

                var trademarkIDs = string.Empty;
                var trademarkList = new List<Trademark>();

                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();

                using (var command = new MySqlCommand("Object_ExportByQuery2", this._connection) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new MySqlParameter("query1", MySqlDbType.MediumText) { Value = query, Direction = ParameterDirection.Input });

                    var dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        var trademark = new Trademark
                        {
                            ID = (int)dataReader["ID"],

                            OwnerName = dataReader["OwnerName"] as string,

                            Name = dataReader["Name"] as string,
                            Office = new Office
                            {
                                OfficeName = dataReader["OfficeName"] as string
                            },
                            OfficeStatus = dataReader["OfficeStatus"] as string,

                            TrademarkNumber = dataReader["TrademarkNumber"] as string,
                            InternationalRegistrationNumber = dataReader["InternationalRegistrationNumber"] as string,
                            FilingNumber = dataReader["FilingNumber"] as string,
                            RegistrationNumber = dataReader["RegistrationNumber"] as string,
                            TMURL = dataReader["TMURL"] as string,
                            Brand = new Brand
                            {
                                Name = dataReader["BrandName"] as string
                            },
                            ReceiptDate = dataReader["ReceiptDate"] as string,
                            FilingDateValue = dataReader["FilingDateValue"] as string,
                            PublicationDate = dataReader["PublicationDate"] as string,
                            RegistrationDate = dataReader["RegistrationDate"] as string,
                            ExpiryDate = dataReader["ExpiryDate"] as string,
                            //SixMonthsAnniversary = dataReader["SixMonthsAnniversary"] as string,
                            PriorityDate = dataReader["PriorityDate"] as string,
                            PriorityCountryAndPriorityTMNumber = dataReader["PriorityCountryAndPriorityTMNumber"] as string,
                            SeniorityUsed = (dataReader["SeniorityUsed"] as sbyte? ?? 0) == 1,
                            SeniorityDetails = dataReader["SeniorityDetails"] as string,
                            DeletionRequest = (dataReader["DeletionRequest"] as sbyte? ?? 0) == 1,
                            DeletionRequestReason = dataReader["DeletionRequestReason"] as string,
                            DeletionDuplicate = dataReader["DeletionDuplicate"] as string,
                            RevocationTarget = (dataReader["RevocationTarget"] as sbyte? ?? 0) == 1,
                            UserStatusDescription = dataReader["UserStatusDescription"] as string,
                            Figurative = (dataReader["Figurative"] as sbyte? ?? 0) == 1,
                            TrademarkType = dataReader["TrademarkType"] as string,
                            FigurativeURL = dataReader["FigurativeURL"] as string,
                            LanguageFiling = dataReader["LanguageFiling"] as string,
                            LanguageSecond = dataReader["LanguageSecond"] as string,
                            Geography = dataReader["Geography"] as string,
                            InvolvedInRevocation = (dataReader["InvolvedInRevocation"] as sbyte? ?? 0) == 1,
                            BigfootGroupOwned = dataReader["BigfootGroupOwned"] as string,

                            OpenSimilarityResearchTask = dataReader["OpenSimilarityResearchTask"] as string,
                            InitialSubmitter = dataReader["InitialSubmitter"] as string,
                            LastSimilarityResearchCompletedOn = dataReader["LastSimilarityResearchCompletedOn"] as string,
                            OppositionResearch = dataReader["OppositionResearch"] as string,
                            SimilarTrademarkSpellings = dataReader["SimilarTrademarkSpellings"] as string,

                            WIPODesignatedProtection = dataReader["WIPODesignatedProtection"] as string,
                            ARIPODesignatedState = dataReader["ARIPODesignatedState"] as string,
                            TrademarkNameEnglishTranslation = dataReader["TrademarkNameEnglishTranslation"] as string,
                            WIPOBasicApplicationISO = dataReader["WIPOBasicApplicationISO"] as string,
                            WIPOBasicApplicationFilingDate = dataReader["WIPOBasicApplicationFilingDate"] as string,
                            WIPOBasicApplicationNumber = dataReader["WIPOBasicApplicationNumber"] as string,

                            PaymentStatusRegisteredLV = dataReader["PaymentStatusRegisteredLV"] as string,
                            AcceptanceDueDate = dataReader["AcceptanceDueDate"] as string,
                            CommentsLV = dataReader["CommentsLV"] as string,
                            LVAppealDeadline = dataReader["LVAppealDeadline"] as string,
                            ReasonForTheRefusalLV = dataReader["ReasonForTheRefusalLV"] as string
                        };

                        trademarkList.Add(trademark);

                        trademarkIDs += (string.IsNullOrWhiteSpace(trademarkIDs) ? string.Empty : ",") + dataReader["ID"] as string;
                    }

                    dataReader.Close();
                }

                //dbo.TrademarkExtra
                using (var command = new MySqlCommand("Object_ExportByQuery2", this._connection) { CommandType = CommandType.StoredProcedure })
                {
                    var query1 = "SELECT * FROM TrademarkExtra WHERE ID IN (" + trademarkIDs + ")";
                    
                    command.Parameters.Add(new MySqlParameter("query1", MySqlDbType.MediumText) { Value = query1, Direction = ParameterDirection.Input });

                    var dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        var index = trademarkList.FindIndex(t => t.ID == (int)dataReader["ID"]);

                        if (index < 0)
                            continue;

                        trademarkList[index].Class1 = (dataReader["Class1"] as sbyte? ?? 0) == 1;
                        trademarkList[index].Class1Description = dataReader["Class1Description"] as string;
                        trademarkList[index].Class2 = (dataReader["Class2"] as sbyte? ?? 0) == 1;
                        trademarkList[index].Class2Description = dataReader["Class2Description"] as string;
                        trademarkList[index].Class3 = (dataReader["Class3"] as sbyte? ?? 0) == 1;
                        trademarkList[index].Class3Description = dataReader["Class3Description"] as string;
                        trademarkList[index].Class4 = (dataReader["Class4"] as sbyte? ?? 0) == 1;
                        trademarkList[index].Class4Description = dataReader["Class4Description"] as string;
                        trademarkList[index].Class5 = (dataReader["Class5"] as sbyte? ?? 0) == 1;
                        trademarkList[index].Class5Description = dataReader["Class5Description"] as string;
                        trademarkList[index].Class6 = (dataReader["Class6"] as sbyte? ?? 0) == 1;
                        trademarkList[index].Class6Description = dataReader["Class6Description"] as string;
                        trademarkList[index].Class7 = (dataReader["Class7"] as sbyte? ?? 0) == 1;
                        trademarkList[index].Class7Description = dataReader["Class7Description"] as string;
                        trademarkList[index].Class8 = (dataReader["Class8"] as sbyte? ?? 0) == 1;
                        trademarkList[index].Class8Description = dataReader["Class8Description"] as string;
                        trademarkList[index].Class9 = (dataReader["Class9"] as sbyte? ?? 0) == 1;
                        trademarkList[index].Class9Description = dataReader["Class9Description"] as string;
                        trademarkList[index].Class10 = (dataReader["Class10"] as sbyte? ?? 0) == 1;
                        trademarkList[index].Class10Description = dataReader["Class10Description"] as string;
                    }

                    dataReader.Close();
                }

                //dbo.TrademarkExtra2
                using (var command = new MySqlCommand("Object_ExportByQuery2", this._connection) { CommandType = CommandType.StoredProcedure })
                {
                    var query1 = "SELECT * FROM TrademarkExtra2 WHERE ID IN (" + trademarkIDs + ")";

                    command.Parameters.Add(new MySqlParameter("query1", MySqlDbType.MediumText) { Value = query1, Direction = ParameterDirection.Input });

                    var dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        var index = trademarkList.FindIndex(t => t.ID == (int)dataReader["ID"]);

                        if (index < 0)
                            continue;

                        trademarkList[index].Class11 = (dataReader["Class11"] as sbyte? ?? 0) == 1;
                        trademarkList[index].Class11Description = dataReader["Class11Description"] as string;
                        trademarkList[index].Class12 = (dataReader["Class12"] as sbyte? ?? 0) == 1;
                        trademarkList[index].Class12Description = dataReader["Class12Description"] as string;
                        trademarkList[index].Class13 = (dataReader["Class13"] as sbyte? ?? 0) == 1;
                        trademarkList[index].Class13Description = dataReader["Class13Description"] as string;
                        trademarkList[index].Class14 = (dataReader["Class14"] as sbyte? ?? 0) == 1;
                        trademarkList[index].Class14Description = dataReader["Class14Description"] as string;
                        trademarkList[index].Class15 = (dataReader["Class15"] as sbyte? ?? 0) == 1;
                        trademarkList[index].Class15Description = dataReader["Class15Description"] as string;
                        trademarkList[index].Class16 = (dataReader["Class16"] as sbyte? ?? 0) == 1;
                        trademarkList[index].Class16Description = dataReader["Class16Description"] as string;
                        trademarkList[index].Class17 = (dataReader["Class17"] as sbyte? ?? 0) == 1;
                        trademarkList[index].Class17Description = dataReader["Class17Description"] as string;
                        trademarkList[index].Class18 = (dataReader["Class18"] as sbyte? ?? 0) == 1;
                        trademarkList[index].Class18Description = dataReader["Class18Description"] as string;
                        trademarkList[index].Class19 = (dataReader["Class19"] as sbyte? ?? 0) == 1;
                        trademarkList[index].Class19Description = dataReader["Class19Description"] as string;
                        trademarkList[index].Class20 = (dataReader["Class20"] as sbyte? ?? 0) == 1;
                        trademarkList[index].Class20Description = dataReader["Class20Description"] as string;
                    }

                    dataReader.Close();
                }

                //dbo.TrademarkExtra3
                using (var command = new MySqlCommand("Object_ExportByQuery2", this._connection) { CommandType = CommandType.StoredProcedure })
                {
                    var query1 = "SELECT * FROM TrademarkExtra3 WHERE ID IN (" + trademarkIDs + ")";

                    command.Parameters.Add(new MySqlParameter("query1", MySqlDbType.MediumText) { Value = query1, Direction = ParameterDirection.Input });

                    var dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        var index = trademarkList.FindIndex(t => t.ID == (int)dataReader["ID"]);

                        if (index < 0)
                            continue;

                        trademarkList[index].Class21 = (dataReader["Class21"] as sbyte? ?? 0) == 1;
                        trademarkList[index].Class21Description = dataReader["Class21Description"] as string;
                        trademarkList[index].Class22 = (dataReader["Class22"] as sbyte? ?? 0) == 1;
                        trademarkList[index].Class22Description = dataReader["Class22Description"] as string;
                        trademarkList[index].Class23 = (dataReader["Class23"] as sbyte? ?? 0) == 1;
                        trademarkList[index].Class23Description = dataReader["Class23Description"] as string;
                        trademarkList[index].Class24 = (dataReader["Class24"] as sbyte? ?? 0) == 1;
                        trademarkList[index].Class24Description = dataReader["Class24Description"] as string;
                        trademarkList[index].Class25 = (dataReader["Class25"] as sbyte? ?? 0) == 1;
                        trademarkList[index].Class25Description = dataReader["Class25Description"] as string;
                        trademarkList[index].Class26 = (dataReader["Class26"] as sbyte? ?? 0) == 1;
                        trademarkList[index].Class26Description = dataReader["Class26Description"] as string;
                        trademarkList[index].Class27 = (dataReader["Class27"] as sbyte? ?? 0) == 1;
                        trademarkList[index].Class27Description = dataReader["Class27Description"] as string;
                        trademarkList[index].Class28 = (dataReader["Class28"] as sbyte? ?? 0) == 1;
                        trademarkList[index].Class28Description = dataReader["Class28Description"] as string;
                        trademarkList[index].Class29 = (dataReader["Class29"] as sbyte? ?? 0) == 1;
                        trademarkList[index].Class29Description = dataReader["Class29Description"] as string;
                        trademarkList[index].Class30 = (dataReader["Class30"] as sbyte? ?? 0) == 1;
                        trademarkList[index].Class30Description = dataReader["Class30Description"] as string;
                    }

                    dataReader.Close();
                }

                //dbo.TrademarkExtra4
                using (var command = new MySqlCommand("Object_ExportByQuery2", this._connection) { CommandType = CommandType.StoredProcedure })
                {
                    var query1 = "SELECT * FROM TrademarkExtra4 WHERE ID IN (" + trademarkIDs + ")";

                    command.Parameters.Add(new MySqlParameter("query1", MySqlDbType.MediumText) { Value = query1, Direction = ParameterDirection.Input });

                    var dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        var index = trademarkList.FindIndex(t => t.ID == (int)dataReader["ID"]);

                        if (index < 0)
                            continue;

                        trademarkList[index].Class31 = (dataReader["Class31"] as sbyte? ?? 0) == 1;
                        trademarkList[index].Class31Description = dataReader["Class31Description"] as string;
                        trademarkList[index].Class32 = (dataReader["Class32"] as sbyte? ?? 0) == 1;
                        trademarkList[index].Class32Description = dataReader["Class32Description"] as string;
                        trademarkList[index].Class33 = (dataReader["Class33"] as sbyte? ?? 0) == 1;
                        trademarkList[index].Class33Description = dataReader["Class33Description"] as string;
                        trademarkList[index].Class34 = (dataReader["Class34"] as sbyte? ?? 0) == 1;
                        trademarkList[index].Class34Description = dataReader["Class34Description"] as string;
                        trademarkList[index].Class35 = (dataReader["Class35"] as sbyte? ?? 0) == 1;
                        trademarkList[index].Class35Description = dataReader["Class35Description"] as string;
                        trademarkList[index].Class36 = (dataReader["Class36"] as sbyte? ?? 0) == 1;
                        trademarkList[index].Class36Description = dataReader["Class36Description"] as string;
                        trademarkList[index].Class37 = (dataReader["Class37"] as sbyte? ?? 0) == 1;
                        trademarkList[index].Class37Description = dataReader["Class37Description"] as string;
                        trademarkList[index].Class38 = (dataReader["Class38"] as sbyte? ?? 0) == 1;
                        trademarkList[index].Class38Description = dataReader["Class38Description"] as string;
                        trademarkList[index].Class39 = (dataReader["Class39"] as sbyte? ?? 0) == 1;
                        trademarkList[index].Class39Description = dataReader["Class39Description"] as string;
                        trademarkList[index].Class40 = (dataReader["Class40"] as sbyte? ?? 0) == 1;
                        trademarkList[index].Class40Description = dataReader["Class40Description"] as string;
                    }

                    dataReader.Close();
                }

                //dbo.TrademarkExtra5
                using (var command = new MySqlCommand("Object_ExportByQuery2", this._connection) { CommandType = CommandType.StoredProcedure })
                {
                    var query1 = "SELECT * FROM TrademarkExtra5 WHERE ID IN (" + trademarkIDs + ")";

                    command.Parameters.Add(new MySqlParameter("query1", MySqlDbType.MediumText) { Value = query1, Direction = ParameterDirection.Input });

                    var dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        var index = trademarkList.FindIndex(t => t.ID == (int)dataReader["ID"]);

                        if (index < 0)
                            continue;

                        trademarkList[index].Class41 = (dataReader["Class41"] as sbyte? ?? 0) == 1;
                        trademarkList[index].Class41Description = dataReader["Class41Description"] as string;
                        trademarkList[index].Class42 = (dataReader["Class42"] as sbyte? ?? 0) == 1;
                        trademarkList[index].Class42Description = dataReader["Class42Description"] as string;
                        trademarkList[index].Class43 = (dataReader["Class43"] as sbyte? ?? 0) == 1;
                        trademarkList[index].Class43Description = dataReader["Class43Description"] as string;
                        trademarkList[index].Class44 = (dataReader["Class44"] as sbyte? ?? 0) == 1;
                        trademarkList[index].Class44Description = dataReader["Class44Description"] as string;
                        trademarkList[index].Class45 = (dataReader["Class45"] as sbyte? ?? 0) == 1;
                        trademarkList[index].Class45Description = dataReader["Class45Description"] as string;
                    }

                    dataReader.Close();
                }

                //dbo.TrademarkExtra6
                using (var command = new MySqlCommand("Object_ExportByQuery2", this._connection) { CommandType = CommandType.StoredProcedure })
                {
                    var query1 = $@"SELECT T6.*, D.Name AS TMWebsiteName, DD.Name AS OwnerWebsiteName, DDD.Name AS ComWebsiteName
                         FROM TrademarkExtra6 T6
                         LEFT JOIN DomainN D ON T6.TMWebsiteID = D.ID
                         LEFT JOIN DomainN DD ON T6.OwnerWebsiteID = DD.ID
                         LEFT JOIN DomainN DDD ON T6.ComWebsiteID = DDD.ID
                         WHERE T6.ID IN ({trademarkIDs})";

                    command.Parameters.Add(new MySqlParameter("query1", MySqlDbType.MediumText) { Value = query1, Direction = ParameterDirection.Input });

                    var dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        var index = trademarkList.FindIndex(t => t.ID == (int)dataReader["ID"]);

                        if (index < 0)
                            continue;

                        trademarkList[index].ResearcherName = dataReader["ResearcherName"] as string;
                        trademarkList[index].CancellationStrategy = dataReader["CancellationStrategy"] as string;
                        trademarkList[index].MarkUse = dataReader["MarkUse"] as string;
                        trademarkList[index].CompetingMarks = (dataReader["CompetingMarks"] as sbyte? ?? 0) == 1;
                        trademarkList[index].CompetingMark = dataReader["CompetingMark"] as string;
                        trademarkList[index].CancelResearcherComments = dataReader["CancelResearcherComments"] as string;
                        trademarkList[index].OwnerDefense = dataReader["OwnerDefense"] as string;

                        trademarkList[index].SourceName = dataReader["SourceName"] as string;
                        trademarkList[index].BFStrategy = dataReader["BFStrategy"] as string;
                        trademarkList[index].StrategyNotes = dataReader["StrategyNotes"] as string;
                        trademarkList[index].NameValue = dataReader["NameValue"] as string;
                        trademarkList[index].CancelBuyBudget = dataReader["CancelBuyBudget"] as string;

                        trademarkList[index].RevocationReferenceExternal = dataReader["RevocationReferenceExternal"] as string;

                        trademarkList[index].InvalidityNumber = dataReader["InvalidityNumber"] as string;
                        trademarkList[index].InvalidityInvokedGround = dataReader["InvalidityInvokedGround"] as string;
                        trademarkList[index].InvalidityDate = dataReader["InvalidityDate"] as string;
                        trademarkList[index].InvalidityActionOutcome = dataReader["InvalidityActionOutcome"] as string;

                        trademarkList[index].LetterReference = dataReader["LetterReference"] as string;
                        trademarkList[index].LetterOrigin = dataReader["LetterOrigin"] as string;
                        trademarkList[index].LetterSendingMethod = dataReader["LetterSendingMethod"] as string;
                        trademarkList[index].LetterSentOn = dataReader["LetterSentOn"] as string;
                        trademarkList[index].OwnerResponseDeadline = dataReader["OwnerResponseDeadline"] as string;
                        trademarkList[index].LetterOutcome = dataReader["LetterOutcome"] as string;

                        trademarkList[index].TMWebsite = new DomainN
                        {
                            Name = dataReader["TMWebsiteName"] as string
                        };

                        trademarkList[index].OwnerWebsite = new DomainN
                        {
                            Name = dataReader["OwnerWebsiteName"] as string
                        };

                        trademarkList[index].ComWebsite = new DomainN
                        {
                            Name = dataReader["ComWebsiteName"] as string
                        };
                    }

                    dataReader.Close();
                }

                foreach (var trademark in trademarkList)
                {
                    result.Append(DataUtils.EscapeCSV($"{trademark.Name}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.OwnerName}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.Office?.OfficeName}") + ",");
                    result.Append(","); //result.Append(DataUtils.EscapeCSV($"{dataReader["OriginalOfficeName"] as string}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.Brand?.Name}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.TMWebsite?.Name}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.OwnerWebsite?.Name}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.ComWebsite?.Name}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.OfficeStatus}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.TrademarkNumber}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.InternationalRegistrationNumber}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.FilingNumber}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.RegistrationNumber}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.TMURL}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.ReceiptDate}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.FilingDateValue}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.PublicationDate}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.RegistrationDate}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.ExpiryDate}") + ",");
                    result.Append(DataUtils.EscapeCSV($" ") + ","); //result.Append(DataUtils.EscapeCSV($"{dataReader["SixMonthsAnniversary"] as string}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.PriorityDate}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.PriorityCountryAndPriorityTMNumber}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.SeniorityUsed}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.SeniorityDetails}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.DeletionRequest}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.DeletionRequestReason}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.DeletionDuplicate}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.RevocationTarget}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.UserStatusDescription}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.Figurative}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.TrademarkType}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.FigurativeURL}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.LanguageFiling}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.LanguageSecond}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.Geography}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.InvolvedInRevocation}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.BigfootGroupOwned}") + ",");

                    result.Append(DataUtils.EscapeCSV($"{trademark.OpenSimilarityResearchTask}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.InitialSubmitter}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.LastSimilarityResearchCompletedOn}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.OppositionResearch}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.SimilarTrademarkSpellings}") + ",");

                    result.Append(DataUtils.EscapeCSV($"{trademark.WIPODesignatedProtection}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.ARIPODesignatedState}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.TrademarkNameEnglishTranslation}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.WIPOBasicApplicationISO}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.WIPOBasicApplicationFilingDate}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.WIPOBasicApplicationNumber}") + ",");

                    result.Append(DataUtils.EscapeCSV($"{trademark.PaymentStatusRegisteredLV}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.AcceptanceDueDate}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.CommentsLV}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.LVAppealDeadline}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.ReasonForTheRefusalLV}") + ",");

                    for (var i = 1; i <= 45; i++)
                    {
                        result.Append(DataUtils.EscapeCSV($"{Convert.ToBoolean(typeof(Trademark).GetProperty($"Class{i}").GetValue(trademark))}") + ",");
                        result.Append(DataUtils.EscapeCSV($"{typeof(Trademark).GetProperty($"Class{i}Description").GetValue(trademark) as string}") + ",");
                    }

                    result.Append(DataUtils.EscapeCSV($"{trademark.ResearcherName}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.CancellationStrategy}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.MarkUse}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.CompetingMarks}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.CompetingMark}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.CancelResearcherComments}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.OwnerDefense}") + ",");

                    result.Append(DataUtils.EscapeCSV($"{trademark.SourceName}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.BFStrategy}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.StrategyNotes}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.NameValue}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.CancelBuyBudget}") + ",");

                    result.Append(DataUtils.EscapeCSV($"{trademark.RevocationReferenceExternal}") + ",");

                    result.Append(DataUtils.EscapeCSV($"{trademark.InvalidityNumber}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.InvalidityInvokedGround}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.InvalidityDate}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.InvalidityActionOutcome}") + ",");

                    result.Append(DataUtils.EscapeCSV($"{trademark.LetterReference}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.LetterOrigin}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.LetterSendingMethod}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.LetterSentOn}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.OwnerResponseDeadline}") + ",");
                    result.Append(DataUtils.EscapeCSV($"{trademark.LetterOutcome}") + ",");

                    result.Append(Environment.NewLine);
                }

                return result;
            }
            catch
            {
                throw;
            }
            finally
            {
                this._connection.Close();
            }
        }

        #endregion

        #region "Public Methods"

        public void Dispose()
        {
            this._connection.Dispose();
        }

        #endregion
    }
}
