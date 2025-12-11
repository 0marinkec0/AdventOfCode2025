using System.ComponentModel;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace AdventOfCode_Day6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lines = ReadAllLines("D:\\.NET Programiranje\\.NET Learning\\AdventOfCode2025\\AdventOfCode_Day6\\Day6.txt");

            int cnt = lines[0].Count();
            List<long> UntilOperatorFoundList = new();
            List<long> finalResultList = new();

            for (int i = cnt; i > 0; i--)
            {
                StringBuilder stringBuilder = new();
                
                for (int j = 0; j <= lines.Count-1; j++)
                {
                    var checkCharacter = lines[j].ElementAt(i - 1).ToString();

                    if (checkCharacter.Equals("*"))
                    {
                        var res = UntilOperatorFoundList.Aggregate((x, y) => x * y) * long.Parse(stringBuilder.ToString());
                        finalResultList.Add(res);
                        UntilOperatorFoundList = new();
                        stringBuilder = new();
                        break; 
                    }

                    if (checkCharacter.Equals("+"))
                    {
                        var res = UntilOperatorFoundList.Aggregate((x, y) => x + y) + long.Parse(stringBuilder.ToString());
                        finalResultList.Add(res);
                        UntilOperatorFoundList = new();
                        stringBuilder = new();
                        break;
                    }

                    if (!checkCharacter.Equals(" "))
                        stringBuilder.Append(lines[j].ElementAt(i - 1).ToString());

                    else
                        continue;
                }

                if(stringBuilder.Length>0 && stringBuilder is not null)
                UntilOperatorFoundList.Add(long.Parse(stringBuilder.ToString()));                     
            }

            Console.WriteLine(finalResultList.Sum());
        }





        public static void Part1Solution(List<string> lines)
        {
            var result = lines.Select(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries)
             .Select(x => x)
              .ToList())
              .ToList();

            List<List<string>> list2 = new();

            int counte = result[0].Count();

            for (int i = 0; i < counte; i++)
            {
                List<string> newList = new();
                foreach (var line in result)
                {

                    //Console.WriteLine(line[i]);
                    newList.Add(line[i]);

                    //Console.WriteLine("*****");
                }

                list2.Add(newList);
            }


            List<long> ints = new List<long>();

            foreach (var ori in list2)
            {
                var line = ori.ToList();

                var operato = char.Parse(line.Last());
                line.Remove(line.Last());

                long result2 = 0;

                ////ovo dodano za part2
                var biggestValue = line.Max(x => x.Length);

                List<long> fixedList = new();

                while (biggestValue > 0)
                {
                    StringBuilder str = new();
                    int a = 0;

                    foreach (var l in line)
                    {
                        a = int.Parse(l) % 10;
                        str.Append(a);
                    }

                    line = line.Select(s => s.Length > 0 ? s[..^1] : s).Where(s => s.Length > 0).ToList();

                    fixedList.Add(long.Parse(str.ToString()));
                    biggestValue--;
                }

                switch (operato)
                {
                    case '*':
                        result2 = fixedList.Select(x => x).Aggregate((x, y) => x * y);
                        ints.Add(result2);
                        break;
                    case '+':
                        result2 = fixedList.Select(x => x).Aggregate((x, y) => x + y);
                        ints.Add(result2);
                        break;
                }
            }

            Console.WriteLine(ints.Sum());

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
