using System.Diagnostics.Metrics;

namespace AdventOfCode_Day4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = ReadAndParseAllLines("D:\\.NET Programiranje\\.NET Learning\\AdventOfCode2025\\AdventOfCode_Day4\\Day4.txt");      

            RollOfPaper roll = new RollOfPaper(input);

            Console.WriteLine(roll.Part1Soulution());
            Console.WriteLine(roll.Part2Solution());
        }

        public static List<List<char>> ReadAndParseAllLines(string path)
        {
            var lines = File.ReadAllLines(path);

            List<List<char>> result = new();

            foreach (var line in lines)
            {
                List<char> inner = new();

                foreach (var a in line)
                {
                    inner.Add(a);
                }
                result.Add(inner);
            }

            return result;
        }
    }
}
