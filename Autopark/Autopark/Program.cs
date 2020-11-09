using System;
using System.Linq;

namespace Autopark
{
    class Program
    {
        static void Main(string[] args)
        {
            var carTypes = new [] 
            { 
                new VehicleType("Bus", 1.2), 
                new VehicleType("Car"), 
                new VehicleType("Rink", 1.5), 
                new VehicleType("Tractor", 1.2) 
            };
            double maxTaxRate = 0.0, sumTaxRate = 0.0;

            carTypes[^1].RoadTaxRate = 1.3;  
            //print with Display(), finding max tax rate and sum of tax rates
            foreach (var type in carTypes)
            {
                type.Display();
                Console.WriteLine();
                if (type.RoadTaxRate > maxTaxRate)
                    maxTaxRate = type.RoadTaxRate;
                sumTaxRate += type.RoadTaxRate;
            }
            double averageTaxRate = sumTaxRate / carTypes.Length;
            Console.WriteLine($"Maximum tax rate - {maxTaxRate}");
            Console.WriteLine($"Average tax rate - {averageTaxRate}");
            //print with ToString()
            foreach (var type in carTypes) 
            {
                Console.WriteLine(type);
            }
            var cars = new[]
            {
                new Vehicle(carTypes[0], new GasolineEngine(2, 8.1), "Volkswagen Crafter", "5427 AX-7", 2022, 2015, 376000, Color.Blue, 75),
                new Vehicle(carTypes[0], new GasolineEngine(2.18, 8.5), "Volkswagen Crafter", "6427 AA-7", 2500, 2014, 227010, Color.White, 75),
                new Vehicle(carTypes[0], new ElectricalEngine(50), "Electric Bus E321", "6785 BA-7", 12080, 2019, 20451, Color.Green, 150),
                new Vehicle(carTypes[1], new DieselEngine(1.6, 7.2), "Volkswagen Golf 5", "8682 AX-7", 1200, 2006, 230451, Color.Gray, 55),
                new Vehicle(carTypes[1], new ElectricalEngine(25), "Tesla Model S 70D", "E001 AA-7", 2200, 2019, 10454, Color.White, 70),
                new Vehicle(carTypes[2], new DieselEngine(3.2, 25), "Hamm HD 12 VV", null, 3000, 2016, 122, Color.Yellow, 20),
                new Vehicle(carTypes[3], new DieselEngine(4.75, 20.1), "МТЗ Беларус-1025.4", "1145 AB-7", 1200, 2020, 109, Color.Red, 135)
            };
            AutoparkHelper.PrintCarsArray(cars);
            Array.Sort(cars);
            AutoparkHelper.PrintCarsArray(cars);
            // finding cars with min and max mileage
            int minMileage = cars[0].Mileage, maxMileage = cars[0].Mileage;
            Vehicle minMileageCar = null, maxMileageCar = null;
            foreach (var car in cars)
            {
                if (car.Mileage < minMileage)
                {
                    minMileage = car.Mileage;
                    minMileageCar = car;
                }
                if (car.Mileage > maxMileage)
                {
                    maxMileage = car.Mileage;
                    maxMileageCar = car;
                }
            }
            Console.WriteLine($"The car with minimum mileage: {minMileageCar}");
            Console.WriteLine($"The car with maximum mileage: {maxMileageCar}");
            // finding the same cars
            int[] tempArrayForSameCars = new int[cars.Length];
            for (int i = 0; i < cars.Length; i++)
            {
                for (int j = i+1; j < cars.Length; j++)
                {
                    if (cars[i].Equals(cars[j]))
                    {
                        tempArrayForSameCars[i] = 1;
                        tempArrayForSameCars[j] = 1;
                    }
                        
                }
            }
            if (tempArrayForSameCars.Contains(1))
            {
                Console.WriteLine("The list contains identical cars:");
                for (int i = 0; i < tempArrayForSameCars.Length; i++)
                {
                    if (tempArrayForSameCars[i] == 1)
                        Console.WriteLine(cars[i]);
                }
            }
        }
    }
}
