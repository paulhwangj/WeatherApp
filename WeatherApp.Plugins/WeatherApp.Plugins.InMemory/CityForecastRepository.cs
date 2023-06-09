using System.Net;
using WeatherApp.Models;
using WeatherApp.UseCases.PluginInterfaces;

namespace WeatherApp.Plugins.InMemory
{
    public class CityForecastRepository : ICityForecastRepository
    {
        public List<Forecast> _forecasts = new List<Forecast>
        {
            new Forecast()
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

            new CityForecast()
            {
                CityId = 3,
                CityName = "Tokyo",
                Date = new DateTime(2023,06,08),
                TemperatureC = 42,
                WindInMph = 55,
                FeelsLikeInFahrenheit = 92,
                Humidity = 20
            },

            new CityForecast()
            {
                CityId = 4,
                CityName = "Las Vegas",
                Date = new DateTime(2023,06,08),
                TemperatureC = 20,
                WindInMph = 55,
                FeelsLikeInFahrenheit = 92,
                Humidity = 42
            },

            new CityForecast()
            {
                CityId = 5,
                CityName = "Miami",
                Date = new DateTime(2023,06,08),
                TemperatureC = 42,
                WindInMph = 55,
                FeelsLikeInFahrenheit = 92,
                Humidity = 50
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

        // Returns a list that's filtered by name
        public async Task<IEnumerable<CityForecast>> GetCityForecastsByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return await Task.FromResult(_cityForecasts);
            return _cityForecasts.Where(x => x.CityName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}