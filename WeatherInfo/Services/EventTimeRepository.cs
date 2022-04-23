using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using WeatherInfo.Models;

namespace WeatherInfo.Services
{
    public class EventTimeRepository : IEventTimeRepository
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public async Task<Event> GetSunInfoAsync(double latitude, double longitude)
        {
            string Baseurl = "https://api.sunrise-sunset.org";

            try
            {
                Event sunInfo = new Event();
                using (var client = new HttpClient())
                {
                    //Passing service base url
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    //Define request data format
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                    HttpResponseMessage Res = await client.GetAsync($"json?lat={latitude}&lng={longitude}&date=today");
                    //Checking the response is successful or not which is sent using HttpClient
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api
                        var SunResponse = Res.Content.ReadAsStringAsync().Result;
                        //Deserializing the response recieved from web api and storing into the Employee list
                        sunInfo = JsonConvert.DeserializeObject<Event>(SunResponse);
                        return sunInfo;
                    }
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
            return null;
        }
    }
}