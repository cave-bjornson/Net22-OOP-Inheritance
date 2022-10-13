namespace Zoo;

public class Bird : Animal
{
    private static Action DefaultSound = () => Console.WriteLine("*Tweet Tweet!*");

    public Bird()
    {
        Sound += DefaultSound;
    }

    public Bird(string species, string name, Gender gender, bool flightCapable, Action? sound = default)
        : base(species, name, gender)
    {
        FlightCapable = flightCapable;
        Sound += sound ?? DefaultSound;
    }

    public bool FlightCapable { get; init; } = true;

    public override void Move()
    {
        var movementString = FlightCapable ? "flies around! *flap flap*" : "waddles about! *waddle, waddle*";
        Console.WriteLine($"The {Species} {movementString}");
        base.Move();
    }

    public override string ToString()
    {
        return @$"{base.ToString()},
\---{nameof(FlightCapable)}: {FlightCapable}";
    }
}