using System;
using System.Collections.Generic;
using System.Linq;

public class ConShip
{
    private List<ConBase> Containers = new List<ConBase>();
    public double MaxSpeed { get; set; }
    public int MaxContainerCount { get; set; }
    public double MaxWeight { get; set; } // In kilograms for consistency

    public ConShip(double maxSpeed, int maxContainerCount, double maxWeight)
    {
        MaxSpeed = maxSpeed;
        MaxContainerCount = maxContainerCount;
        MaxWeight = maxWeight;
    }

    public bool LoadContainer(ConBase container)
    {
        if (Containers.Count >= MaxContainerCount || CurrentTotalWeight() + container.TareWeight + container.CargoMass > MaxWeight)
        {
            Console.WriteLine("Failed to load container: exceeds capacity or weight limits.");
            return false;
        }
        Containers.Add(container);
        Console.WriteLine($"Container {container.SerialNumber} loaded successfully.");
        return true;
    }

    public bool UnloadContainer(string serialNumber)
    {
        var container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container != null)
        {
            Containers.Remove(container);
            Console.WriteLine($"Container {serialNumber} unloaded successfully.");
            return true;
        }
        Console.WriteLine($"Container {serialNumber} not found.");
        return false;
    }

    public void PrintShipInfo()
    {
        Console.WriteLine($"Ship can carry {MaxContainerCount} containers up to {MaxWeight} kg at {MaxSpeed} knots.");
        Console.WriteLine($"Currently carrying {Containers.Count} containers.");
    }

    public void PrintAllContainersInfo()
    {
        foreach (var container in Containers)
        {
            Console.WriteLine($"Serial Number: {container.SerialNumber}, Cargo Mass: {container.CargoMass}, Type: {container.GetType().Name}");
        }
    }

    private double CurrentTotalWeight() => Containers.Sum(c => c.TareWeight + c.CargoMass);

   
}

