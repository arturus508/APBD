public class ConShip
{
    public List<ConBase> Containers { get; private set; } = new List<ConBase>();
    public double MaxSpeed { get; set; }
    public int MaxContainerCount { get; set; }
    public double MaxWeight { get; set; } // In tons

    public ConShip(double maxSpeed, int maxContainerCount, double maxWeight)
    {
        MaxSpeed = maxSpeed;
        MaxContainerCount = maxContainerCount;
        MaxWeight = maxWeight;
    }

    public void LoadContainer(ConBase container)
    {
        if (Containers.Count >= MaxContainerCount || CurrentTotalWeight() + container.TareWeight + container.CargoMass > MaxWeight * 1000)
        {
            Console.WriteLine("Cannot load container: exceeds capacity or weight limits.");
            return;
        }
        Containers.Add(container);
    }

    public void UnloadContainer(string serialNumber)
    {
        Containers.RemoveAll(c => c.SerialNumber == serialNumber);
    }


    private double CurrentTotalWeight()
    {
        return Containers.Sum(c => c.TareWeight + c.CargoMass);
    }
}
