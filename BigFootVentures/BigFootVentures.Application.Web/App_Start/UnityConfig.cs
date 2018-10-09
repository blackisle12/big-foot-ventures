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

            container.RegisterType<IManagementService<Agreement>>(new InjectionFactory(c => new ManagementService<Agreement>(connectionString)));
            container.RegisterType<IManagementService<Brand>>(new InjectionFactory(c => new ManagementService<Brand>(connectionString)));
            container.RegisterType<IManagementService<Company>>(new InjectionFactory(c => new ManagementService<Company>(connectionString)));
            container.RegisterType<IManagementService<Contact>>(new InjectionFactory(c => new ManagementService<Contact>(connectionString)));
            container.RegisterType<IManagementService<DomainN>>(new InjectionFactory(c => new ManagementService<DomainN>(connectionString)));
            container.RegisterType<IManagementService<Enquiry>>(new InjectionFactory(c => new ManagementService<Enquiry>(connectionString)));
            container.RegisterType<IManagementService<Lead>>(new InjectionFactory(c => new ManagementService<Lead>(connectionString)));
            container.RegisterType<IManagementService<LoginInformation>>(new InjectionFactory(c => new ManagementService<LoginInformation>(connectionString)));
            container.RegisterType<IManagementService<OfficeStatus>>(new InjectionFactory(c => new ManagementService<OfficeStatus>(connectionString)));
            container.RegisterType<IManagementService<Register>>(new InjectionFactory(c => new ManagementService<Register>(connectionString)));

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}