using BigFootVentures.Business.Objects.Management;
using BigFootVentures.Service.BusinessService;
using System.Configuration;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace BigFootVentures.Application.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            var connectionString = ConfigurationManager.ConnectionStrings["bigfootventures_dev"].ConnectionString;

            container.RegisterType<IManagementService<AgreementT>>(new InjectionFactory(c => new ManagementService<AgreementT>(connectionString)));
            container.RegisterType<IManagementService<Brand>>(new InjectionFactory(c => new ManagementService<Brand>(connectionString)));
            container.RegisterType<IManagementService<Company>>(new InjectionFactory(c => new ManagementService<Company>(connectionString)));
            container.RegisterType<IManagementService<Contact>>(new InjectionFactory(c => new ManagementService<Contact>(connectionString)));
            container.RegisterType<IManagementService<DomainN>>(new InjectionFactory(c => new ManagementService<DomainN>(connectionString)));
            container.RegisterType<IManagementService<EmailResponse>>(new InjectionFactory(c => new ManagementService<EmailResponse>(connectionString)));
            container.RegisterType<IManagementService<Enquiry>>(new InjectionFactory(c => new ManagementService<Enquiry>(connectionString)));
            container.RegisterType<IManagementService<Lead>>(new InjectionFactory(c => new ManagementService<Lead>(connectionString)));
            container.RegisterType<IManagementService<LegalCase>>(new InjectionFactory(c => new ManagementService<LegalCase>(connectionString)));
            container.RegisterType<IManagementService<LoginInformation>>(new InjectionFactory(c => new ManagementService<LoginInformation>(connectionString)));
            container.RegisterType<IManagementService<Office>>(new InjectionFactory(c => new ManagementService<Office>(connectionString)));
            container.RegisterType<IManagementService<OfficeStatus>>(new InjectionFactory(c => new ManagementService<OfficeStatus>(connectionString)));
            container.RegisterType<IManagementService<Register>>(new InjectionFactory(c => new ManagementService<Register>(connectionString)));
            container.RegisterType<IManagementService<SimilarTrademark>>(new InjectionFactory(c => new ManagementService<SimilarTrademark>(connectionString)));
            container.RegisterType<IManagementService<TMRepresentative>>(new InjectionFactory(c => new ManagementService<TMRepresentative>(connectionString)));
            container.RegisterType<IManagementService<Trademark>>(new InjectionFactory(c => new ManagementService<Trademark>(connectionString)));
            container.RegisterType<IManagementService<TrademarkOwner>>(new InjectionFactory(c => new ManagementService<TrademarkOwner>(connectionString)));

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}