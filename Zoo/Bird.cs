namespace Zoo;

public class Bird : Animal
{
    public event Action Song
    {
        add => SongEvents += value;
        remove => SongEvents -= value;
    }

    protected event Action SongEvents;

    public Bird()
        : this(string.Empty, string.Empty, Gender.Undetermined, true)
    {
    }

    public Bird(string species, string name, Gender gender, bool flightCapable, Action? song = default)
        : base(species, name, gender)
    {
        FlightCapable = flightCapable;
        SongEvents += song ?? (() =>
        {
            Beep();
            Beep();
            WriteLine($"The {Species} {Name} sings. *Tweet Tweet!*");
        });
    }

    public bool FlightCapable { get; init; }

    public override void Move()
    {
        var movementString = FlightCapable ? "flies around! *flap flap*" : "waddles about! *waddle, waddle*";
        Console.WriteLine($"The {Species} {movementString}");
        base.Move();
    }

    public override void MakeSound()
    {
        SongEvents.Invoke();
    }
}