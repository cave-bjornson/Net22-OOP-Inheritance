namespace Zoo;

public class Bird : Animal
{
    protected event Action Song;

    private static readonly Action defaultSong = () => Console.WriteLine("*Tweet Tweet!*");

    public Bird()
    {
        Song += defaultSong;
    }

    public Bird(string species, string name, Gender gender, bool flightCapable, Action? song = default)
        : base(species, name, gender)
    {
        FlightCapable = flightCapable;
        Song += song ?? defaultSong;
    }

    public bool FlightCapable { get; init; } = true;

    public override void Move()
    {
        var movementString = FlightCapable ? "flies around! *flap flap*" : "waddles about! *waddle, waddle*";
        Console.WriteLine($"The {Species} {movementString}");
        base.Move();
    }

    public override void MakeSound()
    {
        Song?.Invoke();
    }

    public override string ToString()
    {
        return @$"{base.ToString()},
\---{nameof(FlightCapable)}: {FlightCapable}";
    }
}