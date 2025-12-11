using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Runtime;

namespace AdvendOfCode_Day5;

internal class Program
{
    static void Main(string[] args)
    {
        //BenchmarkRunner.Run<RangeBenchmarks>();

        var lines = ReadAllLines("D:\\.NET Programiranje\\.NET Learning\\AdventOfCode2025\\AdvendOfCode_Day5\\Day5.txt");

        var inputValues = ReadAndParseValues(lines);

        List<long> listOfNumbers = inputValues.Item2;
        List<(long, long)> listOfRanges = inputValues.Item1;

        //Part1
        var resultPart1 = listOfNumbers
            .Where( x => listOfRanges.Any(l => x >= l.Item1 && x<=l.Item2))
            .Count();


        //part2
        var resultPart2 = listOfRanges.CreateTupleListWithOverlapedValues()
                                      .CountValuesFromTupleRage();


        Console.WriteLine($"Part 1 solution: {resultPart1}");
        Console.WriteLine($"Part 2 solution: {resultPart2}");
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

    public static (List<(long, long)>, List<long>) ReadAndParseValues(List<string> strings)
    {   
        List<(long, long)> ranges = new();
        List<long> numbers = new();
        bool startAddingNumbersToAnotherList = true;

        foreach (var value in strings)
        {
            if(string.IsNullOrEmpty(value))
            {
                startAddingNumbersToAnotherList = false;
                continue;
            }

            if (startAddingNumbersToAnotherList == true)
            {
                var rangeValues = value.Split("-");
                long minValue = long.Parse(rangeValues[0]);
                long maxValue = long.Parse(rangeValues[1]);

                ranges.Add((minValue, maxValue));
            }
            else if (startAddingNumbersToAnotherList == false)
            {
                numbers.Add(long.Parse(value));
            }  
        }

        return (ranges, numbers);
    }

}


//Part 2
public static class ExtensionMetod
{
    public static List<(long,long)> CreateTupleListWithOverlapedValues(this List<(long, long)> list)
    {
        var sortedList = list.OrderBy(x => x).ToList();
        var oldValue = sortedList[0];

        List<(long, long)> outputList = new();

        for (int i = 1; i <= list.Count-1; i++)
        {
            if (sortedList[i].Item1 >= oldValue.Item1 && sortedList[i].Item2 <= oldValue.Item2)
                continue;

            if (oldValue.Item2 >= sortedList[i].Item1)
            {
                oldValue = (oldValue.Item1, sortedList[i].Item2);
            }
            else
            {
                outputList.Add(oldValue);
                oldValue = sortedList[i];
            }
        }
        outputList.Add(oldValue);
        return outputList;          
    }
    public static long CountValuesFromTupleRage(this List<(long, long)> list)
    {
        long countValuesInRange = 0;
        foreach (var item in list)
        {
           countValuesInRange = countValuesInRange + (item.Item2 - item.Item1) + 1;
        }
        return countValuesInRange;
    }     
}


//For benchmark test 
public class RangeBenchmarks
{
    private List<(long, long)> listOfRanges;

    [GlobalSetup]
    public void Setup()
    {
        var lines = Program.ReadAllLines("D:\\.NET Programiranje\\.NET Learning\\AdventOfCode2025\\AdvendOfCode_Day5\\Day5.txt");

        var inputValues = Program.ReadAndParseValues(lines);

        listOfRanges = inputValues.Item1;

    }

    [Benchmark]
    public long Benchmark_FullPipeline()
    {
        return listOfRanges
            .CreateTupleListWithOverlapedValues()
            .CountValuesFromTupleRage();
    }
}
