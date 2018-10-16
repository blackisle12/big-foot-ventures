using System;

namespace BigFootVentures.Business.Objects.Management
{
    public sealed class Office : BusinessBase
    {
        #region "Private Members"

        private string _registrationPaymentNotification;
        private string _registrationPaymentMethod;
        private string _oppositionPaymentNotification;
        private string _oppositionPaymentMethod;

        #endregion

        #region "Properties"

        public string OwnerName { get; set; }

        public string OfficeName { get; set; }
        public string ExternalID { get; set; }
        public string GeographyType { get; set; }
        public string State { get; set; }
        public string StateAbbreviation{ get; set; }
        public string OfficeProperty { get; set; }
        public string OfficeUrl { get; set; }
        public string OfficeValueCategory { get; set; }
        public bool IsOnline { get; set; }
        public string OnlineComments { get; set; }
        //public string CountryManager { get; set; }
        public string PublicationDateComments { get; set; }
        public string RegistrationDateComments { get; set; }
        public string OppositionPeriodMonths { get; set; }
        public string SearchUrl { get; set; }
        public string OfficeStatusesSource { get; set; }
        public string OfficeNameArchive { get; set; }
        public bool NationalNumberAssigned { get; set; }
        public string Points { get; set; }
        public bool PCT { get; set; }
        public bool Paris { get; set; }
        public bool WTO { get; set; }

        public string RegistrationPaymentNotification { get { return this._registrationPaymentNotification; } set { this._registrationPaymentNotification = value; if (!string.IsNullOrWhiteSpace(value)) { this.RegistrationPaymentNotifications = value.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries); } } }
        public string RegistrationPaymentMethod { get { return this._registrationPaymentMethod; } set { this._registrationPaymentMethod = value; if (!string.IsNullOrWhiteSpace(value)) { this.RegistrationPaymentMethods = value.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries); } } }
        public string OppositionPaymentNotification { get { return this._oppositionPaymentNotification; } set { this._oppositionPaymentNotification = value; if (!string.IsNullOrWhiteSpace(value)) { this.OppositionPaymentNotifications = value.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries); } } }
        public string OppositionPaymentMethod { get { return this._oppositionPaymentMethod; } set { this._oppositionPaymentMethod = value; if (!string.IsNullOrWhiteSpace(value)) { this.OppositionPaymentMethods = value.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries); } } }

        #endregion

        #region "Calculated Properties"

        public string[] RegistrationPaymentNotifications { get; set; }
        public string[] RegistrationPaymentNotificationsAvailable { get; set; }
        public string[] RegistrationPaymentNotificationsSelected { get; set; }
        public string[] RegistrationPaymentMethods { get; set; }
        public string[] RegistrationPaymentMethodsAvailable { get; set; }
        public string[] RegistrationPaymentMethodsSelected { get; set; }
        public string[] OppositionPaymentNotifications { get; set; }
        public string[] OppositionPaymentNotificationsAvailable { get; set; }
        public string[] OppositionPaymentNotificationsSelected { get; set; }
        public string[] OppositionPaymentMethods { get; set; }
        public string[] OppositionPaymentMethodsAvailable { get; set; }
        public string[] OppositionPaymentMethodsSelected { get; set; }

        #endregion
    }
}
