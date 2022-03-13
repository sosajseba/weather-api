using Api.Entities;

namespace Api.Interfaces;
public interface IUnitOfWork : IDisposable
{
    IGenericRepository<Weather> WeatherRepository { get; }
    IGenericRepository<Country> CountryRepository { get; }
    IGenericRepository<City> CityRepository { get; }

    void SaveChanges();

    Task SaveChangesAsync();
}