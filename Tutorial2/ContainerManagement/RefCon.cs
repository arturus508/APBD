public class RefCon : ConBase, IHazNoti
{
    private double temperature;

    public double Temperature
    {
        get => temperature;
        set => temperature = value;
    }

    
    public RefCon(int id) : base("C", id)
    {
        SerialNumber = SerialNumberGenerator.GenerateSerialNumber("C");
    }

    public override void CargoLoading(double mass)
    {
        if (!IsTemperatureAcceptable())
        {
            throw new InvalidOperationException($"The current temperature setting of {Temperature}°C is not acceptable for loading.");
        }
        CargoMass = mass;
    }

    public override void CargoEmptying()
    {
        CargoMass = 0;
    }

    public void SendHazNoti(string message)
    {
        Console.WriteLine($"Hazard Alert for Refrigerated Container {SerialNumber}: {message}");
    }

    private bool IsTemperatureAcceptable()
    {
        
        return true;
    }

    
    private string GetTemperatureCategory()
    {
        if (temperature > 20) return "Hot";
        if (temperature >= 10 && temperature <= 20) return "Normal";
        if (temperature >= 5 && temperature < 10) return "Mild";
        if (temperature >= 0 && temperature < 5) return "Cold";
        return "Frozen";
    }
}
