using System.ComponentModel;

namespace BigFootVentures.Business.Objects.Enumerators
{
    public static class ManagementEnums
    {
        public static class Generic
        {
            public enum Language
            {
                [Description("")]
                NotSet,

                EN, BG, CS, DA, DE, EL, ES, ET, FI, FR, HU, IT, NL, PL, PT, RO, SE, SK, SL, SV, LT, TR, KR, JP, NO, AF, AX, AL, DZ, EG, AS, AD, AO, AI, AQ, AG, AR, AM, AW, AU, AT, AZ,
                BS, BH, BD, BB, BY, BE, BZ, BM, BT, BO, BQ, BA, BW, BV, BR, IO, BN, BF, BI, CV, KH, CM, CA, KY, CF, TD, CL, CN, CX, CC, CO, KM, CG, CD, CK, CR, CI, HR, CU, CW, CY, CZ,
                DK, DJ, DM, DO, EC, GQ, ER, EE, FK, FO, FJ, GF, PF, TF, GA, GM, GE, GH, GI, GR, GL, GD, GP, GU, GT, GG, GN, GW, GY, HT, HM, VA, HN, HK, IS, IN, ID, IR, IQ, IE, IM, IL,
                JM, JE, JO, KZ, KE, KI, KP, KW, KG, LA, LV, LB, LS, LR, LY, LI, LU, MO, MK, MG, MW, MY, MV, ML, MT, MH, MQ, MR, MU, YT, MX, FM, MD, MC, MN, ME, MS, MA, MZ, MM, NA, NR,
                NP, NC, NZ, NI, NE, NG, NU, NF, MP, OM, PK, PW, PS, PA, PG, PY, PE, PH, PN, PR, QA, RE, RU, RW, BL, SH, KN, LC, MF, PM, VC, WS, SM, ST, SA, SN, RS, SC, SG, SX, SI, SB,
                SO, ZA, GS, SS, LK, SD, SR, SJ, SZ, CH, SY, TW, TJ, TZ, TH, TL, TG, TK, TO, TT, TN, TM, TC, TV, UG, UA, AE, GB, US, UM, UY, UZ, VU, VE, VN, VG, VI, WF, EH, YE, ZM, ZW,

                [Description("No Language")]
                NoLanguage
            }
        }

        public static class Agreement
        {
            public enum ObjectOfAgreement
            {
                [Description("Trademarks")]
                Trademarks,

                [Description("Domains")]
                Domains,

                [Description("Trademarks & Domains")]
                TrademarksAndDomains
            }

            public enum Type
            {
                [Description("")]
                NotSet,

                [Description("Coexist")]
                Coexist,

                [Description("Assignment")]
                Assignment,

                [Description("Consent")]
                Consent,

                [Description("Undertakings")]
                Undertakings
            }
        }

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

        public static class EmailResponse
        {
            public enum Status
            {
                [Description("")]
                NotSet,

                [Description("Received")]
                Received,
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

        public static class Office
        {
            public enum GeographyType
            {
                [Description("")]
                NotSet,

                [Description("Country")]
                Country,

                [Description("Regional")]
                Regional,
            }

            public enum OfficeValueCategory
            {
                [Description("")]
                NotSet,

                [Description("Tier 1 - EU")]
                Tier1EU,

                [Description("Tier 1 - US")]
                Tier1US,

                [Description("Tier 2 - Developed Countries")]
                Tier2DevelopedCountries,

                [Description("Tier 3 - Developing")]
                Tier3Developing,
            }

            public enum RegistrationPaymentNotification
            {
                [Description("Email")]
                Email,

                [Description("Letter")]
                Letter,

                [Description("Online")]
                Online,
            }

            public enum RegistrationPaymentMethod
            {
                [Description("IBAN")]
                IBAN,

                [Description("Online - Local CC")]
                OnlineLocalCC,

                [Description("Online - International CC")]
                OnlineInternationalCC,

                [Description("Check")]
                Check,

                [Description("ACH")]
                ACH,

                [Description("Phone - CC")]
                PhoneCC,

                [Description("Cash")]
                Cash,

                [Description("Office - Current Account")]
                OfficeCurrentAccount,

                [Description("Revenue Stamp")]
                RevenueStamp,
            }

            public enum OppositionPaymentNotification
            {
                [Description("Email")]
                Email,

                [Description("Letter")]
                Letter,

                [Description("Online")]
                Online,
            }

            public enum OppositionPaymentMethod
            {
                [Description("IBAN")]
                IBAN,

                [Description("Online")]
                Online,

                [Description("Check")]
                Check,

                [Description("In Person")]
                InPeson,

                [Description("ACH")]
                ACH,

