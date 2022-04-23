using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherInfo.Models
{
    public partial class Event
    {
        [JsonProperty("results")]
        public Result Results { get; set; }
    }

    public partial class Result
    {
        [JsonProperty("sunrise")]
        public string Sunrise { get; set; }

        [JsonProperty("sunset")]
        public string Sunset { get; set; }
    }
}
