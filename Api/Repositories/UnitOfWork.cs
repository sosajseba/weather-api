using Api.Interfaces;
using Api.Entities;
using Api.DataAccess;

namespace Api.Repositories;
public class UnitOfWork : IUnitOfWork
{
    private readonly WeatherContext _context;

    public UnitOfWork(WeatherContext context)
    {
        _context = context;
    }

    public IGenericRepository<Weather> WeatherRepository => new GenericRepository<Weather>(_context);
    public IGenericRepository<Country> CountryRepository => new GenericRepository<Country>(_context);
    public IGenericRepository<City> CityRepository => new GenericRepository<City>(_context);

    public void Dispose()
    {
        if (_context != null)
        {
            _context.Dispose();
        }
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}