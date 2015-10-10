using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Problem: If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, how many letters would be used?
/// Note: My solution will compute the amount of letters it takes from 1 to x, assuming 1 <= x <= 1000  
/// </summary>

class Solution17 {
    static void Main(string[] args) {
        // This will translate the ones place to word form. 
        Dictionary<int, string> onesMap = new Dictionary<int, string> {
            { 0, "" },
            { 1, "one" },
            { 2, "two" },
            { 3, "three" },
            { 4, "four" },
            { 5, "five" },
            { 6, "six" },
            { 7, "seven" },
            { 8, "eight" },
            { 9, "nine" },

        };
        // This will translate the tens place to word form (with special case of 1X numbers)
        Dictionary<int, string> tensMap = new Dictionary<int, string> {
            { 0, "" },
            { 10, "ten" },
            { 11, "eleven" },
            { 12, "twelve" },
            { 13, "thirteen" },
            { 14, "fourteen" },
            { 15, "fifteen" },
            { 16, "sixteen" },
            { 17, "seventeen" },
            { 18, "eighteen" },
            { 19, "nineteen" },
            { 2, "twenty" },
            { 3, "thirty" },
            { 4, "forty" },
            { 5, "fifty" },
            { 6, "sixty" },
            { 7, "seventy" },
            { 8, "eighty" },
            { 9, "ninety" }
        };
        // How far up do we want to go? This program will work when input is between 1 and 1000.
        var input = 1000;
        // Initialize a variable to store the sum of the letters in.
        var letterSum = 0;

        for (var i = 1; i <= input; i++) {
            // If at 1000, add 11 letters to the total for "one thousand" and exit the loop
            if (i == 1000) {
                letterSum += 11;
                break;
            } else {
                var hundreds = (i % 1000) / 100;
                var tens = (i % 100) / 10;
                var ones = i % 10;
                // Add length of hundreds place name with 7 because "hundreds".Length is 7
                if (hundreds > 0) {
                    letterSum += onesMap[hundreds].Length + 7;
                    if (tens > 0 || ones > 0) {
                        // Accounts for "and" if needed
                        letterSum += 3;
                    }
                }
                if (tens > 0) {
                    if (tens == 1) {
                        // Add the appropriate "teen" value from the tens hashmap and reset ones to 0 since
                        // this statement addresses both tens and ones place.
                        letterSum += tensMap[10 + ones].Length;
                        ones = 0;
                    } else
                        // Just handle the tens place regularly, since there is no teen value
                        letterSum += tensMap[tens].Length;
                }
                // Handle the ones place
                if (ones > 0)
                    letterSum += onesMap[ones].Length;
            }
        }

        // Answer: 21124
        Console.WriteLine(letterSum);
    }
}

