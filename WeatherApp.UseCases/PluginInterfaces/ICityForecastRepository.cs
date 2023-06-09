using WeatherApp.Models;

namespace WeatherApp.UseCases.PluginInterfaces
{
    public interface ICityForecastRepository
    {
        Task<CityForecast> GetForecastAsync(int cityId);
    }
}