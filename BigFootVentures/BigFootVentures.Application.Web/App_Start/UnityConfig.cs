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

            container.RegisterType<IManagementService<Brand>>(new InjectionFactory(c => new ManagementService<Brand>(connectionString)));
            container.RegisterType<IManagementService<Company>>(new InjectionFactory(c => new ManagementService<Company>(connectionString)));
            container.RegisterType<IManagementService<Register>>(new InjectionFactory(c => new ManagementService<Register>(connectionString)));
            container.RegisterType<IManagementService<DomainEnquiry>>(new InjectionFactory(c => new ManagementService<DomainEnquiry>(connectionString)));

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}