using System;

namespace rpg_encounter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Creates all characters in encounter.
            Samurai samurai = new Samurai("Samurai");
            Wizard wizard = new Wizard("Wizard");
            Ninja ninja = new Ninja("Ninja");
            Zombie zombie1 = new Zombie("Zombie1");
            Zombie zombie2 = new Zombie("Zombie2");
            Spider spider1 = new Spider("Spider1");

            // Starts encounter.
            Encounter encounter1 = new Encounter(samurai, wizard, ninja, zombie1, zombie2, spider1);
            Console.WriteLine("-- END OF PROGRAM --\n");
        }
    }
}
