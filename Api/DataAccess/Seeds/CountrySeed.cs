using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Api.Entities;

namespace Api.DataAccess.Seeds;
public class CountrySeed : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.HasData(new Country { Id = 1, Name = "Argentina" });
        builder.HasData(new Country { Id = 2, Name = "Brasil" });
    }
}