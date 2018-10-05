﻿using BigFootVentures.Business.Objects.Management;
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
                var entity = new DomainN
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
                    SalePriceUSD = dataReader["SalesPriceUSD"] as string,
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
                };

                entities.Add(entity);
            }

            return entities;
        }

        public MySqlParameter[] CreateParameters(object model)
        {
            var entity = (DomainN)model;
            var parameters = new List<MySqlParameter>();

            parameters.AddRange(new MySqlParameter[]
            {
                new MySqlParameter("pRegistrantCompanyID", MySqlDbType.Int32) { Value = entity.RegistrantCompanyID, Direction = ParameterDirection.Input },

                new MySqlParameter("pName", MySqlDbType.VarChar, 100) { Value = entity.Name, Direction = ParameterDirection.Input },
                new MySqlParameter("pDomainEnquiryID", MySqlDbType.Int32) { Value = entity.DomainEnquiryID, Direction = ParameterDirection.Input },
                new MySqlParameter("pBrandID", MySqlDbType.Int32) { Value = entity.BrandID, Direction = ParameterDirection.Input },
                new MySqlParameter("pBFStrategy", MySqlDbType.VarChar, 45) { Value = entity.BFStrategy, Direction = ParameterDirection.Input },
                new MySqlParameter("pBuysideFunnel", MySqlDbType.VarChar, 45) { Value = entity.BuysideFunnel, Direction = ParameterDirection.Input },
                new MySqlParameter("pRemarks", MySqlDbType.VarChar, 255) { Value = entity.Remarks, Direction = ParameterDirection.Input },
                new MySqlParameter("pFMVOrderOfMagnitude", MySqlDbType.VarChar, 45) { Value = entity.FMVOrderOfMagnitude, Direction = ParameterDirection.Input },
                new MySqlParameter("pStatus", MySqlDbType.VarChar, 45) { Value = entity.Status, Direction = ParameterDirection.Input },
                new MySqlParameter("pVersion", MySqlDbType.VarChar, 45) { Value = entity.Version, Direction = ParameterDirection.Input },
                new MySqlParameter("pCategory", MySqlDbType.VarChar, 45) { Value = entity.Category, Direction = ParameterDirection.Input },
                new MySqlParameter("pAccountID", MySqlDbType.VarChar, 45) { Value = entity.AccountID, Direction = ParameterDirection.Input },
                new MySqlParameter("pWebsiteCurrent", entity.WebsiteCurrent ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pLocked", entity.Locked ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pWebsiteUse", MySqlDbType.VarChar, 45) { Value = entity.WebsiteUse, Direction = ParameterDirection.Input },
                new MySqlParameter("pWebsiteDescription", MySqlDbType.VarChar, 255) { Value = entity.WebsiteDescription, Direction = ParameterDirection.Input },
                new MySqlParameter("pWebsiteRedirect", MySqlDbType.VarChar, 255) { Value = entity.WebsiteRedirect, Direction = ParameterDirection.Input },
                new MySqlParameter("pExpirationDate", MySqlDbType.VarChar, 45) { Value = entity.ExpirationDate, Direction = ParameterDirection.Input },
                new MySqlParameter("pCompanyWebsite", entity.CompanyWebsite ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pAutoRenew", entity.AutoRenew ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pWHOIS", MySqlDbType.VarChar, 45) { Value = entity.WHOIS, Direction = ParameterDirection.Input },
                new MySqlParameter("pRegistrationPriceUSD", MySqlDbType.VarChar, 45) { Value = entity.RegistrationPriceUSD, Direction = ParameterDirection.Input },
                new MySqlParameter("pRegistrationDate", MySqlDbType.VarChar, 45) { Value = entity.RegistrationDate, Direction = ParameterDirection.Input },
                new MySqlParameter("pBigFootParkingPage", MySqlDbType.VarChar, 45) { Value = entity.BigFootParkingPage, Direction = ParameterDirection.Input },
                new MySqlParameter("pPrivacyProtected", entity.PrivacyProtected ? 1 : 0) { Direction = ParameterDirection.Input },

                new MySqlParameter("pRegistrarID", MySqlDbType.Int32) { Value = entity.RegistrarID, Direction = ParameterDirection.Input },

                new MySqlParameter("pRegistrantID", MySqlDbType.Int32) { Value = entity.RegistrantID, Direction = ParameterDirection.Input },
                new MySqlParameter("pPreviousRegistrantID", MySqlDbType.Int32) { Value = entity.PreviousRegistrantID, Direction = ParameterDirection.Input },
                new MySqlParameter("pRegistrantEmail", MySqlDbType.VarChar, 100) { Value = entity.RegistrantEmail, Direction = ParameterDirection.Input },
                new MySqlParameter("pPrivateRegistrationEmail", MySqlDbType.VarChar, 100) { Value = entity.PrivateRegistrationEmail, Direction = ParameterDirection.Input },
                new MySqlParameter("pPreviousRegistrantChangedOn", MySqlDbType.VarChar, 45) { Value = entity.PreviousRegistrantChangedOn, Direction = ParameterDirection.Input },

                new MySqlParameter("pPurchasePriceUSD", MySqlDbType.VarChar, 45) { Value = entity.PurchasePriceUSD, Direction = ParameterDirection.Input },
                new MySqlParameter("pPurchaseDate", MySqlDbType.VarChar, 45) { Value = entity.PurchaseDate, Direction = ParameterDirection.Input },
                new MySqlParameter("pSalePriceUSD", MySqlDbType.VarChar, 45) { Value = entity.SalePriceUSD, Direction = ParameterDirection.Input },
                new MySqlParameter("pSaleDate", MySqlDbType.VarChar, 45) { Value = entity.SaleDate, Direction = ParameterDirection.Input },

                new MySqlParameter("pCDDateSent", MySqlDbType.VarChar, 45) { Value = entity.CDDateSent, Direction = ParameterDirection.Input },
                new MySqlParameter("pCDSentFrom", MySqlDbType.VarChar, 45) { Value = entity.CDSentFrom, Direction = ParameterDirection.Input },
                new MySqlParameter("pCDSentMethod", MySqlDbType.VarChar, 45) { Value = entity.CDSentMethod, Direction = ParameterDirection.Input },
                new MySqlParameter("pCDCourier", MySqlDbType.VarChar, 45) { Value = entity.CDCourier, Direction = ParameterDirection.Input },
                new MySqlParameter("pCDTrackingNumber", MySqlDbType.VarChar, 45) { Value = entity.CDTrackingNumber, Direction = ParameterDirection.Input },
                new MySqlParameter("pTrademarkUsedInTheUDRPID", MySqlDbType.Int32) { Value = entity.TrademarkUsedInTheUDRPID, Direction = ParameterDirection.Input },
                new MySqlParameter("pUDRPFilingDate", MySqlDbType.VarChar, 45) { Value = entity.UDRPFilingDate, Direction = ParameterDirection.Input },
                new MySqlParameter("pUDRPCostInUSD", MySqlDbType.VarChar, 45) { Value = entity.UDRPCostInUSD, Direction = ParameterDirection.Input },
                new MySqlParameter("pUDRPCostOtherThanUSD", MySqlDbType.VarChar, 45) { Value = entity.UDRPCostOtherThanUSD, Direction = ParameterDirection.Input },
                new MySqlParameter("pUDRPCaseNumber", MySqlDbType.VarChar, 45) { Value = entity.UDRPCaseNumber, Direction = ParameterDirection.Input },
                new MySqlParameter("pArbitratorName", MySqlDbType.VarChar, 45) { Value = entity.ArbitratorName, Direction = ParameterDirection.Input },
                new MySqlParameter("pUDRPJurisdiction", MySqlDbType.VarChar, 100) { Value = entity.UDRPJurisdiction, Direction = ParameterDirection.Input },
                new MySqlParameter("pLanguageOfProceedings", MySqlDbType.VarChar, 45) { Value = entity.LanguageOfProceedings, Direction = ParameterDirection.Input },
                new MySqlParameter("pLegalActionRelatedProceedings", entity.LegalActionRelatedProceedings ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pUDRPOutcome", MySqlDbType.VarChar, 45) { Value = entity.UDRPOutcome, Direction = ParameterDirection.Input },
                new MySqlParameter("pUDRPComment", MySqlDbType.VarChar, 255) { Value = entity.UDRPComment, Direction = ParameterDirection.Input },

                new MySqlParameter("pDeletionRequest", entity.DeletionRequest ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pDeletionRequestReason", MySqlDbType.VarChar, 255) { Value = entity.DeletionRequestReason, Direction = ParameterDirection.Input }
            });

            return parameters.ToArray();
        }

        #endregion
    }
}
