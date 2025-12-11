using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;

namespace AdventOfCode_Day2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllText("D:\\.NET Programiranje\\.NET Learning\\AdventOfCode2025\\AdventOfCode_Day2\\Day2.txt");

            var items = lines.Split(",");

            List<string> result = new List<string>();

            foreach (var item in items)
            {
                var parts = item.Split('-', StringSplitOptions.RemoveEmptyEntries);

                long start = long.Parse(parts[0]);
                long end = long.Parse(parts[1]);

                result.Add(item);
            }

            List<long> cumulative = new List<long>();

            foreach (var item in result)
            {
                var parts = item.Split("-");

                long start = long.Parse(parts[0]);
                long end = long.Parse(parts[1]);

                for (long i = start; i <= end; i++)
                {
                    var numberLength = i.ToString().Length;

                    for (int j = numberLength; j > 1; j--)
                    {
                        var numbertAsString = i.ToString();

                        if (numberLength % j == 0)
                        {
                            int step = numberLength / j;
                            int startIndex = 0;

                            Dictionary<string, int> dict = new Dictionary<string, int>();

                            for (int k = 0; k < j; k++)
                            {
                                if (startIndex + step > numberLength)
                                {
                                    break;
                                }
                                var splitNumber = numbertAsString.Substring(startIndex, step);
                                startIndex = startIndex + step;

                                if (dict.ContainsKey(splitNumber))
                                {
                                    dict[splitNumber] += 1;
                                }
                                else
                                {
                                    dict[splitNumber] = 1;
                                }
                            }

                            if (dict.Count == 1)
                            {
                                cumulative.Add(i);
                                break;
                            }                         
                        }
                    }
                }
            }
            Console.WriteLine(cumulative.Sum());
        }

        private void Part1Solution(List<string> result)
        {
            List<long> cumulative = new List<long>();

            foreach (var item in result)
            {
                var parts = item.Split("-");

                long start = long.Parse(parts[0]);
                long end = long.Parse(parts[1]);


                for (long i = start; i < end; i++)
                {
                    var splitNumber = i.ToString().Length;

                    if (splitNumber % 2 == 0)
                    {
                        var numberAsString = i.ToString();

                        var firstHalf = numberAsString.Substring(0, numberAsString.Length / 2);
                        var secondHalf = numberAsString.Substring(numberAsString.Length / 2, numberAsString.Length / 2);

                        if (long.Parse(firstHalf) == long.Parse(secondHalf))
                        {
                            cumulative.Add(i);
                        }
                    }
                    else if (splitNumber % 3 == 0)
                    {
                        var numberAsString = i.ToString();
                        var firstHalf = numberAsString.Substring(0, numberAsString.Length / 3);
                        var secondHalf = numberAsString.Substring(numberAsString.Length / 3, numberAsString.Length / 3);
                        var thirdHalf = numberAsString.Substring(numberAsString.Length / 3 * 2, numberAsString.Length / 3);

                    }
                }
            }
            Console.WriteLine(cumulative.Sum());
        }

    }
}
