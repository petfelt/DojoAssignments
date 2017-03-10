using System;
using System.Collections.Generic;

namespace DeckProgram
{
    public class Deck {
        public List<Card> cards {get; set;}
        
        public Deck() {
            // Standard 52 card deck will be created. (No Jokers, obviously.)
            reset();
        }

        public Card deal() {
            Card returnMe = cards[0];
            cards.RemoveAt(0);
            return returnMe;
        }

        public void reset() {
            // Standard 52 card deck will be created. (No Jokers, obviously.)
            cards = new List<Card>(53);
            for(int suit = 1; suit < 5; suit++){
                for(int value = 1; value < 14; value++){
                    cards.Add(new Card(suit,value));
                }
            }
        }

        public void shuffle() {
            // Will randomly swap each and every card in the deck at least once.
            Random rand = new Random();
            for(var i =0; i < cards.Count; i++){
                int j = rand.Next(i,52);
                var temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }
        }

        public override string ToString() {
            Console.WriteLine("-- (You're cheating) Deck: --");
            for(var i =0; i < cards.Count; i++){
                Console.WriteLine(cards[i]);
            }
            return "";
        }



    }
}