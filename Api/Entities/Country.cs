using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Api.Dtos;


namespace Api.Entities;

public class Country : Base
{
    [Required]
    [Column(TypeName = "VARCHAR(100)")]
    public string Name { get; set; } = string.Empty;

    public CountryDto ToDto()
    {
        return new CountryDto
        {
            Id = Id,
            Name = Name
        };
    }
}