using System;
using System.Collections.Generic;
using System.Text;

namespace Autopark
{
    class VehicleType
    {
        public string CarType { get; set; }
        public double RoadTaxRate { get; set; }

        public VehicleType()
        {
        }
        // test comment
        public VehicleType(string typeName, double taxCoefficient = 1)
        {
            CarType = typeName;
            RoadTaxRate = taxCoefficient;
        }

        public void Display()
        {
            Console.WriteLine($"CarType = {CarType}");
            Console.WriteLine($"RoadTaxRate = {RoadTaxRate}");
        }

        public override string ToString() => $"{CarType}, {RoadTaxRate}";
    }
}
