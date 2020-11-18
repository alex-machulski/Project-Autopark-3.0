using System;
using System.Collections.Generic;

namespace Autopark
{
    class Vehicle : IComparable<Vehicle>
    {
        internal int Id { get; set; }
        internal List<Rent> RentList { get; set; } = new List<Rent>();
        internal VehicleType Type { get; }
        internal AbstractEngine CarEngine { get; }
        internal string ModelName { get; }
        internal string RegistrationNumber { get; }
        internal int Weight { get; }
        internal int ManufactureYear { get; }
        internal int Mileage { get; }
        internal Color CarColor { get; }
        internal double TankCapacity { get; }
        

        public Vehicle()
        {
        }

        public Vehicle(int id,
                       VehicleType type,
                       AbstractEngine carEngine,
                       string modelName,
                       string registrationNumber,
                       int weight,
                       int manufactureYear,
                       int mileage,
                       Color carColor,
                       double tankCapacity)
        {
            Id = id;
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

        public double GetCalcTaxPerMonth(int weight, VehicleType type, AbstractEngine carEngine)
        {
            return (weight * 0.0013) + (type.RoadTaxRate * carEngine.EngineTaxRate * 30) + 5;
        }

        public double GetTotalIncome()
        {
            double totalIncome = 0.0;
            foreach (var position in RentList)
            {
                totalIncome += position.RentPrice;
            }
            return totalIncome;
        }
        public double GetTotalProfit()
        {
            return GetTotalIncome() - GetCalcTaxPerMonth(Weight, Type, CarEngine);
        }
        public override string ToString()
        {
            return $"{Id}, {Type.CarType}, {Type.RoadTaxRate}, {CarEngine}, {ModelName}, {RegistrationNumber}, {Weight} kg, {ManufactureYear}, {Mileage} km, {CarColor}, {TankCapacity}, {GetCalcTaxPerMonth(Weight, Type, CarEngine).ToString("0.00")}";
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
