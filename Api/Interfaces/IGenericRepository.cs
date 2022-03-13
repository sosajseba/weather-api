using Microsoft.EntityFrameworkCore;
using Api.Entities;

namespace Api.Interfaces;

public interface IGenericRepository<T> where T : Base
{
    IQueryable<T> Query();
    Task<T?> GetById(int id);
    Task Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}