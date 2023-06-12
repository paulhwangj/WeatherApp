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
        private APIClient client;


        public CityForecastRepositoryAPI()
        {
            client = new APIClient(System.Environment.GetEnvironmentVariable("API_KEY"));
        }

        public async Task<Forecast> GetForecastAsync(int zipCode)
        {
            // Call API and get information
            var weather = await client.GetWeatherCurrentAsync($"{zipCode}");

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