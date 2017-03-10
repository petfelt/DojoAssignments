using System;

namespace rpg_encounter
{
    public class Ninja : Human
    {
        public Ninja(string person) : base(person)
        {
            name = person;
            dexterity = 175;
        }
        public void steal(object obj)
        {
            attack(obj);
            health += 10;
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("|     The {0} also stole 10 health from {1}!",name, (obj as Human).name);
            Console.WriteLine("-------------------------------------------------------------\n");
        }

        public void get_Away(){
            health -= 15;
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("|     The {0} tried to get away and lost 15 health!",name);
            Console.WriteLine("-------------------------------------------------------------\n");
        }
    }
}