using System;

namespace Autopark
{
    class Vehicle : IComparable<Vehicle>
    {
        private VehicleType Type { get; }
        private string ModelName { get; }
        private string RegistrationNumber { get; }
        private int Weight { get; }
        private int ManufactureYear { get; }
        internal int Mileage { get; }
        private Color CarColor { get; }
        private double TankCapacity { get; }

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
            return $"{Type.CarType}, {Type.RoadTaxRate}, {ModelName}, {RegistrationNumber}, {Weight} kg, {ManufactureYear}, {Mileage} km, {CarColor}, {TankCapacity}, {GetCalcTaxPerMonth(Weight, Type).ToString("0.00")}";
        }

        public int CompareTo(Vehicle secondVehicle)
        {
            if (GetCalcTaxPerMonth(Weight, Type) < secondVehicle.GetCalcTaxPerMonth(secondVehicle.Weight, secondVehicle.Type))
                return -1;
            else if (GetCalcTaxPerMonth(Weight, Type) > secondVehicle.GetCalcTaxPerMonth(secondVehicle.Weight, secondVehicle.Type))
                return 1;
            else
                return 0;
        }
    }
}
