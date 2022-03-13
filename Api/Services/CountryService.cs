using Api.Dtos;
using Api.Interfaces;
using Api.Responses;

namespace Api.Services;

public class CountryService : ICountryService
{
    private readonly IUnitOfWork _unitOfWork;

    public CountryService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public Response<IEnumerable<CountryDto>> GetAll(int page, int size)
    {
        int tPage = page <= 0 ? 1 : page;
        int tSize = (size <= 0 || size > 100) ? 40 : size;

        var countries = _unitOfWork.CountryRepository.Query().OrderBy(x => x.Id).Skip((tPage - 1) * tSize).Take(tSize).ToList();

        var response = from c in countries select c.ToDto();

        return new Response<IEnumerable<CountryDto>>(response, true, "Ok");
    }
}