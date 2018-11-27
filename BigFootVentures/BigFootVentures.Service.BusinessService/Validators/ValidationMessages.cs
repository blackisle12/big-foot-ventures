namespace BigFootVentures.Service.BusinessService.Validators
{
    public static class ValidationMessages
    {
        public const string REQUIRED = "This field is required";
        public const string ROLES_REQUIRED = "Please select atleast 1 role";

        public const string EMAILADDRESS_EXISTS = "An account with this email address already exists";
        public const string USERACCOUNT_INVALID = "User account with username {0} is invalid";
        public const string USERACCOUNT_PASSWORD_INCORRECT = "User account password is incorrect";
        public const string USERACCOUNT_INACTIVE = "User account is inactive";
    }
}
