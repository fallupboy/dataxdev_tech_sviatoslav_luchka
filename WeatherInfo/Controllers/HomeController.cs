using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WeatherInfo.Models;
using WeatherInfo.Services;

namespace WeatherInfo.Controllers
{
    public class HomeController : Controller
    {
        // log4net logger
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // dependency injection
        private readonly ICityRepository _cityRepository;
        private readonly IEventTimeRepository _eventTimeRepository;

        public HomeController(ICityRepository cityRepository, IEventTimeRepository eventTimeRepository)
        {
            _cityRepository = cityRepository;
            _eventTimeRepository = eventTimeRepository;
        }

        // GET all cities
        public ActionResult Index(string search)
        {
            var cities = _cityRepository.GetAll();
            if (search != null)
            {
                cities = _cityRepository.GetAllFiltered(search);
            }
            return View(cities);
        }

        // GET city events info
        public async Task<ActionResult> EventsInfo(int id, string type)
        {
            try
            {
                var city = _cityRepository.GetCityInfo(id);
                var eventTimeInfo = await _eventTimeRepository.GetSunInfoAsync(city.Latitude, city.Longitude);
                if (eventTimeInfo != null)
                {
                    ViewData["CityName"] = city.Name;
                    ViewData["EventType"] = type;
                    return View(eventTimeInfo);
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
            return RedirectToAction("Index");
        }
    }
}
