public class LiqCon : ConBase, IHazNoti
{
    public bool IsHazardous { get; set; }

    public LiqCon(int id) : base("L", id) {}

    public override void CargoLoading(double mass)
    {
        double allowedMass = IsHazardous ? MaxPayload * 0.5 : MaxPayload * 0.9;
        if (mass > allowedMass) throw new OverfillEx($"Cannot load more than {allowedMass} kg.");

        CargoMass = mass;
    }

    public override void CargoEmptying() => CargoMass = 0;

    public void SendHazNoti(string message) => Console.WriteLine($"Hazard Alert - {SerialNumber}: {message}");
}
