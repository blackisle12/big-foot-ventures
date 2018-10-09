namespace BigFootVentures.Business.Objects.Management
{
    public sealed class Lead : BusinessBase
    {
        #region "Properties"

        public string OwnerName { get; set; }

        public string Status { get; set; }
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Company { get; set; }
        public string Industry { get; set; }
        public string NoOfEmployees { get; set; }
        public string Source { get; set; }

        public string Country { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }

        public bool AssignUsingActiveAssignmentRule { get; set; }

        #endregion
    }
}
