using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC2
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText("input.txt").Split("\r\n").ToList();

            var passwordRecords = new List<PasswordRecord>();
            foreach(var record in input)
            {
                passwordRecords.Add(new PasswordRecord(record));
            }

            Console.WriteLine(passwordRecords.Where(x => x.IsValid()).Count());
        }
    }

    public class PasswordRecord
    {
        public Policy Policy { get; set; }
        public string Password { get; set; }
        
        public bool IsValid()
        {
            if (Password[Policy.Min - 1] == Policy.Character && Password[Policy.Max - 1] == Policy.Character) return false;
            if (Password[Policy.Min - 1] == Policy.Character || Password[Policy.Max - 1] == Policy.Character) return true;

            return false;
        }

        public PasswordRecord(string record)
        {
            var splits = record.Split(" ");
            var fullPolicy = splits[0].Split("-");
            var policyMin = int.Parse(fullPolicy[0]);
            var policyMax = int.Parse(fullPolicy[1]);

            var character = char.Parse(splits[1].Trim(':'));

            Policy = new Policy { Character = character, Min = policyMin, Max = policyMax };
            Password = splits[2];
        }
    }

    public class Policy
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public char Character { get; set; }
    }
}
