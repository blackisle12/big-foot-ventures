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

            container.RegisterType<IManagementService>(new InjectionFactory(c => new ManagementService(ConfigurationManager.ConnectionStrings["bigfootventures_dev"].ConnectionString)));

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}