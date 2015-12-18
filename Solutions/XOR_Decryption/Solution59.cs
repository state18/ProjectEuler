using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Solution59 {

    static void Main(string[] args) {

        // Read from cipher.txt and store all of the integers into an array
        IEnumerable<int> cipherText = System.IO.File.ReadAllText("cipher.txt").Split(',').Select(x => int.Parse(x));

        Console.WriteLine("How long is the key?");
        int keyLengthInput;
        while (!int.TryParse(Console.ReadLine(), out keyLengthInput)) {
            Console.WriteLine("Invalid input. Enter an integer.");
        }

        var sum = (FindKey(cipherText, keyLengthInput));

        Console.WriteLine(sum);
    }


    static int FindKey(IEnumerable<int> message, int keyLength) {

        // Contains "keylength" number of integers. These are the integers that will be XOR'ed with "space" character to figure out the key letter for each group.
        // If there were no spaces, "e" would be used instead. A more accurate way might be to look at bigrams between groups?
        var counter = 0;
        var splitMessage = message.GroupBy(x => counter++ % keyLength);
        var key = splitMessage.Select(y => y.GroupBy(z => z).OrderByDescending(a => a.Count()).First().Key).Select(b => b ^ 32);

        var keyEnumerator = key.GetEnumerator();
        int sumOfCharacters = 0;
        foreach (var item in message) {

            if (!keyEnumerator.MoveNext()) {
                keyEnumerator = key.GetEnumerator();
                keyEnumerator.MoveNext();
            }
            //Console.WriteLine(keyEnumerator.Current);
            var deciphered = (char)(item ^ keyEnumerator.Current);
            sumOfCharacters += deciphered;
            Console.Write(deciphered);
        }

        
        return sumOfCharacters;

    }
}

