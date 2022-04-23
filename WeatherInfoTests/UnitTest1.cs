using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using WeatherInfo.Controllers;
using WeatherInfo.Models;
using WeatherInfo.Services;

namespace WeatherInfoTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Check_HomeControllerIndexView_Test()
        {
            // Arrange
            ICityRepository cityRepo = new CityRepository();
            IEventTimeRepository eventTimeRepo = new EventTimeRepository();
            HomeController controller = new HomeController(cityRepo, eventTimeRepo);

            // Act
            ViewResult result = controller.Index("test") as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Check_CityEventTimeInfo_Test()
        {
            // Arrange
            IEventTimeRepository repo = new EventTimeRepository();
            City city = new City() { Id = 99, Name = "Kharkiv", Latitude = 49.993500, Longitude = 36.230385 };
            Event ev = new Event();
            ev.Results = new Result() { Sunrise = "2:29:32 AM", Sunset = "4:39:31 PM" };

            // Act
            var result = repo.GetSunInfoAsync(city.Latitude, city.Longitude).Result;

            // Assert
            Assert.AreEqual(new Tuple<string, string>(ev.Results.Sunrise, ev.Results.Sunset), new Tuple<string, string>(result.Results.Sunrise, result.Results.Sunset));
        }
    }
}
