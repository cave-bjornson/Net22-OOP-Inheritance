namespace Zoo;

public interface IConsumable
{
    public string Name { get; set; }
}

public enum Gender
{
    Male,
    Female,
}

public struct Food : IConsumable
{
    public string Name { get; set; }
}