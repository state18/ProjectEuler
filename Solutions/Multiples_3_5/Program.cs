using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Problem: Find the sum of all the multiples of 3 or 5 below 1000.
/// </summary>
namespace Multiples_3_5
{
    public class Program
    {
        public static void Main(String[] args) {
            // sum will store our progress towards the sum of the multiples
            int sum = 0;

            // First we address the multiples of 3
            for (var i = 3; i < 1000; i += 3) {
                sum += i;
            }

            // Now we address the multiples of 5
            for(var i = 5; i < 1000; i += 5) {
                // We don't want to include common multiples of 3 and 5 because 3 has already been addressed.
                if (i % 15 != 0)
                    sum += i;
            }
            // Answer: 233168
            Console.WriteLine(sum);  
        }
    }
}
