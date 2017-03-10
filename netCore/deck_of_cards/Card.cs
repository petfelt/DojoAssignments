using System;

namespace DeckProgram
{
    public class Card {
        public string stringVal {get; set;}
        public string suit {get; set;}
        public int val {get; set;}


        public Card(string cardName = "Ace", string whatSuit = "Spades", int myVal = 1){
            stringVal = cardName;
            suit = whatSuit;
            val = myVal;
        }

        public Card(int whatSuit = 1, int myVal = 1){
            // This constructor sets the suit and suit name using ints.
            if(whatSuit == 1){
                suit = "Clubs";
            } else if (whatSuit == 2){
                suit = "Spades";
            } else if (whatSuit == 3){
                suit = "Hearts";
            } else {
                suit = "Diamonds";
            }

            if(myVal == 1) {
                stringVal = "Ace";
            } else if(myVal == 11){
                stringVal = "Jack";
            } else if(myVal == 12){
                stringVal = "Queen";
            } else if(myVal == 13){
                stringVal = "King";
            } else {
                stringVal = myVal.ToString();
            }
            val = myVal;

        }

        public override string ToString() {
            return "The " + stringVal + " of " + suit;
        }

    }
}