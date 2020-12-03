using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC3
{
    class Program
    {
        private static int _ROW_LENGTH = 30;
        private static int _ROW_MAX_INDEX = _ROW_LENGTH + 1;
        

        static void Main(string[] args)
        {
            var slopeList = new List<KeyValuePair<int, int>>();
            slopeList.Add(new KeyValuePair<int, int>(1, 1));
            slopeList.Add(new KeyValuePair<int, int>(3, 1));
            slopeList.Add(new KeyValuePair<int, int>(5, 1));
            slopeList.Add(new KeyValuePair<int, int>(7, 1));
            slopeList.Add(new KeyValuePair<int, int>(1, 2));

            var rows = File.ReadAllText("input.txt").Split("\r\n").ToList();

            var allHits = new List<int>();
            foreach(var slope in slopeList)
            {
                allHits.Add(CalculateTreeHits(rows, slope));
            }

            long sum = 1;
            allHits.ForEach(x => sum *= x);
            Console.WriteLine($"{sum}");
        }

        private static int CalculateTreeHits(List<string> rows, KeyValuePair<int, int> slope)
        {
            var rowIndex = 0;
            var trees = 0;
            for (var row = 0; row < rows.Count - 1; row = row + slope.Value) // y
            {
                rowIndex = rowIndex + slope.Key; // increment x axis
                                                   // due to repeats, if the column is over 30, then we bring it back down to 0, and translate using modulo
                if (rowIndex > _ROW_LENGTH)
                {
                    rowIndex = rowIndex % _ROW_MAX_INDEX;
                }

                var examinedRow = rows[row + slope.Value];
                var place = examinedRow[rowIndex];

                if (place == '#') trees++;
            }

            return trees;
        }
    }
}
