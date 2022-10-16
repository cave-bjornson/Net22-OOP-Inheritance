namespace Zoo;

public class Bear : Animal
{
    private const byte DefaultAngerLimit = 3;
    private readonly byte _angerLimit;

    public Bear()
    {
        _angerLimit = DefaultAngerLimit;
    }

    public Bear(string species, string name, Gender gender, byte angerLimit = DefaultAngerLimit)
        : base(species, name, gender)
    {
        _angerLimit = angerLimit;
    }

    public byte AngerLevel { get; set; } = 0;

    public void Poke(Animal poker)
    {
        AngerLevel++;
        string angerString = AngerLevel switch
        {
            0 => "calm",
            1 => "irritated",
            2 => "angry",
            3 => "really angry",
            > 3 => "mad"
        };
        WriteLine($"The {poker.Species} {poker.Name} pokes the bear. It becomes {angerString}");
        if (AngerLevel <= _angerLimit)
        {
            return;
        }

        WriteLine($"The bear is pissed off! It gives the {poker.Species} a big whop!");
        if (poker is IPrey)
        {
            var prey = (IPrey)poker;
            prey.Kill();
            if (Hungry)
            {
                WriteLine($"The bear got hungry so it eats the {poker.Species}! *Nom Nom*");
                Eat(prey);
            }
        }
    }

    public override void Sleep()
    {
        WriteLine("The bear sleeps until next spring. ZZZzzz...");
        base.Sleep();
    }

    public override void Move()
    {
        WriteLine("The bear shuffles along and climbs a tree.");
        base.Move();
    }

    public override void MakeSound()
    {
        WriteLine($"{Name}, the {Species}: GROWL!");
    }
}