namespace AdventOfCode_Day1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = ReadAllLines("D:\\.NET Programiranje\\.NET Learning\\AdventOfCode2025\\AdventOfCode_Day1\\Day1.txt");

            int startinPoint = 50;
            int result = 0;

            foreach (var line in input)
            {
                char letter = line[0];
                var number = int.Parse(line.Substring(1));

                if (letter == 'L')
                {
                    for (int i = 0; i < number; i++)
                    {
                        startinPoint = startinPoint - 1;

                        if (startinPoint == 0)
                            result++;

                        if (startinPoint == -1)
                            startinPoint = 99;
                    }
                }
                else if (letter == 'R')
                {
                    for (int i = 0; i < number; ++i)
                    {
                        startinPoint = startinPoint + 1;

                        if (startinPoint == 100)
                        {
                            result++;
                            startinPoint = 0;
                        }
                    }                  
                }
            }

            Console.WriteLine(Part1Solution(input));
            Console.WriteLine(result);
        }


        public static int Part1Solution(List<string> input)
        {
            int startinPoint = 50;
            int result = 0;

            foreach (var line in input)
            {
                char letter = line[0];
                var number = int.Parse(line.Substring(1));

                if (letter == 'L')
                {
                    for (int i = 0; i < number; i++)
                    {
                        startinPoint = startinPoint - 1;

                        if (startinPoint == -1)
                            startinPoint = 99;
                    }

                    if (startinPoint == 0)
                        result++;

                }
                else if (letter == 'R')
                {
                    for (int i = 0; i < number; ++i)
                    {
                        startinPoint = startinPoint + 1;

                        if (startinPoint == 100)
                        {
                            startinPoint = 0;
                        }
                    }

                    if (startinPoint == 0)
                        result++;

                }
            }
            return result;
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
    }
}
