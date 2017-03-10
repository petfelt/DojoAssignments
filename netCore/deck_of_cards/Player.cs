using System;
using System.Collections.Generic;


namespace DeckProgram
{
    public class Player {
        public string name {get; set;}
        public List<Card> hand {get; set;}

        public Player(string myName = "Buddy") {
            name = myName; 
            hand = new List<Card>();
        }
        
        public Card draw(Deck myDeck) {
            Card temp = myDeck.deal();
            hand.Add(temp);
            return temp;
        }

        public Card discard(int idx){
            if(hand[idx] != null) {
                Card returnMe = hand[idx];
                hand.RemoveAt(idx);
                return returnMe;
            }
            return null;
        }

        public override string ToString() {
            Console.WriteLine("-- " + name + "'s Hand: --");
            if(hand.Count != 0){
                for(var i = 0; i < hand.Count-1; i++){
                    Console.Write(hand[i] + ", ");
                }
                Console.WriteLine(hand[hand.Count-1] + ".");
            }
            return  "";
        }

    }
}