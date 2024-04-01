class Program
{
    static void Main(string[] args)
    {
        ConShip myShip = new ConShip(30, 10, 20000); // Example ship

        // Create different types of containers
        LiqCon milkContainer = new LiqCon(1) { CargoMass = 500, IsHazardous = false };
        GasCon heliumContainer = new GasCon(2) { CargoMass = 300 };
        RefCon bananaContainer = new RefCon(3) { CargoMass = 800 };
        
        // Try loading containers onto the ship
        myShip.LoadContainer(milkContainer);
        myShip.LoadContainer(heliumContainer);
        myShip.LoadContainer(bananaContainer);
        
        // Print ship and container info
        myShip.PrintShipInfo();
        myShip.PrintAllContainersInfo();
    }
}
