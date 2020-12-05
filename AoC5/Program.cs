using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC5
{
    class Program
    {
        static void Main(string[] args)
        {
            var boardingPasses = File.ReadAllText("input.txt").Split("\r\n").ToList();

            var seatIds = new List<decimal>();

            foreach(var pass in boardingPasses)
            {
                decimal passRowMin = 0;
                decimal passRowMax = 127;

                decimal passColMin =  0;
                decimal passColMax = 7;

                foreach(var c in pass)
                {
                    if (c == 'F') passRowMax = Math.Floor( ((passRowMax - passRowMin) / 2) + passRowMin);
                    if (c == 'B') passRowMin = Math.Ceiling( ((passRowMax - passRowMin) / 2) + passRowMin );

                    if (c == 'L') passColMax = Math.Floor(((passColMax - passColMin) / 2) + passColMin);
                    if (c == 'R') passColMin = Math.Ceiling(((passColMax - passColMin) / 2) + passColMin);
                }

                if (passRowMax == passRowMin && passColMax == passColMin)
                {
                    seatIds.Add( (passRowMax * 8) + passColMax);
                }
            }

            Console.WriteLine($"High seat id: {seatIds.Max()}");

            var ordered = seatIds.OrderBy(x => x).Select(x => Convert.ToInt32(x)).ToList();
            var missing = Enumerable.Range(ordered.Min(), ordered.Max()).Except(ordered);

            var yourSeat = missing.Where(x => !missing.Contains(x - 1) && !missing.Contains(x + 1)).FirstOrDefault();

            Console.WriteLine($"your seat: {yourSeat}");
        }
    }
}
