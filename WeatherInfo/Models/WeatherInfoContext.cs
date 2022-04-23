using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WeatherInfo.Models
{
    public class WeatherInfoContext : DbContext
    {
        public WeatherInfoContext() : base("MydbConn") 
        {
            Database.SetInitializer<WeatherInfoContext>(new CreateDatabaseIfNotExists<WeatherInfoContext>());
        }

        public DbSet<City> Cities { get; set; }
    }
}