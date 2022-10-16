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
        WriteLine($"The {poker.Species} {poker.Name} pokes the bear. It becomes angrier");
        AngerLevel++;
        if (AngerLevel > _angerLimit)
        {
            WriteLine($"The bear is pissed off! It gives the {poker.Species} a big whop!");
            if (poker is IPrey)
            {
                Move();
                var prey = (IPrey)poker;
                prey.Kill();
                if (Hungry)
                {
                    WriteLine($"The bear got hungry so it eats the {poker.Species}! *Nom Nom*");
                    Eat(prey);
                }
            }
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