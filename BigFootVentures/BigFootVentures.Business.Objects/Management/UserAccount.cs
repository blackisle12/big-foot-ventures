using System;

namespace BigFootVentures.Business.Objects.Management
{
    public sealed class UserAccount : BusinessBase
    {
        #region "Private Members"

        private string _roles;

        #endregion

        #region "Properties"

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Department { get; set; }
        public string Division { get; set; }
        public string EmployeeNumber { get; set; }

        public string MailingCountry { get; set; }
        public string MailingStreet { get; set; }
        public string MailingCity { get; set; }
        public string MailingState { get; set; }
        public string MailingZipCode { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public string Roles { get { return this._roles; } set { this._roles = value; if (!string.IsNullOrWhiteSpace(value)) { this.Roless = value.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries); } } }

        #endregion

        #region "Calculated Properties"

        public string[] Roless { get; set; }
        public string[] RolesAvailable { get; set; }
        public string[] RolesSelected { get; set; }

        #endregion
    }
}
