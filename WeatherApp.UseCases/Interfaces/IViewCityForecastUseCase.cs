using WeatherApp.Models;

namespace WeatherApp.UseCases.Interfaces
{
    public interface IViewCityForecastUseCase
    {
        Task<Forecast> ExecuteAsync(int cityId);
    }
}