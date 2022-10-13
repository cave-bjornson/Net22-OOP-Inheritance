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
        if (AngerLevel > _angerLimit)
        {
            // TODO kill other animal then eat if hungry.
        }
    }

    public override void Sleep()
    {
        Console.WriteLine("The bear sleeps until next spring. ZZZzzz...");
        base.Sleep();
    }

    public override void Move()
    {
        Console.WriteLine("The bear shuffles along and climbs a tree.");
        base.Move();
    }

    public override void MakeSound()
    {
        Console.WriteLine("GROWL!");
    }
}