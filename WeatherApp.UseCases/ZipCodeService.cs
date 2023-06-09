using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace WeatherApp.UseCases
{
    public class ZipCodeService
    {
        private readonly HttpClient _httpClient;

        public ZipCodeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<(string City, string State)> GetCityAndState(string zipCode)
        {
            string apiUrl = $"https://api.zippopotam.us/us/{zipCode}";
            var response = await _httpClient.GetFromJsonAsync<ZipCodeApiResponse>(apiUrl);
            Console.WriteLine(response.ToString());

            string city = response?.Places?[0]?.PlaceName;
            string state = response?.Places?[0]?.State;

            return (city, state);
        }
    }

    public class ZipCodeApiResponse
    {
        public Place[] Places { get; set; }
    }

    public class Place
    {
        [JsonPropertyName("place name")]
        public string PlaceName { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }
    }
}
