int[] input = new int[] { 1, 9, 2, 8, 3, 7, 4, 6, 5 };

foreach (int number in ProceduralCode(input))
    Console.Write($"{number} ");
Console.WriteLine();

foreach (int number in KeywordSyntax(input))
    Console.Write($"{number} ");
Console.WriteLine();

foreach (int number in MethodCallSyntax(input))
    Console.Write($"{number} ");
Console.WriteLine();

IEnumerable<int> ProceduralCode(int[] input)
{
    List<int> filtered = new List<int>();

    // Filter to only even numbers.
    foreach (int number in input)
        if (number % 2 == 0)
            filtered.Add(number);

    // Sorting the results.
    int[] results = filtered.ToArray();
    Array.Sort(results);

    // Doubling everything.
    for (int index = 0; index < results.Length; index++)
        results[index] *= 2;

    return results;
}

IEnumerable<int> KeywordSyntax(int[] input)
{
    return from n in input
           where n % 2 == 0
           orderby n
           select n * 2;
}

IEnumerable<int> MethodCallSyntax(int[] input)
{
    return input
        .Where(n => n % 2 == 0)
        .OrderBy(n => n)
        .Select(n => n * 2);
}
