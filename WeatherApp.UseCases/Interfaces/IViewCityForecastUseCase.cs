using WeatherApp.Models;

namespace WeatherApp.UseCases.Interfaces
{
    public interface IViewCityForecastUseCase
    {
        Task<CityForecast> ExecuteAsync(int cityId);
    }
}