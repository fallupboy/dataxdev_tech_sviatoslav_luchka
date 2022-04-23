using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherInfo.Models;

namespace WeatherInfo.Services
{
    public interface IEventTimeRepository
    {
        Task<Event> GetSunInfoAsync(double latitude, double longitude);
    }
}
