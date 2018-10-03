using BigFootVentures.Business.Objects.Management;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace BigFootVentures.Business.DataAccess.Mapping.Management
{
    public sealed class DomainMapper : IMapper
    {
        #region "Public Methods"

        public ICollection<object> ParseData(MySqlDataReader dataReader)
        {
            var entities = new List<object>();

            while (dataReader.Read())
            {
                entities.Add(new DomainN
                {
                    ID = (int)dataReader["ID"],

                    OwnerName = dataReader["OwnerName"] as string,

                    RegistrantCompanyID = dataReader["RegistrantCompanyID"] as int?,

                    Name = dataReader["Name"] as string,
                    DomainEnquiryID = dataReader["DomainEnquiryID"] as int?,
                    BrandID = dataReader["BrandID"] as int?,
                    BFStrategy = dataReader["BFStrategy"] as string,
                    BuysideFunnel = dataReader["BuysideFunnel"] as string,
                    Remarks = dataReader["Remarks"] as string,
                    FMVOrderOfMagnitude = dataReader["FMVOrderOfMagnitude"] as string,
                    Status = dataReader["Status"] as string,
                    Version = dataReader["Version"] as string,
                    Category = dataReader["Category"] as string,
                    AccountID = dataReader["AccountID"] as string,
                    WebsiteCurrent = (Convert.ToSByte(dataReader["WebsiteCurrent"]) == 1),
                    Locked = (Convert.ToSByte(dataReader["Locked"]) == 1),
                    WebsiteUse = dataReader["WebsiteUse"] as string,
                    WebsiteDescription = dataReader["WebsiteDescription"] as string,
                    WebsiteRedirect = dataReader["WebsiteRedirect"] as string,
                    ExpirationDate = dataReader["ExpirationDate"] as string,
                    CompanyWebsite = (Convert.ToSByte(dataReader["CompanyWebsite"]) == 1),
                    AutoRenew = (Convert.ToSByte(dataReader["AutoRenew"]) == 1),
                    WHOIS = dataReader["WHOIS"] as string,
                    RegistrationPriceUSD = dataReader["RegistrationPriceUSD"] as string,
                    RegistrationDate = dataReader["RegistrationDate"] as string,
                    BigFootParkingPage = dataReader["BigFootParkingPage"] as string,
                    PrivacyProtected = (Convert.ToSByte(dataReader["PrivacyProtected"]) == 1),

                    RegistrarID = dataReader["RegistrarID"] as int?,

                    RegistrantID = dataReader["RegistrantID"] as int?,
                    PreviousRegistrantID = dataReader["PreviousRegistrantID"] as int?,
                    RegistrantEmail = dataReader["RegistrantEmail"] as string,
                    PrivateRegistrationEmail = dataReader["PrivateRegistrationEmail"] as string,
                    PreviousRegistrantChangedOn = dataReader["PreviousRegistrantChangedOn"] as string,

                    PurchasePriceUSD = dataReader["PurchasePriceUSD"] as string,
                    PurchaseDate = dataReader["PurchaseDate"] as string,
                    SalePriceUSD = dataReader["SalePriceUSD"] as string,
                    SaleDate = dataReader["SaleDate"] as string,

                    CDDateSent = dataReader["CDDateSent"] as string,
                    CDSentFrom = dataReader["CDSentFrom"] as string,
                    CDSentMethod = dataReader["CDSentMethod"] as string,
                    CDCourier = dataReader["CDCourier"] as string,
                    CDTrackingNumber = dataReader["CDTrackingNumber"] as string,
                    TrademarkUsedInTheUDRPID = dataReader["TrademarkUsedInTheUDRPID"] as int?,
                    UDRPFilingDate = dataReader["UDRPFilingDate"] as string,
                    UDRPCostInUSD = dataReader["UDRPCostInUSD"] as string,
                    UDRPCostOtherThanUSD = dataReader["UDRPCostOtherThanUSD"] as string,
                    UDRPCaseNumber = dataReader["UDRPCaseNumber"] as string,
                    ArbitratorName = dataReader["ArbitratorName"] as string,
                    UDRPJurisdiction = dataReader["UDRPJurisdiction"] as string,
                    LanguageOfProceedings = dataReader["LanguageOfProceedings"] as string,
                    LegalActionRelatedProceedings = (Convert.ToSByte(dataReader["LegalActionRelatedProceedings"]) == 1),
                    UDRPOutcome = dataReader["UDRPOutcome"] as string,
                    UDRPComment = dataReader["UDRPComment"] as string,

                    DeletionRequest = (Convert.ToSByte(dataReader["DeletionRequest"]) == 1),
                    DeletionRequestReason = dataReader["DeletionRequestReason"] as string
                });
            }

            return entities;
        }

        public MySqlParameter[] CreateParameters(object entity)
        {
            var domain = (DomainN)entity;
            var parameters = new List<MySqlParameter>();

            parameters.AddRange(new MySqlParameter[]
            {
                new MySqlParameter("pRegistrantCompanyID", MySqlDbType.Int32) { Value = domain.RegistrantCompanyID, Direction = ParameterDirection.Input },

                new MySqlParameter("pName", MySqlDbType.VarChar, 100) { Value = domain.Name, Direction = ParameterDirection.Input },
                new MySqlParameter("pDomainEnquiryID", MySqlDbType.Int32) { Value = domain.DomainEnquiryID, Direction = ParameterDirection.Input },
                new MySqlParameter("pBrandID", MySqlDbType.Int32) { Value = domain.BrandID, Direction = ParameterDirection.Input },
                new MySqlParameter("pBFStrategy", MySqlDbType.VarChar, 45) { Value = domain.BFStrategy, Direction = ParameterDirection.Input },
                new MySqlParameter("pBuysideFunnel", MySqlDbType.VarChar, 45) { Value = domain.BuysideFunnel, Direction = ParameterDirection.Input },
                new MySqlParameter("pRemarks", MySqlDbType.VarChar, 255) { Value = domain.Remarks, Direction = ParameterDirection.Input },
                new MySqlParameter("pFMVOrderOfMagnitude", MySqlDbType.VarChar, 45) { Value = domain.FMVOrderOfMagnitude, Direction = ParameterDirection.Input },
                new MySqlParameter("pStatus", MySqlDbType.VarChar, 45) { Value = domain.Status, Direction = ParameterDirection.Input },
                new MySqlParameter("pVersion", MySqlDbType.VarChar, 45) { Value = domain.Version, Direction = ParameterDirection.Input },
                new MySqlParameter("pCategory", MySqlDbType.VarChar, 45) { Value = domain.Category, Direction = ParameterDirection.Input },
                new MySqlParameter("pAccountID", MySqlDbType.VarChar, 45) { Value = domain.AccountID, Direction = ParameterDirection.Input },
                new MySqlParameter("pWebsiteCurrent", domain.WebsiteCurrent ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pLocked", domain.Locked ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pWebsiteUse", MySqlDbType.VarChar, 45) { Value = domain.WebsiteUse, Direction = ParameterDirection.Input },
                new MySqlParameter("pWebsiteDescription", MySqlDbType.VarChar, 255) { Value = domain.WebsiteDescription, Direction = ParameterDirection.Input },
                new MySqlParameter("pWebsiteRedirect", MySqlDbType.VarChar, 255) { Value = domain.WebsiteRedirect, Direction = ParameterDirection.Input },
                new MySqlParameter("pExpirationDate", MySqlDbType.VarChar, 45) { Value = domain.ExpirationDate, Direction = ParameterDirection.Input },
                new MySqlParameter("pCompanyWebsite", domain.CompanyWebsite ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pAutoRenew", domain.AutoRenew ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pWHOIS", MySqlDbType.VarChar, 45) { Value = domain.WHOIS, Direction = ParameterDirection.Input },
                new MySqlParameter("pRegistrationPriceUSD", MySqlDbType.VarChar, 45) { Value = domain.RegistrationPriceUSD, Direction = ParameterDirection.Input },
                new MySqlParameter("pRegistrationDate", MySqlDbType.VarChar, 45) { Value = domain.RegistrationDate, Direction = ParameterDirection.Input },
                new MySqlParameter("pBigFootParkingPage", MySqlDbType.VarChar, 45) { Value = domain.BigFootParkingPage, Direction = ParameterDirection.Input },
                new MySqlParameter("pPrivacyProtected", domain.PrivacyProtected ? 1 : 0) { Direction = ParameterDirection.Input },

                new MySqlParameter("pRegistrarID", MySqlDbType.Int32) { Value = domain.RegistrarID, Direction = ParameterDirection.Input },

                new MySqlParameter("pRegistrantID", MySqlDbType.Int32) { Value = domain.RegistrantID, Direction = ParameterDirection.Input },
                new MySqlParameter("pPreviousRegistrantID", MySqlDbType.Int32) { Value = domain.PreviousRegistrantID, Direction = ParameterDirection.Input },
                new MySqlParameter("pRegistrantEmail", MySqlDbType.VarChar, 100) { Value = domain.RegistrantEmail, Direction = ParameterDirection.Input },
                new MySqlParameter("pPrivateRegistrationEmail", MySqlDbType.VarChar, 100) { Value = domain.PrivateRegistrationEmail, Direction = ParameterDirection.Input },
                new MySqlParameter("pPreviousRegistrantChangedOn", MySqlDbType.VarChar, 45) { Value = domain.PreviousRegistrantChangedOn, Direction = ParameterDirection.Input },

                new MySqlParameter("pPurchasePriceUSD", MySqlDbType.VarChar, 45) { Value = domain.PurchasePriceUSD, Direction = ParameterDirection.Input },
                new MySqlParameter("pPurchaseDate", MySqlDbType.VarChar, 45) { Value = domain.PurchaseDate, Direction = ParameterDirection.Input },
                new MySqlParameter("pSalePriceUSD", MySqlDbType.VarChar, 45) { Value = domain.SalePriceUSD, Direction = ParameterDirection.Input },
                new MySqlParameter("pSaleDate", MySqlDbType.VarChar, 45) { Value = domain.SaleDate, Direction = ParameterDirection.Input },

                new MySqlParameter("pCDDateSent", MySqlDbType.VarChar, 45) { Value = domain.CDDateSent, Direction = ParameterDirection.Input },
                new MySqlParameter("pCDSentFrom", MySqlDbType.VarChar, 45) { Value = domain.CDSentFrom, Direction = ParameterDirection.Input },
                new MySqlParameter("pCDSentMethod", MySqlDbType.VarChar, 45) { Value = domain.CDSentMethod, Direction = ParameterDirection.Input },
                new MySqlParameter("pCDCourier", MySqlDbType.VarChar, 45) { Value = domain.CDCourier, Direction = ParameterDirection.Input },
                new MySqlParameter("pCDTrackingNumber", MySqlDbType.VarChar, 45) { Value = domain.CDTrackingNumber, Direction = ParameterDirection.Input },
                new MySqlParameter("pTrademarkUsedInTheUDRPID", MySqlDbType.Int32) { Value = domain.TrademarkUsedInTheUDRPID, Direction = ParameterDirection.Input },
                new MySqlParameter("pUDRPFilingDate", MySqlDbType.VarChar, 45) { Value = domain.UDRPFilingDate, Direction = ParameterDirection.Input },
                new MySqlParameter("pUDRPCostInUSD", MySqlDbType.VarChar, 45) { Value = domain.UDRPCostInUSD, Direction = ParameterDirection.Input },
                new MySqlParameter("pUDRPCostOtherThanUSD", MySqlDbType.VarChar, 45) { Value = domain.UDRPCostOtherThanUSD, Direction = ParameterDirection.Input },
                new MySqlParameter("pUDRPCaseNumber", MySqlDbType.VarChar, 45) { Value = domain.UDRPCaseNumber, Direction = ParameterDirection.Input },
                new MySqlParameter("pArbitratorName", MySqlDbType.VarChar, 45) { Value = domain.ArbitratorName, Direction = ParameterDirection.Input },
                new MySqlParameter("pUDRPJurisdiction", MySqlDbType.VarChar, 100) { Value = domain.UDRPJurisdiction, Direction = ParameterDirection.Input },
                new MySqlParameter("pLanguageOfProceedings", MySqlDbType.VarChar, 45) { Value = domain.LanguageOfProceedings, Direction = ParameterDirection.Input },
                new MySqlParameter("pLegalActionRelatedProceedings", domain.LegalActionRelatedProceedings ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pUDRPOutcome", MySqlDbType.VarChar, 45) { Value = domain.UDRPOutcome, Direction = ParameterDirection.Input },
                new MySqlParameter("pUDRPComment", MySqlDbType.VarChar, 255) { Value = domain.UDRPComment, Direction = ParameterDirection.Input },

                new MySqlParameter("pDeletionRequest", domain.DeletionRequest ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pDeletionRequestReason", MySqlDbType.VarChar, 255) { Value = domain.DeletionRequestReason, Direction = ParameterDirection.Input }
            });

            return parameters.ToArray();
        }

        #endregion
    }
}
