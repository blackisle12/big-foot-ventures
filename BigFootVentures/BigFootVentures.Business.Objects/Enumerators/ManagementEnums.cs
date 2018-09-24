using System.ComponentModel;

namespace BigFootVentures.Business.Objects.Enumerators
{
    public static class ManagementEnums
    {
        public static class Brand
        {
            public enum Purpose
            {
                [Description("")]
                NotSet,

                [Description("Core")]
                Core,

                [Description("Non-Core")]
                NonCore
            }

            public enum Value
            {
                [Description("")]
                NotSet,

                [Description("Low")]
                Low,

                [Description("Medium")]
                Medium,

                [Description("High")]
                High
            }

            public enum Category
            {
                [Description("Actor Names")]
                ActorNames,

                [Description("Airlines")]
                Airlines,

                [Description("Animals")]
                Animals,

                [Description("Brandbucket")]
                Brandbucket,

                [Description("First Names")]
                FirstNames,

                [Description("Last Names")]
                LastNames,

                [Description("Locations")]
                Locations,

                [Description("MG's Request")]
                MGRequest,

                [Description("Misc")]
                Misc,

                [Description("Model Names")]
                ModelNames,

                [Description("Movie Titles")]
                MovieTitles,

                [Description("Names")]
                Names,

                [Description("Numbers")]
                Numbers,

                [Description("Sitematrix")]
                Sitematrix,

                [Description("Typo")]
                Typo
            }
        }

        public static class Company
        {
            public enum AccountRecordType
            {
                [Description("Business Account")]
                BusinessAccount,

                [Description("External Client")]
                ExternalClient,

                [Description("Person Account")]
                PersonAccount
            }
        }
    }
}
