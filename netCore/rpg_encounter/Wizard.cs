using System;

namespace rpg_encounter
{
    public class Wizard : Human
    {
        public Wizard(string person) : base(person)
        {
            name = person;
            intelligence = 25;
            health = 50;
        }

        public void heal()
        {
            health+=(10*intelligence);
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("|       The {0} healed him/her/themselves by {1} HP!",name,(10*intelligence));
            Console.WriteLine("-------------------------------------------------------------\n");
        }

        public void fireball(object obj)
        {
            Random rand = new Random();
            Human enemy = obj as Human;
            if (enemy == null)
            {
                Console.WriteLine("Failed Attack");
            }
            else
            {
                int fire = rand.Next(20,51);
                enemy.health -= fire;
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("|         The {0} cast a fireball against the {1}!",name, enemy.name);
                Console.WriteLine("|         It did {0} damage!",fire);
                Console.WriteLine("-------------------------------------------------------------\n");
            }
        }

    }
}