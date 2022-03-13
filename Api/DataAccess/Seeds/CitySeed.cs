using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Api.Entities;

namespace Api.DataAccess.Seeds;
public class CitySeed : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.HasData(new City { Id = 1, CountryId = 1, Name = "Ciudad Autónoma de Buenos Aires" });
        builder.HasData(new City { Id = 2, CountryId = 1, Name = "Buenos Aires" });
        builder.HasData(new City { Id = 3, CountryId = 2, Name = "Río de Janeiro" });
        builder.HasData(new City { Id = 4, CountryId = 2, Name = "São Paulo" });
    }
}