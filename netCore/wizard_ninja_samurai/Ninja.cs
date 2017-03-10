using System;

namespace WizardNinjaSamurai
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
        }

        public void get_Away(){
            health -= 15;
        }
    }
}