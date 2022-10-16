using System.Text;

namespace Zoo;

using System.Collections;
public abstract class Hominid : Animal
{
    protected Hominid()
        : this(string.Empty, string.Empty, Gender.Undetermined)
    {
    }

    protected Hominid(string species, string name, Gender gender)
        : base(species, name, gender)
    {
    }

    protected ICollection? _inventory;

    public ICollection? Inventory => _inventory;

    public override string ToString()
    {
        var inventoryString = new StringBuilder("[");
        foreach (object? item in _inventory)
        {
            inventoryString.Append(item.ToString() + ',');
        }

        inventoryString.Append(']');

        return $"{base.ToString()}\n" +
               $"{nameof(Inventory)}: {inventoryString}";
    }

    public abstract void UseTool(object? tool);
}