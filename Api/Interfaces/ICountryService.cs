using Api.Dtos;
using Api.Responses;

namespace Api.Interfaces;

public interface ICountryService
{
    Response<IEnumerable<CountryDto>> GetAll(int page, int size);
}