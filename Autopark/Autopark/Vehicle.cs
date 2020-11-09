using System;

namespace Autopark
{
    class Vehicle : IComparable<Vehicle>
    {
        private VehicleType Type { get; }
        private Engine CarEngine { get; }
        private string ModelName { get; }
        private string RegistrationNumber { get; }
        private int Weight { get; }
        private int ManufactureYear { get; }
        internal int Mileage { get; }
        private Color CarColor { get; }
        internal double TankCapacity { get; }
        

        public Vehicle()
        {
        }

        public Vehicle(VehicleType type,
                       Engine carEngine,
                       string modelName,
                       string registrationNumber,
                       int weight,
                       int manufactureYear,
                       int mileage,
                       Color carColor,
                       double tankCapacity)
        {
            Type = type;
            CarEngine = carEngine;
            ModelName = modelName;
            RegistrationNumber = registrationNumber;
            Weight = weight;
            ManufactureYear = manufactureYear;
            Mileage = mileage;
            CarColor = carColor;
            TankCapacity = tankCapacity;
        }

        public double GetCalcTaxPerMonth(int weight, VehicleType type, Engine carEngine)
        {
            return (weight * 0.0013) + (type.RoadTaxRate * carEngine.EngineTaxRate * 30) + 5;
        }
        public override string ToString()
        {
            return $"{Type.CarType}, {Type.RoadTaxRate}, {CarEngine}, {ModelName}, {RegistrationNumber}, {Weight} kg, {ManufactureYear}, {Mileage} km, {CarColor}, {TankCapacity}, {GetCalcTaxPerMonth(Weight, Type, CarEngine).ToString("0.00")}";
        }

        public int CompareTo(Vehicle secondVehicle)
        {
            if (GetCalcTaxPerMonth(Weight, Type, CarEngine) < secondVehicle.GetCalcTaxPerMonth(secondVehicle.Weight, secondVehicle.Type, secondVehicle.CarEngine))
                return -1;
            else if (GetCalcTaxPerMonth(Weight, Type, CarEngine) > secondVehicle.GetCalcTaxPerMonth(secondVehicle.Weight, secondVehicle.Type, secondVehicle.CarEngine))
                return 1;
            else
                return 0;
        }

        public override bool Equals(Object obj)
        {
            if (obj.GetType() != this.GetType())
                return false;

            Vehicle secondVehicle = (Vehicle)obj;

            if (secondVehicle.Type.CarType == this.Type.CarType && secondVehicle.ModelName == this.ModelName)
                return true;
            else
                return false;
        }
    }
}
