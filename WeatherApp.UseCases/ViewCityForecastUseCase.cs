using System.Runtime.CompilerServices;
using WeatherApp.Models;
using WeatherApp.UseCases.Interfaces;
using WeatherApp.UseCases.PluginInterfaces;

namespace WeatherApp.UseCases
{
    public class ViewCityForecastUseCase : IViewCityForecastUseCase
    {
        private readonly ICityForecastRepository cityForecastRepository;

        public ViewCityForecastUseCase(ICityForecastRepository cityForecastRepository)
        {
            this.cityForecastRepository = cityForecastRepository;
        }

        public async Task<Forecast> ExecuteAsync(int cityId)
        {
            return await cityForecastRepository.GetForecastAsync(cityId);
        }
    }
}