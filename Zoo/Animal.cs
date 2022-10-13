// <copyright file="Animal.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Zoo;

public abstract class Animal
{
    protected event Action? Sound;

    protected Animal()
    {
    }

    protected Animal(string species, string name, Gender gender, Action? sound = default)
    {
        Species = species;
        Name = name;
        Gender = gender;
        Sound = sound;
    }

    public string Species { get; init; } = string.Empty;

    public string Name { get; init; } = string.Empty;

    public Gender Gender { get; init; }

    public bool Alive { get; set; } = true;

    public bool Hungry { get; private set; } = false;

    public bool Tired { get; private set; } = false;

    /// <summary>
    /// Creates a new instance of Animal that is the offspring of 2 animals.
    /// </summary>
    /// <typeparam name="T">Derived from Animal.</typeparam>
    /// <param name="animal1">1st parent Animal</param>
    /// <param name="animal2">1st parent Animal</param>
    /// <returns>A new <typeparam name="T"><typeparamref name="T"/></typeparam></returns>
    /// <exception cref="ArgumentException">Thrown if same gender.</exception>
    public static T Procreate<T>(T animal1, T animal2)
        where T : Animal, new()
    {
        if (animal1.Species != animal2.Species || animal1.Gender == animal2.Gender)
        {
            throw new ArgumentException("Incompatible for procreation.", nameof(animal2));
        }

        string babyName = animal1.Name + animal2.Name;
        var babyGender = (Gender)new Random().Next(2);
        T animalBaby = new()
        {
            Name = babyName,
            Gender = babyGender,
            Species = animal1.Species,
        };
        return animalBaby;
    }

    public virtual void Eat(IConsumable consumable)
    {
        Hungry = false;
    }

    public virtual void Sleep()
    {
        Tired = false;
    }

    public virtual void Move()
    {
        Hungry = true;
        Tired = true;
    }

    /// <summary>
    /// Creates a new instance of <typeparamref name="T"/> that is the offspring of this
    /// and an another instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">Derived from Animal.</typeparam>
    /// <param name="otherAnimal">The other parent Animal.</param>
    /// <returns>A new <typeparam name="T"><typeparamref name="T"/></typeparam></returns>
    public T Mate<T>(T otherAnimal)
        where T : Animal, new()
    {
        return Procreate((T)this, otherAnimal);
    }

    public virtual void MakeSound()
    {
        Sound?.Invoke();
    }

    public override string ToString()
    {
        return @$"Class {this.GetType().Name}:
\---{nameof(Species)}: {Species},
\---{nameof(Name)}: {Name},
\---{nameof(Gender)}: {Gender},
\---{nameof(Alive)}: {Alive},
\---{nameof(Hungry)}: {Hungry},
\---{nameof(Tired)}: {Tired}";
    }
}