// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

public static int FindMaximumValue(int[] numbers)
{
    if (numbers == null || numbers.Length == 0)
    {
        throw new ArgumentException("The numbers array cannot be null or empty.", nameof(numbers));
    }

    int maxValue = numbers[0];
    foreach (var num in numbers)
    {
        if (num > maxValue)
        {
            maxValue = num;
        }
    }
    return maxValue;
}

