public static class SerialNumberGenerator
{
    private static int lastNumber = 0;
    private static readonly object lockObj = new object();

    public static string GenerateSerialNumber(string prefix)
    {
        lock (lockObj)
        {
            lastNumber++;
            return $"KON-{prefix}-{lastNumber}";
        }
    }
}
