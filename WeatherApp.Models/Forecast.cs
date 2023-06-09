using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    public class Forecast
    {
        public int ZipCode { get; set; }
        public string CityName { get; set; }
        public string State { get; set; }

        public double TemperatureF { get; set; }
        public double FeelsLikeInFahrenheit { get; set; }
        public double WindInMph { get; set; }
        public int Humidity { get; set; }
    }
}
