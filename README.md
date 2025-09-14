Yield Return vs List Return in C#
=================================

This project is a .NET Console Application that benchmarks two different methods 
for generating even numbers:

1. Using List<T> with return
2. Using yield return with IEnumerable<T>

The program measures:
- Execution time (using Stopwatch)
- Memory usage (using GC.GetTotalMemory)

------------------------------------------------------------
Why Compare?
------------------------------------------------------------
List<T> with return:
  + Stores all results in memory (easy to reuse).
  - Uses more memory for large datasets.

yield return:
  + Generates items lazily (low memory usage).
  - Recomputes values on each iteration.

------------------------------------------------------------
Code Example
------------------------------------------------------------
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

------------------------------------------------------------
Sample Output (example run with number = 10,000,000)
------------------------------------------------------------
List return:   520 ms, Count = 5000001, Memory used = 152 MB
Yield return:  390 ms, Count = 5000001, Memory used = 1 MB

*Note: Actual results will vary depending on hardware.*

------------------------------------------------------------
How to Run
------------------------------------------------------------
1. Clone the repository:
   git clone https://github.com/your-username/yield-vs-list-benchmark.git
   cd yield-vs-list-benchmark

2. Build and run:
   dotnet run

3. Adjust the "number" variable in Program.cs to test with different sizes.

------------------------------------------------------------
Key Takeaways
------------------------------------------------------------
- Use yield return for streaming large datasets with low memory.
- Use List<T> if you need random access or to iterate multiple times.

------------------------------------------------------------
