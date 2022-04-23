using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherInfo.Models;

namespace WeatherInfo.Services
{
    public class CityRepository : ICityRepository
    {
        WeatherInfoContext db = new WeatherInfoContext();

        public IEnumerable<City> GetAll()
        {
            return db.Cities.OrderBy(city => city.Name).ToList();
        }

        public IEnumerable<City> GetAllFiltered(string filter)
        {
            return db.Cities.Where(b => b.Name.Contains(filter)).ToList();
        }

        public City GetCityInfo(int id)
        {
            var city = db.Cities.FirstOrDefault(c => c.Id == id);
            return city;
        }
    }
}