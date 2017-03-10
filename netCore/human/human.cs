using System;

namespace Human_Project {
    public class Human {
        public string Name {get; set;}
        public int Strength {get; set;}
        public int Intelligence {get; set;}
        public int Dexterity {get; set;}
        public int Health {get; set;}

        public Human(){
            Console.WriteLine("An unnamed human has been created.");
            Name = "Unnamed";
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            Health = 100;
        }
        public Human(string myName){
            Console.WriteLine("A human named {0} has been created.", myName);
            Name = myName;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            Health = 100;
        }
        public Human(string myName, int myStr, int myInt, int myDext, int myHp){
            Console.WriteLine("A custom human named {0} has been created.", myName);
            Name = myName;
            Strength = myStr;
            Intelligence = myInt;
            Dexterity = myDext;
            Health = myHp;
        }

        public void Attack(object Hurtee) {
            if(Hurtee is Human) {
                (Hurtee as Human).Health -= (Strength*5);
                Console.WriteLine("{0} has attacked {1}, dealing {2} damage! {1} now has {3} health.",Name,(Hurtee as Human).Name,(Strength*5),(Hurtee as Human).Health);
            }
        }
        
    }
}