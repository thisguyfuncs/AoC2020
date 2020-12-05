using System;
using System.IO;
using System.Linq;

namespace AoC5
{
    class Program
    {
        static decimal Calc(decimal min, decimal max) => Math.Floor(((max - min) / 2) + min);

        static void Main(string[] args)
        {
            var seatIds = File.ReadAllText("input.txt").Split("\r\n").ToList().Select(GetSeatId).ToList();

            var missing = Enumerable.Range(seatIds.Min(), seatIds.Max()).Except(seatIds);
            var yourSeat = missing.FirstOrDefault(x => !missing.Contains(x - 1) && !missing.Contains(x + 1));

            Console.WriteLine($"high: {seatIds.Max()}, your seat: {yourSeat}");
        }

        private static int GetSeatId(string pass)
        {
            decimal passRowMin, passRowMax, passColMin, passColMax;
            passRowMin = passColMin = 0;
            passRowMax = 127;
            passColMax = 7;

            foreach (var c in pass)
            {
                if (c == 'F') passRowMax = Calc(passRowMin, passRowMax);
                if (c == 'B') passRowMin = Calc(passRowMin, passRowMax);
                if (c == 'L') passColMax = Calc(passColMin, passColMax);
                if (c == 'R') passColMin = Calc(passColMin, passColMax);
            }

            return Convert.ToInt32((passRowMax * 8) + passColMax);
        }
    }
}
