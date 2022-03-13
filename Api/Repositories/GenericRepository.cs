using Microsoft.EntityFrameworkCore;
using Api.DataAccess;
using Api.Entities;
using Api.Interfaces;
using System.Linq.Expressions;

namespace Api.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : Base
{
    private readonly WeatherContext _context;
    protected readonly DbSet<T> _entities;
    public GenericRepository(WeatherContext context)
    {
        _context = context;
        _entities = context.Set<T>();
    }
    public IQueryable<T> Query()
    {
        return _entities.AsQueryable();
    }
    public async Task<T?> GetById(int id)
    {
        return await _entities.FindAsync(id);
    }
    public async Task Add(T entity)
    {
        await _entities.AddAsync(entity);
    }
    public void Update(T entity)
    {
        _entities.Update(entity);
    }
    public void Delete(T entity)
    {
        _entities.Remove(entity);
    }
}
