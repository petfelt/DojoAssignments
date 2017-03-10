using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            for(int i = 1; i < 256; i++) {
                Console.WriteLine(i);
            }

            for(int i = 1; i < 101; i++) {
                if(i%3 == 0 && i%5 == 0){
                    Console.WriteLine("FizzBuzz");
                }
                else if(i%3 == 0){
                    Console.WriteLine("Fizz");
                }
                else if(i%5 == 0){
                    Console.WriteLine("Buzz");
                }
            }
            Console.WriteLine("------------------");

            Random rand = new Random();
            for(int val = 0; val < 10; val++) {
                int temp = rand.Next(1,100);
                if(temp%3 == 0 && temp%5 == 0){
                    Console.WriteLine("FizzBuzz");
                }
                else if(temp%3 == 0){
                    Console.WriteLine("Fizz");
                }
                else if(temp%5 == 0){
                    Console.WriteLine("Buzz");
                }
            }
        }
    }
}
