using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Api.Dtos;

namespace Api.Entities;

public class City : Base
{
    [Required]
    public int CountryId { get; set; }
    [Required]
    [Column(TypeName = "VARCHAR(100)")]
    public string Name { get; set; } = string.Empty;
    public Country? Country { get; set; }

    public CityDto ToDto()
    {
        return new CityDto
        {
            Id = Id,
            CountryId = CountryId,
            Name = Name
        };
    }
}