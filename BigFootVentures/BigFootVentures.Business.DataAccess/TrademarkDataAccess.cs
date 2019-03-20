using BigFootVentures.Business.Objects.Management;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace BigFootVentures.Business.DataAccess
{
    public interface ITrademarkDataAccess
    {
        #region "Factory Methods"

        Trademark Get(int ID);

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

        #endregion

        #region "Public Methods"

        public void Dispose()
        {
            this._connection.Dispose();
        }

        #endregion
    }
}
