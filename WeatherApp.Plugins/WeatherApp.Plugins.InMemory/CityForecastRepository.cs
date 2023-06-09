using System.Net;
using WeatherApp.Models;
using WeatherApp.UseCases.PluginInterfaces;

namespace WeatherApp.Plugins.InMemory
{
    public class CityForecastRepository : ICityForecastRepository
    {
        public List<CityForecast> _cityForecasts = new List<CityForecast>
        {
            new CityForecast()
            {
                CityId = 1,
                CityName = "New York",
                Date = new DateTime(2023,06,08),
                TemperatureC = 23, 
                WindInMph = 9,
                FeelsLikeInFahrenheit = 73,
                Humidity = 40
            },

            new CityForecast()
            {
                CityId = 2,
                CityName = "Los Angeles",
                Date = new DateTime(2023,06,08),
                TemperatureC = 30,
                WindInMph = 12,
                FeelsLikeInFahrenheit = 86,
                Humidity = 20
            },


        };

        // Retrieves data about specified city
        public async Task<CityForecast> GetForecastAsync(int cityId)
        {
            CityForecast city = _cityForecasts.First(x => x.CityId == cityId);

            if (city == null)
                return _cityForecasts[0];

            return city;
        }
    }
}