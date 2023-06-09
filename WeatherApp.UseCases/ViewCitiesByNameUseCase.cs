using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.UseCases.Interfaces;
using WeatherApp.UseCases.PluginInterfaces;

namespace WeatherApp.UseCases
{
    public class ViewCitiesByNameUseCase : IViewCitiesByNameUseCase
    {
        private readonly ICityForecastRepository cityForecastRepository;

        public ViewCitiesByNameUseCase(ICityForecastRepository cityForecastRepository)
        {
            this.cityForecastRepository = cityForecastRepository;
        }

        public async Task<IEnumerable<CityForecast>> ExecuteAsync(string name)
        {
            return await cityForecastRepository.GetCityForecastsByNameAsync(name);
        }
    }
}
