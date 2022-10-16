using System.Text;
using SamSpeaker;

namespace Zoo;

public class Human : Hominid, IPrey
{
    private readonly List<Animal> _animals;

    public Human()
        : this(string.Empty, Gender.Undetermined)
    {
    }

    public Human(string name, Gender gender)
        : base(species: "Human", name, gender)
    {
        _inventory = new List<IUseable>();
        _animals = new List<Animal>();
    }

    public List<IUseable> Inventory => (List<IUseable>)_inventory;

    public List<Animal> Animals => _animals;

    public override void MakeSound() => this.MakeSound("Hello World!");

    public void MakeSound(string speechLine) => Speaker.Speak(speechLine);

    public override void UseTool(object? tool)
    {
        ArgumentNullException.ThrowIfNull(tool);

        var useable = tool as IUseable;
        if (useable == null)
        {
            throw new ArgumentException($"{nameof(tool)} is not of type {typeof(IUseable)}");
        }

        if (!Inventory.Exists(item => item == useable))
        {
            WriteLine($"The human {Name} does not have a {useable.Name}");
            return;
        }

        WriteLine($"The human {Name} uses the {useable.Name}");
    }

    public override string ToString()
    {
        var ownedAnimalsString = new StringBuilder("[");
        foreach (Animal animal in _animals)
        {
            ownedAnimalsString.Append($"{animal.Species}: {animal.Name},");
        }

        ownedAnimalsString.Append(']');

        return $"{base.ToString()}\n" +
               $"{nameof(Animals)}: {ownedAnimalsString}";
    }
}