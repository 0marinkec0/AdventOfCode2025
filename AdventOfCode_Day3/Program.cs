using System.ComponentModel.Design;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Serialization.Formatters;
using System.Text;

namespace AdventOfCode_Day3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = ReadAllLines("D:\\.NET Programiranje\\.NET Learning\\AdventOfCode2025\\AdventOfCode_Day3\\Day3.txt");
            List<long> ouput = new List<long>();

            foreach (var line in input)
            {
                StringBuilder sb = new StringBuilder();
                int index = line.Length - 12;

                for (int i = 0; i < line.Length; i++)
                {
                    char value = line[i];

                    while (sb.Length > 0 && index > 0 && sb[sb.Length - 1] < value)
                    {
                        sb.Remove(sb.Length - 1, 1);
                        index--;
                    }

                    sb.Append(value);
                }

                if (sb.Length > 12)
                    sb.Length = 12;

                ouput.Add(long.Parse(sb.ToString()));
            }

            foreach (var l in ouput)
            {
                Console.WriteLine(l);
            }
            Console.WriteLine(ouput.Sum());
          
        }

        public static List<string> ReadAllLines(string path)
        {
            StreamReader sr = new StreamReader(path);

            string line = sr.ReadLine()!;

            List<string> lines = new List<string>();

            while (line != null)
            {

                lines.Add(line);

                line = sr.ReadLine()!;
            }
            sr.Close();

            return lines;
        }

        private void Part1Solution(List<string> input)
        {
            List<int> result = new List<int>();

            foreach (var line in input)
            {
                List<int> strings = new List<int>();

                for (int i = 0; i < line.Length; i++)
                {
                    for (int j = 1 + i; j < line.Length; j++)
                    {
                        var a = line[i];
                        var b = line[j];
                        string outout = String.Concat(a, b);
                        strings.Add(int.Parse(outout));
                    }
                }
                result.Add(strings.Max());
            }
            Console.WriteLine(result.Sum());
        }

    }
}
