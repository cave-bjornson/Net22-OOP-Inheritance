using System.Text.Json;
using System.Text.Json.Serialization;

namespace Zoo;

public interface IConsumable : IUseable
{
}

public interface IUseable
{
    public string Name { get; }
}

public interface IPrey : IConsumable
{
    public bool Alive { get; set; }

    public void Kill()
    {
        this.Alive = false;
    }
}

public enum Gender
{
    Undetermined,
    Male,
    Female,
}

public record Food(string Name) : IConsumable;

public record Tool(string Name) : IUseable;

public static class AnimalExtension
{
    /// <summary>
    /// Extension method that dumps members of <c>Animal</c> as Json string.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="x"></param>
    public static void Dump<T>(this T x)
        where T : Animal
    {
        string json = JsonSerializer.Serialize(x, new JsonSerializerOptions
        {
            WriteIndented = true,
            Converters =
        {
            new JsonStringEnumConverter(JsonNamingPolicy.CamelCase),
        },
        });
        WriteLine(json);
    }
}