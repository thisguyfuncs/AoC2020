using System.IO;
using System.Linq;

namespace AoC4
{
    class Program
    {
        static void Main(string[] args)
        {
            var rows = File.ReadAllText("input.txt").Split("\r\n").ToList();
        }
    }
}
