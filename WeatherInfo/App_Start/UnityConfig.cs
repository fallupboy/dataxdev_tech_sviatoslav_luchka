using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using WeatherInfo.Services;

namespace WeatherInfo
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<ICityRepository, CityRepository>();
            container.RegisterType<IEventTimeRepository, EventTimeRepository>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}