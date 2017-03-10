using System;

namespace rpg_encounter
{
    public class Spider : Human
    {
        public Spider(string person) : base(person)
        {
            name = person;
            intelligence = 5;
            health = 70;
            dexterity = 10;
            strength = 5;
        }

        public void intimidate(object obj)
        {
            Human enemy = obj as Human;
            if (enemy == null)
            {
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("|       The spider couldn't find a target to attack!        |");
                Console.WriteLine("-------------------------------------------------------------\n");
            }
            else
            {
                int bite = 5;
                enemy.dexterity -= bite;
                enemy.intelligence -= bite;
                health += bite;
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("| The spider decreased the {0}'s dxt/int stats by 5!",enemy.name);
                Console.WriteLine("-------------------------------------------------------------\n");
            }
        }

        public void bite(object obj)
        {
            Random rand = new Random();
            Human enemy = obj as Human;
            if (enemy == null)
            {
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("|       The spider couldn't find a target to attack!        |");
                Console.WriteLine("-------------------------------------------------------------\n");
            }
            else
            {
                int bite = rand.Next(10,25);
                enemy.health -= bite;
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("|     The spider bit the {0} and did {1} damage!",enemy.name, bite);
                Console.WriteLine("-------------------------------------------------------------\n");
            }
        }

    }
}