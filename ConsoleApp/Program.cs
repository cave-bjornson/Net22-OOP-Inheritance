using Zoo;

namespace ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var bearA = new Bear("Brown Bear", "Banjo", Gender.Male);
            WriteLine(bearA);
            WriteLine();
            bearA.Move();
            WriteLine();
            var bearB = new Bear("Brown Bear", "Boudicca", Gender.Female);
            WriteLine(bearB);
            WriteLine();
            Bear bearC = bearA.Mate(bearB);
            WriteLine(bearC);
            WriteLine();

            var bird = new Bird("Yellow Canary", "Tweety", Gender.Male, flightCapable: true);
            WriteLine(bird);
            WriteLine();
            // Testing the ability to add methods to the Bird class event based song property.
            bird.Song += Beep;
            bird.Song += Beep;
            bird.Song += Beep;
            bird.Song += () => WriteLine("I tawt I taw a puddy tat!");

            var chimp = new GreatApe("Chimpanzee", "Noam Chimpsky", Gender.Male);
            WriteLine(chimp);
            chimp.UseTool(CrudeTool.Rock);
            WriteLine();

            var human = new Human("Zoo Keeper", Gender.Male);
            human.Inventory.Add(new Tool("Key to the Zoo"));
            human.Inventory.Add(new Food("Hamburger"));
            human.Animals.AddRange(new Animal[] { bearA, bearB, bearC, chimp });
            WriteLine(human);
            WriteLine();

            // Test all sounds except the human and the bird.
            human.Animals.ForEach(animal => animal.MakeSound());

            // Bird is gonna beep the console.
            WriteLine("Press a key to make the bird sing (Speaker will beep, check your volume)");
            ReadKey();
            bird.MakeSound();
            WriteLine();

            // This is gonna use the executable in the SamSpeaker folder.
            WriteLine("Press a key to make the human talk (Speech synthesis so check your volume)");
            ReadKey();
            human.MakeSound("Hello! My name is SAM!");
            WriteLine();

            do
            {
                WriteLine("Press a key to poke the bear.");
                ReadKey();
                bearA.Poke(human);
            } while (human.Alive);
        }
    }
}