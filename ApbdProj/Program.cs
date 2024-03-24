// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

public static double CalculateAverage(int[] numbers)
{
    if (numbers == null || numbers.Length == 0)
    {
        throw new ArgumentException("The numbers array cannot be null or empty.", nameof(numbers));
    }

    double sum = numbers.Sum();
    return sum / numbers.Length;
}
