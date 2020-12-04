using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoC4
{
    class Program
    {
        static void Main(string[] args)
        {
            var rows = File.ReadAllText("input.txt").Split("\r\n\r\n").Select(x => x.Replace("\r\n", " ")).ToList();

            var valid = 0;
            foreach(var row in rows)
            {
                if (row.Contains("byr:") && row.Contains("iyr:") && row.Contains("eyr:") && row.Contains("hgt:") && row.Contains("hcl:") && row.Contains("ecl:") && row.Contains("pid:"))
                {
                    var byr = int.Parse(row.Split("byr:")[1].Split(" ")[0]);
                    if (byr < 1920 || byr > 2002)
                    {
                        continue;
                    }

                    var iyr = int.Parse(row.Split("iyr:")[1].Split(" ")[0]);
                    if (iyr < 2010 || iyr > 2020)
                    {
                        continue;
                    }

                    var eyr = int.Parse(row.Split("eyr:")[1].Split(" ")[0]);
                    if (eyr < 2020 || eyr > 2030)
                    {
                        continue;
                    }

                    var hgt = row.Split("hgt:")[1].Split(" ")[0];
                    if (!hgt.EndsWith("cm") && !hgt.EndsWith("in"))
                    {
                        continue;
                    }
                    if (hgt.EndsWith("cm"))
                    {
                        var val = int.Parse(hgt.Replace("cm", ""));
                        if (val < 150 || val > 193)
                        {
                            continue;
                        }
                    }
                    if (hgt.EndsWith("in"))
                    {
                        var val = int.Parse(hgt.Replace("in", ""));
                        if (val < 59 || val > 76)
                        {
                            continue;
                        }
                    }

                    Regex regex = new Regex("^[#]{1}[0-9a-f]{6}$");
                    var hcl = row.Split("hcl:")[1].Split(" ")[0];
                    if (!regex.IsMatch(hcl))
                    {
                        continue;
                    }

                    var validEcl = new List<string> { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
                    var ecl = row.Split("ecl:")[1].Split(" ")[0];
                    if (!validEcl.Contains(ecl))
                    {
                        continue;
                    }

                    var pidRegex = new Regex("^[0-9]{9}$");
                    var pid = row.Split("pid:")[1].Split(" ")[0];
                    if (!pidRegex.IsMatch(pid))
                    {
                        continue;
                    }


                    valid++;
                }
                else
                {
                    continue;
                }
            }

            Console.WriteLine($"{valid}");
        }
    }
}
