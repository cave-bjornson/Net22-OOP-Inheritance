namespace Zoo;

using System.Collections;
public abstract class Hominid : Animal
{
    private readonly ICollection? inventory;

    protected Hominid()
    {
    }

    protected Hominid(string species, string name, Gender gender)
        : base(species, name, gender)
    {
    }

    protected abstract void UseTool(object? tool);
}