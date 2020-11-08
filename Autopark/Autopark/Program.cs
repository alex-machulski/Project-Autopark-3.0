using System;

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
                new Vehicle(carTypes[0], "Volkswagen Crafter", "5427 AX-7", 2022, 2015, 376000, Color.Blue, 75),
                new Vehicle(carTypes[0], "Volkswagen Crafter", "6427 AA-7", 2500, 2014, 227010, Color.White, 75),
                new Vehicle(carTypes[0], "Electric Bus E321", "6785 BA-7", 12080, 2019, 20451, Color.Green, 34),
                new Vehicle(carTypes[1], "Volkswagen Golf 5", "8682 AX-7", 1200, 2006, 230451, Color.Gray, 55),
                new Vehicle(carTypes[1], "Tesla Model S 70D", "E001 AA-7", 2200, 2019, 10454, Color.White, 70),
                new Vehicle(carTypes[2], "Hamm HD 12 VV", null, 3000, 2016, 122, Color.Yellow, 42),
                new Vehicle(carTypes[3], "МТЗ Беларус-1025.4", "1145 AB-7", 1200, 2020, 109, Color.Red, 135)
            };
            AutoparkHelper.PrintCarsArray(cars);
            Array.Sort(cars);
            AutoparkHelper.PrintCarsArray(cars);
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
        }
    }
}
