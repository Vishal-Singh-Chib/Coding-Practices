using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPrac
{
    class MinMax
    {
        static void Main3()
        {
            {
                string input = "visshala";

                // Step 1: Count the frequency of each character
                Dictionary<char, int> charFrequency = new Dictionary<char, int>();

                foreach (char ch in input)
                {
                    if (charFrequency.ContainsKey(ch))
                    {
                        charFrequency[ch]++;

                    }
                    else
                    {

                        charFrequency[ch] = 1;
                    }
                }

                // Step 2: Find the character with the maximum frequency
                char maxChar = '0';
                char minChar = '0'; // to store the max occurring character
                int maxCount = 0;
                int minCount = 0;// to store the max count

                foreach (var kvp in charFrequency)
                {
                    if (kvp.Value > maxCount)
                    {
                        maxCount = kvp.Value;
                        maxChar = kvp.Key;
                    }

                    if (kvp.Value == 1)
                    {
                        minCount = kvp.Value;
                        minChar = kvp.Key;
                        Console.WriteLine($"The character '{minChar}' occurs {minCount} times.");

                    }


                    // Step 3: Display the result
                    Console.WriteLine($"The character '{maxChar}' occurs {maxCount} times.");
                }
            }
        }
    }
}

