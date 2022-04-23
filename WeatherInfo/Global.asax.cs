using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WeatherInfo.Models;

namespace WeatherInfo
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            UnityConfig.RegisterComponents();

            log4net.Config.XmlConfigurator.Configure();

            WeatherInfoContext context = new WeatherInfoContext();

            List<City> cities = new List<City>()
            {
                new City() { Id = 1, Name = "Ternopil", Longitude = 49.553520, Latitude = 25.594770 },
                new City() { Id = 2, Name = "Lviv", Longitude = 24.031111, Latitude = 49.842957 },
                new City() { Id = 3, Name = "Uzhhorod", Longitude = 22.288229, Latitude = 48.621025 },
                new City() { Id = 4, Name = "Luhansk", Longitude = 39.307816, Latitude = 48.574039 },
                new City() { Id = 5, Name = "Odesa", Longitude = 30.712481, Latitude = 46.482952 },
                new City() { Id = 6, Name = "Rivne", Longitude = 26.251617, Latitude = 50.619900 },
                new City() { Id = 7, Name = "Poltava", Longitude = 34.551273, Latitude = 49.589542 },
                new City() { Id = 8, Name = "Kerch", Longitude = 36.468292, Latitude = 45.357315 },
                new City() { Id = 9, Name = "Yalta", Longitude = 34.161301, Latitude = 44.506302 },
                new City() { Id = 10, Name = "Uman'", Longitude = 30.221500, Latitude = 48.748718 }
            };

            foreach (var city in cities)
            {
                context.Cities.Add(city);
            }
            context.SaveChanges();
        }
    }
}
