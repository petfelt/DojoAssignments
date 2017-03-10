using System;

namespace rpg_encounter
{
    public class Human
    {
        public string name;

        //The { get; set; } format creates accessor methods for the field specified
        //This is done to allow flexibility
        public int health { get; set; }
        public int strength { get; set; }
        public int intelligence { get; set; }
        public int dexterity { get; set; }

        public Human(string person)
        {
            name = person;
            strength = 3;
            intelligence = 3;
            dexterity = 3;
            health = 100;
        }
        public Human(string person, int str, int intel, int dex, int hp)
        {
            name = person;
            strength = str;
            intelligence = intel;
            dexterity = dex;
            health = hp;
        }
        public void attack(object obj)
        {
            Human enemy = obj as Human;
            if (enemy == null)
            {
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("|       The {0} couldn't find a target to attack!",name);
                Console.WriteLine("-------------------------------------------------------------\n");
            }
            else
            {
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("|        The {0} attacked {1} and did {2} damage!",name,enemy.name,(strength*3));
                Console.WriteLine("-------------------------------------------------------------\n");
                enemy.health -= strength * 5;
            }
        }

        public override string ToString(){
            return name + ":  Strength: " + strength + " Intel.: " + intelligence + " Dexterity: " + dexterity + " HP: " + health + ".";
        }


    }
}