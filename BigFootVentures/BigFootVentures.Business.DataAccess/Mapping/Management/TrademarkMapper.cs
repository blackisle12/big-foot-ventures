using BigFootVentures.Business.DataAccess.Utilities;
using BigFootVentures.Business.Objects.Management;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BigFootVentures.Business.DataAccess.Mapping.Management
{
    public sealed class TrademarkMapper : IMapper
    {
        #region "Public Methods"

        public ICollection<object> ParseData(MySqlDataReader dataReader)
        {
            var entities = new List<object>();
            
            while (dataReader.Read())
            {
                var entity = new Trademark
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
                    SixMonthsAnniversary = dataReader["SixMonthsAnniversary"] as string,
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
                    ReasonForTheRefusalLV = dataReader["ReasonForTheRefusalLV"] as string,

                    Class1 = (dataReader["Class1"] as sbyte? ?? 0) == 1,
                    Class1Description = dataReader["Class1Description"] as string,
                    Class2 = (dataReader["Class2"] as sbyte? ?? 0) == 1,
                    Class2Description = dataReader["Class2Description"] as string,
                    Class3 = (dataReader["Class3"] as sbyte? ?? 0) == 1,
                    Class3Description = dataReader["Class3Description"] as string,
                    Class4 = (dataReader["Class4"] as sbyte? ?? 0) == 1,
                    Class4Description = dataReader["Class4Description"] as string,
                    Class5 = (dataReader["Class5"] as sbyte? ?? 0) == 1,
                    Class5Description = dataReader["Class5Description"] as string,
                    Class6 = (dataReader["Class6"] as sbyte? ?? 0) == 1,
                    Class6Description = dataReader["Class6Description"] as string,
                    Class7 = (dataReader["Class7"] as sbyte? ?? 0) == 1,
                    Class7Description = dataReader["Class7Description"] as string,
                    Class8 = (dataReader["Class8"] as sbyte? ?? 0) == 1,
                    Class8Description = dataReader["Class8Description"] as string,
                    Class9 = (dataReader["Class9"] as sbyte? ?? 0) == 1,
                    Class9Description = dataReader["Class9Description"] as string,
                    Class10 = (dataReader["Class10"] as sbyte? ?? 0) == 1,
                    Class10Description = dataReader["Class10Description"] as string,
                    Class11 = (dataReader["Class11"] as sbyte? ?? 0) == 1,
                    Class11Description = dataReader["Class11Description"] as string,
                    Class12 = (dataReader["Class12"] as sbyte? ?? 0) == 1,
                    Class12Description = dataReader["Class12Description"] as string,
                    Class13 = (dataReader["Class13"] as sbyte? ?? 0) == 1,
                    Class13Description = dataReader["Class13Description"] as string,
                    Class14 = (dataReader["Class14"] as sbyte? ?? 0) == 1,
                    Class14Description = dataReader["Class14Description"] as string,
                    Class15 = (dataReader["Class15"] as sbyte? ?? 0) == 1,
                    Class15Description = dataReader["Class15Description"] as string,
                    Class16 = (dataReader["Class16"] as sbyte? ?? 0) == 1,
                    Class16Description = dataReader["Class16Description"] as string,
                    Class17 = (dataReader["Class17"] as sbyte? ?? 0) == 1,
                    Class17Description = dataReader["Class17Description"] as string,
                    Class18 = (dataReader["Class18"] as sbyte? ?? 0) == 1,
                    Class18Description = dataReader["Class18Description"] as string,
                    Class19 = (dataReader["Class19"] as sbyte? ?? 0) == 1,
                    Class19Description = dataReader["Class19Description"] as string,
                    Class20 = (dataReader["Class20"] as sbyte? ?? 0) == 1,
                    Class20Description = dataReader["Class20Description"] as string,
                    Class21 = (dataReader["Class21"] as sbyte? ?? 0) == 1,
                    Class21Description = dataReader["Class21Description"] as string,
                    Class22 = (dataReader["Class22"] as sbyte? ?? 0) == 1,
                    Class22Description = dataReader["Class22Description"] as string,
                    Class23 = (dataReader["Class23"] as sbyte? ?? 0) == 1,
                    Class23Description = dataReader["Class23Description"] as string,
                    Class24 = (dataReader["Class24"] as sbyte? ?? 0) == 1,
                    Class24Description = dataReader["Class24Description"] as string,
                    Class25 = (dataReader["Class25"] as sbyte? ?? 0) == 1,
                    Class25Description = dataReader["Class25Description"] as string,
                    Class26 = (dataReader["Class26"] as sbyte? ?? 0) == 1,
                    Class26Description = dataReader["Class26Description"] as string,
                    Class27 = (dataReader["Class27"] as sbyte? ?? 0) == 1,
                    Class27Description = dataReader["Class27Description"] as string,
                    Class28 = (dataReader["Class28"] as sbyte? ?? 0) == 1,
                    Class28Description = dataReader["Class28Description"] as string,
                    Class29 = (dataReader["Class29"] as sbyte? ?? 0) == 1,
                    Class29Description = dataReader["Class29Description"] as string,
                    Class30 = (dataReader["Class30"] as sbyte? ?? 0) == 1,
                    Class30Description = dataReader["Class30Description"] as string,
                    Class31 = (dataReader["Class31"] as sbyte? ?? 0) == 1,
                    Class31Description = dataReader["Class31Description"] as string,
                    Class32 = (dataReader["Class32"] as sbyte? ?? 0) == 1,
                    Class32Description = dataReader["Class32Description"] as string,
                    Class33 = (dataReader["Class33"] as sbyte? ?? 0) == 1,
                    Class33Description = dataReader["Class33Description"] as string,
                    Class34 = (dataReader["Class34"] as sbyte? ?? 0) == 1,
                    Class34Description = dataReader["Class34Description"] as string,
                    Class35 = (dataReader["Class35"] as sbyte? ?? 0) == 1,
                    Class35Description = dataReader["Class35Description"] as string,
                    Class36 = (dataReader["Class36"] as sbyte? ?? 0) == 1,
                    Class36Description = dataReader["Class36Description"] as string,
                    Class37 = (dataReader["Class37"] as sbyte? ?? 0) == 1,
                    Class37Description = dataReader["Class37Description"] as string,
                    Class38 = (dataReader["Class38"] as sbyte? ?? 0) == 1,
                    Class38Description = dataReader["Class38Description"] as string,
                    Class39 = (dataReader["Class39"] as sbyte? ?? 0) == 1,
                    Class39Description = dataReader["Class39Description"] as string,
                    Class40 = (dataReader["Class40"] as sbyte? ?? 0) == 1,
                    Class40Description = dataReader["Class40Description"] as string,
                    Class41 = (dataReader["Class41"] as sbyte? ?? 0) == 1,
                    Class41Description = dataReader["Class41Description"] as string,
                    Class42 = (dataReader["Class42"] as sbyte? ?? 0) == 1,
                    Class42Description = dataReader["Class42Description"] as string,
                    Class43 = (dataReader["Class43"] as sbyte? ?? 0) == 1,
                    Class43Description = dataReader["Class43Description"] as string,
                    Class44 = (dataReader["Class44"] as sbyte? ?? 0) == 1,
                    Class44Description = dataReader["Class44Description"] as string,
                    Class45 = (dataReader["Class45"] as sbyte? ?? 0) == 1,
                    Class45Description = dataReader["Class45Description"] as string,

                    ResearcherName = dataReader["ResearcherName"] as string,
                    CancellationStrategy = dataReader["CancellationStrategy"] as string,
                    MarkUse = dataReader["MarkUse"] as string,
                    CompetingMarks = (dataReader["CompetingMarks"] as sbyte? ?? 0) == 1,
                    CompetingMark = dataReader["CompetingMark"] as string,
                    CancelResearcherComments = dataReader["CancelResearcherComments"] as string,
                    OwnerDefense = dataReader["OwnerDefense"] as string,

                    SourceName = dataReader["SourceName"] as string,
                    BFStrategy = dataReader["BFStrategy"] as string,
                    StrategyNotes = dataReader["StrategyNotes"] as string,
                    NameValue = dataReader["NameValue"] as string,
                    CancelBuyBudget = dataReader["CancelBuyBudget"] as string,

                    RevocationReferenceExternal = dataReader["RevocationReferenceExternal"] as string,

                    InvalidityNumber = dataReader["InvalidityNumber"] as string,
                    InvalidityInvokedGround = dataReader["InvalidityInvokedGround"] as string,
                    InvalidityDate = dataReader["InvalidityDate"] as string,
                    InvalidityActionOutcome = dataReader["InvalidityActionOutcome"] as string,

                    LetterReference = dataReader["LetterReference"] as string,
                    LetterOrigin = dataReader["LetterOrigin"] as string,
                    LetterSendingMethod = dataReader["LetterSendingMethod"] as string,
                    LetterSentOn = dataReader["LetterSentOn"] as string,
                    OwnerResponseDeadline = dataReader["OwnerResponseDeadline"] as string,
                    LetterOutcome = dataReader["LetterOutcome"] as string
                };

                if (int.TryParse((dataReader["OfficeID"] as int?)?.ToString(), out int officeID))
                {
                    entity.Office = new Office { ID = officeID };
                }

                if (int.TryParse((dataReader["BrandID"] as int?)?.ToString(), out int brandID))
                {
                    entity.Brand = new Brand { ID = brandID };
                }

                if (int.TryParse((dataReader["OriginalOfficeID"] as int?)?.ToString(), out int originalOfficeID))
                {
                    entity.OriginalOffice = new Office { ID = originalOfficeID };
                }

                if (int.TryParse((dataReader["TMWebsiteID"] as int?)?.ToString(), out int TMWebsiteID))
                {
                    entity.TMWebsite = new DomainN { ID = TMWebsiteID };
                }

                if (int.TryParse((dataReader["OwnerWebsiteID"] as int?)?.ToString(), out int ownerWebsiteID))
                {
                    entity.OwnerWebsite = new DomainN { ID = ownerWebsiteID };
                }

                if (int.TryParse((dataReader["ComWebsiteID"] as int?)?.ToString(), out int comWebsiteID))
                {
                    entity.ComWebsite = new DomainN { ID = comWebsiteID };
                }

                if (int.TryParse((dataReader["InvalidityApplicantID"] as int?)?.ToString(), out int invalidityApplicantID))
                {
                    entity.InvalidityApplicant = new Company { ID = invalidityApplicantID };
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
                var entity = new Trademark
                {
                    ID = (int)dataReader["ID"],

                    Name = dataReader["Name"] as string,
                    TrademarkNumber = dataReader["TrademarkNumber"] as string,
                    InternationalRegistrationNumber = dataReader["InternationalRegistrationNumber"] as string,
                    FilingDateValue = dataReader["FilingDateValue"] as string,
                    PublicationDate = dataReader["PublicationDate"] as string
                };

                entities.Add(entity);
            }

            return entities;
        }

        public StringBuilder ExportData(MySqlDataReader dataReader)
        {
            var file = new StringBuilder();

            file.Append("Name,Owner Name,Office Name,Original Office Name,Brand Name,TM Website,Owner Website,Com Website,Office Status,Trademark Number,International Registration Number,Filing Number,Registration Number,TM URL,Receipt Date,Filing Date Value,");
            file.Append("Publication Date,Registration Date,Expiry Date,6 Months Anniversary,Priority Date,Priority Country and Priority TM Number,Seniority Used, Seniority Details,");
            file.Append("Deletion Request,Deletion Request Reason,Deletion Duplicate,Revocation Target,User Status Description,Figurative,Trademark Type,Figurative URL,Language Filing,");
            file.Append("Language Second,Geography,Involved in Revocation,BigFoot Group Owned,Open Similarity Research Task,Initial Submitter,Last Similarity Research Completed On,");
            file.Append("Opposition Research,Similar Trademark Spellings,WIPO Designated Protection,ARIPO Designated State,Trademark Name English Translation,WIPO Basic Application ISO,");
            file.Append("WIPO Basic Application Filing Date,WIPO Basic Application Number,Payment Status Registered LV,Acceptance Due Date,Comments LV,LV Appeal Deadline,Reason for the Refusal LV,");
            //file.Append("Class1,Class1Description,Class2,Class2Description,Class3,Class3Description,Class4,Class4Description,Class5,Class5Description,Class6,Class6Description,Class7,Class7Description,");
            //file.Append("Class8,Class8Description,Class9,Class9Description,Class10,Class10Description,Class11,Class11Description,Class12,Class12Description,Class13,Class13Description,Class14,Class14Description,");
            //file.Append("Class15,Class15Description,Class16,Class16Description,Class17,Class17Description,Class18,Class18Description,Class19,Class19Description,Class20,Class20Description,Class21,Class21Description,");
            //file.Append("Class22,Class22Description,Class23,Class23Description,Class24,Class24Description,Class25,Class25Description,Class26,Class26Description,Class27,Class27Description,Class28,Class28Description,");
            //file.Append("Class29,Class29Description,Class30,Class30Description,Class31,Class31Description,Class32,Class32Description,Class33,Class33Description,Class34,Class34Description,Class35,Class35Description,");
            //file.Append("Class36,Class36Description,Class37,Class37Description,Class38,Class38Description,Class39,Class39Description,Class40,Class40Description,Class41,Class41Description,Class42,Class42Description,");
            //file.Append("Class43,Class43Description,Class44,Class44Description,Class45,Class45Description,Researcher Name,Cancellation Strategy,Mark Use,Competing Marks,Competing Mark,Cancel Researcher Comments,");
            //file.Append("Researcher Name,Cancellation Strategy,Mark Use,Competing Marks,Competing Mark,Cancel Researcher Comments,");
            //file.Append("Owner Defense,Source Name,BF Strategy,Strategy Notes,Name Value,Cancel Buy Budget,Revocation Reference External,Invalidity Number,Invalidity Invoked Ground,Invalidity Date,Invalidity Action Outcome,");
            //file.Append("Letter Reference,Letter Origin,Letter Sending Method,Letter Sent On,Owner Response Deadline,Letter Outcome");
            file.Append(Environment.NewLine);

            while (dataReader.Read())
            {
                file.Append(DataUtils.EscapeCSV($"{dataReader["Name"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["OwnerName"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["OfficeName"] as string}") + ",");
                file.Append(","); //file.Append(DataUtils.EscapeCSV($"{dataReader["OriginalOfficeName"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["BrandName"] as string}") + ",");
                file.Append(","); //file.Append(DataUtils.EscapeCSV($"{dataReader["TMWebsiteName"] as string}") + ",");
                file.Append(","); //file.Append(DataUtils.EscapeCSV($"{dataReader["OwnerWebsiteName"] as string}") + ",");
                file.Append(","); //file.Append(DataUtils.EscapeCSV($"{dataReader["ComWebsiteName"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["OfficeStatus"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["TrademarkNumber"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["InternationalRegistrationNumber"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["FilingNumber"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["RegistrationNumber"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["TMURL"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["ReceiptDate"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["FilingDateValue"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["PublicationDate"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["RegistrationDate"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["ExpiryDate"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["SixMonthsAnniversary"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["PriorityDate"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["PriorityCountryAndPriorityTMNumber"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{(dataReader["SeniorityUsed"] as sbyte? ?? 0) == 1}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["SeniorityDetails"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{(dataReader["DeletionRequest"] as sbyte? ?? 0) == 1}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["DeletionRequestReason"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["DeletionDuplicate"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{(dataReader["RevocationTarget"] as sbyte? ?? 0) == 1}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["UserStatusDescription"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{(dataReader["Figurative"] as sbyte? ?? 0) == 1}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["TrademarkType"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["FigurativeURL"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["LanguageFiling"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["LanguageSecond"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["Geography"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{(dataReader["InvolvedInRevocation"] as sbyte? ?? 0) == 1}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["BigfootGroupOwned"] as string}") + ",");

                file.Append(DataUtils.EscapeCSV($"{dataReader["OpenSimilarityResearchTask"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["InitialSubmitter"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["LastSimilarityResearchCompletedOn"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["OppositionResearch"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["SimilarTrademarkSpellings"] as string}") + ",");

                file.Append(DataUtils.EscapeCSV($"{dataReader["WIPODesignatedProtection"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["ARIPODesignatedState"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["TrademarkNameEnglishTranslation"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["WIPOBasicApplicationISO"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["WIPOBasicApplicationFilingDate"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["WIPOBasicApplicationNumber"] as string}") + ",");

                file.Append(DataUtils.EscapeCSV($"{dataReader["PaymentStatusRegisteredLV"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["AcceptanceDueDate"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["CommentsLV"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["LVAppealDeadline"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["ReasonForTheRefusalLV"] as string}") + ",");

                //for (var i = 1; i <= 45; i++)
                //{
                //    file.Append(DataUtils.EscapeCSV($"{(dataReader[$"Class{i}"] as sbyte? ?? 0) == 1}") + ",");
                //    file.Append(DataUtils.EscapeCSV($"{dataReader[$"Class{i}Description"] as string}") + ",");
                //}

                //file.Append(DataUtils.EscapeCSV($"{dataReader["ResearcherName"] as string}") + ",");
                //file.Append(DataUtils.EscapeCSV($"{dataReader["CancellationStrategy"] as string}") + ",");
                //file.Append(DataUtils.EscapeCSV($"{dataReader["MarkUse"] as string}") + ",");
                //file.Append(DataUtils.EscapeCSV($"{(dataReader["CompetingMarks"] as sbyte? ?? 0) == 1}") + ",");
                //file.Append(DataUtils.EscapeCSV($"{dataReader["CompetingMark"] as string}") + ",");
                //file.Append(DataUtils.EscapeCSV($"{dataReader["CancelResearcherComments"] as string}") + ",");
                //file.Append(DataUtils.EscapeCSV($"{dataReader["OwnerDefense"] as string}") + ",");

                //file.Append(DataUtils.EscapeCSV($"{dataReader["SourceName"] as string}") + ",");
                //file.Append(DataUtils.EscapeCSV($"{dataReader["BFStrategy"] as string}") + ",");
                //file.Append(DataUtils.EscapeCSV($"{dataReader["StrategyNotes"] as string}") + ",");
                //file.Append(DataUtils.EscapeCSV($"{dataReader["NameValue"] as string}") + ",");
                //file.Append(DataUtils.EscapeCSV($"{dataReader["CancelBuyBudget"] as string}") + ",");

                //file.Append(DataUtils.EscapeCSV($"{dataReader["RevocationReferenceExternal"] as string}") + ",");

                //file.Append(DataUtils.EscapeCSV($"{dataReader["InvalidityNumber"] as string}") + ",");
                //file.Append(DataUtils.EscapeCSV($"{dataReader["InvalidityInvokedGround"] as string}") + ",");
                //file.Append(DataUtils.EscapeCSV($"{dataReader["InvalidityDate"] as string}") + ",");
                //file.Append(DataUtils.EscapeCSV($"{dataReader["InvalidityActionOutcome"] as string}") + ",");

                //file.Append(DataUtils.EscapeCSV($"{dataReader["LetterReference"] as string}") + ",");
                //file.Append(DataUtils.EscapeCSV($"{dataReader["LetterOrigin"] as string}") + ",");
                //file.Append(DataUtils.EscapeCSV($"{dataReader["LetterSendingMethod"] as string}") + ",");
                //file.Append(DataUtils.EscapeCSV($"{dataReader["LetterSentOn"] as string}") + ",");
                //file.Append(DataUtils.EscapeCSV($"{dataReader["OwnerResponseDeadline"] as string}") + ",");
                //file.Append(DataUtils.EscapeCSV($"{dataReader["LetterOutcome"] as string}") + ",");

                file.Append(Environment.NewLine);
            }

            return file;
        }

        public MySqlParameter[] CreateParameters(object model)
        {
            var entity = (Trademark)model;
            var parameters = new List<MySqlParameter>();

            parameters.AddRange(new MySqlParameter[]
            {
                new MySqlParameter("pOwnerName", MySqlDbType.VarChar, 100) { Value = entity.OwnerName, Direction = ParameterDirection.Input },

                new MySqlParameter("pName", MySqlDbType.VarChar, 100) { Value = entity.Name, Direction = ParameterDirection.Input },
                new MySqlParameter("pOfficeID", MySqlDbType.Int32) { Value = entity.Office?.ID, Direction = ParameterDirection.Input },
                new MySqlParameter("pOfficeStatus", MySqlDbType.VarChar, 45) { Value = entity.OfficeStatus, Direction = ParameterDirection.Input },

                new MySqlParameter("pTrademarkNumber", MySqlDbType.VarChar, 45) { Value = entity.TrademarkNumber, Direction = ParameterDirection.Input },
                new MySqlParameter("pInternationalRegistrationNumber", MySqlDbType.VarChar, 255) { Value = entity.InternationalRegistrationNumber, Direction = ParameterDirection.Input },
                new MySqlParameter("pRegistrationNumber", MySqlDbType.VarChar, 255) { Value = entity.RegistrationNumber, Direction = ParameterDirection.Input },
                new MySqlParameter("pFilingNumber", MySqlDbType.VarChar, 255) { Value = entity.FilingNumber, Direction = ParameterDirection.Input },
                new MySqlParameter("pTMURL", MySqlDbType.VarChar, 255) { Value = entity.TMURL, Direction = ParameterDirection.Input },
                new MySqlParameter("pBrandID", MySqlDbType.Int32) { Value = entity.Brand?.ID, Direction = ParameterDirection.Input },
                new MySqlParameter("pOriginalOfficeID", MySqlDbType.Int32) { Value = entity.OriginalOffice?.ID, Direction = ParameterDirection.Input },
                new MySqlParameter("pReceiptDate", MySqlDbType.VarChar, 45) { Value = entity.ReceiptDate, Direction = ParameterDirection.Input },
                new MySqlParameter("pFilingDateValue", MySqlDbType.VarChar, 45) { Value = entity.FilingDateValue, Direction = ParameterDirection.Input },
                new MySqlParameter("pPublicationDate", MySqlDbType.VarChar, 45) { Value = entity.PublicationDate, Direction = ParameterDirection.Input },
                new MySqlParameter("pRegistrationDate", MySqlDbType.VarChar, 45) { Value = entity.RegistrationDate, Direction = ParameterDirection.Input },
                new MySqlParameter("pExpiryDate", MySqlDbType.VarChar, 45) { Value = entity.ExpiryDate, Direction = ParameterDirection.Input },
                new MySqlParameter("pSixMonthsAnniversary", MySqlDbType.VarChar, 45) { Value = entity.SixMonthsAnniversary, Direction = ParameterDirection.Input },
                new MySqlParameter("pPriorityDate", MySqlDbType.VarChar, 45) { Value = entity.PriorityDate, Direction = ParameterDirection.Input },
                new MySqlParameter("pPriorityCountryAndPriorityTMNumber", MySqlDbType.VarChar, 255) { Value = entity.PriorityCountryAndPriorityTMNumber, Direction = ParameterDirection.Input },
                new MySqlParameter("pSeniorityUsed", entity.SeniorityUsed ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pSeniorityDetails", MySqlDbType.VarChar, 255) { Value = entity.SeniorityDetails, Direction = ParameterDirection.Input },
                new MySqlParameter("pDeletionRequest", entity.DeletionRequest ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pDeletionRequestReason", MySqlDbType.VarChar, 255) { Value = entity.DeletionRequestReason, Direction = ParameterDirection.Input },
                new MySqlParameter("pDeletionDuplicate", MySqlDbType.VarChar, 100) { Value = entity.DeletionDuplicate, Direction = ParameterDirection.Input },
                new MySqlParameter("pRevocationTarget", entity.RevocationTarget ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pUserStatusDescription", MySqlDbType.VarChar, 255) { Value = entity.UserStatusDescription, Direction = ParameterDirection.Input },
                new MySqlParameter("pFigurative", entity.Figurative ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pTrademarkType", MySqlDbType.VarChar, 45) { Value = entity.TrademarkType, Direction = ParameterDirection.Input },
                new MySqlParameter("pFigurativeURL", MySqlDbType.VarChar, 255) { Value = entity.FigurativeURL, Direction = ParameterDirection.Input },
                new MySqlParameter("pLanguageFiling", MySqlDbType.VarChar, 45) { Value = entity.LanguageFiling, Direction = ParameterDirection.Input },
                new MySqlParameter("pLanguageSecond", MySqlDbType.VarChar, 45) { Value = entity.LanguageSecond, Direction = ParameterDirection.Input },
                new MySqlParameter("pGeography", MySqlDbType.VarChar, 45) { Value = entity.Geography, Direction = ParameterDirection.Input },
                new MySqlParameter("pInvolvedInRevocation", entity.InvolvedInRevocation ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pBigfootGroupOwned", MySqlDbType.VarChar, 45) { Value = entity.BigfootGroupOwned, Direction = ParameterDirection.Input },

                new MySqlParameter("pOpenSimilarityResearchTask", MySqlDbType.VarChar, 45) { Value = entity.OpenSimilarityResearchTask, Direction = ParameterDirection.Input },
                new MySqlParameter("pInitialSubmitter", MySqlDbType.VarChar, 100) { Value = entity.InitialSubmitter, Direction = ParameterDirection.Input },
                new MySqlParameter("pLastSimilarityResearchCompletedOn", MySqlDbType.VarChar, 45) { Value = entity.LastSimilarityResearchCompletedOn, Direction = ParameterDirection.Input },
                new MySqlParameter("pOppositionResearch", MySqlDbType.VarChar, 45) { Value = entity.OppositionResearch, Direction = ParameterDirection.Input },
                new MySqlParameter("pSimilarTrademarkSpellings", MySqlDbType.VarChar, 255) { Value = entity.SimilarTrademarkSpellings, Direction = ParameterDirection.Input },

                new MySqlParameter("pWIPODesignatedProtection", MySqlDbType.VarChar, 255) { Value = entity.WIPODesignatedProtection, Direction = ParameterDirection.Input },
                new MySqlParameter("pARIPODesignatedState", MySqlDbType.VarChar, 255) { Value = entity.ARIPODesignatedState, Direction = ParameterDirection.Input },
                new MySqlParameter("pTrademarkNameEnglishTranslation", MySqlDbType.VarChar, 100) { Value = entity.TrademarkNameEnglishTranslation, Direction = ParameterDirection.Input },
                new MySqlParameter("pWIPOBasicApplicationISO", MySqlDbType.VarChar, 255) { Value = entity.WIPOBasicApplicationISO, Direction = ParameterDirection.Input },
                new MySqlParameter("pWIPOBasicApplicationFilingDate", MySqlDbType.VarChar, 45) { Value = entity.WIPOBasicApplicationFilingDate, Direction = ParameterDirection.Input },
                new MySqlParameter("pWIPOBasicApplicationNumber", MySqlDbType.VarChar, 45) { Value = entity.WIPOBasicApplicationNumber, Direction = ParameterDirection.Input },

                new MySqlParameter("pPaymentStatusRegisteredLV", MySqlDbType.VarChar, 255) { Value = entity.PaymentStatusRegisteredLV, Direction = ParameterDirection.Input },
                new MySqlParameter("pAcceptanceDueDate", MySqlDbType.VarChar, 45) { Value = entity.AcceptanceDueDate, Direction = ParameterDirection.Input },
                new MySqlParameter("pCommentsLV", MySqlDbType.VarChar, 255) { Value = entity.CommentsLV, Direction = ParameterDirection.Input },
                new MySqlParameter("pLVAppealDeadline", MySqlDbType.VarChar, 45) { Value = entity.LVAppealDeadline, Direction = ParameterDirection.Input },
                new MySqlParameter("pReasonForTheRefusalLV", MySqlDbType.VarChar, 255) { Value = entity.ReasonForTheRefusalLV, Direction = ParameterDirection.Input },

                new MySqlParameter("pClass1", entity.Class1 ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pClass1Description", MySqlDbType.VarChar, 255) { Value = entity.Class1Description, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass2", entity.Class2 ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pClass2Description", MySqlDbType.VarChar, 255) { Value = entity.Class2Description, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass3", entity.Class3 ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pClass3Description", MySqlDbType.VarChar, 255) { Value = entity.Class3Description, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass4", entity.Class4 ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pClass4Description", MySqlDbType.VarChar, 255) { Value = entity.Class4Description, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass5", entity.Class5 ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pClass5Description", MySqlDbType.VarChar, 255) { Value = entity.Class5Description, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass6", entity.Class6 ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pClass6Description", MySqlDbType.VarChar, 255) { Value = entity.Class6Description, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass7", entity.Class7 ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pClass7Description", MySqlDbType.VarChar, 255) { Value = entity.Class7Description, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass8", entity.Class8 ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pClass8Description", MySqlDbType.VarChar, 255) { Value = entity.Class8Description, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass9", entity.Class9 ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pClass9Description", MySqlDbType.VarChar, 255) { Value = entity.Class9Description, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass10", entity.Class10 ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pClass10Description", MySqlDbType.VarChar, 255) { Value = entity.Class10Description, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass11", entity.Class11 ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pClass11Description", MySqlDbType.VarChar, 255) { Value = entity.Class11Description, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass12", entity.Class12 ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pClass12Description", MySqlDbType.VarChar, 255) { Value = entity.Class12Description, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass13", entity.Class13 ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pClass13Description", MySqlDbType.VarChar, 255) { Value = entity.Class13Description, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass14", entity.Class14 ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pClass14Description", MySqlDbType.VarChar, 255) { Value = entity.Class14Description, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass15", entity.Class15 ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pClass15Description", MySqlDbType.VarChar, 255) { Value = entity.Class15Description, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass16", entity.Class16 ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pClass16Description", MySqlDbType.VarChar, 255) { Value = entity.Class16Description, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass17", entity.Class17 ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pClass17Description", MySqlDbType.VarChar, 255) { Value = entity.Class17Description, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass18", entity.Class18 ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pClass18Description", MySqlDbType.VarChar, 255) { Value = entity.Class18Description, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass19", entity.Class19 ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pClass19Description", MySqlDbType.VarChar, 255) { Value = entity.Class19Description, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass20", entity.Class20 ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pClass20Description", MySqlDbType.VarChar, 255) { Value = entity.Class20Description, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass21", entity.Class21 ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pClass21Description", MySqlDbType.VarChar, 255) { Value = entity.Class21Description, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass22", entity.Class22 ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pClass22Description", MySqlDbType.VarChar, 255) { Value = entity.Class22Description, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass23", entity.Class23 ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pClass23Description", MySqlDbType.VarChar, 255) { Value = entity.Class23Description, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass24", entity.Class24 ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pClass24Description", MySqlDbType.VarChar, 255) { Value = entity.Class24Description, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass25", entity.Class25 ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pClass25Description", MySqlDbType.VarChar, 255) { Value = entity.Class25Description, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass26", entity.Class26 ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pClass26Description", MySqlDbType.VarChar, 255) { Value = entity.Class26Description, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass27", entity.Class27 ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pClass27Description", MySqlDbType.VarChar, 255) { Value = entity.Class27Description, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass28", entity.Class28 ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pClass28Description", MySqlDbType.VarChar, 255) { Value = entity.Class28Description, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass29", entity.Class29 ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pClass29Description", MySqlDbType.VarChar, 255) { Value = entity.Class29Description, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass30", entity.Class30 ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pClass30Description", MySqlDbType.VarChar, 255) { Value = entity.Class30Description, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass31", entity.Class31 ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pClass31Description", MySqlDbType.VarChar, 255) { Value = entity.Class31Description, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass32", entity.Class32 ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pClass32Description", MySqlDbType.VarChar, 255) { Value = entity.Class32Description, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass33", entity.Class33 ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pClass33Description", MySqlDbType.VarChar, 255) { Value = entity.Class33Description, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass34", entity.Class34 ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pClass34Description", MySqlDbType.VarChar, 255) { Value = entity.Class34Description, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass35", entity.Class35 ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pClass35Description", MySqlDbType.VarChar, 255) { Value = entity.Class35Description, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass36", entity.Class36 ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pClass36Description", MySqlDbType.VarChar, 255) { Value = entity.Class36Description, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass37", entity.Class37 ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pClass37Description", MySqlDbType.VarChar, 255) { Value = entity.Class37Description, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass38", entity.Class38 ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pClass38Description", MySqlDbType.VarChar, 255) { Value = entity.Class38Description, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass39", entity.Class39 ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pClass39Description", MySqlDbType.VarChar, 255) { Value = entity.Class39Description, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass40", entity.Class40 ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pClass40Description", MySqlDbType.VarChar, 255) { Value = entity.Class40Description, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass41", entity.Class41 ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pClass41Description", MySqlDbType.VarChar, 255) { Value = entity.Class41Description, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass42", entity.Class42 ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pClass42Description", MySqlDbType.VarChar, 255) { Value = entity.Class42Description, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass43", entity.Class43 ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pClass43Description", MySqlDbType.VarChar, 255) { Value = entity.Class43Description, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass44", entity.Class44 ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pClass44Description", MySqlDbType.VarChar, 255) { Value = entity.Class44Description, Direction = ParameterDirection.Input },
                new MySqlParameter("pClass45", entity.Class45 ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pClass45Description", MySqlDbType.VarChar, 255) { Value = entity.Class45Description, Direction = ParameterDirection.Input },

                new MySqlParameter("pResearcherName", MySqlDbType.VarChar, 100) { Value = entity.ResearcherName, Direction = ParameterDirection.Input },
                new MySqlParameter("pTMWebsiteID", MySqlDbType.Int32) { Value = entity.TMWebsite?.ID, Direction = ParameterDirection.Input },
                new MySqlParameter("pOwnerWebsiteID", MySqlDbType.Int32) { Value = entity.OwnerWebsite?.ID, Direction = ParameterDirection.Input },
                new MySqlParameter("pComWebsiteID", MySqlDbType.Int32) { Value = entity.ComWebsite?.ID, Direction = ParameterDirection.Input },
                new MySqlParameter("pCancellationStrategy", MySqlDbType.VarChar, 45) { Value = entity.CancellationStrategy, Direction = ParameterDirection.Input },
                new MySqlParameter("pMarkUse", MySqlDbType.VarChar, 45) { Value = entity.MarkUse, Direction = ParameterDirection.Input },
                new MySqlParameter("pCompetingMarks", entity.CompetingMarks ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pCompetingMark", MySqlDbType.VarChar, 255) { Value = entity.CompetingMark, Direction = ParameterDirection.Input },
                new MySqlParameter("pCancelResearcherComments", MySqlDbType.VarChar, 255) { Value = entity.CancelResearcherComments, Direction = ParameterDirection.Input },
                new MySqlParameter("pOwnerDefense", MySqlDbType.VarChar, 45) { Value = entity.OwnerDefense, Direction = ParameterDirection.Input },

                new MySqlParameter("pSourceName", MySqlDbType.VarChar, 100) { Value = entity.SourceName, Direction = ParameterDirection.Input },
                new MySqlParameter("pBFStrategy", MySqlDbType.VarChar, 45) { Value = entity.BFStrategy, Direction = ParameterDirection.Input },
                new MySqlParameter("pStrategyNotes", MySqlDbType.VarChar, 255) { Value = entity.StrategyNotes, Direction = ParameterDirection.Input },
                new MySqlParameter("pNameValue", MySqlDbType.VarChar, 45) { Value = entity.NameValue, Direction = ParameterDirection.Input },
                new MySqlParameter("pCancelBuyBudget", MySqlDbType.VarChar, 100) { Value = entity.CancelBuyBudget, Direction = ParameterDirection.Input },

                new MySqlParameter("pRevocationReferenceExternal", MySqlDbType.VarChar, 100) { Value = entity.RevocationReferenceExternal, Direction = ParameterDirection.Input },

                new MySqlParameter("pInvalidityNumber", MySqlDbType.VarChar, 45) { Value = entity.InvalidityNumber, Direction = ParameterDirection.Input },
                new MySqlParameter("pInvalidityApplicantID", MySqlDbType.Int32) { Value = entity.InvalidityApplicant?.ID, Direction = ParameterDirection.Input },
                new MySqlParameter("pInvalidityInvokedGround", MySqlDbType.VarChar, 255) { Value = entity.InvalidityInvokedGround, Direction = ParameterDirection.Input },
                new MySqlParameter("pInvalidityDate", MySqlDbType.VarChar, 45) { Value = entity.InvalidityDate, Direction = ParameterDirection.Input },
                new MySqlParameter("pInvalidityActionOutcome", MySqlDbType.VarChar, 45) { Value = entity.InvalidityActionOutcome, Direction = ParameterDirection.Input },

                new MySqlParameter("pLetterReference", MySqlDbType.VarChar, 45) { Value = entity.LetterReference, Direction = ParameterDirection.Input },
                new MySqlParameter("pLetterOrigin", MySqlDbType.VarChar, 45) { Value = entity.LetterOrigin, Direction = ParameterDirection.Input },
                new MySqlParameter("pLetterSendingMethod", MySqlDbType.VarChar, 45) { Value = entity.LetterSendingMethod, Direction = ParameterDirection.Input },
                new MySqlParameter("pLetterSentOn", MySqlDbType.VarChar, 45) { Value = entity.LetterSentOn, Direction = ParameterDirection.Input },
                new MySqlParameter("pOwnerResponseDeadline", MySqlDbType.VarChar, 45) { Value = entity.OwnerResponseDeadline, Direction = ParameterDirection.Input },
                new MySqlParameter("pLetterOutcome", MySqlDbType.VarChar, 45) { Value = entity.LetterOutcome, Direction = ParameterDirection.Input },
            });

            return parameters.ToArray();
        }

        #endregion
    }
}
