using System;

namespace WizardNinjaSamurai
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
                }
            }
        }

        public void meditate(){
            health = 200;
        }

        public void how_many(){
            Console.WriteLine("-- There are {0} Samurai in existence. --",count);
        }
        
    }
}