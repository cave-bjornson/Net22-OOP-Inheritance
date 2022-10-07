// --------------------------------------------------------------------------------
// <copyright file="Animal.cs">
//   Björn Agnemo NET22
// </copyright>
// <summary>
//   Defines the Animal type.
// </summary>
// --------------------------------------------------------------------------------

namespace Zoo
{
    public class Animal
    {
        public string Name { get; set; } = string.Empty;

        public Sex Sex { get; set; } = Sex.TBD;

        public bool Alive { get; private set; } = true;

        public bool Hungry { get; private set; } = false;

        public bool Tired { get; private set; } = false;

        public void Eat(object food)
        {
            Hungry = false;
        }

        public void Sleep()
        {
            Tired = false;
        }

        public void Move()
        {
            Hungry = true;
            Tired = true;
        }

        public virtual Animal? Mate(Animal otherAnimal)
        {
            if (this.GetType() == otherAnimal.GetType() && this.Sex != otherAnimal.Sex)
            {
                return new Animal();
            }

            return null;
        }
    }
}