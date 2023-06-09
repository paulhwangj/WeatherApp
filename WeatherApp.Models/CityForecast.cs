namespace WeatherApp.Models
{
    public class CityForecast
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public int WindInMph { get; set; }
        public int FeelsLikeInFahrenheit { get; set; }
        public int Humidity { get; set; }
    }
}