using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Initialize the ships
        ConShip ship1 = new ConShip(25, 5, 20000);
        ConShip ship2 = new ConShip(30, 5, 25000); 

        // Create individual containers
        LiqCon liquidContainer = new LiqCon(1) { TareWeight = 500, IsHazardous = true };
        liquidContainer.LoadCargo(5000); 
        GasCon gasContainer = new GasCon(2) { TareWeight = 300 };
        gasContainer.LoadCargo(3000); 
        RefCon refrigeratedContainer = new RefCon(3) { TareWeight = 400, Temperature = -5 };
        refrigeratedContainer.LoadCargo(4000); 

        // Create a list of containers to load onto ship1
        List<ConBase> containersToLoad = new List<ConBase>
        {
            liquidContainer,
            gasContainer,
            refrigeratedContainer
        };

        // Demonstrating loading a list
        Console.WriteLine("Loading multiple containers onto ship1:");
        ship1.LoadContainers(containersToLoad);

        // Print ship1's information
        Console.WriteLine("\nShip1's information after loading containers:");
        ship1.PrintShipInfo();

        // Demonstrating removing a container from ship1
        Console.WriteLine($"\nRemoving the liquid container (Serial: {liquidContainer.SerialNumber}) from ship1:");
        ship1.UnloadContainer(liquidContainer.SerialNumber);

        // Print ship1's information after removing the container
        Console.WriteLine("\nShip1's information after removing a container:");
        ship1.PrintShipInfo();
    }
}





