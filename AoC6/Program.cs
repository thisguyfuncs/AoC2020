using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC6
{
    class Program
    {
        static void Main(string[] args)
        {
            var rows = File.ReadAllText("input.txt").Split("\r\n\r\n").ToList();
            var total = 0;

            foreach(var row in rows)
            {
                var rowGroups = row.Split("\r\n").Select(x => x.ToArray().ToList()).ToList();
                total += rowGroups
                    .Skip(1)
                    .Aggregate(
                        new HashSet<char>(rowGroups.First()),
                        (h, e) => { h.IntersectWith(e); return h; }
                    ).Count();
            }

            Console.WriteLine($"{total}");
        }
    }
}
