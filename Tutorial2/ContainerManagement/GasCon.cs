public class GasCon : ConBase, IHazNoti
{   
    public bool IsHazardous { get; set; }

    public double Pressure { get; set; }

     public GasCon(int id) : base("G", id)
    {
        SerialNumber = SerialNumberGenerator.GenerateSerialNumber("G");
    }

 public override void CargoLoading(double mass)
    {
        double allowedMass = IsHazardous ? MaxPayload * 0.5 : MaxPayload;
        if (mass > allowedMass)
        {
            throw new OverfillEx($"Cannot load more than {allowedMass} kg in Gas Container.");
        }
        CargoMass = mass;
    }   



    public override void CargoEmptying() => CargoMass *= 0.05; // Leave 5% of gas as residue.

    public void SendHazNoti(string message) => Console.WriteLine($"Hazard Alert - {SerialNumber}: {message}");
}