                [Description("Phone - CC")]
                PhoneCC,

                [Description("Cash")]
                Cash,

                [Description("Office - Current Account")]
                OfficeCurrentAccount,

                [Description("Revenue Stamp")]
                RevenueStamp,
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

        public static class Trademark
        {
            public enum OfficeStatus
            {
                [Description("Cancelled")]
                Cancelled,

                [Description("Expired")]
                Expired,

                [Description("Filed")]
                Filed,

                [Description("Opposed")]
                Opposed,

                [Description("Published")]
                Published,

                [Description("Refused")]
                Refused,

                [Description("Registered")]
                Registered,

                [Description("Surrendered")]
                Surrendered,

                [Description("Terminated")]
                Terminated,

                [Description("Under Cancellation")]
                UnderCancellation
            }

            public enum TrademarkType
            {
                [Description("")]
                NotSet,

                [Description("Word")]
                Word,

                [Description("Figurative")]
                Figurative,

                [Description("Combined (Word & Figurative)")]
                Combined
            }

            public enum Geography
            {
                [Description("")]
                NotSet,

                [Description("EU")]
                EU,

                [Description("US")]
                US,

                [Description("France")]
                France,

                [Description("UK")]
                UK
            }

            public enum BigfootGroupOwned
            {
                [Description("")]
                NotSet,

                [Description("Unknown")]
                Unknown,

                [Description("Yes")]
                Yes,

                [Description("No")]
                No
            }

            public enum OpenSimilarityResearchTask
            {
                [Description("")]
                NotSet,

                [Description("Yes")]
                Yes,

                [Description("No")]
                No
            }

            public enum OppositionResearch
            {
                [Description("")]
                NotSet,

                [Description("To Be Done")]
                ToBeDone,

                [Description("Done")]
                Done,

                [Description("Not Applicable")]
                NotApplicable
            }

            public enum CancellationStrategy
            {
                [Description("")]
                NotSet,

                [Description("Proceed")]
                Proceed,

                [Description("Dead")]
                Dead
            }

            public enum MarkUse
            {
                [Description("")]
                NotSet,

                [Description("Active")]
                Active,

                [Description("Inactive")]
                Inactive,

                [Description("Slightly Active")]
                SlightlyActive,

                [Description("Don't know")]
                DontKnow
            }

            public enum OwnerDefense
            {
                [Description("")]
                NotSet,

                [Description("Strong - MNC")]
                StrongMNC,

                [Description("Medium")]
                Medium,

                [Description("Weak")]
                Weak,

                [Description("Unknown")]
                Unknown
            }

            public enum BFStrategy
            {
                [Description("")]
                NotSet,

                [Description("Cancellation Assessment")]
                CancellationAssessment
            }

            public enum NameValue
            {
                [Description("")]
                NotSet,

                [Description("<$1K")]
                LessThan1k,

                [Description(">$1K - <$10K")]
                LessThan10k,

                [Description(">$10K - <$100K")]
                LessThan100k,

                [Description(">$100K")]
                GreaterThan100k
            }

            public enum InvalidityActionOutcome
            {
                [Description("")]
                NotSet,

                [Description("Unsuccessful")]
                Unsuccessful,

                [Description("Successful")]
                Successful,

                [Description("Withdrawn by us")]
                WithdrawnByUs,

                [Description("Invalid - TM expired")]
                InvalidTMExpired,

                [Description("Revoked")]
                Revoked
            }

            public enum LetterOrigin
            {
                [Description("")]
                NotSet,

                [Description("Cebu")]
                Cebu,

                [Description("Hongkong")]
                Hongkong,

                [Description("Tokyo")]
                Tokyo
            }

            public enum LetterSendingMethod
            {
                [Description("")]
                NotSet,

                [Description("Courier")]
                Courier,

                [Description("Registered post")]
                RegisteredPost,

                [Description("Regular post")]
                RegularPost
            }

            public enum LetterOutcome
            {
                [Description("")]
                NotSet,

                [Description("No answer")]
                NoAnswer,

                [Description("In negotiations")]
                InNegotations,

                [Description("Accepted")]
                Accepted,

                [Description("Refused")]
                Refused
            }

            public enum WIPO
            {
                [Description("Afghanistan (AF)")]
                Afghanistan,

                [Description("Africa (OAPI")]
                Africa,

                [Description("Aland Islands (AX)")]
                AlandIslands,

                [Description("Albania (AL")]
                Albania,

                [Description("Algeria (DZ)")]
                Algeria,

                [Description("American Samoa (AS)")]
                AmericanSamoa,

                [Description("Andorra (AD)")]
                Andorra,

                [Description("Angola (AO)")]
                Angola,

