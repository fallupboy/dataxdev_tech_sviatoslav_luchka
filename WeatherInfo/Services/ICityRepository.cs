using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherInfo.Models;

namespace WeatherInfo.Services
{
    public interface ICityRepository
    {
        IEnumerable<City> GetAll();
        IEnumerable<City> GetAllFiltered(string filter);
        City GetCityInfo(int id);
    }
}
