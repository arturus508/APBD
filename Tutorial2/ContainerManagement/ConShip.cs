public class ConShip
{
    public List<ConBase> Containers { get; private set; } = new List<ConBase>();
    public double MaxSpeed { get; set; }
    public int MaxContainerCount { get; set; }
    public double MaxWeight { get; set; } 

    public ConShip(double maxSpeed, int maxContainerCount, double maxWeight)
    {
        MaxSpeed = maxSpeed;
        MaxContainerCount = maxContainerCount;
        MaxWeight = maxWeight;
    }

    public bool LoadContainer(ConBase container)
    {
        if (Containers.Count >= MaxContainerCount || CurrentTotalWeight() + container.CargoMass + container.TareWeight > MaxWeight)
        {
            Console.WriteLine("Cannot load container: exceeds capacity or weight limits.");
            return false;
        }
        Containers.Add(container);
        Console.WriteLine($"Container {container.SerialNumber} loaded.");
        return true;
    }

    
  public bool UnloadContainer(string serialNumber)
    {
        var container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container != null)
        {
            Containers.Remove(container);
            Console.WriteLine($"Container {serialNumber} unloaded.");
            return true;
        }
        Console.WriteLine($"Container {serialNumber} not found.");
        return false;
    }



    public bool ReplaceContainer(string serialNumberToReplace, ConBase newContainer)
    {
        bool isUnloaded = UnloadContainer(serialNumberToReplace);
        if (!isUnloaded)
        {
            Console.WriteLine($"Container {serialNumberToReplace} could not be found or replaced.");
            return false;
        }

        bool isLoaded = LoadContainer(newContainer);
        if (!isLoaded)
        {
            Console.WriteLine($"New container {newContainer.SerialNumber} could not be loaded.");
            return false;
        }

        Console.WriteLine($"Container {serialNumberToReplace} replaced with {newContainer.SerialNumber}.");
        return true;
    }

    public void TransferContainer(ConShip targetShip, string serialNumber)
    {
        var container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container != null && targetShip.LoadContainer(container))
        {
            Containers.Remove(container);
            Console.WriteLine($"Container {serialNumber} transferred.");
        }
        else
        {
            Console.WriteLine($"Container {serialNumber} could not be transferred.");
        }
    }

    public void PrintShipInfo()
    {
        Console.WriteLine($"Ship Details: Max Speed = {MaxSpeed} knots, Max Containers = {MaxContainerCount}, Max Weight = {MaxWeight} kg");
        Console.WriteLine($"Currently carrying {Containers.Count} containers:");
        foreach (var container in Containers)
        {
            Console.WriteLine($" - Type: {container.GetType().Name}, Serial: {container.SerialNumber}, Cargo Mass: {container.CargoMass} kg");
        }
    }
    
    public void PrintContainerInfo(string serialNumber)
{
    var container = Containers.FirstOrDefault(c => c.SerialNumber.Equals(serialNumber, StringComparison.OrdinalIgnoreCase));
    if (container != null)
    {
        Console.WriteLine($"Container Details - Type: {container.GetType().Name}, Serial: {container.SerialNumber}, Cargo Mass: {container.CargoMass} kg");
    }
    else
    {
        Console.WriteLine($"No container found with serial number: {serialNumber}");
    }
}


    public void LoadContainers(List<ConBase> containers)
    {
        foreach (var container in containers)
        {
            if (!LoadContainer(container))
            {
                Console.WriteLine($"Failed to load container {container.SerialNumber}: exceeds capacity or weight limits.");
            }
        }
    }

    private double CurrentTotalWeight() => Containers.Sum(c => c.CargoMass + c.TareWeight);
}


