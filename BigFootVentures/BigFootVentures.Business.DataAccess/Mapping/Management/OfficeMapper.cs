﻿using BigFootVentures.Business.DataAccess.Utilities;
using BigFootVentures.Business.Objects.Management;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BigFootVentures.Business.DataAccess.Mapping.Management
{
    public sealed class OfficeMapper : IMapper
    {
        #region "Public Methods"

        public ICollection<object> ParseData(MySqlDataReader dataReader)
        {
            var entities = new List<object>();

            while (dataReader.Read())
            {
                var entity = new Office
                {
                    ID = (int)dataReader["ID"],
                    OwnerName = dataReader["OwnerName"] as string,

                    OfficeName = dataReader["OfficeName"] as string,
                    ExternalID = dataReader["ExternalID"] as string,
                    GeographyType = dataReader["GeographyType"] as string,
                    State = dataReader["State"] as string,
                    StateAbbreviation = dataReader["StateAbbreviation"] as string,
                    OfficeProperty = dataReader["OfficeProperty"] as string,
                    OfficeUrl = dataReader["OfficeUrl"] as string,
                    OfficeValueCategory = dataReader["OfficeValueCategory"] as string,
                    Online = ((dataReader["Online"] as sbyte? ?? 0) == 1),
                    OnlineComments = dataReader["OnlineComments"] as string,
                    //CountryManager = dataReader["CountryManager"] as string,
                    PublicationDateComments = dataReader["PublicationDateComments"] as string,
                    RegistrationDateComments = dataReader["RegistrationDateComments"] as string,
                    OppositionPeriodMonths = dataReader["OppositionPeriodMonths"] as string,
                    SearchUrl = dataReader["SearchUrl"] as string,
                    OfficeStatusesSource = dataReader["OfficeStatusesSource"] as string,
                    OfficeNameArchive = dataReader["OfficeNameArchive"] as string,
                    NationalNumberAssigned = ((dataReader["NationalNumberAssigned"] as sbyte? ?? 0) == 1),
                    Points = dataReader["Points"] as string,
                    PCT = ((dataReader["PCT"] as sbyte? ?? 0) == 1),
                    Paris = ((dataReader["Paris"] as sbyte? ?? 0) == 1),
                    WTO = ((dataReader["WTO"] as sbyte? ?? 0) == 1),

                    RegistrationPaymentNotification = dataReader["RegistrationPaymentNotification"] as string,
                    RegistrationPaymentMethod = dataReader["RegistrationPaymentMethod"] as string,
                    OppositionPaymentNotification = dataReader["OppositionPaymentNotification"] as string,
                    OppositionPaymentMethod = dataReader["OppositionPaymentMethod"] as string,
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
                var entity = new Office
                {
                    ID = (int)dataReader["ID"],

                    OfficeName = dataReader["OfficeName"] as string
                };

                entities.Add(entity);
            }

            return entities;
        }

        public StringBuilder ExportData(MySqlDataReader dataReader)
        {
            var file = new StringBuilder();

            file.Append("Office Name,Owner Name,External ID,Geography Type,State,State Abbreviation,Office Property,Office URL,Office Value Category,Online,Online Comments,Publication Date Comments,");
            file.Append("Registration Date Comments,Opposition Period Monts, Search URL, Office Statuses Source, Office Name Archive,National Number Assigned,Points,PCT,Paris,WTO,");
            file.Append("Registration Payment Notification,Registration Payment Method,Opposition Payment Notification,Opposition Payment Method");
            file.Append(Environment.NewLine);

            while (dataReader.Read())
            {
                file.Append(DataUtils.EscapeCSV($"{dataReader["OfficeName"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["OwnerName"] as string}") + ",");

                file.Append(DataUtils.EscapeCSV($"{dataReader["ExternalID"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["GeographyType"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["State"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["StateAbbreviation"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["OfficeProperty"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["OfficeUrl"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["OfficeValueCategory"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{(dataReader["Online"] as sbyte? ?? 0) == 1}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["OnlineComments"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["PublicationDateComments"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["RegistrationDateComments"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["OppositionPeriodMonths"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["SearchUrl"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["OfficeStatusesSource"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["OfficeNameArchive"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["NationalNumberAssigned"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["Points"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{(dataReader["PCT"] as sbyte? ?? 0) == 1}") + ",");
                file.Append(DataUtils.EscapeCSV($"{(dataReader["Paris"] as sbyte? ?? 0) == 1}") + ",");
                file.Append(DataUtils.EscapeCSV($"{(dataReader["WTO"] as sbyte? ?? 0) == 1}") + ",");

                file.Append(DataUtils.EscapeCSV($"{dataReader["RegistrationPaymentNotification"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["RegistrationPaymentMethod"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["OppositionPaymentNotification"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["OppositionPaymentMethod"] as string}") + ",");

                file.Append(Environment.NewLine);
            }

            return file;
        }

        public MySqlParameter[] CreateParameters(object model)
        {
            var entity = (Office)model;
            var parameters = new List<MySqlParameter>();

            parameters.AddRange(new MySqlParameter[]
            {
                new MySqlParameter("pOwnerName", MySqlDbType.VarChar, 100) { Value = entity.OwnerName, Direction = ParameterDirection.Input },

                new MySqlParameter("pOfficeName", MySqlDbType.VarChar, 100) { Value = entity.OfficeName, Direction = ParameterDirection.Input },
                new MySqlParameter("pExternalID", MySqlDbType.VarChar, 45) { Value = entity.ExternalID, Direction = ParameterDirection.Input },
                new MySqlParameter("pGeographyType", MySqlDbType.VarChar, 45) { Value = entity.GeographyType, Direction = ParameterDirection.Input },
                new MySqlParameter("pState", MySqlDbType.VarChar, 100) { Value = entity.State, Direction = ParameterDirection.Input },
                new MySqlParameter("pStateAbbreviation", MySqlDbType.VarChar, 45) { Value = entity.StateAbbreviation, Direction = ParameterDirection.Input },
                new MySqlParameter("pOfficeProperty", MySqlDbType.VarChar, 100) { Value = entity.OfficeProperty, Direction = ParameterDirection.Input },
                new MySqlParameter("pOfficeUrl", MySqlDbType.VarChar, 255) { Value = entity.OfficeUrl, Direction = ParameterDirection.Input },
                new MySqlParameter("pOfficeValueCategory", MySqlDbType.VarChar, 45) { Value = entity.OfficeValueCategory, Direction = ParameterDirection.Input },
                new MySqlParameter("pOnline", entity.Online ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pOnlineComments", MySqlDbType.VarChar, 255) { Value = entity.OnlineComments, Direction = ParameterDirection.Input },
                //new MySqlParameter("pCountryManager", MySqlDbType.VarChar, 100) { Value = entity.CountryManager, Direction = ParameterDirection.Input },
                new MySqlParameter("pPublicationDateComments", MySqlDbType.VarChar, 255) { Value = entity.PublicationDateComments, Direction = ParameterDirection.Input },
                new MySqlParameter("pRegistrationDateComments", MySqlDbType.VarChar, 255) { Value = entity.RegistrationDateComments, Direction = ParameterDirection.Input },
                new MySqlParameter("pOppositionPeriodMonths", MySqlDbType.VarChar, 45) { Value = entity.OppositionPeriodMonths, Direction = ParameterDirection.Input },
                new MySqlParameter("pSearchUrl", MySqlDbType.VarChar, 255) { Value = entity.SearchUrl, Direction = ParameterDirection.Input },
                new MySqlParameter("pOfficeStatusesSource", MySqlDbType.VarChar, 100) { Value = entity.OfficeStatusesSource, Direction = ParameterDirection.Input },
                new MySqlParameter("pOfficeNameArchive", MySqlDbType.VarChar, 100) { Value = entity.OfficeNameArchive, Direction = ParameterDirection.Input },
                new MySqlParameter("pNationalNumberAssigned", entity.NationalNumberAssigned ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pPoints", MySqlDbType.VarChar, 100) { Value = entity.Points, Direction = ParameterDirection.Input },
                new MySqlParameter("pPCT", entity.PCT ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pParis", entity.Paris ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pWTO", entity.WTO ? 1 : 0) { Direction = ParameterDirection.Input },

                new MySqlParameter("pRegistrationPaymentNotification", MySqlDbType.VarChar, 100) { Value = entity.RegistrationPaymentNotification, Direction = ParameterDirection.Input },
                new MySqlParameter("pRegistrationPaymentMethod", MySqlDbType.VarChar, 100) { Value = entity.RegistrationPaymentMethod, Direction = ParameterDirection.Input },
                new MySqlParameter("pOppositionPaymentNotification", MySqlDbType.VarChar, 100) { Value = entity.OppositionPaymentNotification, Direction = ParameterDirection.Input },
                new MySqlParameter("pOppositionPaymentMethod", MySqlDbType.VarChar, 100) { Value = entity.OppositionPaymentMethod, Direction = ParameterDirection.Input },

            });

            return parameters.ToArray();
        }
        #endregion
    }
}
