using System;

namespace Human_Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Let's create some humans!");
            Human human1 = new Human("Victoria");
            Human human2 = new Human("Victor");
            human1.Attack(human2);
        }
    }
}
