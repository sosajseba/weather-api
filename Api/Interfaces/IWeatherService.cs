using Api.Dtos;
using Api.Responses;

namespace Api.Interfaces;

public interface IWeatherService
{
    Response<WeatherDto> GetCurrentWeather(int countryId, int cityId);
    Response<IEnumerable<ForecastDto>> GetForecast(int countryId, int cityId);
}