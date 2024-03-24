// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

public static double CalculateAverage(int[] numbers)
{
    double sum = 0;
    foreach (int number in numbers) // Changed variable name from num to number
    {
        sum += number;
    }
    return numbers.Length > 0 ? sum / numbers.Length : 0;
}

