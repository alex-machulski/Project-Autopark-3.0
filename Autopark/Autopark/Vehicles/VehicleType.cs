using System;

namespace Autopark
{
    class VehicleType
    {
        internal int IdType { get; set; }
        internal string CarType { get; set; }
        internal double RoadTaxRate { get; set; }

        public VehicleType()
        {
        }

        public VehicleType(int idType, string carType, double roadTaxRate = 1)
        {
            IdType = idType;
            CarType = carType;
            RoadTaxRate = roadTaxRate;
        }

        public void Display()
        {
            Console.WriteLine($"CarType = {CarType}");
            Console.WriteLine($"RoadTaxRate = {RoadTaxRate}");
        }

        public override string ToString() => $"{CarType}, {RoadTaxRate}";
    }
}
