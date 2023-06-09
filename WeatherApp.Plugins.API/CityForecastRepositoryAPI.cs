using WeatherApp.Models;
using WeatherApp.UseCases.PluginInterfaces;
using WeatherAPI_CSharp;
using System.Xml.Linq;
using System.IO;
using System.Net.Http.Headers;
using Forecast = WeatherApp.Models.Forecast;

namespace WeatherApp.Plugins.API
{
    public class CityForecastRepositoryAPI : ICityForecastRepository
    {
        private APIClient client = new APIClient("5507533fa8fd404696d164315230906");

        public async Task<Forecast> GetForecastAsync(int zipCode)
        {
            // Call API and get information
            var weather = await client.GetWeatherCurrentAsync($"{zipCode}");
            Console.WriteLine($"Weather in Oshkosh is {weather.TemperatureFahrenheit}");

            Forecast forecast = new Forecast()
            {
                ZipCode = zipCode,
                TemperatureF = weather.TemperatureFahrenheit,
                WindInMph = weather.WindMph,
                Humidity = weather.Humidity,
            };

            return forecast;
        }
    }
}