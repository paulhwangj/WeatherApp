using WeatherApp.Models;

namespace WeatherApp.UseCases.Interfaces
{
    public interface IViewCitiesByNameUseCase
    {
        Task<IEnumerable<CityForecast>> ExecuteAsync(string name);
    }
}