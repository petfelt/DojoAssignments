using System;

namespace rpg_encounter
{
    public class Zombie : Human
    {
        public Zombie(string person) : base(person)
        {
            name = person;
            intelligence = 1;
            health = 30;
            dexterity = 2;
            strength = 2;
        }

        public void life_steal(object obj)
        {
            Random rand = new Random();
            Human enemy = obj as Human;
            if (enemy == null)
            {
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("|       The zombie couldn't find a target to attack!        |");
                Console.WriteLine("-------------------------------------------------------------\n");
            }
            else
            {
                int bite = rand.Next(7,18);
                enemy.health -= bite;
                health += bite;
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("|           The zombie stole {1} life from the {0}!",enemy.name, bite);
                Console.WriteLine("-------------------------------------------------------------\n");
            }
        }

        public void chew(object obj)
        {
            Random rand = new Random();
            Human enemy = obj as Human;
            if (enemy == null)
            {
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("|       The zombie couldn't find a target to attack!        |");
                Console.WriteLine("-------------------------------------------------------------\n");
            }
            else
            {
                int bite = rand.Next(17,29);
                enemy.health -= bite;
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("|     The zombie chewed on the {0} and did {1} damage!",enemy.name, bite);
                Console.WriteLine("-------------------------------------------------------------\n");
            }
        }

    }
}