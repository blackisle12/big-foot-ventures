using BigFootVentures.Business.DataAccess.Mapping;
using BigFootVentures.Business.DataAccess.Mapping.Management;
using BigFootVentures.Business.Objects.Management;
using System;

namespace BigFootVentures.Service.BusinessService.DataAccessMapping
{
    internal static class ManagementMapper
    {
        #region "Public Methods"

        public static IMapper GetMapper(Type type)
        {
            if (type == typeof(AgreementT))
            {
                return new AgreementMapper();
            }
            else if (type == typeof(Brand))
            {
                return new BrandMapper();
            }
            else if (type == typeof(Cancellation))
            {
                return new CancellationMapper();
            }
            else if (type == typeof(Company))
            {
                return new CompanyMapper();
            }
            else if (type == typeof(Contact))
            {
                return new ContactMapper();
            }
            else if (type == typeof(DomainN))
            {
                return new DomainMapper();
            }
            else if (type == typeof(EmailResponse))
            {
                return new EmailResponseMapper();
            }
            else if (type == typeof(Enquiry))
            {
                return new EnquiryMapper();
            }
            else if (type == typeof(Lead))
            {
                return new LeadMapper();
            }
            else if (type == typeof(LegalCase))
            {
                return new LegalCaseMapper();
            }
            else if (type == typeof(LoginInformation))
            {
                return new LoginInformationMapper();
            }
            else if (type == typeof(Office))
            {
                return new OfficeMapper();
            }
            else if (type == typeof(OfficeStatus))
            {
                return new OfficeStatusMapper();
            }
            else if (type == typeof(PreFilingSimilarityResearch))
            {
                return new PreFilingSimilarityResearchMapper();
            }
            else if (type == typeof(Register))
            {
                return new RegisterMapper();
            }
            else if (type == typeof(SimilarTrademark))
            {
                return new SimilarTrademarkMapper();
            }
            else if (type == typeof(Task))
            {
                return new TaskMapper();
            }
            else if (type == typeof(Trademark))
            {
                return new TrademarkMapper();
            }
            else if (type == typeof(TrademarkOwner))
            {
                return new TrademarkOwnerMapper();
            }
            else if (type == typeof(UserAccount))
            {
                return new UserAccountMapper();
            }
            else
            {
                return null;
            }
        }

        #endregion
    }
}
