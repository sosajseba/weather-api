using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Api.Entities;

namespace Api.DataAccess.Seeds;
public class WeatherSeed : IEntityTypeConfiguration<Weather>
{
    public void Configure(EntityTypeBuilder<Weather> builder)
    {
        int count = 5;

        for (int i = 1; i < 5; i++)
        {
            for (int j = 0; j < 30; j++)
            {
                var temp2 = NextDecimal(-50, 50);

                builder.HasData(new Weather
                {
                    Id = count,
                    CityId = i,
                    RainChance = (byte)(new Random().Next(0, 100)),
                    TempC = decimal.Round(temp2, 1),
                    TempF = decimal.Round(ToFarenheit(temp2), 1),
                    Wind = decimal.Round(NextDecimal(0, 20), 1),
                    Condition = GetRandomCondition(),
                    Humidity = (byte)(new Random().Next(0, 100)),
                    Date = DateTime.Today.AddDays(j)
                });
                count++;
            }
        }
    }

    private Condition GetRandomCondition()
    {
        Random random = new Random();
        Type type = typeof(Condition);
        Array values = type.GetEnumValues();
        int index = random.Next(values.Length);
        Condition value = (Condition)values.GetValue(index);
        return value;
    }

    private decimal NextDecimal(double minValue, double maxValue)
    {
        Random rand = new Random();
        return (decimal)(rand.NextDouble() * (maxValue - minValue) + minValue);
    }

    private decimal ToFarenheit(decimal celsius){
        return (celsius * 9/5) + 32;
    }
}