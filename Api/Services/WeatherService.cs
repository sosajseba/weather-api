using Api.Interfaces;
using Api.Dtos;
using Api.Responses;

namespace Api.Services;
public class WeatherService : IWeatherService
{
    private readonly IUnitOfWork _unitOfWork;

    public WeatherService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public Response<WeatherDto> GetCurrentWeather(int countryId, int cityId)
    {
        var dbCountry = _unitOfWork.CountryRepository.Query().FirstOrDefault(c => c.Id == countryId);
        var dbCity = _unitOfWork.CityRepository.Query().FirstOrDefault(c => c.Id == cityId);
        if (dbCountry != null)
        {
            if (dbCity != null)
            {
                if (dbCity.CountryId != dbCountry.Id)
                    return new Response<WeatherDto>(false, $"'{dbCity.Name}' city does not belong to '{dbCountry.Name}'");
                var currentWeather = _unitOfWork.WeatherRepository.Query().FirstOrDefault(w => w.CityId == dbCity.Id && DateTime.Now.Date.CompareTo(w.Date.Date) == 0);
                if (currentWeather != null)
                {
                    var currentWeatherDto = currentWeather.ToDto();
                    return new Response<WeatherDto>(currentWeatherDto, true, "Ok");
                }
                return new Response<WeatherDto>(true, $"No data loaded for '{dbCity.Name}'");
            }
            return new Response<WeatherDto>(false, $"City not found");
        }
        return new Response<WeatherDto>(false, $"Country not found");
    }

    public Response<IEnumerable<ForecastDto>> GetForecast(int countryId, int cityId)
    {
        var dbCountry = _unitOfWork.CountryRepository.Query().FirstOrDefault(c => c.Id == countryId);
        var dbCity = _unitOfWork.CityRepository.Query().FirstOrDefault(c => c.Id == cityId);
        if (dbCountry != null)
        {
            if (dbCity != null)
            {
                if (dbCity.CountryId != dbCountry.Id)
                    return new Response<IEnumerable<ForecastDto>>(false, $"'{dbCity.Name}' city does not belong to '{dbCountry.Name}'");

                var offset = DateTime.Now.AddDays(6);

                var forecast = _unitOfWork.WeatherRepository.Query().Where(
                    w => DateTime.Now.AddDays(1).CompareTo(w.Date.Date) < 0 &&
                    offset.CompareTo(w.Date.Date) > 0 &&
                    w.CityId == dbCity.Id
                ).Select(x => new ForecastDto { Date = x.Date, Condition = x.Condition.ToString(), TempC = x.TempC, TempF = x.TempF }).ToList();

                if (forecast.Count() > 0)
                {
                    return new Response<IEnumerable<ForecastDto>>(forecast, true, "Ok");
                }
                return new Response<IEnumerable<ForecastDto>>(true, $"No data loaded for '{dbCity.Name}'");
            }
            return new Response<IEnumerable<ForecastDto>>(false, $"City not found");
        }
        return new Response<IEnumerable<ForecastDto>>(false, $"Country not found");
    }
}