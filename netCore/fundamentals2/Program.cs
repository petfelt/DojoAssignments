using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {


            int[] basicArr1 = {0,1,2,3,4,5,6,7,8,9};
            string[] basicArr2 = new string[4]{"Tim","Martin","Nikki","Sara"};
            bool[] basicArr3 = new bool[10]{true, false, true, false, true, false, true, false, true, false};
            Console.WriteLine("Basic Arrays:");
            Console.Write("0-9: ");
            foreach(var item in basicArr1){
                Console.Write("{0}, ", item.ToString());
            }
            Console.WriteLine(" ");
            Console.Write("Names: ");
            foreach(var item in basicArr2){
                Console.Write("{0}, ", item);
            }
            Console.WriteLine(" ");
            Console.Write("True-False: ");
            foreach(var item in basicArr1){
                Console.Write("{0}, ", item.ToString());
            }
            Console.WriteLine(" ");


            Console.WriteLine("");
            Console.WriteLine("Multiplication Table:");
            int[][] multiplicationTable = new int[][]{
                new int[10],
                new int[10],
                new int[10],
                new int[10],
                new int[10],
                new int[10],
                new int[10],
                new int[10],
                new int[10],
                new int[10]
            };
            int outertemp = 0;
            foreach(int[] innerArr in multiplicationTable){
                Console.Write("[ ");
                int innertemp = 0;
                foreach(int tablepiece in innerArr) {
                    multiplicationTable[outertemp][innertemp] = (outertemp+1)*(innertemp+1);
                    if(multiplicationTable[outertemp][innertemp].ToString().Length == 1){
                        Console.Write("{0},   ", multiplicationTable[outertemp][innertemp]);

                    }
                    else if(multiplicationTable[outertemp][innertemp].ToString().Length == 2){
                        Console.Write("{0},  ", multiplicationTable[outertemp][innertemp]);
                    }
                    else {
                        Console.Write("{0}, ", multiplicationTable[outertemp][innertemp]);
                    }
                    innertemp++;
                }
                Console.WriteLine("]");
                outertemp++;
            }
            Console.WriteLine("");


            Console.WriteLine("List of Flavors:");
            List<string> flavors = new List<string>();
            flavors.Add("Mint Chocolate");
            flavors.Add("Vanilla");
            flavors.Add("Chocolate");
            flavors.Add("Strawberry");
            flavors.Add("Chocolate Chip Cookie Dough");
            Console.WriteLine("We currently have {0} flavors of ice cream.", flavors.Count);
            Console.WriteLine("The third flavor on the list is {0}.",flavors[2]);
            Console.WriteLine("We will now remove this flavor from the list.");
            flavors.RemoveAt(2);
            Console.WriteLine("We now have {0} flavors of ice cream.", flavors.Count);


            Console.WriteLine("");
            Console.WriteLine("User Info Dictionary:");
            Dictionary<string,string> user = new Dictionary<string,string>();
            foreach(string name in basicArr2){
                user.Add(name, null);
            }
            Random rand = new Random();
            foreach(string name in basicArr2){
                user[name] = flavors[rand.Next(0,4)];
                Console.WriteLine(" ~ {0} - {1} ", name, user[name]);
            }
            Console.WriteLine("");


        }
    }
}
