public abstract class ConBase
{
    public double CargoMass { get; protected set; }
    public double Height { get; set; }
    public double TareWeight { get; set; }
    public double Depth { get; set; }
    public string SerialNumber { get; protected set; }
    public double MaxPayload { get; set; }

    protected ConBase(string type, int id)
    {
        SerialNumber = $"KON-{type}-{id}";
    }

    public abstract void CargoLoading(double mass);
    public abstract void CargoEmptying();
}
