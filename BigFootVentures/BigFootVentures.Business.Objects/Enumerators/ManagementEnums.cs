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

        public static class Contact
        {
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
        }

        public static class Domain
        {
            public enum BFStrategy
            {
                [Description("")]
                NotSet,

                [Description("Hold")]
                Hold,

                [Description("Buy")]
                Buy,

                [Description("Sell")]
                Sell,

                [Description("UDRP")]
                UDRP,

                [Description("None")]
                None,

                [Description("Cease and Desist")]
                CeaseAndDesist,

                [Description("C&D and UDRP")]
                CDAndUDRP
            }

            public enum BuysideFunnel
            {
                [Description("")]
                NotSet,

                [Description("Agreed keep in touch")]
                AgreedKeepIntouch,

                [Description("Ceased Negotiations")]
                CeasedNegotiations,

                [Description("In Negotiations")]
                InNegotiations,

                [Description("Not Interested")]
                NotInterested,

                [Description("Purchased")]
                Purchased,

                [Description("Registered")]
                Registered,

                [Description("Sent Enquiry")]
                SentEnquiry,

                [Description("To be contacted")]
                ToBeContacted
            }

            public enum FMVOrderOfMagnitude
            {
                [Description("")]
                NotSet,

                [Description("<$1K")]
                LessThan1K,

                [Description(">1K - <$10K")]
                LessThan10K,

                [Description("$10K - $20K")]
                LessThanOrEqual20K,

                [Description("$20K - $50K")]
                LessThanOrEqual50K,

                [Description("$50K - $100K")]
                LessThanOrEqual100K,

                [Description("$100K - $250K")]
                LessThanOrEqual250K,

                [Description("$250K")]
                Equal250K
            }

            public enum Status
            {
                [Description("")]
                NotSet,

                [Description("Active")]
                Active,

                [Description("Bought")]
                Bought,

                [Description("Cancelled")]
                Cancelled,

                [Description("Expired")]
                Expired,

                [Description("Inactive")]
                Inactive,

                [Description("Leased (BigFoot: Lessee)")]
                LeasedBigFootLessee,

                [Description("Leased (BigFoot: Lessor)")]
                LeasedBigFootLessor,

                [Description("Registered")]
                Registered,

                [Description("Sold")]
                Sold,

                [Description("Update Pending")]
                UpdatePending,

                [Description("PendingDocumentValidation")]
                PendingDocumentValidation
            }

            public enum WebsiteUse
            {
                [Description("")]
                NotSet,

                [Description("Active")]
                Active,

                [Description("Landing Page")]
                LandingPage,

                [Description("Link Farm")]
                LinkFarm,

                [Description("For Sale")]
                ForSale,

                [Description("Under Construction")]
                UnderConstruction,

                [Description("Redirects")]
                Redirects,

                [Description("Blank Page")]
                BlankPage,

                [Description("Parked")]
                Parked,

                [Description("Developed")]
                Developed,

                [Description("Developed External Frame")]
                DevelopedExternalFrame,

                [Description("Disallowed")]
                Disallowed,

                [Description("Jsoup Error - 200")]
                JsoupError200,

                [Description("Not Resolving")]
                NotResolving,

                [Description("Placeholder")]
                Placeholder,

                [Description("Undeveloped")]
                Undeveloped,

                [Description("Coming Soon")]
                ComingSoon,

                [Description("BigFoot Parking Page")]
                BigFootParkingPage
            }

            public enum CDSentFrom
            {
                [Description("")]
                NotSet,

                [Description("NYC")]
                NYC,

                [Description("Miami")]
                Miami,

                [Description("Antwerp")]
                Antwerp,

                [Description("HK")]
                HK,

                [Description("Singapore")]
                Singapore,

                [Description("Tokyo")]
                Tokyo
            }

            public enum CDSentMethod
            {
                [Description("")]
                NotSet,

                [Description("Regular Post")]
                RegularPost,

                [Description("Registered Post")]
                RegisteredPost,

                [Description("Courier")]
                Courier,

                [Description("E-mail")]
                Email
            }

            public enum CDCourier
            {
                [Description("")]
                NotSet,

                [Description("Fedex")]
                Fedex,

                [Description("UPS")]
                UPS,

                [Description("DHL")]
                DHL,

                [Description("Singpost")]
                Singpost
            }

            public enum UDRPJurisdiction
            {
                [Description("")]
                NotSet,

                [Description("WIPO")]
                WIPO,

                [Description("Asian Domain Name Dispute Resolution Centre")]
                AsianDomainNameDisputeResolutionCentre,

                [Description("National Arbitration Forum")]
                NationalArbitrationForum,

                [Description("The Czech Arbitration Court Arbitration Center for Internet Disputes")]
                TheCzechArbitrationCourtArbitrationCenterForInternetDisputes,

                [Description("Arab Center for Domain Name Dispute Resolution")]
                ArabCenterForDomainNameDisputeResolution,
            }

            public enum LanguageOfProceedings
            {
                [Description("")]
                NotSet,

                EN,BG,CS,DA,DE,EL,ES,ET,FI,FR,HU,IT,NL,PL,PT,RO,SE,SK,SL,SV,LT,TR,KR,JP,NO,AF,AX,AL,DZ,EG,AS,AD,AO,AI,AQ,AG,AR,AM,AW,AU,AT,AZ,
                BS,BH,BD,BB,BY,BE,BZ,BM,BT,BO,BQ,BA,BW,BV,BR,IO,BN,BF,BI,CV,KH,CM,CA,KY,CF,TD,CL,CN,CX,CC,CO,KM,CG,CD,CK,CR,CI,HR,CU,CW,CY,CZ,
                DK,DJ,DM,DO,EC,GQ,ER,EE,FK,FO,FJ,GF,PF,TF,GA,GM,GE,GH,GI,GR,GL,GD,GP,GU,GT,GG,GN,GW,GY,HT,HM,VA,HN,HK,IS,IN,ID,IR,IQ,IE,IM,IL,
                JM,JE,JO,KZ,KE,KI,KP,KW,KG,LA,LV,LB,LS,LR,LY,LI,LU,MO,MK,MG,MW,MY,MV,ML,MT,MH,MQ,MR,MU,YT,MX,FM,MD,MC,MN,ME,MS,MA,MZ,MM,NA,NR,
                NP,NC,NZ,NI,NE,NG,NU,NF,MP,OM,PK,PW,PS,PA,PG,PY,PE,PH,PN,PR,QA,RE,RU,RW,BL,SH,KN,LC,MF,PM,VC,WS,SM,ST,SA,SN,RS,SC,SG,SX,SI,SB,
                SO,ZA,GS,SS,LK,SD,SR,SJ,SZ,CH,SY,TW,TJ,TZ,TH,TL,TG,TK,TO,TT,TN,TM,TC,TV,UG,UA,AE,GB,US,UM,UY,UZ,VU,VE,VN,VG,VI,WF,EH,YE,ZM,ZW,

                [Description("No Language")]
                NoLanguage
            }

            public enum UDRPOutcome
            {
                [Description("")]
                NotSet,

                [Description("Successful")]
                Successful,

                [Description("Unsuccessful")]
                Unsuccessful
            }
        }

        public static class Enquiry
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
                [Description("")]
                NotSet,

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

        public static class Lead
        {
            public enum Status
            {
                [Description("Contacted")]
                Contacted,

                [Description("Open")]
                Open,

                [Description("Qualified")]
                Qualified,

                [Description("Unqualified")]
                Unqualified
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

            public enum Source
            {
                [Description("")]
                NotSet,

                [Description("Advertisement")]
                Advertisement,

                [Description("Employee Referral")]
                EmployeeReferral,

                [Description("External Referral")]
                ExternalReferral,

                [Description("Partner")]
                Partner,

                [Description("Public Relations")]
                PublicRelations,

                [Description("Seminar - Internal")]
                SeminarInternal,

                [Description("Seminar - Partner")]
                SeminarPartner,

                [Description("Trade Show")]
                TradeShow,

                [Description("Web")]
                Web,

                [Description("Word of mouth")]
                WordOfMouth,

                [Description("Other")]
                Other
            }
        }

        public static class LoginInformation
        {
            public enum Country
            {
                [Description("")]
                NotSet,
              
                [Description("Australia")]
                Austrailia,

                [Description("Benelux")]
                Benelux,

                [Description("Canada")]
                Canada,

                [Description("China")]
                China,

                [Description("Columbia")]
                Columbia,

                [Description("European Union")]
                EuropeanUnion,

                [Description("France")]
                France,

                [Description("Germany")]
                Germany,

                [Description("Hong Kong")]
                HongKong,

                [Description("Italy")]
                Italy,

                [Description("Macau")]
                Macau,

                [Description("Malaysia")]
                Malaysia,

                [Description("New Zeland")]
                NewZeland,

                [Description("Singapore")]
                Singapore,

                [Description("Taiwan")]
                Taiwan,

                [Description("United Kingdom")]
                UnitedKingdom,

                [Description("USA")]
                USA,

                [Description("Vietnam")]
                Vietnam
            }
        }
      
        public static class OfficeStatus
        {
            public enum StatusGrouping
            {
                [Description("")]
                NotSet,

                [Description("Under Examination")]
                UnderExamination,

                [Description("Published")]
                Published,

                [Description("Refused")]
                Refused,

                [Description("Opposed")]
                Opposed,

                [Description("Registered")]
                Registered,

                [Description("Appealed")]
                Appealed,

                [Description("Withdrawn")]
                Withdrawn,

                [Description("Surrended")]
                Surrended,

                [Description("Converted")]
                Converted,

                [Description("Cancelled")]
                Cancelled,

                [Description("Interrupted")]
                Interrupted,

                [Description("Expired")]
                Expired,

                [Description("Removed")]
                Removed,
            }
        }
    }
}
