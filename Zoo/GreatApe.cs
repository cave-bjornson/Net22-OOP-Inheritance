namespace Zoo;

public class GreatApe : Hominid
{
    public GreatApe()
        : this(string.Empty, string.Empty, Gender.Undetermined)
    {
    }

    public GreatApe(string species, string name, Gender gender)
        : base(species, name, gender)
    {
        _inventory = new CrudeTool[4];
        Array.Copy(Enum.GetValues(typeof(CrudeTool)), 1, (Array)_inventory, 0, 4);
    }

    public override void MakeSound()
    {
        WriteLine($"The {Species} {Name} says: " + Random.Shared.Next(3) switch
        {
            0 => "Eeek Eeek!",
            1 => "Mook mook!",
            2 => "I daresay it will be a lovely weather this afternoon!"
        });
    }

    public override void UseTool(object? tool)
    {
        if (tool is not CrudeTool)
        {
            throw new ArgumentException($"{nameof(tool)} is not of type {typeof(CrudeTool)}");
        }

        var stringPrefix = $"The {Species} {Name}";
        if (!Array.Exists(_inventory as CrudeTool[], item => tool.Equals(item)))
        {
            WriteLine($"The {Species} {Name} does not have a {tool}");
            return;
        }

        string result = tool switch
        {
            CrudeTool.Stick => $"scratches itself on the back with the {tool}.",
            CrudeTool.Rock => $"throws the {tool} at some visitors.",
            CrudeTool.Grass => $"wears the {tool} on its head",
            CrudeTool.Leaf => $"chews on the {tool}"
        };

        WriteLine($"{stringPrefix} {result}");
    }
}

public enum CrudeTool
{
    None,
    Stick,
    Rock,
    Grass,
    Leaf,
}