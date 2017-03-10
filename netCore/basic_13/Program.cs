using System;

namespace ConsoleApplication
{
    public class Program
    {

        public static void basic1(){
            Console.WriteLine("Print 1-255:");
            for (int i = 1; i <= 255; i++)
            {
                Console.WriteLine(i);
            }
        }
        public static void basic2(){
            Console.WriteLine("\n\nPrint odd numbers between 1-255:");
            for (int i = 1; i <= 255; i=i+2)
            {
                Console.WriteLine(i);
            }
        }
        public static void basic3(){
            Console.WriteLine("\n\nPrint Sum:");
            int sum = 0;
            for (int i = 0; i <= 255; i++)
            {
                Console.WriteLine("New Number: {0}",i);
                Console.WriteLine("New Sum: {0}",sum=sum+i);
            }
        }
        public static void basic4(int[] myArray){
            Console.WriteLine("\n\nIterating through an Array:");
            Console.Write("[ ");
            for (int idx = 0; idx < myArray.Length; idx++){
                Console.Write("{0}, ", myArray[idx]);
            }
            Console.WriteLine("]");
        }
        public static void basic5(int[] myArray){
            Console.WriteLine("\n\nFind Max:");
            int max = -10000;
            for (int idx = 0; idx < myArray.Length; idx++){
                if(myArray[idx] > max){
                    max = myArray[idx];
                }
            }
            Console.WriteLine("Max: {0}", max);
        }
        public static void basic6(int[] myArray){
            Console.WriteLine("\n\nFind Average:");
            int avg = 0;
            for (int idx = 0; idx < myArray.Length; idx++){
                avg += myArray[idx];
            }
            avg = avg/myArray.Length;
            Console.WriteLine("Average: {0}", avg);
        }
        public static void basic7(){
            Console.WriteLine("\n\nArray with Odd Numbers:");
            int[] y = new int[128];
            int i = 1;
            Console.Write("[ ");
            foreach(int idx in y)
            {
                y[idx] = i;
                i = i+2;
                Console.Write("{0}, ",y[idx]);

            }
            Console.WriteLine("]");
        }
        public static void basic8(int[] myArray, int y){
            Console.WriteLine("\n\nGreater than Y:");
            Console.WriteLine("Y: {0}",y);
            Console.Write("Array values greater than y: ");
            int count = 0;
            for (int idx = 0; idx < myArray.Length; idx++){
                if(myArray[idx] > y){
                    count++;
                }
            }
            Console.WriteLine("{0}",count);
        }
        public static void basic9(int[] myArray){
            Console.WriteLine("\n\nSquare the Values:");
            Console.Write("[ ");
            for (int idx = 0; idx < myArray.Length; idx++){
                myArray[idx] = myArray[idx]*myArray[idx];
                Console.Write("{0}, ",myArray[idx]);
            }
            Console.WriteLine("]");
        }
        public static void basic10(int[] myArray){
            Console.WriteLine("\n\nEliminate Negative Numbers:");
            Console.Write("[ ");
            for (int idx = 0; idx < myArray.Length; idx++){
                if(myArray[idx] < 0){
                    myArray[idx] = 0;
                }
                Console.Write("{0}, ",myArray[idx]);
            }
            Console.WriteLine("]");
        }
        public static void basic11(int[] myArray){
            Console.WriteLine("\n\nMax, Min, and Average:");
            Console.Write("Array values greater than y: ");
            int max = -100000;
            int min = 100000;
            int avg = 0;
            for (int idx = 0; idx < myArray.Length; idx++){
                if(myArray[idx] > max){
                    max = myArray[idx];
                }
                if(myArray[idx] < min){
                    min = myArray[idx];
                }
                avg += myArray[idx];
            }
            avg = avg/myArray.Length;
            Console.WriteLine("Average: {0}", avg);
            Console.WriteLine("Max: {0}",max);
            Console.WriteLine("Min: {0}",min);
        }
        public static void basic12(int[] myArray){
            Console.WriteLine("\n\nShifting the values in an array:");
            Console.Write("Shifted Values: [ ");
            for (int idx = 0; idx < myArray.Length-1; idx++){
                myArray[idx] = myArray[idx+1];
                Console.Write("{0}, ", myArray[idx]);
            }
            myArray[myArray.Length-1] = 0;
            Console.WriteLine("{0} ]", myArray[myArray.Length-1]);
        }
        public static void basic13(object[] myArray){
            Console.WriteLine("\n\nNumber to String:");
            Console.Write("Any negative number is replaced: [ ");
            for (int idx = 0; idx < myArray.Length; idx++){
                if((int)myArray[idx] < 0){
                    myArray[idx] = "Dojo";
                }
                Console.Write("{0}, ",myArray[idx]);
            }
            Console.WriteLine("]");
        }

        public static void Main(string[] args)
        {
            basic1();
            basic2();
            basic3();
            basic4(new int[] {1,3,5,7,9,13});
            basic5(new int[] {1,33,32,77,0,-1});
            basic6(new int[] {2,10,3,1,2,-19,1,-1,255,3790});
            basic7();
            basic8(new int[] {2,10,3,1,2,-19,1,-1,255,3790}, 4);
            basic9(new int[] {2,3,5,6,9, -50});
            basic10(new int[] {1,-6,2,10,-2,8,-45});
            basic11(new int[] {1,-6,2,10,-2,8,-45});
            basic12(new int[] {1,-6,2,10,-2,8,-45});
            basic13(new object[] {1,-6,2,10,-2,8,-45});
            
            
        }
    }
}
