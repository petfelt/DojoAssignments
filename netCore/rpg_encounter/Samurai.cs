using System;

namespace rpg_encounter
{
    public class Samurai : Human
    {
        public static int count = 0;
        public Samurai(string person) : base(person)
        {
            name = person;
            health = 200;
            count++;
        }

        public void death_blow(object obj)
        {
            attack(obj);
            if (obj != null)
            {
                if((obj as Human).health < 50){
                    (obj as Human).health = 0;
                    Console.WriteLine("-------------------------------------------------------------");
                    Console.WriteLine("|     The attack was a DEATH BLOW! {0} is dead!!",(obj as Human).name);
                    Console.WriteLine("-------------------------------------------------------------\n");
                } else {
                    Console.WriteLine("-------------------------------------------------------------");
                    Console.WriteLine("|     The death blow was unsuccessful. {0} remains alive.",(obj as Human).name);
                    Console.WriteLine("-------------------------------------------------------------\n");
                }
            }
        }

        public void meditate(){
            health = 200;
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("|       The {0} meditated back to full health.",name);
            Console.WriteLine("-------------------------------------------------------------\n");
        }

        public void how_many(){
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("|       There is {0} Samurai in existence.",count);
            Console.WriteLine("-------------------------------------------------------------\n");
        }
        
    }
}