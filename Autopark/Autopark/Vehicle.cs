using System;
using System.Collections.Generic;
using System.Text;

namespace Autopark
{
    class Vehicle : IComparable
    {
        public VehicleType Type { get; set; }
        public string ModelName { get; set; }
        public string RegistrationNumber { get; set; }
        public int Weight { get; set; }
        public int ManufactureYear { get; set; }
        public int Mileage { get; set; }
        public Color CarColor { get; set; }
        public double TankCapacity { get; set; }

        public Vehicle()
        {
        }

        public Vehicle(VehicleType type, string modelName, string registrationNumber, int weight, int manufactureYear, int mileage, Color carColor, double tankCapacity)
        {
            Type = type;
            ModelName = modelName;
            RegistrationNumber = registrationNumber;
            Weight = weight;
            ManufactureYear = manufactureYear;
            Mileage = mileage;
            CarColor = carColor;
            TankCapacity = tankCapacity;
        }

        public double GetCalcTaxPerMonth(int weight, VehicleType type) => (weight * 0.0013) + (type.RoadTaxRate * 30) + 5;
        public override string ToString()
        {
            return $"{Type.CarType}, {Type.RoadTaxRate}, {ModelName}, {RegistrationNumber}, {Weight} kg, {ManufactureYear}, {Mileage} km, {CarColor}, {TankCapacity}, {GetCalcTaxPerMonth(Weight, Type)}";
        }
    }
}
