using System;
using System.IO;
using System.Linq;

namespace AoC1
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText("input.txt").Split("\n").Select(x => int.Parse(x)).ToList();

            for(var iterator = 0; iterator < input.Count; iterator++)
            {
                var firstNumber = input[iterator];

                for(var secondIterator = 0; secondIterator < input.Count; secondIterator++)
                {
                    var secondNumber = input[secondIterator];

                    for(var thirdIterator = 0; thirdIterator < input.Count; thirdIterator++)
                    {
                        if (firstNumber + secondNumber + input[thirdIterator] == 2020)
                        {
                            Console.WriteLine("2020");
                            Console.WriteLine(firstNumber * secondNumber * input[thirdIterator]);
                        }
                    }
                }
            }
        }
    }
}
