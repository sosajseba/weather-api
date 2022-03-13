using Api.Dtos;
using Api.Interfaces;
using Api.Responses;

namespace Api.Services;

public class CityService : ICityService
{
    private readonly IUnitOfWork _unitOfWork;

    public CityService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public Response<IEnumerable<CityDto>> GetAll(int page, int size, int countryId)
    {
        int tPage = page <= 0 ? 1 : page;
        int tSize = (size <= 0 || size > 100) ? 40 : size;

        var cities = _unitOfWork.CityRepository.Query().Where(x => (countryId != 0) ? x.CountryId == countryId : true).OrderBy(x => x.Id).Skip((tPage - 1) * tSize).Take(tSize).ToList();

        var response = from c in cities select c.ToDto();

        return new Response<IEnumerable<CityDto>>(response, true, "Ok");
    }
}