using System;
using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        int number = 10_000_000;

        Console.WriteLine("Comparing List Return vs Yield Return");
        Console.WriteLine($"Generating even numbers up to {number}\n");

        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();

        long beforeMem = GC.GetTotalMemory(true);
        Stopwatch sw = Stopwatch.StartNew();
        var listNumbers = GetEvenNumbersList(number);
        foreach (var num in listNumbers) { }
        sw.Stop();
        long afterMem = GC.GetTotalMemory(true);

        Console.WriteLine($"List return:   {sw.ElapsedMilliseconds} ms, Count = {listNumbers.Count}, Memory used = {(afterMem - beforeMem) / 1024 / 1024} MB");

        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();

        beforeMem = GC.GetTotalMemory(true);
        sw.Restart();
        int count = 0;
        foreach (var num in GetEvenNumbersYield(number))
        {
            count++;
        }
        sw.Stop();
        afterMem = GC.GetTotalMemory(true);

        Console.WriteLine($"Yield return:  {sw.ElapsedMilliseconds} ms, Count = {count}, Memory used = {(afterMem - beforeMem) / 1024 / 1024} MB");
    }
            
    public static List<int> GetEvenNumbersList(int number)
    {
        List<int> evenNumbers = new();
        for (int i = 0; i <= number; i += 2)
        {
            evenNumbers.Add(i);
        }
        return evenNumbers;
    }

    public static IEnumerable<int> GetEvenNumbersYield(int number)
    {
        for (int i = 0; i <= number; i += 2)
        {
            yield return i;
        }
    }
}
