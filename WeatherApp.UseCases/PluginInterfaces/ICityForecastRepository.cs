using WeatherApp.Models;

namespace WeatherApp.UseCases.PluginInterfaces
{
    public interface ICityForecastRepository
    {
        Task<Forecast> GetForecastAsync(int cityId);
    }
}