                [Description("Anguilla (AI)")]
                Anguilla,

                [Description("Antartica (AQ)")]
                Antartica,

                [Description("Antigua and Barbuda (AG)")]
                AntiguaAndBarbuda,

                [Description("Argentina (AR)")]
                Argentina,

                [Description("Armenia (AM)")]
                Armenia,

                [Description("Aruba (AW)")]
                Aruba,

                [Description("Australia (AU)")]
                Australia,

                [Description("Austria (AT)")]
                Austria,

                [Description("Azerbaijan (AZ)")]
                Azerbaijan,

                [Description("Bahamas (BS)")]
                Bahamas,

                [Description("Bahrain (BH)")]
                Bahrain,

                [Description("Bangladesh (BD)")]
                Bangladesh,

                [Description("Barbados (BB)")]
                Barbados,

                [Description("Belarus (BY)")]
                Belarus,

                [Description("Belgium (BE)")]
                Belgium,

                [Description("Belize (BZ)")]
                Belize,

                [Description("Benelux (BOIP)")]
                Benelux,

                [Description("Benin (BJ)")]
                Benin,

                [Description("Bermuna (BM)")]
                Bermuna,

                [Description("Bhutan (BT)")]
                Bhutan,

                [Description("Bolivia (Plurinational State of) (BO)")]
                Bolivia,

                [Description("Bonaire, Sint Eustatius and Saba (BQ)")]
                Bonaire,

                [Description("Bosnia and Herzegovina (BA)")]
                BosniaAndHerzegovina,

                [Description("Botswana (BW)")]
                Botswana,

                [Description("Bouvet Island (BV)")]
                BouvetIsland,

                [Description("Brazil (BR)")]
                Brazil,

                [Description("British Indian Ocean Territory (IO)")]
                BritishIndianOceanTerritory,

                [Description("Brunei Darussalam (BN)")]
                BruneiDarussalam,

                [Description("Bulgaria (BG)")]
                Bulgaria,

                [Description("Burkina Faso (BF)")]
                BurkinaFaso,

                [Description("Burundi (BI)")]
                Burundi,

                [Description("Carbo Verde (CV)")]
                CarboVerde,

                [Description("Cambodia (KH)")]
                Cambodia,

                [Description("Cameroon (CM)")]
                Cameroon,

                [Description("Canada (CA)")]
                Canada,

                [Description("Cayman Islands (KY)")]
                CaymanIslands,

                [Description("Central African Republic (CF)")]
                CentralAfricanRepublic,

                [Description("Chad (TD)")]
                Chad,

                [Description("Chile (CL)")]
                Chile,

                [Description("China (CN)")]
                China,

                [Description("Christmas Island (CX)")]
                ChristmasIsland,

                [Description("Cocos (Keeling) Islands (CC)")]
                CocosIslands,

                [Description("Colombia (CO)")]
                Colombia,

                [Description("Comoros (KM)")]
                Comoros,

                [Description("Congo (CG)")]
                Congo,

                [Description("Congo (Democratic Republic of the) (CD)")]
                CongoDemocratic,

                [Description("Cook Islands (CK)")]
                CookIslands,

                [Description("Costa Rica (CR)")]
                CostaRica,

                [Description("Cote d'Ioire (CI)")]
                CoteDIviore,

                [Description("Croatia (HR)")]
                Croatia,

                [Description("Cuba (CU)")]
                Cuba,

                [Description("Curacao (CW)")]
                Curacao,

                [Description("Cyprus (CY)")]
                Cyprus,

                [Description("Czech Republic (CZ)")]
                CzechRepublic,

                [Description("Democratic People's Republic of Korea (KP)")]
                DemocraticPeopleRepublicOfKorea,

                [Description("Denmark (DK)")]
                Denmark,

                [Description("Djibouti (DJ)")]
                Djibouti,

                [Description("Dominica (DM)")]
                Dominica,

                [Description("Dominican Republic (DO)")]
                DominicanRepublic,

                [Description("Ecuador (EC)")]
                Ecuador
            }

            public enum ARIPO
            {
                [Description("BW - Botswana")]
                Botswana,

                [Description("LR - Liberia")]
                Liberia,

                [Description("LS - Lesotho")]
                Lesotho,

                [Description("MW - Malawi")]
                Malawi,

                [Description("NA - Namibia")]
                Namibia,

                [Description("SZ - Swaziland")]
                Swaziland,

                [Description("TZ - United Republic of Tanzania")]
                UnitedRepublicOfTanzania,

                [Description("UG - Uganda")]
                Uganda,

                [Description("ZW - Zimbabwe")]
                Zimbabwe
            }
        }
    }
}
