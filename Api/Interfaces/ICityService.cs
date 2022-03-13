using Api.Dtos;
using Api.Responses;

namespace Api.Interfaces;

public interface ICityService
{
    Response<IEnumerable<CityDto>> GetAll(int page, int size, int countryId);
}