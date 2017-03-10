using System;

namespace WizardNinjaSamurai
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("-- A bunch of demo attacks are about to be performed. --");
            Samurai sammy = new Samurai("Bammy");
            Samurai sammy2 = new Samurai("Sammy");
            Wizard wizzy = new Wizard("Wizzy");
            Ninja ninja = new Ninja("Ninja");
            sammy2.how_many();
            wizzy.fireball(sammy2);
            Console.WriteLine(sammy2);
            sammy2.meditate();
            Console.WriteLine(sammy2);
            sammy2.attack(wizzy);
            sammy2.attack(wizzy);
            sammy2.attack(wizzy);
            sammy2.attack(wizzy);
            sammy2.death_blow(wizzy);
            Console.WriteLine(wizzy);
            ninja.steal(sammy2);
            ninja.steal(sammy2);
            ninja.get_Away();
            Console.WriteLine(ninja);
        }
    }
}
