using System;
using System.IO;
using System.Linq;

namespace AoC5
{
    class Program
    {
        static void Main(string[] args)
        {
            var seatIds = File.ReadAllText("input.txt").Split("\r\n").ToList().Select(x => Convert.ToInt32(GetSeatId(x))).ToList();
            Console.WriteLine($"High seat id: {seatIds.Max()}");

            var missing = Enumerable.Range(seatIds.Min(), seatIds.Max()).Except(seatIds);
            var yourSeat = missing.Where(x => !missing.Contains(x - 1) && !missing.Contains(x + 1)).FirstOrDefault();
            Console.WriteLine($"your seat: {yourSeat}");
        }

        private static decimal GetSeatId(string pass)
        {
            decimal passRowMin, passRowMax, passColMin, passColMax;
            passRowMin = passColMin = 0;
            passRowMax = 127;
            passColMax = 7;

            foreach (var c in pass)
            {
                if (c == 'F') passRowMax = Math.Floor(((passRowMax - passRowMin) / 2) + passRowMin);
                if (c == 'B') passRowMin = Math.Ceiling(((passRowMax - passRowMin) / 2) + passRowMin);

                if (c == 'L') passColMax = Math.Floor(((passColMax - passColMin) / 2) + passColMin);
                if (c == 'R') passColMin = Math.Ceiling(((passColMax - passColMin) / 2) + passColMin);
            }

            return (passRowMax * 8) + passColMax;
        }
    }
}
