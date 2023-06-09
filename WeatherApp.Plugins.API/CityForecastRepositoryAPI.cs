using WeatherApp.Models;
using WeatherApp.UseCases.PluginInterfaces;
using WeatherAPI_CSharp;
using System.Xml.Linq;
using System.IO;
using System.Net.Http.Headers;

namespace WeatherApp.Plugins.API
{
    public class CityForecastRepositoryAPI : ICityForecastRepository
    {
        private APIClient client = new APIClient("5507533fa8fd404696d164315230906");
        public List<CityForecast> _cityForecasts = new List<CityForecast>();

        public async Task<IEnumerable<CityForecast>> GetCityForecastsByNameAsync(string name)
        {
            string path = "C:\\Users\\bough\\source\\repos\\WeatherApp\\WeatherApp.Plugins.API\\USCities.txt";
            string line;
            string previousCity = "a", previousState = "b", currentCity = "c", currentState = "d";
            int cityId = 0;

            // Open the file to read from it, creating a new CityForecast for each city
            using (StreamReader sr = File.OpenText(path))
            {
                line = sr.ReadLine();   // skips the first line

                while ((line = sr.ReadLine()) != null)
                {
                    // Reassigns to the (potential) new city and state
                    string[] cityInformation = line.Split(',');
                    currentCity = cityInformation[0];
                    currentState = cityInformation[1];

                    // If it's the same city and state, we skip
                    if (previousCity == currentCity && previousState == currentState)
                        continue;

                    // Create the new CityForecast instance, update what the previously added city was
                    _cityForecasts.Add(new CityForecast { CityId = cityId, CityName = currentCity, State = currentState });
                    previousCity = currentCity;
                    previousState = currentState;
                    cityId++;
                }
            }

            if (_cityForecasts.Count() == 0)
                _cityForecasts.Add(new CityForecast() { CityId = 0, CityName = "Problem", State = "Occurred" });

            return await Task.FromResult(_cityForecasts);
        }

        public async Task<CityForecast> GetForecastAsync(int cityId)
        {
            CityForecast city = _cityForecasts[cityId];
            
            // Call API and get information
            var weather = await client.GetWeatherCurrentAsync($"{city.CityName}");

            city.TemperatureC = Convert.ToInt32(weather.TemperatureCelsius);
            city.WindInMph = Convert.ToInt32(weather.WindMph);
            city.Humidity = weather.Humidity;

            return city;
        }
    }
}