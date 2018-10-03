﻿using System.ComponentModel;

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

            public enum Type
            {
                [Description("")]
                NotSet,

                [Description("Lawfirm")]
                Lawfirm,

                [Description("Representative")]
                Representative,

                [Description("Analyst")]
                Analyst,

                [Description("Competitor")]
                Competitor,

                [Description("Customer")]
                Customer,

                [Description("Integrator")]
                Integrator,

                [Description("Investor")]
                Investor,

                [Description("Partner")]
                Partner,

                [Description("Press")]
                Press,

                [Description("Prospect")]
                Prospect,

                [Description("Reseller")]
                Reseller,

                [Description("Other")]
                Other
            }

            public enum CompanySize
            {
                [Description("")]
                NotSet,

                [Description("Small < 10 Employees")]
                Small,

                [Description("Medium 10-100 Employees")]
                Medium,

                [Description("Large - MNC > 100 Employees")]
                Large
            }

            public enum Industry
            {
                [Description("")]
                NotSet,

                [Description("Domain Broker")]
                DomainBroker,

                [Description("Lawfirm")]
                Lawfirm,

                [Description("Agriculture")]
                Agriculture,

                [Description("Apparel")]
                Apparel,

                [Description("Banking")]
                Banking,

                [Description("Biotechnology")]
                Biotechnology,

                [Description("Chemicals")]
                Chemicals,

                [Description("Communications")]
                Communications,

                [Description("Construction")]
                Construction,

                [Description("Consulting")]
                Consulting,

                [Description("Education")]
                Education,

                [Description("Electronics")]
                Electronics,

                [Description("Energy")]
                Energy,

                [Description("Engineering")]
                Engineering,

                [Description("Entertainment")]
                Entertainment,

                [Description("Environmental")]
                Environmental,

                [Description("Finance")]
                Finance,

                [Description("Food & Beverage")]
                FoodAndBeverage,

                [Description("Government")]
                Government,

                [Description("Healthcare")]
                Healthcare,

                [Description("Hospitality")]
                Hospitality,

                [Description("Insurance")]
                Insurance,

                [Description("Machinery")]
                Machinery,

                [Description("Manufacturing")]
                Manufacturing,

                [Description("Media")]
                Media,

                [Description("Not For Profit")]
                NotForProfit,

                [Description("Other")]
                Other,

                [Description("Recreation")]
                Recreation,

                [Description("Retail")]
                Retail,

                [Description("Shipping")]
                Shipping,

                [Description("Technology")]
                Technology,

                [Description("Telecommunications")]
                Telecommunications,

                [Description("Transportation")]
                Transportation,

                [Description("Utilities")]
                Utilities
            }

            public enum Salutation
            {
                [Description("")]
                NotSet,

                [Description("Mr.")]
                Mr,

                [Description("Ms.")]
                Ms,

                [Description("Mrs.")]
                Mrs,

                [Description("Dr.")]
                Dr,

                [Description("Prof.")]
                Prof
            }

            public enum AddressType
            {
                [Description("")]
                NotSet,

                [Description("Commercial Building")]
                CommercialBuilding,

                [Description("Residential")]
                Residential
            }
        }

        public static class DomainEnquiry
        {
            public enum RecordType
            {
                [Description("Domain Enquiry")]
                DomainEnquiry,

                [Description("IT Support")]
                ITSupport
            }

            public enum Priority
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

            public enum StatusDomainEnquiry
            {
                [Description("To be contacted")]
                ToBeContacted,

                [Description("Not Interested")]
                NotInterested,

                [Description("In Negotiations")]
                InNegotiations,

                [Description("Couldn't agree on terms")]
                CouldntAgreeOnTerms,

                [Description("Agreed keep in touch")]
                AgreedKeepInTouch,

                [Description("Follow up")]
                FollowUp,

                [Description("Acquired")]
                Acquired,

                [Description("Leased (BigFoot: Lessor)")]
                LeasedBigFootLessor,

                [Description("Leased (BigFoot: Lessee)")]
                LeasedBigFootLessee,

                [Description("Don't contact us again")]
                DontContactUsAgain,

                [Description("Sent Enquiry 1")]
                SentEnquiry1,

                [Description("Sent Enquiry 2")]
                SentEnquiry2,

                [Description("Sent Enquiry 3")]
                SentEnquiry3,

                [Description("Sent Enquiry 4")]
                SentEnquiry4
            }

            public enum StatusITSupport
            {
                [Description("New")]
                New,

                [Description("On Hold")]
                OnHold,

                [Description("Escalated")]
                Escalated,

                [Description("Under Evaluation")]
                UnderEvaluation,

                [Description("Design/Development")]
                DesignDevelopment,

                [Description("Build Complete")]
                BuildComplete,

                [Description("Testing in Progress")]
                TestingInProgress,

                [Description("Closed")]
                Closed
            }

            public enum CaseAssign
            {
                [Description("")]
                NotSet,

                [Description("Rajiv")]
                Rajiv,

                [Description("Shravan")]
                Shravan
            }

            public enum CaseOrigin
            {
                [Description("")]
                NotSet,

                [Description("Close")]
                Close,

                [Description("Admin")]
                Admin,

                [Description("Email")]
                Email,

                [Description("Phone")]
                Phone,

                [Description("User")]
                User,

                [Description("Web")]
                Web
            }
        }
    }
}