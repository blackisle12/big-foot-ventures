using System.ComponentModel;

namespace BigFootVentures.Business.Objects.Enumerators
{
    public static class MembershipEnums
    {
        public enum Role
        {
            [Description("Default")]
            Default,

            [Description("Administrator")]
            Administrator
        }
    }
}
