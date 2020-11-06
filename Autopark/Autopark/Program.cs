using System;

namespace Autopark
{
    class Program
    {
        static void Main(string[] args)
        {
            VehicleType[] carTypes = new VehicleType[] 
            { new VehicleType("Bus", 1.2), new VehicleType("Car"), new VehicleType("Rink", 1.5), new VehicleType("Tractor", 1.2) };
            double maxTaxRate = 0.0, sumTaxRate = 0.0;

            carTypes[carTypes.Length - 1].RoadTaxRate = 1.3;  
            //print with Display(), finding max tax rate and sum of tax rates
            foreach (VehicleType item in carTypes)
            {
                item.Display();
                Console.WriteLine();
                if (item.RoadTaxRate > maxTaxRate)
                    maxTaxRate = item.RoadTaxRate;
                sumTaxRate += item.RoadTaxRate;
            }
            double averageTaxRate = sumTaxRate / carTypes.Length;
            Console.WriteLine($"Maximum tax rate - {maxTaxRate}");
            Console.WriteLine($"Average tax rate - {averageTaxRate}");
            //print with ToString()
            foreach (VehicleType item in carTypes) 
            {
                Console.WriteLine(item);
            }            
        }
    }
}
