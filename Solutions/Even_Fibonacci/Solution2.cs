using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Problem: By considering the terms in the Fibonacci sequence whose values do not exceed four million,
/// find the sum of the even valued terms.
/// </summary>

class Solution2 {
    static void Main(string[] args) {
        // currentNumber will track which number in the Fibonacci sequence we are currently examining
        int currentNumber = 2;
        // prevNumber will track the previous number in the Fibonacci sequence.
        int prevNumber = 1;
        // totalEvens will track our total from adding together even Fibonacci numbers
        int totalEvens = 0;

        // We continue searching for even numbers while our Fibonacci sequence does not exceed four million
        while(currentNumber <= 4000000) {

            // If at an even number, add it to the total.
            if (currentNumber % 2 == 0)
                totalEvens += currentNumber;

            // The next value in the Fibonacci sequence is the sum of the current value and the previous value
            currentNumber += prevNumber;
            // The previous value is set to the new current value minus the old previous value 
            prevNumber = currentNumber - prevNumber;
            
        }
        // Answer: 4613732
        Console.WriteLine(totalEvens);
    }
}

