
using Microsoft.EntityFrameworkCore;
using Api.DataAccess.Seeds;
using Api.Entities;

namespace Api.DataAccess;
public class WeatherContext : DbContext
{
    public WeatherContext(DbContextOptions<WeatherContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CountrySeed());
        modelBuilder.ApplyConfiguration(new CitySeed());
        modelBuilder.ApplyConfiguration(new WeatherSeed());
    }

    public DbSet<City>? City { get; set; }
    public DbSet<Country>? Country { get; set; }
    public DbSet<Weather>? Weather { get; set; }

}