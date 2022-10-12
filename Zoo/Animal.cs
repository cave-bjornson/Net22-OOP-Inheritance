// <copyright file="Animal.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Zoo;

public abstract class Animal
{
    protected Animal()
    {
    }

    protected Animal(string name, Gender gender)
    {
        this.Name = name;
        this.Gender = gender;
    }

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
        if (animal1.Gender == animal2.Gender)
        {
            throw new ArgumentException("Incompatible for procreation.", nameof(animal2));
        }

        string babyName = animal1.Name + animal2.Name;
        var babyGender = (Gender)new Random().Next(2);
        T animalBaby = new()
        {
            Name = babyName,
            Gender = babyGender,
        };
        return animalBaby;
    }

    public void Eat(IConsumable consumable)
    {
        this.Hungry = false;
    }

    public void Sleep()
    {
        this.Tired = false;
    }

    public void Move()
    {
        this.Hungry = true;
        this.Tired = true;
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

    public abstract void MakeSound();

    public override string ToString()
    {
        return
            $"{this.GetType().Name}: {nameof(this.Name)}: {this.Name}, {nameof(this.Gender)}: {this.Gender}, {nameof(this.Alive)}: {this.Alive}, {nameof(this.Hungry)}: {this.Hungry}, {nameof(this.Tired)}: {this.Tired}";
    }
}