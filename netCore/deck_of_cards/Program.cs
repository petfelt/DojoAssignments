using System;

namespace DeckProgram
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Deck myDeck = new Deck();
            myDeck.shuffle();
            Console.WriteLine(myDeck);
            Player myPlayer = new Player("Bobby");
            myPlayer.draw(myDeck);
            myPlayer.draw(myDeck);
            Console.WriteLine(myPlayer);
            Console.WriteLine(myDeck);
        }
    }
}
