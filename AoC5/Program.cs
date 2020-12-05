using System;
using System.IO;
using System.Linq;

namespace AoC5
{
    class Program
    {
        static void Main(string[] args)
        {
            var rows = File.ReadAllText("input.txt").Split("\r\n\r\n").Select(x => x.Replace("\r\n", " ")).ToList();
        }
    }
}
