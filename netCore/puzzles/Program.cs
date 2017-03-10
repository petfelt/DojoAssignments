using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static int[] RandomArray(){
            int[] tempArray = new int[10];
            Random rand = new Random();
            for(int i = 0; i < 10; i++){
                tempArray[i] = rand.Next(5,26);
            }
            return tempArray;
        }

        public static string TossCoin(int toss){
            Console.WriteLine("Toss a coin!");
            string result = "Tails";
            if(toss == 1){
                result = "Heads";
            }
            return result;
        }

        public static double TossMultipleCoins(int num){
            int numHeads = 0;
            Console.WriteLine("\nMultiple coin tosses!");
            Random rand = new Random();
            for(int i = 0; i < num; i++){
                if(TossCoin(rand.Next(0,2)) == "Heads"){
                    numHeads++;
                }
            }
            return (double)numHeads/num;
        }

        public static string[] Names(){
            Console.WriteLine("\nShuffled Array of Names:");
            string[] shuffleArray = new string[5];
            shuffleArray[0] = "Todd";
            shuffleArray[1] = "Tiffany";
            shuffleArray[2] = "Charlie";
            shuffleArray[3] = "Geneva";
            shuffleArray[4] = "Sydney";
            Random rand = new Random();

            for (var idx = 0; idx < shuffleArray.Length; idx++){
                string temp = shuffleArray[idx];
                int r = rand.Next(0,4);
                shuffleArray[idx] = shuffleArray[r];
                shuffleArray[r] = temp;
            }
            string[] returnArray = new string[5];
            int count = 0;
            for (var idx = 0; idx < shuffleArray.Length; idx++){
                Console.WriteLine(shuffleArray[idx]);
                if(shuffleArray[idx].Length > 5) {
                    returnArray[count] = shuffleArray[idx];
                    count++;
                }
            }
            Console.WriteLine("\nReturned Array of Names:");
            return returnArray;
        }

        public static void Main(string[] args)
        {
            Random rand = new Random();
            Console.WriteLine("\nMy Random Array:");
            foreach(int i in RandomArray()){
                Console.WriteLine(i);
            }
            Console.WriteLine("\nOne Coin Toss:");
            Console.WriteLine(TossCoin(rand.Next(0,2)));
            Console.WriteLine("Ratio of heads to tails for 8 tosses: {0}", TossMultipleCoins(8));

            foreach(string i in Names()){
                Console.WriteLine(i);
            }
        }
    }
}
