using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<object> box = new List<object>();
            box.Add(7);
            box.Add(28);
            box.Add(-1);
            box.Add(true);
            box.Add("chair");
            int temp = 0;
            for (var idx = 0; idx < box.Count; idx++){
                Console.WriteLine(box[idx].ToString());
                if (!(box[idx] is bool) && !(box[idx] is string)){
                    temp = temp + (int)box[idx];
                }
            }

            Console.WriteLine("Sum of all ints in list: {0} \n\n",temp);
        }
    }
}
